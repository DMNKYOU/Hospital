namespace PMI.Hospital.Infrastructure.Persistence.ChildrenWardPatients.Repository.Actions.Remove
{
    /// <summary>
    /// The person entity remover.
    /// </summary>
    public interface IChildrenWardPatientRemover
    {
        /// <summary>
        /// Removes person entity.
        /// </summary>
        /// <param name="id">The id for removing.</param>
        /// <returns>The result of asynchronous operation.</returns>
        Task RemoveAsync(string id);
    }
}
