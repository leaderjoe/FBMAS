using System;

namespace FBMAS.External.Data.DTO;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? PhoneNumber { get; set; }
    public string? Email { get; set; }
}
