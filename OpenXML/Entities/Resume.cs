using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenXML.Entities
{
    public class Resume
    {
        public string profileSummary { get; set; }

        public List<WorkExperience> workExperiences { get; set; }

        public List<EducationExperience> educationExperience { get; set; }

        public Resume()
        {
            workExperiences = new List<WorkExperience>();
            educationExperience = new List<EducationExperience>();
        }
    }
}
