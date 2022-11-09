using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;

namespace AngbandOS.Core;

[Serializable]
internal class TheDaggerIcicleFixedArtifact : Base2FixedArtifact
{
    public override ItemClass BaseItemCategory => new SwordDagger();

    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "The Dagger 'Icicle'";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Blows => true;
    public override bool BrandCold => true;
    public override bool BrandPois => true;
    public override int Cost => 50000;
    public override int Dd => 2;
    public override bool Dex => true;
    public override int Ds => 4;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.DaggerIcicle;
    public override string FriendlyName => "'Icicle'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 10;
    public override int Pval => 2;
    public override int Rarity => 40;
    public override bool Regen => true;
    public override bool ResCold => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlowDigest => true;
    public override bool Speed => true;
    public override int ToA => 0;
    public override int ToD => 9;
    public override int ToH => 6;
    public override int Weight => 12;
}
