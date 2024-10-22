using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Models;

namespace WineApp.Services
{
    public static class ApiKeys
    {
        public static string CustomVisionEndPoint => "https://fvrbigfive-prediction.cognitiveservices.azure.com";
        public static string PredictionKey => "2b3ee4bba41b4a0198ee802a27511728";
        public static string ProjectId => "dc5e0d66-71db-4807-aabe-8adb59700646";
        public static string PublishedName => "BigFiveModel";
    }

    public class CustomVisionService
    {
        public static async Task<PredictionModel?> ClassifyImageAsync(Stream photoStream)
        {
            try
            {
                var endpoint = new CustomVisionPredictionClient(new ApiKeyServiceClientCredentials(ApiKeys.PredictionKey))
                {
                    Endpoint = ApiKeys.CustomVisionEndPoint
                };

                // Send image to the Custom Vision API
                var results = await endpoint.ClassifyImageAsync(Guid.Parse(ApiKeys.ProjectId), ApiKeys.PublishedName, photoStream);

                // Return the most likely prediction
                return results.Predictions?.OrderByDescending(x => x.Probability).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new PredictionModel();
            }
        }
    }
}
