using System;
using FBMAS.Utilities.Enums;

namespace FBMAS.External.Data.DTO;

public class UserConfiguration
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public NotifyBy NotifyBy { get; set; }
}
