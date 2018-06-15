using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Netduino.Foundation.Displays;
using tinyLCD;
using static Microsoft.SPOT.Hardware.I2CDevice;

namespace tinyLCD
{
    public class Program
    {
        public static void Main()
        {
            var device = new SSD1306();

            DisplayLinesOnDisplay(device);

            DrawText(device,0, 0, 2, "HO");
            DrawText(device,0, 10, 2, "HLO");
            DrawText(device, 0, 20, 2, "HELLO");

            device.Show();
        }

        private static void DisplayLinesOnDisplay(SSD1306 device)
        {
            for (int y = 0; y < 64; y++)
            {
                for (int x = 0; x < 128; x++)
                {
                    var shouldDisplay = x % 2 == 0 ? true : false;
                    device.DrawPixel(x, y, shouldDisplay);
                }
            }
        }

        /// <summary>
        ///     Draw a text message on the display using the current font.
        /// </summary>
        /// <param name="x">Abscissa of the location of the text.</param>
        /// <param name="y">Ordinate of the location of the text.</param>
        /// <param name="spacing">Number of pixels between characters.</param>
        /// <param name="text">Text to display.</param>
        /// <param name="wrap">Wrap the text at the end of the display?</param>
        public static void DrawText(SSD1306 device, int x, int y, int spacing, string text, bool wrap = false)
        {
           // var font = new Font8x8();

            var fontHeight = 8;
            
                byte[] bitMap = new byte[text.Length * fontHeight];

            for (int index = 0; index < text.Length; index++)
            {
                byte[] characterMap = new byte[] { 0x3E, 0x63, 0x7B, 0x7B, 0x7B, 0x03, 0x1E, 0x00 };

                for (int characterSegment = 0; characterSegment < fontHeight; characterSegment++)
                {
                    bitMap[index + (characterSegment * text.Length)] = characterMap[characterSegment];
                }
            }
            device.DrawBitmap(x, y, text.Length, fontHeight, bitMap,Netduino.Foundation.Displays.DisplayBase.BitmapMode.And);


        }

        private void CodeNotBeingUsed()
        {
            //var display = new GraphicsLibrary(oled);

            //display.Clear(true);
            //display.CurrentFont = new Font8x8();
            //display.DrawText(4, 10, 0, "NETDUINO 3 WiFi");
            //display.DrawText(48, 25, 0, "says");
            //display.DrawText(16, 40, 2, "Hello, world.");
            //display.DrawLine(0, 60, 127, 60);
            //display.Show();

            //var fileSystems = Microsoft.SPOT.IO.VolumeInfo.GetFileSystems();

            //foreach (var item in fileSystems)
            //{
            //  Debug.Print (item.ToString());
            //}

            //var hwp = new HardwareProvider();
            //Cpu.Pin sd;
            //Cpu.Pin sc;

            //hwp.GetI2CPins(out sc, out sd);



            //Thread.Sleep(Timeout.Infinite);

        }
    }
}
