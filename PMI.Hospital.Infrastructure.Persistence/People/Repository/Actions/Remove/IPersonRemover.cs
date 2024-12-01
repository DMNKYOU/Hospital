using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMI.Hospital.Infrastructure.Persistence.People.Repository.Actions.Remove
{
    /// <summary>
    /// The person entity remover.
    /// </summary>
    public interface IPersonRemover
    {
        /// <summary>
        /// Removes person entity.
        /// </summary>
        /// <param name="id">The id for removing.</param>
        /// <returns>The result of asynchronous operation.</returns>
        Task RemoveAsync(string id);
    }
}
