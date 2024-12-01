namespace PMI.Hospital.Shared.Common;

/// <summary>
/// Result from page query.
/// </summary>
/// <typeparam name="TItem">The type of collection item for page.</typeparam>
public sealed class PageResult<TItem>
{
    /// <summary>
    /// Gets the result value.
    /// </summary>
    public ICollection<TItem> Value { get; }

    /// <summary>
    /// Gets the page number.
    /// </summary>
    public int PageNumber { get; }

    /// <summary>
    /// Gets converts to total items.
    /// </summary>
    public int TotalItems { get; }

    /// <summary>
    /// Gets total pages in source.
    /// </summary>
    public int TotalPages { get; }

    /// <summary>
    /// Gets count of elements for one page.
    /// </summary>
    public int PageSize { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PageResult{TItem}"/> class.
    /// </summary>
    public PageResult()
    {
        Value = new List<TItem>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PageResult{T}" /> class.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="pageNumber">The page number.</param>
    /// <param name="totalPages">The total pages.</param>
    /// <param name="totalItems">The total items.</param>
    /// <param name="pageSize">The count of elements for one page.</param>
    public PageResult(
        ICollection<TItem> value,
        int pageNumber,
        int totalPages,
        int totalItems,
        int pageSize)
    {
        Value = value;
        TotalPages = totalPages;
        PageNumber = pageNumber;
        TotalItems = totalItems;
        PageSize = pageSize;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PageResult{TItem}"/> class.
    /// </summary>
    /// <param name="items"><see cref="IEnumerable{TItem}"/>.</param>
    /// <param name="pageNumber">Number of page.</param>
    /// <param name="totalPages">Total pages.</param>
    /// <param name="totalItems">Total items.</param>
    /// <param name="pageSize">Page size.</param>
    public PageResult(
        IEnumerable<TItem> items,
        int pageNumber,
        int totalPages,
        int totalItems,
        int pageSize)
    {
        TotalPages = totalPages;
        PageNumber = pageNumber;
        TotalItems = totalItems;
        PageSize = pageSize;
        Value = items.ToList();
    }
}