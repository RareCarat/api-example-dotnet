using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace API.RareCarat.Example.Model
{
    /// <summary>
    /// Certificated grading for the diamond's fluorescence.
    /// </summary>
    public enum FluorescenceGrade
    {
        /// <summary>
        /// No fluorescence.
        /// </summary>
        None = 0,
        /// <summary>
        /// No fluorescence.
        /// </summary>
        Negligible = 0,
        /// <summary>
        /// Faint fluorescence.
        /// </summary>
        Faint = 1,
        /// <summary>
        /// Medium fluorescence.
        /// </summary>
        Medium = 2,
        /// <summary>
        /// Strong fluorescence.
        /// </summary>
        Strong = 3,
        /// <summary>
        /// Very strong fluorescence.
        /// </summary>
        [EnumMember(Value = "Very Strong")]
        VeryStrong = 4,
        /// <summary>
        /// Unknown fluorescence.
        /// </summary>
        Unknown = 999
    }
}
