using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class TheAmuletOfLobonFixedArtifact : Base2FixedArtifact
{
    public override char Character => '"';
    public override string Name => "The Amulet of Lobon";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Con => true;
    public override int Cost => 60000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.AmuletOfLobon;
    public override string FriendlyName => "of Lobon";
    public override bool HasOwnType => true;
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool InstaArt => true;
    public override int Level => 50;
    public override int Pval => 2;
    public override int Rarity => 10;
    public override bool ResFire => true;
    public override int Sval => 10;
    public override int ToA => 0;
    public override int ToD => 0;
    public override int ToH => 0;
    public override ItemCategory Tval => ItemCategory.Amulet;
    public override int Weight => 3;
}
