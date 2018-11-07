using ClientScripts.Models;
using System;
using System.Drawing;

namespace ClientScripts.Extensions
{
    public static class RectangleExtensions
    {
        public static Rect ToRect(this Rectangle rectangle)
        {
            if (rectangle == null)
                throw new ArgumentNullException(nameof(rectangle));

            return new Rect { X1 = rectangle.X, Y1 = rectangle.Y, Width = rectangle.Width, Height = rectangle.Height };
        }
    }
}
