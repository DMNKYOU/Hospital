using PMI.Hospital.Core.Models.People;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMI.Hospital.Infrastructure.Persistence.People.Repository.Actions.Create
{
    /// <summary>
    /// The people creator.
    /// </summary>
    public interface IPersonCreator
    {
        /// <summary>
        /// Creates the person.
        /// </summary>
        /// <param name="entity">The module to set.</param>
        /// <returns>The result of asynchronous operation.</returns>
        Task CreateAsync(PersonDto entity);
    }
}
