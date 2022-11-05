using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;

namespace AngbandOS.Core;

[Serializable]
internal class TheSpearGungnirFixedArtifact : Base2FixedArtifact
{
    public override BaseItemCategory BaseItemCategory => new PolearmSpear();

    public override char Character => '/';
    public override Colour Colour => Colour.Grey;
    public override string Name => "The Spear 'Gungnir'";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Blessed => true;
    public override bool BrandElec => true;
    public override bool BrandFire => true;
    public override int Cost => 180000;
    public override int Dd => 4;
    public override int Ds => 6;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.SpearGungnir;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Gungnir'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    public override int Level => 15;
    public override bool Lightsource => true;
    public override int Pval => 4;
    public override int Rarity => 45;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool ShowMods => true;
    public override bool SlayGiant => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool SlowDigest => true;
    public override int ToA => 5;
    public override int ToD => 25;
    public override int ToH => 15;
    public override int Weight => 50;
    public override bool Wis => true;
}
