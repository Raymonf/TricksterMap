using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace md3_2.Data
{
    public class PointObject
    {
        /// <summary>
        /// Position Id / PosId
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Type of point object
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Map ID (for portals only)
        /// </summary>
        public int MapId { get; set; }

        /// <summary>
        /// X position
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y position
        /// </summary>
        public int Y { get; set; }
        
        /// <summary>
        /// Options (unconfirmed, is this always 0?)
        /// </summary>
        public int Options { get; set; } = 0;
        
        /// <summary>
        /// Gets the name of the point object's type
        /// </summary>
        /// <returns>Name of the object's type</returns>
        public string GetTypeName()
        {
            switch (Type)
            {
                case 0x00:
                    return "None";
                case 0x01:
                    return "Portal";
                case 0x02:
                    return "Respawn Location";
                case 0x03:
                    return "Monster Spawn";
                case 0x04:
                    return "General NPC";
                case 0x05:
                    return "Shop NPC";
                case 0x07:
                    return "Teleport Item Spawn";
                case 0x09:
                    return "Teleport NPC Spawn";
                case 0x0A:
                    return "Skill NPC";
                case 0x0D:
                    return "NORI Entity (?)";
            }

            return "Unknown (" + Type + ")";
        }
    }
}
