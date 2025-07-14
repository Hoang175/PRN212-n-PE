using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Researcher
{
    public int ResearcherId { get; set; }

    public string FullName { get; set; }

    public string Affiliation { get; set; }

    public string Email { get; set; }

    public string Expertise { get; set; }

    public virtual ICollection<ResearchProject> ResearchProjects { get; set; } = new List<ResearchProject>();
}
