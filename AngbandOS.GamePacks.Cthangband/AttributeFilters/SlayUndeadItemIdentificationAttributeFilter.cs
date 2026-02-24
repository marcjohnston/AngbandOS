using AngbandOS.Core.Interface.Configuration;
using AngbandOS.GamePacks.Cthangband;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class SlayUndeadItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(SlayUndeadAttribute), true) };
}