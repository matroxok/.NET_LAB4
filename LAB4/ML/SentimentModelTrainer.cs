using Microsoft.ML;

namespace LAB4;

public static class SentimentModelTrainer
{
    public static void Train()
    {
        var mlContext = new MLContext();

        var dataPath = Path.Combine("Data", "train.csv");
        var modelPath = Path.Combine("ML", "sentiment-model.zip");

        var data = mlContext.Data.LoadFromTextFile<SentimentData>(
            dataPath,
            hasHeader: true,
            separatorChar: ',',
            allowQuoting: true,
            allowSparse: false);

        var pipeline = mlContext.Transforms.Conversion.MapValueToKey(
                "Label",
                nameof(SentimentData.Sentiment))
            .Append(mlContext.Transforms.Text.FeaturizeText(
                "Features",
                nameof(SentimentData.Text)))
            .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy())
            .Append(mlContext.Transforms.Conversion.MapKeyToValue(
                "PredictedLabel"));

        var model = pipeline.Fit(data);

        Directory.CreateDirectory("ML");

        mlContext.Model.Save(model, data.Schema, modelPath);
    }
}