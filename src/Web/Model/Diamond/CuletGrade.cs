using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace API.RareCarat.Example.Model
{
    /// <summary>
    /// Certificated grading for the diamond's culet.
    /// </summary>
    public enum CuletGrade
    {
        /// <summary>
        /// No culet.
        /// </summary>
        Pointed = 0,
        /// <summary>
        /// No culet.
        /// </summary>
        None = 0,
        /// <summary>
        /// Very small culet.
        /// </summary>
        [EnumMember(Value = "Very Small")]
        VerySmall = 1,
        /// <summary>
        /// Small culet.
        /// </summary>
        Small = 2,
        /// <summary>
        /// Medium culet.
        /// </summary>
        Medium = 3,
        /// <summary>
        /// Slightly large culet.
        /// </summary>
        [EnumMember(Value = "Slightly Large")]
        SlightlyLarge = 4,
        /// <summary>
        /// Large culet.
        /// </summary>
        Large = 5,
        /// <summary>
        /// Extremely large culet.
        /// </summary>
        [EnumMember(Value = "Extremely Large")]
        ExtremelyLarge = 6,
        /// <summary>
        /// Unknown culet.
        /// </summary>
        Unknown = 999
    }
}
