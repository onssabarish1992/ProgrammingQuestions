

// Create resume builder
using OpenXML.Entities;
using OpenXML.Interfaces;

// Create resume builder
IResumeBuilder resumeBuilder = new WordResumeBuilder();

// Build resume content
resumeBuilder.BuildProfileSummary("Skilled and results-driven full-stack Microsoft Dot net developer with 9 years of experience in all phases of software development life cycle (SDLC).");

// Add work experience
resumeBuilder.BuildWorkExperience(new WorkExperience
{
    Title = "Technical Lead",
    Company = "GEP Solutions Private Limited",
    Duration = "2023-2024",
    Description = "Developed and executed a comprehensive master data management platform that uses Microsoft Azure, ASP.NET Core, JavaScript, SQL and NoSQL to create richer, faster, and actionable insights for a 2 customers."
});
resumeBuilder.BuildWorkExperience(new WorkExperience
{
    Title = "Senior Software Engineer",
    Company = "Abtran Limited",
    Duration = "2022 - 2023",
    Description = "Introduced 3 new features and enhanced the existing features using technologies like C#, ASP.NET MVC, SQL Server, and Microsoft Azure."
});
resumeBuilder.BuildWorkExperience(new WorkExperience
{
    Title = "Senior Software Engineer",
    Company = "GEP Solutions Private Limited",
    Duration = "2020 - 2021",
    Description = "Lead the initiative to migrate the existing SQL server database to the NoSQL database, i.e., MongoDB as a part of the product development strategy."
});
resumeBuilder.BuildWorkExperience(new WorkExperience
{
    Title = "Application Development Senior Analyst",
    Company = "Accenture Solutions Private Limited",
    Duration = "2018-2020",
    Description = "Designed and implemented 3 major requirements using ASP.NET Webforms, VB.NET, SQL Server and JavaScript."
});
resumeBuilder.BuildWorkExperience(new WorkExperience
{
    Title = "Senior Software Engineer",
    Company = "Persistent Systems Limited",
    Duration = "2014-2018",
    Description = "Designed and developed abstract classes, interfaces, and classes to construct the business logic using C# with OOPS implementation."
});
// Add education experience
resumeBuilder.BuildEducationExperience(new EducationExperience
{
    Degree = "Master of Science,Business Information and Analytical Systems",
    Institution = "University College Cork",
    Year = "2021-2022"
});
resumeBuilder.BuildEducationExperience(new EducationExperience
{
    Degree = "Bachelor of Engineering",
    Institution = "Bharati Vidyapeeth College of Engineering",
    Year = "2010 - 2014"
});

// Save resume to file
string filePath = "E:\\Companies\\PMG\\Ireland2ndInnings\\Dot Net Developer\\Resume.docx";
resumeBuilder.Save(filePath);

Console.WriteLine("Resume saved to: " + filePath);

Console.ReadKey();



