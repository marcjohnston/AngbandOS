using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class TheLongBowOfSerpentsFixedArtifact : Base2FixedArtifact
{
    public override char Character => '}';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "The Long Bow of Serpents";
    public override int Ac => 0;
    public override int Cost => 20000;
    public override int Dd => 0;
    public override bool Dex => true;
    public override int Ds => 0;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.BowOfSerpents;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Serpents";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 30;
    public override int Pval => 3;
    public override int Rarity => 20;
    public override bool ShowMods => true;
    public override int Sval => 13;
    public override int ToA => 0;
    public override int ToD => 19;
    public override int ToH => 17;
    public override ItemCategory Tval => ItemCategory.Bow;
    public override int Weight => 40;
    public override bool XtraMight => true;
}
