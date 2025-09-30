using System;
using System.Drawing;

namespace OCT_GUI_Application
{
    class TMCM3110Controller
    {
        private SerialPortHandler spTMCM3110_Handler;
        private readonly byte _slaveAddress;
        private readonly Action<string, Color?> _logger;

        // Konstruktor
        public TMCM3110Controller(Action<string, Color?> logger, byte slaveAddress = 2)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _slaveAddress = slaveAddress;
            spTMCM3110_Handler = new SerialPortHandler(logger);
            spTMCM3110_Handler.OpenSerial();
        }

        // Datenlogger
        private void Log(string message, Color? color = null)
        {
            Color c = color ?? Color.White;
            _logger?.Invoke(message, color);
        }

        /// <summary>
        /// Sendet einen TMCL Befehl an den TMCM-3110 Controller.
        /// Stellt sicher, dass die serielle Verbindung offen ist und versucht ggf. neu zu verbinden.
        /// </summary>
        private bool SendTMCLCommand(byte command, byte type, byte axis, uint value, out int replyValue)
        {
            replyValue = 0;

            try
            {
                if (!spTMCM3110_Handler.CheckPort())
                {
                    return false;
                }

                // Frame bauen
                byte[] frame = new byte[9];
                frame[0] = _slaveAddress;
                frame[1] = command;
                frame[2] = type;
                frame[3] = axis;
                frame[4] = (byte)((value >> 24) & 0xFF);
                frame[5] = (byte)((value >> 16) & 0xFF);
                frame[6] = (byte)((value >> 8) & 0xFF);
                frame[7] = (byte)(value & 0xFF);

                // Checksumme
                byte checksum = 0;
                for (int i = 0; i < 8; i++)
                    checksum += frame[i];
                frame[8] = checksum;

                // Senden
                spTMCM3110_Handler.SendFrame(frame, frame.Length);

                // Antwort abwarten
                byte[] response = new byte[9];
                if (!spTMCM3110_Handler.ReadResponse(9, out response))
                {
                    return false;
                }

                // Prüfsumme prüfen
                byte sum = 0;
                for (int i = 0; i < 8; i++)
                    sum += response[i];
                if (sum != response[8]) return false;

                // Status prüfen
                if (response[2] != 100) return false;

                // 32-bit Wert auslesen
                replyValue = (response[4] << 24) |
                                (response[5] << 16) |
                                (response[6] << 8) |
                                response[7];

                spTMCM3110_Handler.LogSuccess();

                return true;
            }
            catch (Exception ex)
            {
                spTMCM3110_Handler.ReopenPortTimeout(ex);
            }

            return false;
        }

        // Seriellen Port schliessen und Verbindung wiederherstellen
        public bool ReopenSerialPort(string portName, int baudRate = 115200)
        {
            return spTMCM3110_Handler.ReopenPort(portName, baudRate);
        }

        // Abstrahierte TMCL Write Funktion
        private bool Write(byte command, byte type, byte axis, uint value)
        {
            return SendTMCLCommand(command, type, axis, value, out _);
        }

        // Abstrahierte TMCL Read Funktion
        private bool Read(byte command, byte type, byte axis, out int value)
        {
            return SendTMCLCommand(command, type, axis, 0, out value);
        }

        // Referenzfahrt starten
        public bool StartReferenceSearch(byte axis)
        {
            if (axis > 2) return false;
            return Write(13, 0, axis, 0);
        }

        // Auf eine Absolute Position in mm bewegen (+/-)
        public bool MovePositionAbs(byte axis, double position_mm)
        {
            if (axis > 2) return false;

            int pitch;
            int usteps_per_revolution;

            switch (axis)
            {
                case 0:
                    pitch = 3;
                    usteps_per_revolution = 10240;
                    break;
                case 1:
                    pitch = 8;
                    usteps_per_revolution = 12800;
                    break;
                default:
                    pitch = 1;
                    usteps_per_revolution = 12800;
                    break;
            }
            double position_usteps_double = Math.Round(position_mm / pitch * usteps_per_revolution, 3);
            int position_usteps = (int)Math.Round(position_usteps_double, MidpointRounding.AwayFromZero);
            uint position_uint = unchecked((uint)position_usteps);

            return Write(4, 0, axis, position_uint);
        }

        // Achsenposition in mm auslesen
        public bool GetActualPosition_mm(byte axis, out double position_mm)
        {
            position_mm = 0;

            if (axis > 2) return false;

            bool read_status = Read(6, 1, axis, out int position_usteps);

            int pitch;
            int usteps_per_revolution;

            switch (axis)
            {
                case 0:
                    pitch = 3;
                    usteps_per_revolution = 10240;
                    break;
                case 1:
                    pitch = 8;
                    usteps_per_revolution = 12800;
                    break;
                default: // axis 2
                    pitch = 1;
                    usteps_per_revolution = 12800;
                    break;
            }

            position_mm = Math.Round((double)position_usteps / usteps_per_revolution * pitch, 3);
            return read_status;
        }

        // Achse anhalten
        public bool MotorStop(byte axis)
        {
            if (axis > 2) return false;
            return Write(3, 0, axis, 0);
        }

        // Achse kontinuierlich nach rechts drehen, speed in U/min
        public bool RotateRight(byte axis, int speed_upm)
        {
            if (axis > 2) return false;

            double speed_pps = (double)speed_upm * 12800 / 60;
            int speed = (int)Math.Round((speed_pps - 0.1105)/30.5177, MidpointRounding.AwayFromZero);

            return Write(1, 0, axis, unchecked((uint)speed));
        }

        // Achse kontinuierlich nach links drehen, speed in U/min
        public bool RotateLeft(byte axis, int speed_upm)
        {
            if (axis > 2) return false;

            double speed_pps = (double)speed_upm * 12800 / 60;
            int speed = (int)Math.Round((speed_pps - 0.1105) / 30.5177, MidpointRounding.AwayFromZero);

            return Write(2, 0, axis, unchecked((uint)speed));
        }
    }
}
