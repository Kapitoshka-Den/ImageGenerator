namespace GenerateImagesAPI.Models;

public class Meta
{
    public Meta(int h, int w, string enableAttentionSlicing, string filePrefix, double guidanceScale,
        string instantResponse, string model, int nSamples, string negativePrompt, string outdir, string prompt,
        string revision, string safetychecker, long seed, int steps, string temp, string vae)
    {
        H = h;
        W = w;
        EnableAttentionSlicing = enableAttentionSlicing;
        FilePrefix = filePrefix;
        GuidanceScale = guidanceScale;
        InstantResponse = instantResponse;
        Model = model;
        NSamples = nSamples;
        NegativePrompt = negativePrompt;
        Outdir = outdir;
        Prompt = prompt;
        Revision = revision;
        Safetychecker = safetychecker;
        Seed = seed;
        Steps = steps;
        Temp = temp;
        Vae = vae;
    }

    public int H { get; set; }
    public int W { get; set; }
    public string EnableAttentionSlicing { get; set; }
    public string FilePrefix { get; set; }
    public double GuidanceScale { get; set; }
    public string InstantResponse { get; set; }
    public string Model { get; set; }
    public int NSamples { get; set; }
    public string NegativePrompt { get; set; }
    public string Outdir { get; set; }
    public string Prompt { get; set; }
    public string Revision { get; set; }
    public string Safetychecker { get; set; }
    public long Seed { get; set; }
    public int Steps { get; set; }
    public string Temp { get; set; }
    public string Vae { get; set; }
}