using AngbandOS.Core.Interface.Configuration;
using AngbandOS.GamePacks.Cthangband;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class RegenItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool?[] DesiredValue)[]? BoolAttributeFilterBindings => new (string AttributeKey, bool?[] DesiredValue)[] { (nameof(RegenAttribute), new bool?[] { true }) };
}