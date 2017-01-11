using API.RareCarat.Example.Configuration;
using API.RareCarat.Example.Helpers;
using API.RareCarat.Example.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace API.RareCarat.Example.Services
{
    public class APIService : IAPIService
    {
        protected HttpClient HttpClient;

        public APIService(IOptions<APIOptions> options)
        {
            HttpClient = new HttpClient();

            HttpClient.BaseAddress = new Uri(options.Value.Endpoint);

            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(
                    Encoding.ASCII.GetBytes(
                        string.Format("{0}:{1}", options.Value.Key, ""))));
        }

        private object MapValues(Diamond diamond)
        {
            // do any transformations in the data you need here
            // view accepted values at https://api.rarecarat.com/#data-resource-attributes
            return new
            {
                Id = diamond.Id, //string - Unique identifier of the diamond used by the retailer. Usually a SKU number.
                Url = diamond.URL, //string - URL to the diamond detail page
                ImagesUrl = diamond.ImagesURLValue, //array - URL(s) to the diamond images
                VideosUrl = diamond.VideosURLValue, //array - URL(s) to the diamond videos.

                CertificateLab = Utils.GetDescriptionFromEnumValue((Enum)diamond.CertificateLab), //string - Laboratory responsible for the diamond certification. (Accepted values: GIA, AGS, IGI, EGL, HRD)
                CertificateUrl = diamond.CertificateURL, //string - URL of the diamond certificate.
                CertificateId = diamond.CertificateID, //string - Unique identifier of the certificate.

                Price = diamond.Price, //decimal - Price of the diamond.
                WirePrice = diamond.WirePrice, //decimal - Price of the diamond, if paid via wire transfer.

                Shape = Utils.GetDescriptionFromEnumValue((Enum)diamond.Shape), //string - Shape of the diamond. (Accepted values: Round, Princess, Marquise, Emerald, Pear, Oval, Heart, Radiant, Asscher, Cushion)
                Carat = diamond.Carat, //decimal - Carat weight of the diamond.
                Cut = Utils.GetDescriptionFromEnumValue((Enum)diamond.Cut), //string - Grade of the diamond cut. (Accepted values: Ideal, Excellent, Very Good, Good, Fair, Poor)
                Color = Utils.GetDescriptionFromEnumValue((Enum)diamond.Color), //string - Grade of the diamond color. (Accepted values: D-Z)
                Clarity = Utils.GetDescriptionFromEnumValue((Enum)diamond.Clarity), //string - Grade of the diamond clarity.(Accepted values: FL-I3)
                Fluorescence = Utils.GetDescriptionFromEnumValue((Enum)diamond.Fluorescence), //string - Grade of the diamond fluorescence. (Accepted values: None, Faint, Medium, Strong, Very Strong)
                Polish = Utils.GetDescriptionFromEnumValue((Enum)diamond.Polish), //string - Grade of the diamond polish. (Accepted values: Excellent, Very Good, Good, Fair, Poor)
                Symmetry = Utils.GetDescriptionFromEnumValue((Enum)diamond.Symmetry), //string - Grade of the diamond symmetry. (Accepted values: Excellent, Very Good, Good, Fair, Poor)

                TableWidthPercentage = diamond.TableWidthPercentage, //decimal - The width of the table expressed as a percentage of its average diameter.
                TableWidth = diamond.TableWidth, //decimal - Measurement of the table (in millimeters).

                DepthPercentage = diamond.DepthPercentage, //decimal - Percentage of ratio of the total depth of the diamond (from table to culet) as compared with the girdle diameter.

                LengthToWidthRatio = diamond.LengthToWidthRatio, //decimal - Percentage of ratio of the length of the diamond as compared to its width.

                Measurements = diamond.Measurements, //string - Measurements (length x width x height) of the diamond (in millimeters).

                Girdle = Utils.GetDescriptionFromEnumValue((Enum)diamond.Girdle), //string - Grade of the diamond girdle. (Accepted values: Extremely Thin, Very Thin, Thin, Slightly Thin, Medium, Slightly Thick, Thick, Very Thick, Extremely Thick)
                GirdleThickness = diamond.GirdleThickness, //decimal - Measurement of the girdle (in millimeters).
                GirdleDiameter = diamond.GirdleDiameter, //decimal - Average diameter of the diamond (in millimeters).
                GirdleToTableDistance = diamond.GirdleToTableDistance, //decimal - Horizontally projected distance from the edge of the table to the edge of the girdle (in millimeters).
                GirdleToCuletDistance = diamond.GirdleToCuletDistance, //decimal - Horizontally projected distance from the culet to the edge of the girdle (in millimeters).

                Culet = Utils.GetDescriptionFromEnumValue((Enum)diamond.Culet), //string - Grade of the diamond culet. (Accepted values: None, Very Small, Small, Medium, Slightly Large, Large, Extremely Large)
                CuletAngle = diamond.CuletAngle, //decimal - Measurement of the culet (in millimeters).

                CrownHeight = diamond.CrownHeight, //decimal - Measurement of the crown - from the top part of the girdle to table (in millimeters).
                CrownHeightPercentage = diamond.CrownHeightPercentage, //decimal - Percentage of ratio of the crown height as compared to the overall diamond height.
                CrownAngle = diamond.CrownAngle, //decimal - Angle of the crown facets in relationship to the girdle plane.

                PavilionDepth = diamond.PavilionDepth, //decimal - Measurement of the pavilion - from the bottom part of the girdle to culet (in millimeters).
                PavilionDepthPercentage = diamond.PavilionDepthPercentage, //decimal - 	Percentage of ratio of the pavilion depth as compared to the overall diamond height.
                PavilionAngle = diamond.PavilionAngle, //decimal - Angle of the pavilion facets in relationship to the girdle plane.

                StarLength = diamond.StarLength, //decimal - Horizontally projected distance from the point of the star facet to the edge of the table (in millimeters).
                StarLengthPercentage = diamond.StarLengthPercentage, //decimal - Length of the star facet expressed as a percentage of the girdle-to-table distance.

                LowerHalfLength = diamond.LowerHalfLength, //decimal - Horizontally projected distance from the point where two pavilion mains meet to the closest edge of the girdle (in millimeters).
                LowerHalfLengthPercentage = diamond.LowerHalfLengthPercentage, //decimal - Length of the lower half expressed as a percentage of the girdle-to-culet distance (in millimeters).

                ShippingDays = diamond.ShippingDays//decimal - Number of days needed to process the purchase order and ship the diamond to the customer.
            };
        }

        public async Task<List<APIResponse>> Create(IEnumerable<Diamond> diamonds)
        {
            var index = 0;
            var batchSize = 100;

            var result = new List<APIResponse>();

            while (index < diamonds.Count())
            {
                var batch = diamonds.Skip(index).Take(batchSize);
                if (batch.Count() > 0)
                {
                    var data = new List<dynamic>();

                    foreach (var item in diamonds)
                    {
                        data.Add(MapValues(item));
                    }

                    var json = JsonConvert.SerializeObject(data);

                    ByteArrayContent content = new ByteArrayContent(Encoding.UTF8.GetBytes(json));
                    content.Headers.ContentEncoding.Add("utf-8");
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var response = await HttpClient.PostAsync("/v1/diamonds", content);

                    result.Add(new APIResponse {
                        StatusCode = (int)response.StatusCode,
                        Content = await response.Content.ReadAsStringAsync()
                    });
                }
                index += batchSize;
            }

            return result;
        }
        public async Task<APIResponse> Get()
        {
            var response = await HttpClient.GetAsync("/v1/diamonds");
            return new APIResponse
            {
                StatusCode = (int)response.StatusCode,
                Content = await response.Content.ReadAsStringAsync()
            };
        }
        public async Task<APIResponse> DeleteAll()
        {
            var response = await HttpClient.DeleteAsync("/v1/diamonds");
            return new APIResponse
            {
                StatusCode = (int)response.StatusCode,
                Content = await response.Content.ReadAsStringAsync()
            };
        }
        public async Task<APIResponse> Delete(string id)
        {
            var response = await HttpClient.DeleteAsync($"/v1/diamonds/{id}");
            return new APIResponse
            {
                StatusCode = (int)response.StatusCode,
                Content = await response.Content.ReadAsStringAsync()
            };
        }

        public async Task<APIResponse> Update(string id, object data)
        {
            var json = JsonConvert.SerializeObject(data);
            ByteArrayContent content = new ByteArrayContent(Encoding.UTF8.GetBytes(json));
            content.Headers.ContentEncoding.Add("utf-8");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"/v1/diamonds/{id}")
            {
                Content = content
            };

            var response = await HttpClient.SendAsync(request);

            return new APIResponse
            {
                StatusCode = (int)response.StatusCode,
                Content = await response.Content.ReadAsStringAsync()
            };
        }
        public async Task<APIResponse> Update(Diamond diamond)
        {
            var data = MapValues(diamond);
            return await Update(diamond.Id, data);
        }
    }
    public interface IAPIService
    {
        Task<List<APIResponse>> Create(IEnumerable<Diamond> diamonds);
        Task<APIResponse> Get();
        Task<APIResponse> DeleteAll();
        Task<APIResponse> Delete(string id);
        Task<APIResponse> Update(string id, object data);
        Task<APIResponse> Update(Diamond diamond);
    }
}
