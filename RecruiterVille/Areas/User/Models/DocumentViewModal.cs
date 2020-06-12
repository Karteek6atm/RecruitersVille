using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecruiterVille.Areas.User.Models
{
    public class DocumentViewModal
    {
        /// <summary>
        /// Gets or sets the objective.
        /// </summary>
        /// <value>
        /// The objective.
        /// </value>
        public IList<string> Objective { get; set; }
        /// <summary>
        /// Gets or sets the experience summary.
        /// </summary>
        /// <value>
        /// The experience summary.
        /// </value>
        public IList<string> ExperienceSummary { get; set; }
        /// <summary>
        /// Gets or sets the certification.
        /// </summary>
        /// <value>
        /// The certification.
        /// </value> 
        public IList<string> Certification { get; set; }
        /// <summary>
        /// Gets or sets the education.
        /// </summary>
        /// <value>
        /// The education.
        /// </value>
        public IList<string> Education { get; set; }
        /// <summary>
        /// Gets or sets the technical skills.
        /// </summary>
        /// <value>
        /// The technical skills.
        /// </value>
        public IList<string> Skill { get; set; }
        /// <summary>
        /// Gets or sets the projects.
        /// </summary>
        /// <value>
        /// The projects.
        /// </value>
        public IList<string> ProjectExperience { get; set; }
        /// <summary>
        /// Gets or sets the achievement.
        /// </summary>
        /// <value>
        /// The achievement.
        /// </value>
        public IList<string> Achievement { get; set; }
        /// <summary>
        /// Gets or sets the links.
        /// </summary>
        /// <value>
        /// The links.
        /// </value>
        public IList<string> Handle { get; set; }

        /// <summary>
        /// Gets or sets the declaration.
        /// </summary>
        /// <value>
        /// The declaration.
        /// </value>
        public IList<string> Declaration { get; set; }

        /// <summary>
        /// Gets or sets the personal.
        /// </summary>
        /// <value>
        /// The personal.
        /// </value>
        public IList<string> Personal { get; set; }

        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        /// <value>
        /// The Email.
        /// </value>
        public IList<string> Email { get; set; }
    }

    public class JobRequestModal
    {
        public int UserLoginId { get; set; }
        public int CompanyId { get; set; }
        public int JobId { get; set; }
        public string strJobId { get; set; }
        public int JobTemplateId { get; set; }
        public string strJobTemplateId { get; set; }
        public string CompanyJobId { get; set; }
        public string JobTitle { get; set; }
        public string JobLocation { get; set; }
        public bool IsJobTemplate { get; set; }
        public string TemplateName { get; set; }
        public int PayType { get; set; }
        public int PayCurrency { get; set; }
        public int MinPayRate { get; set; }
        public int MaxPayRate { get; set; }
        public int JobDurationType { get; set; }
        public int JobDuration { get; set; }
        public int MinExp { get; set; }
        public int MaxExp { get; set; }
        public int TravelAllowanceType { get; set; }
        public int TravelAllowances { get; set; }
        public bool IsWFHAvailable { get; set; }

        [AllowHtml]
        public string JobDescription { get; set; }
        public int ApplicationMethodType { get; set; }
        public string PostFromDate { get; set; }
        public string PostToDate { get; set; }
        public int IndustryId { get; set; }
        public string ApplicationToEmailId { get; set; }
        public string ApplicationCcEmailId { get; set; }
        public string ApplicationURL { get; set; }
        public string SkillIds { get; set; }
        public string SubIndustryIds { get; set; }
        public string JobTypeIds { get; set; }
        public int JobStatus { get; set; }
    }
}
