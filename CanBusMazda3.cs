using System;

namespace CanBusTriple
{
    public class CanBusMazda3 : CBTController
    {
        const byte CMD_LCD = 0x16;

        public CanBusMazda3(string comPort) : base(comPort) { }

        public async void DisplayMessage(string msg)
        {
            var cmd = new byte[1 + Math.Min(msg.Length, 65)];
            cmd[0] = CMD_LCD;
            var chars = msg.ToCharArray();
            for (int i = 1; i < cmd.Length; i++) cmd[i] = (byte)chars[i - 1];
            await Serial.BlindCommand(cmd);
        }
    }
}
