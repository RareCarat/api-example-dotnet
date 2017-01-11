using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace API.RareCarat.Example.Model
{
    /// <summary>
    /// Shape of the diamond cut.
    /// </summary>
    public enum CutShape
    {
        /// <summary>
        /// Round shape.
        /// </summary>
        Round = 1,
        /// <summary>
        /// Princess shape.
        /// </summary>
        Princess = 2,
        /// <summary>
        /// Marquise shape.
        /// </summary>
        Marquise = 3,
        /// <summary>
        /// Emerald shape.
        /// </summary>
        Emerald = 4,
        /// <summary>
        /// Pear shape.
        /// </summary>
        Pear = 5,
        /// <summary>
        /// Oval shape.
        /// </summary>
        Oval = 6,
        /// <summary>
        /// Heart shape.
        /// </summary>
        Heart = 7,
        /// <summary>
        /// Radiant shape.
        /// </summary>
        Radiant = 8,
        /// <summary>
        /// Asscher shape.
        /// </summary>
        Asscher = 9,
        /// <summary>
        /// Cushion shape.
        /// </summary>
        Cushion = 10,
        /// <summary>
        /// Trillian shape.
        /// </summary>
        Trillian = 11,
        /// <summary>
        /// Baguette shape.
        /// </summary>
        Baguette = 12,
        /// <summary>
        /// Unknown shape.
        /// </summary>
        [EnumMember(Value = "")]
        Unknown = 0
    }
}
