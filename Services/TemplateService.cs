using Fluid;
using Fluid.Values;
using CVGen.Models;

namespace CVGen.Services;

public class TemplateService
{
    private readonly FluidParser _parser;
    private readonly TemplateContext _context;

    public TemplateService()
    {
        _parser = new FluidParser();
        _context = new TemplateContext();
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

    public string GetDefaultTemplate()
    {
        return @"<!DOCTYPE html>
<html>
<head>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            line-height: 1.6;
            color: #333;
            margin: 0 auto;
            padding: 20px;
            background-color: #f5f5f5;
        }
        .cv-container {
            background-color: white;
            padding: 40px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }
        h1 {
            color: #2c3e50;
            border-bottom: 3px solid #3498db;
            padding-bottom: 10px;
            margin-top: 0;
        }
        h2 {
            color: #3498db;
            border-bottom: 2px solid #ecf0f1;
            padding-bottom: 5px;
            margin-top: 30px;
        }
        .contact-info {
            margin-bottom: 20px;
        }
        .contact-info p {
            margin: 5px 0;
        }
        .section {
            margin-bottom: 20px;
        }
        .item {
            margin-bottom: 15px;
        }
        .item-header {
            font-weight: bold;
            color: #2c3e50;
        }
        .item-subheader {
            color: #7f8c8d;
            font-style: italic;
        }
        .skills-list {
            display: flex;
            flex-wrap: wrap;
            gap: 10px;
        }
        .skill-tag {
            background-color: #3498db;
            color: white;
            padding: 5px 15px;
            border-radius: 20px;
            font-size: 14px;
        }
        .language-item {
            display: inline-block;
            margin-right: 20px;
        }
    </style>
</head>
<body>
    <div class='cv-container'>
        <h1>{{ cv.PersonalInfo.Name }}</h1>
        
        <div class='contact-info'>
            {% if cv.PersonalInfo.Email != '' %}
            <p><strong>Email:</strong> {{ cv.PersonalInfo.Email }}</p>
            {% endif %}
            {% if cv.PersonalInfo.Phone != '' %}
            <p><strong>Phone:</strong> {{ cv.PersonalInfo.Phone }}</p>
            {% endif %}
            {% if cv.PersonalInfo.Location != '' %}
            <p><strong>Location:</strong> {{ cv.PersonalInfo.Location }}</p>
            {% endif %}
            {% if cv.PersonalInfo.LinkedIn != '' %}
            <p><strong>LinkedIn:</strong> {{ cv.PersonalInfo.LinkedIn }}</p>
            {% endif %}
            {% if cv.PersonalInfo.GitHub != '' %}
            <p><strong>GitHub:</strong> {{ cv.PersonalInfo.GitHub }}</p>
            {% endif %}
        </div>

        {% if cv.Summary != '' %}
        <div class='section'>
            <h2>Professional Summary</h2>
            <p>{{ cv.Summary }}</p>
        </div>
        {% endif %}

        {% if cv.WorkExperience.size > 0 %}
        <div class='section'>
            <h2>Work Experience</h2>
            {% for work in cv.WorkExperience %}
            <div class='item'>
                <div class='item-header'>{{ work.Position }} - {{ work.Company }}</div>
                <div class='item-subheader'>{{ work.StartDate }} - {{ work.EndDate }}</div>
                {% if work.Description != '' %}
                <p>{{ work.Description }}</p>
                {% endif %}
            </div>
            {% endfor %}
        </div>
        {% endif %}

        {% if cv.Education.size > 0 %}
        <div class='section'>
            <h2>Education</h2>
            {% for edu in cv.Education %}
            <div class='item'>
                <div class='item-header'>{{ edu.Degree }}</div>
                <div class='item-subheader'>{{ edu.Institution }} - {{ edu.Year }}</div>
                {% if edu.Description != '' %}
                <p>{{ edu.Description }}</p>
                {% endif %}
            </div>
            {% endfor %}
        </div>
        {% endif %}

        {% if cv.Skills.size > 0 %}
        <div class='section'>
            <h2>Skills</h2>
            <div class='skills-list'>
            {% for skill in cv.Skills %}
                <span class='skill-tag'>{{ skill }}</span>
            {% endfor %}
            </div>
        </div>
        {% endif %}

        {% if cv.Languages.size > 0 %}
        <div class='section'>
            <h2>Languages</h2>
            {% for lang in cv.Languages %}
            <span class='language-item'><strong>{{ lang.Name }}:</strong> {{ lang.Proficiency }}</span>
            {% endfor %}
        </div>
        {% endif %}
    </div>
</body>
</html>";
    }
}
