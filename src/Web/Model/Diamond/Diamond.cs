using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using System.Linq;
using System.Xml.Serialization;

namespace API.RareCarat.Example.Model
{
    /// <summary>
    /// This class represents the diamond resource.
    /// </summary>        
    public class Diamond
    {
        /// <summary>
        /// Identifier of the entity.
        /// </summary>        
        [Required]
        public string Id { get; set; }
        /// <summary>
        /// URL to the diamond detail page.
        /// </summary>
        [Required]
        public string URL { get; set; }
        public string ImagesURLValue { get; set; }
        /// <summary>
        /// URLs to the diamond images.
        /// </summary>
        [NotMapped]
        public virtual List<string> ImagesURL
        {
            get
            {
                if (ImagesURLValue == null)
                    return null;
                return ImagesURLValue.Split(';').ToList();
            }
            set
            {
                if (value != null)
                    ImagesURLValue = string.Join(";", value);
            }
        }
        public string VideosURLValue { get; set; }
        /// <summary>
        /// URLs to the diamond videos.
        /// </summary>
        [NotMapped]
        public List<string> VideosURL
        {
            get
            {
                if (VideosURLValue == null)
                    return null;
                return VideosURLValue.Split(';').ToList();
            }
            set
            {
                if (value != null)
                    VideosURLValue = string.Join(";", value);
            }
        }
        /// <summary>
        /// Laboratory responsible for the diamond certification.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CertificateLaboratory CertificateLab { get; set; }
        /// <summary>
        /// URL of the diamond certificate.
        /// </summary>
        public string CertificateURL { get; set; }
        /// <summary>
        /// Unique identifier of the certificate.
        /// </summary>
        public string CertificateID { get; set; }
        /// <summary>
        /// Price of the diamond.
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Price of the diamond, if paid via wire transfer.
        /// </summary>
        public decimal WirePrice { get; set; }
        /// <summary>
        /// Shape of the diamond cut.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CutShape Shape { get; set; }
        /// <summary>
        /// Carat weight of the diamond.
        /// </summary>
        public decimal Carat { get; set; }
        /// <summary>
        /// Grade of the diamond cut.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CutGrade Cut { get; set; }
        /// <summary>
        /// Grade of the diamond color.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ColorGrade Color { get; set; }
        /// <summary>
        /// Grade of the diamond clarity.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ClarityGrade Clarity { get; set; }
        /// <summary>
        /// Grade of the diamond fluorescence.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public FluorescenceGrade Fluorescence { get; set; }
        /// <summary>
        /// Grade of the diamond polish.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public PolishGrade Polish { get; set; }
        /// <summary>
        /// Grade of the diamond symmetry.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public SymmetryGrade Symmetry { get; set; }
        /// <summary>
        /// Measurement of the table (in millimeters).
        /// </summary>
        public decimal TableWidth { get; set; }
        /// <summary>
        /// The width of the table expressed as a percentage of its average diameter.
        /// </summary>
        public decimal TableWidthPercentage { get; set; }
        /// <summary>
        /// Grade of the diamond girdle
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public GirdleGrade Girdle { get; set; }
        /// <summary>
        /// Measurement of the girdle (in millimeters).
        /// </summary>
        public decimal GirdleThickness { get; set; }
        /// <summary>
        /// Average diameter of the diamond (in millimeters).
        /// </summary>
        public decimal GirdleDiameter { get; set; }
        /// <summary>
        /// Grade of the diamond culet.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CuletGrade Culet { get; set; }
        /// <summary>
        /// Measurement of the culet (in millimeters).
        /// </summary>
        public decimal CuletSize { get; set; }
        /// <summary>
        /// Angle of the culet.
        /// </summary>
        public decimal CuletAngle { get; set; }
        /// <summary>
        /// Measurement of the crown - from the top part of the girdle to table (in millimeters).
        /// </summary>
        public decimal CrownHeight { get; set; }
        /// <summary>
        /// Percentage of ratio of the crown height as compared to the overall diamond height.
        /// </summary>
        public decimal CrownHeightPercentage  { get; set; }
        /// <summary>
        /// Angle of the crown facets in relationship to the girdle plane.
        /// </summary>
        public decimal CrownAngle { get; set; }
        /// <summary>
        /// Measurement of the pavilion - from the bottom part of the girdle to culet (in millimeters).
        /// </summary>
        public decimal PavilionDepth  { get; set; }
        /// <summary>
        /// Percentage of ratio of the pavilion depth as compared to the overall diamond height.
        /// </summary>
        public decimal PavilionDepthPercentage { get; set; }
        /// <summary>
        /// Angle of the pavilion facets in relationship to the girdle plane.
        /// </summary>
        public decimal PavilionAngle  { get; set; }
        /// <summary>
        /// Percentage of ratio of the total depth of the diamond (from table to culet) as compared with the girdle diameter.
        /// </summary>
        public decimal DepthPercentage { get; set; }
        /// <summary>
        /// Percentage of ratio of the length of the diamond as compared to its width.
        /// </summary>
        public decimal LengthToWidthRatio { get; set; }
        /// <summary>
        /// Measurements (L x W x H) of the diamond (in millimeters).
        /// </summary>
        [NotMapped]
        public string Measurements
        {
            get
            {
                return $"{Length.ToString("0.00")} x {Width.ToString("0.00")} x {Height.ToString("0.00")} mm";
            }
            set
            {
                var r = new Regex(@"([\d\.]+)").Matches(value);
                if (r.Count == 3)
                {
                    Length = decimal.Parse(r[0].Value);
                    Width = decimal.Parse(r[1].Value);
                    Height = decimal.Parse(r[2].Value);
                }
                else
                    Length = Width = Height = 0;
            }
        }
        /// <summary>
        /// Length of the diamond (in millimeters).
        /// </summary>
        public decimal Length { get; set; }
        /// <summary>
        /// Width of the diamond (in millimeters).
        /// </summary>
        public decimal Width { get; set; }
        /// <summary>
        /// Height of the diamond (in millimeters).
        /// </summary>
        public decimal Height { get; set; }
        /// <summary>
        /// Horizontally projected distance from the edge of the table to the edge of the girdle (in millimeters).
        /// </summary>
        public decimal GirdleToTableDistance { get; set; }
        /// <summary>
        /// Horizontally projected distance from the point of the star facet to the edge of the table (in millimeters).
        /// </summary>
        public decimal StarLength { get; set; }
        /// <summary>
        /// Length of the star facet expressed as a percentage of the girdle-to-table distance.
        /// </summary>
        public decimal StarLengthPercentage { get; set; }
        /// <summary>
        /// Horizontally projected distance from the culet to the edge of the girdle (in millimeters).
        /// </summary>
        public decimal GirdleToCuletDistance { get; set; }
        /// <summary>
        /// Horizontally projected distance from the point where two pavilion mains meet to the closest edge of the girdle (in millimeters).
        /// </summary>
        public decimal LowerHalfLength { get; set; }
        /// <summary>
        /// Length of the lower half expressed as a percentage of the girdle-to-culet distance (in millimeters).
        /// </summary>
        public decimal LowerHalfLengthPercentage { get; set; }
        /// <summary>
        /// Number of days needed to process the purchase order and ship the diamond to the customer.
        /// </summary>
        public int ShippingDays { get; set; }

    }
}
