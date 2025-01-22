using System;

namespace FBMAS.External.Data.DTO;

public class SearchCriteria
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string SearchQuery { get; set; }
}
