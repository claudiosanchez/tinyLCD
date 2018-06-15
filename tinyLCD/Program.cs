using System.Threading;
using Netduino.Foundation.Displays;

namespace tinyLCD
{
    public class Program
    {
        public static void Main()
        {
            var oled = new SSD1306();
            var display = new GraphicsLibrary(oled);

            display.Clear(true);
            display.CurrentFont = new Font8x8();
            display.DrawText(4, 10, 0, "NETDUINO 3 WiFi");
            display.DrawText(48, 25, 0, "says");
            display.DrawText(16, 40, 2, "Hello, world.");
            display.DrawLine(0, 60, 127, 60);
            display.Show();

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
