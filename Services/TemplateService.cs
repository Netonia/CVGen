using CVGen.Models;
using Fluid;

namespace CVGen.Services;

public class TemplateService
{
    private readonly FluidParser _parser;
    private readonly TemplateContext _context;
    private readonly HttpClient _httpClient;

    public TemplateService(HttpClient httpClient)
    {
        _parser = new FluidParser();
        _context = new TemplateContext();
        _httpClient = httpClient;
        _context.Options.MemberAccessStrategy.Register<CVData>();
        _context.Options.MemberAccessStrategy.Register<PersonalInfo>();
        _context.Options.MemberAccessStrategy.Register<Education>();
        _context.Options.MemberAccessStrategy.Register<WorkExperience>();
        _context.Options.MemberAccessStrategy.Register<Language>();
    }

    public async Task<string> RenderCVAsync(CVData cvData, string template)
    {
        if (!_parser.TryParse(template, out var parsedTemplate, out var error))
        {
            return $"Template Error: {error}";
        }

        _context.SetValue("cv", cvData);
        return await parsedTemplate.RenderAsync(_context);
    }

    public async Task<string> GetDefaultTemplateAsync()
    {
            return await _httpClient.GetStringAsync("templates/default-cv-template.html");
    }
}
