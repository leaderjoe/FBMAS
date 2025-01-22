using System;

namespace FBMAS.External.Data.DTO;

public class Item
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public int UserId { get; set; }
    public required string Url { get; set; }
    public int MatchingSearchCriteriaId { get; set; }

}
