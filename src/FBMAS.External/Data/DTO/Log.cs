using System;

namespace FBMAS.External.Data.DTO;

public class Log
{
    public int Id { get; set; }
    public DateTime Time { get; set; }
    public required string Message { get; set; }
}
