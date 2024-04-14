using OpenXML.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenXML.Interfaces
{
    public interface IResumeBuilder
    {
        void BuildProfileSummary(string profileSummary);
        void BuildWorkExperience(WorkExperience workExperience);
        void BuildEducationExperience(EducationExperience educationExperience);
        void Save(string filePath);
    }
}
