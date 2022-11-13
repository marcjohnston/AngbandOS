using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class TheBroadSwordLightningFixedArtifact : Base2FixedArtifact
{
    public override ItemClass BaseItemCategory => new SwordBroadSword();

    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "The Broad Sword 'Lightning'";
    public override int Ac => 0;
    public override bool BrandElec => true;
    public override int Cost => 95000;
    public override int Dd => 2;
    public override int Ds => 5;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.SwordLightning;
    public override string FriendlyName => "'Lightning'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool KillDragon => true;
    public override int Level => 20;
    public override bool Lightsource => true;
    public override int Pval => 4;
    public override int Rarity => 90;
    public override bool ResElec => true;
    public override bool ResFear => true;
    public override bool ResFire => true;
    public override bool ResPois => true;
    public override bool Search => true;
    public override bool ShowMods => true;
    public override bool SlayOrc => true;
    public override bool SlowDigest => true;
    public override int ToA => 0;
    public override int ToD => 16;
    public override int ToH => 12;
    public override int Weight => 150;
}
