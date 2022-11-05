using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;

namespace AngbandOS.Core;

[Serializable]
internal class TheRingOfElementalPowerStormFixedArtifact : Base2FixedArtifact
{
    public override BaseItemCategory BaseItemCategory => new RingVilya();

    public override char Character => '=';
    public override string Name => "The Ring of Elemental Power (Storm)";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Cha => true;
    public override bool Con => true;
    public override int Cost => 300000;
    public override int Dd => 1;
    public override bool Dex => true;
    public override int Ds => 1;
    public override bool Feather => true;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.RingOfElementalPowerStorm;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Elemental Power (Storm)";
    public override bool HasOwnType => true;
    public override bool HideType => true;
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImElec => true;
    public override bool InstaArt => true;
    public override bool Int => true;
    public override int Level => 90;
    public override int Pval => 3;
    public override int Rarity => 50;
    public override bool Regen => true;
    public override bool SeeInvis => true;
    public override bool SlowDigest => true;
    public override bool Speed => true;
    public override bool Str => true;
    public override bool SustDex => true;
    public override bool SustInt => true;
    public override bool SustStr => true;
    public override bool SustWis => true;
    public override int ToA => 0;
    public override int ToD => 12;
    public override int ToH => 12;
    public override int Weight => 2;
    public override bool Wis => true;
}
