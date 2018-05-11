using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace md3_2.Data
{
    public class RangeObject
    {
        /// <summary>
        /// Range object type
        /// </summary>
        public int Type { get; set; }

        public int Id { get; set; }

        public int X1 { get; set; }
        public int Y1 { get; set; }

        public int X2 { get; set; }
        public int Y2 { get; set; }

        /// <summary>
        /// Options (unconfirmed, is this always 0?)
        /// </summary>
        public int Options { get; set; } = 0;

        /// <summary>
        /// Gets the name of the range object's type
        /// </summary>
        /// <returns>Name of the object's type</returns>
        public string GetTypeName()
        {
            switch (Type)
            {
                case 0x00:
                    return "Setting Debris (Unknown/0)";
                case 0x01:
                    return "Portal Entrance";
                case 0x02:
                    return "Monster Movement Range";
                case 0x05:
                    return "Monster Gather Range";
                case 0x06:
                    return "NPC Movement Scope";
                case 0x09:
                    return "Monster Spawn Range";
                case 0x0A:
                    return "GvG Respawn Range";
            }

            return "Unknown (" + Type + ")";
        }
    }
}
