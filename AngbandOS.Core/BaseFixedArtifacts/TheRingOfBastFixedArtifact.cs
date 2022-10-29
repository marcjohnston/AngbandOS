using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class TheRingOfBastFixedArtifact : Base2FixedArtifact
{
    public override char Character => '=';
    public override string Name => "The Ring of Bast";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Con => true;
    public override int Cost => 175000;
    public override int Dd => 0;
    public override bool Dex => true;
    public override int Ds => 0;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.RingOfBast;
    public override string FriendlyName => "of Bast";
    public override bool HasOwnType => true;
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool InstaArt => true;
    public override int Level => 70;
    public override int Pval => 4;
    public override int Rarity => 50;
    public override bool Speed => true;
    public override bool Str => true;
    public override int Sval => 33;
    public override int ToA => 0;
    public override int ToD => 0;
    public override int ToH => 0;
    public override ItemCategory Tval => ItemCategory.Ring;
    public override int Weight => 2;
}
