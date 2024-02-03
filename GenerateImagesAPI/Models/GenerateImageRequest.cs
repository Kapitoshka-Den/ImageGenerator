using System.Text.Json.Serialization;

namespace GenerateImagesAPI.Models;

public class GenerateImageRequest
{
    
    public GenerateImageRequest(){}
    
    [JsonConstructor]
    public GenerateImageRequest(string key, string prompt, string negativePrompt, string width, string height,
        string samples, string numInferenceSteps, string safetyChecker, string enhancePrompt, string temp, object seed,
        double guidanceScale, object webhook, object trackId)
    {
        Key = key;
        Prompt = prompt;
        NegativePrompt = negativePrompt;
        Width = width;
        Height = height;
        Samples = samples;
        NumInferenceSteps = numInferenceSteps;
        SafetyChecker = safetyChecker;
        EnhancePrompt = enhancePrompt;
        Temp = temp;
        Seed = seed;
        GuidanceScale = guidanceScale;
        Webhook = webhook;
        TrackId = trackId;
    }

    public string Key { get; set; }
    public string? Prompt { get; set; }
    public string? NegativePrompt { get; set; }
    public string Width { get; set; } = "512";
    public string Height { get; set; } = "512";
    public string Samples { get; set; } = "1";
    public string? NumInferenceSteps { get; set; }
    public string SafetyChecker { get; set; }
    public string EnhancePrompt { get; set; }
    public string Temp { get; set; }
    public object Seed { get; set; }
    public double GuidanceScale { get; set; }
    public object Webhook { get; set; }
    public object TrackId { get; set; }
}