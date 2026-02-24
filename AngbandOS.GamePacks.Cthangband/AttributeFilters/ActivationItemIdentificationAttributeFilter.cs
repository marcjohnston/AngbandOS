using AngbandOS.Core.Interface.Configuration;
using AngbandOS.GamePacks.Cthangband;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngbandOS.GamePacks.Cthangband.AttributeFilters
{
    [Serializable]
    public class ActivationItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
    {
        public override bool? ActivationAttributeNonNull => true;
    }
}