using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using OpenXML.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenXML.Entities
{
    public class WordResumeBuilder : IResumeBuilder
    {
        private Resume _resume;
        private WordprocessingDocument _document;

        public WordResumeBuilder()
        {
            _resume = new Resume();
        }

        public void BuildEducationExperience(EducationExperience educationExperience)
        {
            _resume.educationExperience.Add(educationExperience);
        }

        public void BuildProfileSummary(string profileSummary)
        {
            _resume.profileSummary = profileSummary;
        }

        public void BuildWorkExperience(WorkExperience workExperience)
        {
            _resume.workExperiences.Add(workExperience);
        }

        public void Save(string filePath)
        {
            _document = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document);
            MainDocumentPart mainPart = _document.AddMainDocumentPart();
            mainPart.Document = new Document();
            Body body = mainPart.Document.AppendChild(new Body());

            // Add profile summary
            AddHeading2WithUnderline(body, "Profile Summary");
            body.AppendChild(new Paragraph(new Run(new Text(_resume.profileSummary))));

            // Add work experience
            AddHeading2WithUnderline(body, "Work Experience");
            foreach (var workExperience in _resume.workExperiences)
            {
                AddWorkExperience(body, workExperience);
            }

            // Add education experience
            AddHeading2WithUnderline(body, "Education Experience");
            foreach (var educationExperience in _resume.educationExperience)
            {
                AddEducationExperience(body, educationExperience);
            }

            _document.Save();

        }

        private void AddHeading2WithUnderline(Body body, string text)
        {
            Paragraph paragraph = body.AppendChild(new Paragraph());
            paragraph.AppendChild(new ParagraphProperties(new ParagraphStyleId() { Val = "Heading2" }));
            Run run = paragraph.AppendChild(new Run());
            run.AppendChild(new RunFonts() { Ascii = "Calibri" });
            run.AppendChild(new FontSize() { Val = "24" });
            run.AppendChild(new RunProperties(new Header()));
            run.AppendChild(new RunProperties(new Bold()));
            run.AppendChild(new RunProperties(new Underline() { Val = UnderlineValues.Single }));
            run.AppendChild(new Text(text));
        }

        private void AddBoldText(Body body, string text)
        {
            Paragraph paragraph = body.AppendChild(new Paragraph());
            Run run = paragraph.AppendChild(new Run());
            run.AppendChild(new RunProperties(new Bold()));
            run.AppendChild(new Text(text));
        }

        private void AddWorkExperience(Body body,WorkExperience workExperience)
        {
            AddBoldText(body, "Designation: ");
            body.AppendChild(new Paragraph(new Run(new Text(workExperience.Title))));

            AddBoldText(body, "Company: ");
            body.AppendChild(new Paragraph(new Run(new Text(workExperience.Company))));

            AddBoldText(body, "Duration: ");
            body.AppendChild(new Paragraph(new Run(new Text(workExperience.Duration))));

            AddBoldText(body, "Description: ");
            body.AppendChild(new Paragraph(new Run(new Text(workExperience.Description))));
        }

        private void AddEducationExperience(Body body, EducationExperience educationExperience)
        {
            AddBoldText(body, "Degree: ");
            body.AppendChild(new Paragraph(new Run(new Text(educationExperience.Degree))));

            AddBoldText(body, "Institution: ");
            body.AppendChild(new Paragraph(new Run(new Text(educationExperience.Institution))));

            AddBoldText(body, "Year: ");
            body.AppendChild(new Paragraph(new Run(new Text(educationExperience.Year))));
        }
    }
}
