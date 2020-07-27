using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkydivingLog.Infrastructure.Attributes
{
    [AttributeUsage( AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AssociationEnumAttribute : Attribute
    {
        public  string Name { get; set; }
        public AssociationEnumAttribute(params object[] roles)
        {
            if (roles.Any(r => r.GetType().BaseType != typeof(Enum)))
                throw new ArgumentException("roles");

           // this.Roles = string.Join(",", roles.Select(r => Enum.GetName(r.GetType(), r)));
        }
    }
}
