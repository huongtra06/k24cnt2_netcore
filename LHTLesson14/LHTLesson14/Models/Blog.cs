namespace LHTLesson14.Models;
public class Blog { public int Id { get; set; } public string Name { get; set; } = ""; public byte Status { get; set; } = 1; public DateTime CreatedDate { get; set; } = DateTime.Today; public string? Image { get; set; } public string? Description { get; set; } }
