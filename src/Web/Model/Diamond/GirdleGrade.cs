using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace API.RareCarat.Example.Model
{
    /// <summary>
    /// Certificated grading for the diamond's girdle.
    /// </summary>
    public enum GirdleGrade
    {
        /// <summary>
        /// Extremely thin girdle.
        /// </summary>
        [EnumMember(Value = "Extremely Thin")]
        ExtremelyThin = 1,
        /// <summary>
        /// Very thin girdle.
        /// </summary>
        [EnumMember(Value = "Very Thin")]
        VeryThin = 2,
        /// <summary>
        /// Thin girdle.
        /// </summary>
        Thin = 3,
        /// <summary>
        /// Slightly thin girdle.
        /// </summary>
        [EnumMember(Value = "Slightly Thin")]
        SlightlyThin = 4,
        /// <summary>
        /// Medium girdle.
        /// </summary>
        Medium = 5,
        /// <summary>
        /// Slightly thick girdle.
        /// </summary>
        [EnumMember(Value = "Slightly Thick")]
        SlightlyThick = 6,
        /// <summary>
        /// Thick girdle.
        /// </summary>
        Thick = 7,
        /// <summary>
        /// Very thick girdle.
        /// </summary>
        [EnumMember(Value = "Very Thick")]
        VeryThick = 8,
        /// <summary>
        /// Extremely thick girdle.
        /// </summary>
        [EnumMember(Value = "Extremely Thick")]
        ExtremelyThick = 9,
        /// <summary>
        /// Unknown girdle.
        /// </summary>
        [EnumMember(Value = "")]
        Unknown = 0
    }
}
