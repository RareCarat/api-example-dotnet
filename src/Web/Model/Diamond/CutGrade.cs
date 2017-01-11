using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace API.RareCarat.Example.Model
{
    /// <summary>
    /// Certificated grading for the diamond's cut.
    /// </summary>
    public enum CutGrade
    {
        /// <summary>
        /// Ideal cut.
        /// </summary>
        Ideal = 0,
        /// <summary>
        /// Excellent cut.
        /// </summary>
        Excellent = 1,
        /// <summary>
        /// Very good cut.
        /// </summary>
        [EnumMember(Value = "Very Good")]
        VeryGood = 2,
        /// <summary>
        /// Good cut.
        /// </summary>
        Good = 3,
        /// <summary>
        /// Fair cut.
        /// </summary>
        Fair = 4,
        /// <summary>
        /// Poor cut.
        /// </summary>
        Poor = 5,
        /// <summary>
        /// Unknown cut.
        /// </summary>
        Unknown = 999
    }
}
