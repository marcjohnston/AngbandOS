using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class MetalCapOfHolinessFixedArtifact : BaseFixedArtifact
{
    public override ItemClass BaseItemCategory => new HelmMetalCap();

    public override char Character => ']';
    public override Colour Colour => Colour.Grey;
    public override string Name => "The Metal Cap of Holiness";
    public override int Ac => 3;
    public override bool Cha => true;
    public override int Cost => 22000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.CapOfHoliness;
    public override string FriendlyName => "of Holiness";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 10;
    public override int Pval => 3;
    public override int Rarity => 2;
    public override int ToA => 12;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 20;
    public override bool Wis => true;
}
