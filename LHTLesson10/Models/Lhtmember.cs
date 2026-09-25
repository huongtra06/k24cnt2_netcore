using System;
using System.Collections.Generic;

namespace LHTLesson10EFDBFirst.Models;

public partial class Lhtmember
{
    public long Id { get; set; }

    public string? Lhtusername { get; set; }

    public string? Lhtpassword { get; set; }

    public string? Lhtemail { get; set; }

    public string? Lhtphone { get; set; }

    public bool? Lhtstatus { get; set; }
}
