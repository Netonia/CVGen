# CV Generator

A modern, client-side CV (resume) generator built with Blazor WebAssembly and Fluid/Liquid templating.

## Features

- ✨ **Live Preview**: Real-time CV rendering as you type
- 📝 **Comprehensive Sections**: Personal info, summary, work experience, education, skills, and languages
- 🎨 **Professional Template**: Clean, styled CV layout using Liquid templates
- 📄 **PDF Export**: Download your CV as a PDF with one click
- 💾 **HTML Export**: Export your CV as standalone HTML
- 🔒 **Privacy First**: All processing happens client-side; no data leaves your browser
- 📱 **Responsive Design**: Works on desktop and mobile devices

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later

### Running Locally

1. Clone the repository:
```bash
git clone https://github.com/Netonia/CVGen.git
cd CVGen
```

2. Run the application:
```bash
dotnet run
```

3. Open your browser and navigate to `http://localhost:5062`

### Building for Production

```bash
dotnet publish -c Release
```

The published files will be in `bin/Release/net9.0/publish/wwwroot/` and can be hosted on any static web hosting service (GitHub Pages, Netlify, Azure Static Web Apps, etc.).

## Usage

1. **Fill in your information**: Use the form on the left to enter your personal details, work experience, education, skills, and languages
2. **See live preview**: The CV preview on the right updates automatically as you type
3. **Download PDF**: Click "Download PDF" to save your CV as a PDF file
4. **Export HTML**: Click "Export HTML" to download your CV as a standalone HTML file

## Technology Stack

- **Framework**: Blazor WebAssembly (.NET 9)
- **Template Engine**: Fluid.Core (Liquid templates)
- **PDF Generation**: html2pdf.js (via JavaScript interop)
- **Styling**: Custom CSS with Bootstrap components

## Project Structure

```
CVGen/
├── Models/           # Data models (CVData, PersonalInfo, Education, etc.)
├── Services/         # Template rendering service using Fluid
├── Pages/            # Blazor pages (Home.razor with CV form and preview)
├── Layout/           # Application layout components
├── wwwroot/          # Static files (CSS, JavaScript, images)
│   └── js/           # JavaScript interop for PDF/HTML export
└── Program.cs        # Application entry point
```

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is open source and available under the [MIT License](LICENSE).