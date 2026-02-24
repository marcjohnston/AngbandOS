using AngbandOS.Core.Interface.Configuration;
using AngbandOS.GamePacks.Cthangband;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class SlayDragonBaneItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings => new (string, int?, int?)[] { (nameof(SlayDragonAttribute), 3, null) };
}