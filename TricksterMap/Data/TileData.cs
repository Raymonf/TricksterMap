using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TricksterMap.Data
{
    public class TileData
    {
        public int Address { get; set; }
        public int TilesX { get; set; }
        public int TilesY { get; set; }
        public List<Bitmap> Bitmaps { get; set; }
    }
}
