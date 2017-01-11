using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace API.RareCarat.Example.Model
{
    /// <summary>
    /// Certificated grading for the diamond's clarity.
    /// </summary>
    public enum ClarityGrade
    {
        /// <summary>
        /// Flawless, with no inclusions.
        /// </summary>
        FL = 1,
        /// <summary>
        /// Internally flawless clarity.
        /// </summary>
        IF = 2,
        /// <summary>
        /// Very, very slightly included clarity (visible only from the pavilion).
        /// </summary>
        VVS1 = 3,
        /// <summary>
        /// Very, very slightly included clarity (visible from the crown).
        /// </summary>
        VVS2 = 4,
        /// <summary>
        /// Very slightly included clarity (visible only from the pavilion).
        /// </summary>
        VS1 = 5,
        /// <summary>
        /// Very slightly included clarity (visible from the crown).
        /// </summary>
        VS2 = 6,
        /// <summary>
        /// Slightly included clarity (visible only from the pavilion).
        /// </summary>
        SI1 = 7,
        /// <summary>
        /// Slightly included clarity (visible from the crown).
        /// </summary>
        SI2 = 8,
        /// <summary>
        /// Included clarity.
        /// </summary>
        I1 = 9,
        /// <summary>
        /// Very included clarity.
        /// </summary>
        I2 = 10,
        /// <summary>
        /// Very, very included clarity.
        /// </summary>
        I3 = 11,
        /// <summary>
        /// Unknown clarity.
        /// </summary>
        [EnumMember(Value = "")]
        None = 0,
        /// <summary>
        /// Unknown clarity.
        /// </summary>
        Unknown = 999
    }
}
