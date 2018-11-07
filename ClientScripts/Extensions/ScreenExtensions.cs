using ClientScripts.Models;
using System;
using System.Windows.Forms;

namespace ClientScripts.Extensions
{
    public static class ScreenExtensions
    {
        public static DisplayInfo ToDisplayInfo(this Screen screen)
        {
            if (screen == null)
                throw new ArgumentNullException(nameof(screen));

            return new DisplayInfo
            {
                WorkingArea = screen.WorkingArea.ToRect(),
                Primary = screen.Primary,
                DeviceName = screen.DeviceName,
                Bounds = screen.Bounds.ToRect(),
                BitsPerPixel = screen.BitsPerPixel
            };
        }
    }
}
