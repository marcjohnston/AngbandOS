using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class TheRingOfMagicFixedArtifact : Base2FixedArtifact
{
    public override char Character => '=';
    public override string Name => "The Ring of Magic";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Cha => true;
    public override bool Con => true;
    public override int Cost => 75000;
    public override int Dd => 0;
    public override bool Dex => true;
    public override int Ds => 0;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.RingOfMagic;
    public override string FriendlyName => "of Magic";
    public override bool HasOwnType => true;
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool InstaArt => true;
    public override bool Int => true;
    public override int Level => 50;
    public override int Pval => 1;
    public override int Rarity => 25;
    public override bool ResPois => true;
    public override bool Search => true;
    public override bool SeeInvis => true;
    public override bool Stealth => true;
    public override bool Str => true;
    public override int Sval => 32;
    public override int ToA => 0;
    public override int ToD => 0;
    public override int ToH => 0;
    public override ItemCategory Tval => ItemCategory.Ring;
    public override int Weight => 2;
    public override bool Wis => true;
}
