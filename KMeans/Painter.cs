using System.Drawing;

namespace KMeans
{
    public class Painter
    {
        private const int BitmapWidth = 1000;
        private const int PenWidth = 2;

        public Bitmap MakeImage(KMeansData data)
        {
            Bitmap b = new Bitmap(BitmapWidth, BitmapWidth);
            using var g = Graphics.FromImage(b);
            g.Clear(Color.White);
            for (int i = 0; i < data.FormCount; i++)
            {
                g.DrawRectangle(SelectColor(data.Vectors[i].ClassIndex), data.Vectors[i].Point.X,
                    data.Vectors[i].Point.Y, 1, 1);
                g.FillRectangle(SelectColor(data.Vectors[i].ClassIndex).Brush, data.Vectors[i].Point.X,
                    data.Vectors[i].Point.Y, 1, 1);
            }

            return b;
            // b.Save(this.Directory + j.ToString() + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
        }

        private static Pen SelectColor(int classIndex)
        {
            var color = classIndex switch
            {
                1 => Color.Red,
                2 => Color.Coral,
                3 => Color.Blue,
                4 => Color.Green,
                5 => Color.Brown,
                6 => Color.Orange,
                7 => Color.HotPink,
                8 => Color.Purple,
                9 => Color.Gold,
                10 => Color.DarkRed,
                _ => Color.Black,
            };

            return new Pen(color) {Width = PenWidth};
        }
    }
}