using Microsoft.ML.Data;

namespace LAB4;

public class SentimentData
{
    [LoadColumn(1)] public string Text { get; set; } = string.Empty;

    [LoadColumn(3)] public string Sentiment { get; set; } = string.Empty;
}

public class SentimentPrediction
{
    [ColumnName("PredictedLabel")] public string PredictedSentiment { get; set; } = string.Empty;

    public float[] Score { get; set; } = Array.Empty<float>();
}