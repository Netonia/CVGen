namespace CVGen.Models;

public class CVData
{
    public PersonalInfo PersonalInfo { get; set; } = new();
    public string Summary { get; set; } = string.Empty;
    public List<Education> Education { get; set; } = new();
    public List<WorkExperience> WorkExperience { get; set; } = new();
    public List<string> Skills { get; set; } = new();
    public List<Language> Languages { get; set; } = new();
}

public class PersonalInfo
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string LinkedIn { get; set; } = string.Empty;
    public string GitHub { get; set; } = string.Empty;
}

public class Education
{
    public string Degree { get; set; } = string.Empty;
    public string Institution { get; set; } = string.Empty;
    public string Year { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class WorkExperience
{
    public string Position { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public string StartDate { get; set; } = string.Empty;
    public string EndDate { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class Language
{
    public string Name { get; set; } = string.Empty;
    public string Proficiency { get; set; } = string.Empty;
}
