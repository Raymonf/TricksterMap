using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TricksterMap.Data
{
    public class MapDataInfo
    {
        #region Header

        /// <summary>
        /// 0x012F or 0x012E
        /// 0x012F = Data files are compressed
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Bits per pixel for the tile data
        /// </summary>
        public int TileBpp { get; set; } = 0x10;

        /// <summary>
        /// Unknown
        /// </summary>
        public int Param3 { get; set; } = 0;

        /// <summary>
        /// Unknown
        /// </summary>
        public int Param4 { get; set; } = 0;

        /// <summary>
        /// Total size of related files of the map (sum of MD3 + BAC + TIL + LYR), not including EFF file. The size may not match in some cases.
        /// </summary>
        public int MapSizeSum { get; set; } = 0;

        /// <summary>
        /// Unknown
        /// </summary>
        public int Param6 { get; set; }

        /// <summary>
        /// Unknown
        /// </summary>
        public int Param7 { get; set; }

        /// <summary>
        /// Map size X (pixels)
        /// </summary>
        public int MapSizeX { get; set; }

        /// <summary>
        /// Map size Y (pixels)
        /// </summary>
        public int MapSizeY { get; set; }

        /// <summary>
        /// Image size X (pixels)
        /// </summary>
        public int TileSizeX { get; set; }

        /// <summary>
        /// Image size Y (pixels)
        /// </summary>
        public int TileSizeY { get; set; }

        /// <summary>
        /// Tile count X (unconfirmed)
        /// </summary>
        public int TileCountX { get; set; }

        /// <summary>
        /// Tile count Y (unconfirmed)
        /// </summary>
        public int TileCountY { get; set; }

        /// <summary>
        /// Unknown
        /// </summary>
        public int Param14 { get; set; }

        /// <summary>
        /// Number of data blocks in the lyr file
        /// </summary>
        public int LyrDataCount { get; set; }

        /// <summary>
        /// Number of image groups in the til file
        /// </summary>
        public int TileGroupCount { get; set; }
        
        /// <summary>
        /// Unknown
        /// </summary>
        public int Param21 { get; set; } = 0;

        /// <summary>
        /// Unknown
        /// </summary>
        public int Param22 { get; set; } = 0;

        /// <summary>
        /// Unknown
        /// </summary>
        public int Param23 { get; set; } = 0;

        #endregion

        #region Vectors

        /// <summary>
        /// List of config layers
        /// We probably won't touch this but we'll need it when we're rebuilding the MD3 file
        /// </summary>  
        public List<ConfigLayer> ConfigLayers { get; set; } = new List<ConfigLayer>();

        /// <summary>
        /// Range object list (TODO)
        /// </summary>
        public List<RangeObject> RangeObjects { get; set; } = new List<RangeObject>();

        /// <summary>
        /// Point object list (TODO)
        /// </summary>
        public List<PointObject> PointObjects { get; set; } = new List<PointObject>();

        /// <summary>
        /// Effect object list (TODO)
        /// </summary>
        public List<byte[]> EffectObjects { get; set; } = new List<byte[]>();

        #endregion

        #region Temporary Data

        public int BacFileSize { get; set; } = 0;
        public int TilFileSize { get; set; } = 0;
        public int LyrFileSize { get; set; } = 0;

        #endregion
    }
}
