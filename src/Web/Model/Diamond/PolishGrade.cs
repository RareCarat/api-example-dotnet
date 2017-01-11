using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace API.RareCarat.Example.Model
{
    /// <summary>
    /// Certificated grading for the diamond's polish.
    /// </summary>
    public enum PolishGrade
    {
        /// <summary>
        /// Ideal polish.
        /// </summary>
        Ideal = 0,
        /// <summary>
        /// Excellent polish.
        /// </summary>
        Excellent = 1,
        /// <summary>
        /// Very good polish.
        /// </summary>
        [EnumMember(Value = "Very Good")]
        VeryGood = 2,
        /// <summary>
        /// Good polish.
        /// </summary>
        Good = 3,
        /// <summary>
        /// Fair polish.
        /// </summary>
        Fair = 4,
        /// <summary>
        /// Poor polish.
        /// </summary>
        Poor = 5,
        /// <summary>
        /// Unknown polish.
        /// </summary>
        Unknown = 999
    }
}
