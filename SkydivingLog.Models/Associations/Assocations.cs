using System;
using System.Collections.Generic;
using System.Text;

namespace SkydivingLog.Models.Associations
{
    public enum Association
    {
        USPA, //USA - United states parachute assocation.
        DFU, // Denmark - Dansk faldskærms union
        BPA, //Britain - British Parachutistasddasda
        FFP //France - Fédération Francaose de parachutisme
    }

    public interface IAssociation
    {
        Association Association { get; }
    }

    public class UspaAssocation : IAssociation
    {
        public Association Association => Association.USPA;

    }

    public class DFUAssociation : IAssociation
    {
        public Association Association => Association.DFU;
    }

    public class BPAAssociation : IAssociation
    {
        public Association Association => Association.BPA;

    }

    public class FFPAssociation : IAssociation
    {
        public Association Association => Association.FFP;
    }

}
