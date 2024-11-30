using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace PMI.Hospital.Infrastructure.Persistence.DatabaseContext
{
    /// <inheritdoc cref="DbContext" />
    /// <summary>
    /// The application database context.
    /// </summary>
    /// <seealso cref="DbContext" />
    public partial class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// The default database schema.
        /// </summary>
        public const string DefaultSchemaName = "hospital";
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <inheritdoc />
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
