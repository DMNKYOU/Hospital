using PMI.Hospital.Core.Models.People;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMI.Hospital.Infrastructure.Persistence.ChildrenWardPatients.Repository.Actions.Create
{
    /// <summary>
    /// The child patient creator.
    /// </summary>
    public interface IChildrenWardPatientCreator
    {
        /// <summary>
        /// Creates the patient.
        /// </summary>
        /// <param name="personId">The person id data.</param>
        /// <param name="active">The is active value.</param>
        /// <returns>The result of asynchronous operation.</returns>
        Task CreateAsync(string patientId, bool active);
    }
}
