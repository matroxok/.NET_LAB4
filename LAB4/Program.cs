using LAB4.Components;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.Extensions.ML;

namespace LAB4;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();
        
        // certyfikat https inicjalizacja
        builder.Services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme).AddCertificate();

        // MODEL AI
        builder.Services.AddPredictionEnginePool<SentimentData, SentimentPrediction>()
            .FromFile(
                "SentimentModel",
                "ML/sentiment-model.zip",
                true);
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();
        
        // wymuszenie użycia wczesniej dodanego certyfiaktu
        app.UseAuthentication();
        app.UseAuthorization();

        // AI train - tylko raz przy 1 starcie
        // SentimentModelTrainer.Train();
        
        app.Run();
    }
}