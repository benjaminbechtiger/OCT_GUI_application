using System;
using System.Drawing;
using System.IO.Ports;

namespace OCT_GUI_Application
{
    class SerialPortHandler
    {
        private SerialPort serialPort;
        private readonly Action<string, Color?> _logger;
        private bool _errorLogged = false;
        private int _failedAttempts = 0;
        private int MaxFailedAttempts;

        public SerialPortHandler(Action<string, Color?> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            serialPort = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One); //Default Serial Port (Benjamin PC)
        }

        // Datenlogger
        private void Log(string message, Color? color = null)
        {
            Color c = color ?? Color.White;
            _logger?.Invoke(message, color);
        }

        public void OpenSerial()
        {
            try
            {
                serialPort.Open();
            }
            catch (Exception ex)
            {
                Log("Failed to open serial port: " + ex.Message);
            }
        }

        public bool CheckPort()
        {
            if (serialPort == null)
            {
                if (!_errorLogged)
                {
                    Log("Serial port object is null.");
                    _errorLogged = true;
                }
                return false;
            }

            if (!serialPort.IsOpen)
            {
                if (!_errorLogged)
                {
                    Log("Serial port is closed. Please reopen manually.");
                    _errorLogged = true;
                }
                return false;
            }

            return true;
        }

        public void SendFrame(byte[] frame, int count)
        {
            serialPort.Write(frame, 0, count);
            serialPort.BaseStream.Flush();
        }

        public bool ReadResponse(int length, out byte[] response, int timeoutMs = 50)
        {
            response = new byte[length];

            DateTime start = DateTime.Now;
            while (serialPort.BytesToRead < length)
            {
                if ((DateTime.Now - start).TotalMilliseconds > timeoutMs)
                    return false;
                System.Threading.Thread.Sleep(1);
            }

            // Antwort lesen
            int read = serialPort.Read(response, 0, length);
            if (read < length) return false;

            return true;
        }

        public void LogSuccess()
        {
            // success → reset failures
            _failedAttempts = 0;

            // if we had logged an error earlier → clear it and log recovery
            if (_errorLogged)
            {
                Log("Serial communication recovered.");
                _errorLogged = false;
            }
        }

        public void ReopenPortTimeout(Exception ex, int maxAttempts = 10)
        {
            MaxFailedAttempts = maxAttempts;
            _failedAttempts++;

            if (!_errorLogged)
            {
                Log($"[ERROR] Serial communication failed: {ex.Message}");
                _errorLogged = true;
            }

            if (_failedAttempts >= MaxFailedAttempts)
            {
                try
                {
                    if (serialPort.IsOpen) serialPort.Close();
                }
                catch { }
                if (_errorLogged)
                    Log($"[ERROR] Max connection attempts reached. COM port closed.");
            }
        }

        public bool ReopenPort(string portName, int baudRate = 115200, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.One)
        {
            try
            {
                // close old port if still around
                if (serialPort != null)
                {
                    if (serialPort.IsOpen)
                        serialPort.Close();
                    serialPort.Dispose();
                }

                // create new SerialPort
                serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
                serialPort.Open();

                _failedAttempts = 0;
                _errorLogged = false;

                Log($"[INFO] Serial port {portName} reopened successfully.");
                return true;
            }
            catch (Exception ex)
            {
                Log($"[ERROR] Could not reopen serial port {portName}: {ex.Message}");
            }
            return false;
        }
    }
}
