using System.Text.Json.Serialization;

namespace GenerateImagesAPI.Models;

public class GenerateImage
{
    public GenerateImage(){}
    
    [JsonConstructor]
    public GenerateImage(string status, string tip, double generationTime, int id, List<string> output,
        List<string> proxyLinks, string nsfwContentDetected, Meta meta)
    {
        Status = status;
        Tip = tip;
        GenerationTime = generationTime;
        Id = id;
        Output = output;
        ProxyLinks = proxyLinks;
        NsfwContentDetected = nsfwContentDetected;
        Meta = meta;
    }

    public string Status { get; set; }
    public string Tip { get; set; }
    public double GenerationTime { get; set; }
    public int Id { get; set; }
    public List<string> Output { get; set; }
    public List<string> ProxyLinks { get; set; }
    public string NsfwContentDetected { get; set; }
    public Meta Meta { get; set; }
}