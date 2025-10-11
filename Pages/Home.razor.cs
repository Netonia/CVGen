using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using CVGen.Models;
using CVGen.Services;

namespace CVGen.Pages;

public partial class Home : ComponentBase
{
    [Inject]
    public IJSRuntime JSRuntime { get; set; } = default!;

    [Inject]
    public TemplateService TemplateService { get; set; } = default!;

    private CVData cvData = new();
    private string renderedCV = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        LoadSampleData();
        await RenderCV();
    }

    private async Task OnInputChanged()
    {
        await RenderCV();
    }

    private void LoadSampleData()
    {
        cvData.PersonalInfo.Name = "Antoine Griffard";
        cvData.PersonalInfo.Email = "agriffard@hotmail.com";
        cvData.PersonalInfo.Phone = "+1 234 567 8900";
        cvData.PersonalInfo.Location = "San Francisco, CA";
        cvData.PersonalInfo.LinkedIn = "https://www.linkedin.com/in/agriffard";
        cvData.PersonalInfo.GitHub = "https://github.com/agriffard";

        cvData.Summary = "Experienced software developer with expertise in full-stack development, cloud technologies, and modern web frameworks.";

        cvData.Education.Add(new Education
        {
            Degree = "BSc Computer Science",
            Institution = "University of Technology",
            Year = "2022",
            Description = "Graduated with honors, specializing in software engineering and web technologies."
        });

        cvData.WorkExperience.Add(new WorkExperience
        {
            Position = "Software Developer",
            Company = "Tech Corp",
            StartDate = "Jan 2022",
            EndDate = "Present",
            Description = "Developing full-stack web applications using modern technologies and best practices."
        });

        cvData.Skills.AddRange(new[] { "C#", "Blazor", "JavaScript", "React", "SQL", "Azure" });

        cvData.Languages.Add(new Language { Name = "English", Proficiency = "Native" });
        cvData.Languages.Add(new Language { Name = "French", Proficiency = "Fluent" });
    }

    private async Task RenderCV()
    {
        var template = await TemplateService.GetDefaultTemplateAsync();
        renderedCV = await TemplateService.RenderCVAsync(cvData, template);
        StateHasChanged();
    }

    private async Task AddWorkExperience()
    {
        cvData.WorkExperience.Add(new WorkExperience());
        await RenderCV();
    }

    private async Task RemoveWorkExperience(int index)
    {
        cvData.WorkExperience.RemoveAt(index);
        await RenderCV();
    }

    private async Task AddEducation()
    {
        cvData.Education.Add(new Education());
        await RenderCV();
    }

    private async Task RemoveEducation(int index)
    {
        cvData.Education.RemoveAt(index);
        await RenderCV();
    }

    private async Task AddSkill()
    {
        cvData.Skills.Add(string.Empty);
        await RenderCV();
    }

    private async Task RemoveSkill(int index)
    {
        cvData.Skills.RemoveAt(index);
        await RenderCV();
    }

    private async Task AddLanguage()
    {
        cvData.Languages.Add(new Language());
        await RenderCV();
    }

    private async Task RemoveLanguage(int index)
    {
        cvData.Languages.RemoveAt(index);
        await RenderCV();
    }

    private async Task DownloadPdf()
    {
        var filename = $"{cvData.PersonalInfo.Name.Replace(" ", "_")}_CV.pdf";
        if (string.IsNullOrWhiteSpace(cvData.PersonalInfo.Name))
            filename = "CV.pdf";
        
        await JSRuntime.InvokeVoidAsync("pdfExport.downloadPdf", "cv-preview", filename);
    }

    private async Task DownloadHtml()
    {
        var filename = $"{cvData.PersonalInfo.Name.Replace(" ", "_")}_CV.html";
        if (string.IsNullOrWhiteSpace(cvData.PersonalInfo.Name))
            filename = "CV.html";
        
        await JSRuntime.InvokeVoidAsync("pdfExport.downloadHtml", renderedCV, filename);
    }
}