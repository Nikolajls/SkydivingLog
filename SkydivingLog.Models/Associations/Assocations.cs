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
    public abstract class AssociationBase
    {
        public abstract Association Association { get;  }  
    }

    public class UspaAssocation : AssociationBase
    {
        public override Association Association => Association.BPA;

    }

    public class DFUAssociation : AssociationBase
    {
        public override Association Association => Association.DFU;

    }

    public class BPAAssociation : AssociationBase
    {
        public override Association Association => Association.BPA;

    }

    public class FFPAssociation : AssociationBase
    {
        public override Association Association => Association.FFP;


    }
}
