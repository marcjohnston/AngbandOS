using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class TheDaggerFaithFixedArtifact : Base2FixedArtifact
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "The Dagger 'Faith'";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool BrandFire => true;
    public override int Cost => 12000;
    public override int Dd => 1;
    public override int Ds => 4;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.DaggerOfFaith;
    public override string FriendlyName => "'Faith'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 4;
    public override bool Lightsource => true;
    public override int Pval => 0;
    public override int Rarity => 10;
    public override bool ResFire => true;
    public override bool ShowMods => true;
    public override int Sval => 4;
    public override int ToA => 0;
    public override int ToD => 6;
    public override int ToH => 4;
    public override ItemCategory Tval => ItemCategory.Sword;
    public override int Weight => 12;
}
