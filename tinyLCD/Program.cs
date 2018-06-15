using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace tinyLCD
{
    public class Program
    {
        public static void Main()
        {
            //var oled = new Netduino.Foundation.Displays.SSD1306();

            //oled.Clear(true);
            //varde display = new GraphicsLibrary(oled);

            //display.Clear(true);
            //display.CurrentFont = new Font8x8();
            //display.DrawText(4, 10, 0, "NETDUINO 3 WiFi");
            //display.DrawText(48, 25, 0, "says");
            //display.DrawText(16, 40, 2, "Hello, world.");
            //display.DrawLine(0, 60, 127, 60);
            //display.Show();

            var fileSystems = Microsoft.SPOT.IO.VolumeInfo.GetFileSystems();
           
            foreach (var item in fileSystems)
            {
              Debug.Print (item.ToString());
            }

            var hwp = new HardwareProvider();
            Cpu.Pin sd;
            Cpu.Pin sc;

            hwp.GetI2CPins(out sc, out sd);

            //Thread.Sleep(Timeout.Infinite);
        }
    }
}
