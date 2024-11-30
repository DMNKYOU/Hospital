using Newtonsoft.Json;

namespace PMI.Hospital.Shared.Contracts;

/// <summary>
/// The paged request.
/// <summary>
public class PagedRequest
{
    /// <summary>
    /// Gets or sets the count element for one page.
    /// <summary>
    [JsonProperty(PropertyName = "pageSize")]
    public int? PageSize { get; set; }

    /// <summary>
    ///  Gets or sets the page number.
    /// <summary>
    [JsonProperty(PropertyName = "pageNumber")]
    public int? PageNumber { get; set; }

    /// <summary>
    //  Gets or sets the search term for paged request.
    /// <summary>
    [JsonProperty(PropertyName = "searchTerm")]
    public string SearchTerm { get; set; }


    /// <summary>
    //   Gets or sets the sort.
    /// <summary>
    [JsonProperty(PropertyName = "sortBy")]
    public string SortBy { get; set; }
}