using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class UserAccount
{
    public int UserId { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public int? Role { get; set; }

    public DateTime? CreatedDate { get; set; }
}
