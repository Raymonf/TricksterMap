using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace md3_2.Data
{
    public class PointObject
    {
        // Position Id / PosId
        public int Id { get; set; }

        // Type of point object
        public int Type { get; set; }

        // Map ID (for portals only)
        public int MapId { get; set; }

        // X position
        public int X { get; set; }

        // Y position
        public int Y { get; set; }

        // 這個應該不用理
        public int Padding { get; set; } = 0;

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
