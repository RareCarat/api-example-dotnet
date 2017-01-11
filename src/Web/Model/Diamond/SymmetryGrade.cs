using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace API.RareCarat.Example.Model
{
    /// <summary>
    /// Certificated grading for the diamond's symmetry.
    /// </summary>
    public enum SymmetryGrade
    {
        /// <summary>
        /// Ideal symmetry.
        /// </summary>
        Ideal = 0,
        /// <summary>
        /// Excellent symmetry.
        /// </summary>
        Excellent = 1,
        /// <summary>
        /// Very good symmetry.
        /// </summary>
        [EnumMember(Value = "Very Good")]
        VeryGood = 2,
        /// <summary>
        /// Good symmetry.
        /// </summary>
        Good = 3,
        /// <summary>
        /// Fair symmetry.
        /// </summary>
        Fair = 4,
        /// <summary>
        /// Poor symmetry.
        /// </summary>
        Poor = 5,
        /// <summary>
        /// Unknown symmetry.
        /// </summary>
        Unknown = 999
    }
}
