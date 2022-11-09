using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;

namespace AngbandOS.Core;

[Serializable]
internal class TheLongSwordOfTheDawnFixedArtifact : Base2FixedArtifact
{
    public override ItemClass BaseItemCategory => new SwordLongSword();

    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "The Long Sword of the Dawn";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool BrandFire => true;
    public override bool Cha => true;
    public override int Cost => 250000;
    public override int Dd => 3;
    public override int Ds => 5;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.SwordOfTheDawn;
    public override bool FreeAct => true;
    public override string FriendlyName => "of the Dawn";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Infra => true;
    public override int Level => 40;
    public override bool Lightsource => true;
    public override int Pval => 3;
    public override int Rarity => 120;
    public override bool Regen => true;
    public override bool ResBlind => true;
    public override bool ResFear => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool ShowMods => true;
    public override bool SlayDemon => true;
    public override bool SlayDragon => true;
    public override bool SlayEvil => true;
    public override bool SlayUndead => true;
    public override bool SustCha => true;
    public override int ToA => 0;
    public override int ToD => 20;
    public override int ToH => 20;
    public override bool Vorpal => true;
    public override int Weight => 130;
}
