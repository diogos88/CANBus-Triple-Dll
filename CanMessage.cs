using System;
using System.Linq;

namespace CanBusTriple
{
    public class CanMessage
    {
        public int Bus { get; set; }
        public int Id { get; set; }
        public byte[] Data { get; set; }

        public DateTime DateTime { get; set; }
        /**
         * Status contains information about the two receive buffers of MCP2515 chip
         * 01 -> Message received on buffer 1
         * 02 -> Message received on buffer 2
         * 03 -> Messages received on both buffers
         * */
        public int Status { get; set; }

        public string HexId => $"0x{Id:X3}";

        public string HexData
        {
            get
            {
                return Data.Aggregate("", (current, b) => current + $"{b:X2} ");
                //return Data.Aggregate("0x", (current, b) => current + $"{b:X2} ");
            }
        }

        public string ConvertedValue { get; set; }

        public string Time => DateTime.ToString("HH:mm:ss.fff");
    }
}
