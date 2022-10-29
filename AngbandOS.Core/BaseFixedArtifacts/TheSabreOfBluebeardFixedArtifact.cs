using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class TheSabreOfBluebeardFixedArtifact : Base2FixedArtifact
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "The Sabre of Bluebeard";
    public override int Ac => 0;
    public override bool Blows => true;
    public override int Cost => 25000;
    public override int Dd => 1;
    public override int Ds => 7;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.SabreOfBluebeard;
    public override string FriendlyName => "of Bluebeard";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 15;
    public override int Pval => 1;
    public override int Rarity => 8;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override bool SlayDragon => true;
    public override bool SlayGiant => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override int Sval => 11;
    public override int ToA => 0;
    public override int ToD => 8;
    public override int ToH => 6;
    public override ItemCategory Tval => ItemCategory.Sword;
    public override int Weight => 50;
}
