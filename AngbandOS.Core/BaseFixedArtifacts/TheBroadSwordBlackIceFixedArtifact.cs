using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;

namespace AngbandOS.Core;

[Serializable]
internal class TheBroadSwordBlackIceFixedArtifact : Base2FixedArtifact
{
    public override ItemClass BaseItemCategory => new SwordBroadSword();

    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "The Broad Sword 'Black Ice'";
    public override int Ac => 0;
    public override bool BrandCold => true;
    public override int Cost => 40000;
    public override int Dd => 2;
    public override int Ds => 5;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.SwordBlackIce;
    public override string FriendlyName => "'Black Ice'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override bool Lightsource => true;
    public override int Pval => 3;
    public override int Rarity => 20;
    public override bool ResCold => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool SlayOrc => true;
    public override bool SlowDigest => true;
    public override bool Stealth => true;
    public override int ToA => 0;
    public override int ToD => 15;
    public override int ToH => 10;
    public override int Weight => 150;
}
