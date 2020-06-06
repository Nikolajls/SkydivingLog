using System;
using System.Collections.Generic;
using System.Text;
using SkydivingLog.Infrastructure.Queries.CanopyRegulation.Base;
using SkydivingLog.Models.Associations;

namespace SkydivingLog.Infrastructure.Queries.Assocations
{
    public interface IAssocationService
    {
        public ICanopyRegulations GetCanopyRegulations(Association jumpingAssociation);
    }
}
