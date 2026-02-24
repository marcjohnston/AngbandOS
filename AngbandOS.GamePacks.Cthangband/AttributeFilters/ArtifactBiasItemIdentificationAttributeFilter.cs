using AngbandOS.Core.Interface.Configuration;
using AngbandOS.GamePacks.Cthangband;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class ArtifactBiasItemIdentificationAttributeFilter : AttributeFilterGameConfiguration
{
    public override bool? ArtifactBiasAttributeNonNull => true;
}