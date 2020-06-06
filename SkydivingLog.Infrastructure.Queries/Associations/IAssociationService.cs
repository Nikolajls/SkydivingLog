using SkydivingLog.Infrastructure.Queries.CanopyRegulation.Base;
using SkydivingLog.Models.Associations;

namespace SkydivingLog.Infrastructure.Queries.Associations
{
    public interface IAssociationService
    {
        public ICanopyRegulations GetCanopyRegulations(Association jumpingAssociation);
    }
}
