﻿using System;
using System.Collections.Generic;

namespace Q2_SU24_B5.Models;

public partial class Project
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly? StartDate { get; set; }

    public string? Type { get; set; }

    public int? Department { get; set; }

    public virtual Department? DepartmentNavigation { get; set; }
}
