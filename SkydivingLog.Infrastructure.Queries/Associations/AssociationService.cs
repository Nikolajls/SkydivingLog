using Autofac.Features.Indexed;
using SkydivingLog.Infrastructure.Queries.CanopyRegulation.Base;
using SkydivingLog.Models.Associations;

namespace SkydivingLog.Infrastructure.Queries.Associations
{
    public class AssociationService : IAssociationService
    {
        private readonly IIndex<Association, ICanopyRegulations> _regulations;

        public AssociationService(IIndex<Association, ICanopyRegulations> regulations)
        {
            _regulations = regulations;
        }

        public ICanopyRegulations GetCanopyRegulations(Association jumpingAssociation)
        {
            return _regulations[jumpingAssociation];
        }
    }
}
