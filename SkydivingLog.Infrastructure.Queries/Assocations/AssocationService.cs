using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Features.Indexed;
using SkydivingLog.Infrastructure.Queries.CanopyRegulation.Base;
using SkydivingLog.Models.Associations;

namespace SkydivingLog.Infrastructure.Queries.Assocations
{
    public class AssocationService : IAssocationService
    {
        IIndex<Association, ICanopyRegulations> _states;

        public AssocationService(IIndex<Association, ICanopyRegulations> states)
        {
            _states = states;
            int i = 1;
        }
        public ICanopyRegulations GetCanopyRegulations(Association jumpingAssociation)
        {
            var d = _states[jumpingAssociation];
            return d;
        }
    }
}
