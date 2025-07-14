using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class ResearchProject
{
    public int ProjectId { get; set; }

    public string ProjectTitle { get; set; }

    public string ResearchField { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public int? LeadResearcherId { get; set; }

    public decimal Budget { get; set; }

    public virtual Researcher LeadResearcher { get; set; }
}
