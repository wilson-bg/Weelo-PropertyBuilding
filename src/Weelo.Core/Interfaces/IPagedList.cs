using System.Collections.Generic;

namespace Weelo.Core.Interfaces
{

    /// <summary>
    /// Interface for paging list
    /// </summary>
    /// <typeparam name="T">Any type</typeparam>
    /// <seealso cref="System.Collections.Generic.IList{T}" />
    public interface IPagedList<T> : IList<T>
    {

        int PageIndex { get; }

        int PageSize { get; }

        int TotalCount { get; }

        int TotalPages { get; }

        bool HasPreviousPage { get; }

        bool HasNextPage { get; }
    }
}
