using System;
using System.Linq;
using OpenCvSharp;
using System.IO;

namespace OCT_GUI_Application
{
    class ImageManager
    {
        private readonly Action<string> _logger;

        private readonly string SourceFolder = @"C:\Users\HE-Admin\Pictures\Screenshots";
        private readonly string OutputFolder = @"C:\Levitronix\AnalyseBilder";
        private readonly string BackupFolder = @"C:\Levitronix\AnalyseBilder_Backup";

        public double Contrast { get; set; } = 1.3;
        public double Brightness { get; set; } = 5.0;

        public ImageManager(Action<string> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            Directory.CreateDirectory(OutputFolder);
            Directory.CreateDirectory(BackupFolder);
        }

        // Datenlogger
        private void Log(string message)
        {
            _logger?.Invoke(message);
        }

        public void ProcessImages()
        {
            var files = Directory.GetFiles(SourceFolder, "*.*")
                .Where(f => f.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                         || f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                         || f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                .OrderBy(f => f)
                .ToArray();

            Log($"Found {files.Length} images.");

            int counter = 1;
            foreach (var file in files)
            {
                using (Mat img = Cv2.ImRead(file))
                {
                    if (img.Empty())
                    {
                        Log($"Warning: Could not read {file}");
                        continue;
                    }

                    // Adjust contrast and brightness
                    Mat proc = new Mat();
                    img.ConvertTo(proc, MatType.CV_8U, Contrast, Brightness);

                    // Apply bilateral filter
                    Mat bilat = new Mat();
                    Cv2.BilateralFilter(proc, bilat, 5, 30, 20);

                    // Crop region [420:860, 10:650]
                    Rect roi = new Rect(10, 420, 640, 440);
                    Mat crop = new Mat(bilat, roi);

                    // Generate filename
                    string ts = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    string fn = $"OCT_{ts}_{counter:000}.png";

                    // Save to output and backup
                    Cv2.ImWrite(Path.Combine(OutputFolder, fn), crop);
                    Cv2.ImWrite(Path.Combine(BackupFolder, fn), crop);

                    counter++;
                }
            }
            Log("All images exported successfully.");
        }
    }
}
