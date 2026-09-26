namespace LHT2410900076_exam.Models;

public partial class LHTEmployee
{
    public int Id { get; set; }

    public string LHTName { get; set; } = null!;

    public string? LHTGender { get; set; }

    public DateTime? LHTBirthDay { get; set; }

    public string? LHTEmail { get; set; }

    public string? LHTPhone { get; set; }

    public bool LHTActive { get; set; }
}
