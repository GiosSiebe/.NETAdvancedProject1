﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Models;

namespace WineApp.Services
{
    public static class ApiKeys
    {
        public static string CustomVisionEndPoint => "https://sgproject-prediction.cognitiveservices.azure.com/";
        public static string PredictionKey => "47205d705ef14e2394d7ba5790a39836";
        public static string ProjectId => "a2ff5e6d-9464-4242-b2c8-d841c56e7ccb";
        public static string PublishedName => "Project1";
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
