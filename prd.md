# Product Requirements Document (PRD)
## Project: CV Generator – Blazor WASM with Fluid/Liquid Templates

---

### 1. Overview
The CV Generator is a **single-page Blazor WebAssembly application** that allows users to input personal and professional information and generate a **live preview of a CV**. The app uses a **Liquid template** rendered with the **Fluid library** for dynamic, client-side HTML generation and provides an option to **download the CV as a PDF**.

---

### 2. Goals
- Collect user data (personal info, work experience, education, skills, etc.) via a form.
- Render a live CV preview using a **Liquid template** and **Fluid**.
- Allow download/export as **PDF**.
- Fully client-side for privacy; no server storage.

---

### 3. Non-Goals
- No user authentication.
- No cloud storage or sharing.
- No advanced PDF styling beyond basic template.

---

### 4. Target Users
- Job seekers who want a quick CV builder.
- Students and professionals creating simple resumes.
- Developers learning Blazor WASM and client-side templating.

---

### 5. Core Features
#### 5.1 Input Form
- Sections: Personal Info, Contact, Summary, Education, Work Experience, Skills, Languages.
- Each section editable via text inputs, textareas, and lists.
- Optional: character limits for certain fields.

#### 5.2 Live Preview
- **Fluid + Liquid template** renders the CV in real-time.
- Two-column layout: left form, right preview.
- Responsive design.

#### 5.3 Export Options
- Download rendered CV as **PDF**.
- Optional: export as HTML for further editing.

#### 5.4 Template Customization
- Predefined Liquid template with placeholders for all fields.
- Users can optionally switch templates (basic, modern, professional).

---

### 6. Technical Requirements
- **Framework:** Blazor WebAssembly (standalone).
- **Libraries:** Fluid (for Liquid template rendering), optional PDF library (e.g., jsPDF via JS interop).
- **JS Interop:** Required to generate PDF client-side.
- **Storage:** Optional: localStorage to save last CV state.
- **Hosting:** GitHub Pages or any static hosting.

---

### 7. Security
- All processing client-side; no data leaves browser.
- No third-party scripts beyond Fluid and PDF generation library.

---

### 8. User Interface
| Section | Description |
|---------|-------------|
| Header | App title "CV Generator" |
| Form | Sections for personal info, education, work, skills, etc. |
| CV Preview | Live rendered CV using Fluid/Liquid template |
| Footer | Buttons: Download PDF, Export HTML |

---

### 9. Success Metrics
- User can input data → live preview updates instantly.
- CV layout renders correctly with all entered fields.
- PDF download works and preserves formatting.
- Works offline after first load.

---

### 10. Example Flow
**Input:**
- Name: Antoine Griffard
- Email: antoine@example.com
- Education: BSc Computer Science, 2022
- Skills: C#, Blazor, JavaScript

**Output:**
- Live CV preview on screen.
- User clicks "Download PDF" → PDF generated with the CV content.

---

### 11. Future Enhancements
- Multiple CV templates (modern, professional, creative).
- Add profile photo upload.
- Support for multiple languages.
- Export to DOCX or Markdown.
- Shareable link (client-side encoded state).

