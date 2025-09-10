using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace OCT_GUI_Application
{
    class TMCM3110Controller
    {
        private readonly SerialPort _serial;
        private readonly byte _slaveAddress;

        public TMCM3110Controller(SerialPort serial, byte slaveAddress = 2)
        {
            _serial = serial ?? throw new ArgumentNullException(nameof(serial));
            _slaveAddress = slaveAddress;
        }

        /// <summary>
        /// Sendet einen TMCL Befehl an den TMCM-3110 Controller
        /// </summary>
        private bool SendTMCLCommand(byte command, byte type, byte axis, uint value, out int replyValue, int timeoutMs = 50)
        {
            replyValue = 0;
            byte[] frame = new byte[9];

            frame[0] = _slaveAddress;
            frame[1] = command;
            frame[2] = type;
            frame[3] = axis;
            frame[4] = (byte)((value >> 24) & 0xFF);
            frame[5] = (byte)((value >> 16) & 0xFF);
            frame[6] = (byte)((value >> 8) & 0xFF);
            frame[7] = (byte)(value & 0xFF);

            // Checksum
            byte checksum = 0;
            for (int i = 0; i < 8; i++)
                checksum += frame[i];
            frame[8] = checksum;

            // Senden
            _serial.Write(frame, 0, frame.Length);
            _serial.BaseStream.Flush();

            // Warten auf Antwort
            DateTime start = DateTime.Now;
            while (_serial.BytesToRead < 9)
            {
                if ((DateTime.Now - start).TotalMilliseconds > timeoutMs)
                    return false;
                System.Threading.Thread.Sleep(1);
            }

            // Antwort lesen
            byte[] response = new byte[9];
            int read = _serial.Read(response, 0, 9);
            if (read < 9) return false;

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

            return true;
        }

        public bool Write(byte command, byte type, byte axis, uint value)
        {
            return SendTMCLCommand(command, type, axis, value, out _);
        }

        public bool Read(byte command, byte type, byte axis, out int value)
        {
            return SendTMCLCommand(command, type, axis, 0, out value);
        }
    }
}
