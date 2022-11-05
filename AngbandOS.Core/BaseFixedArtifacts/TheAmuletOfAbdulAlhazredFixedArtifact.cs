using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;

namespace AngbandOS.Core;

[Serializable]
internal class TheAmuletOfAbdulAlhazredFixedArtifact : Base2FixedArtifact
{
    public override BaseItemCategory BaseItemCategory => new AmuletIngwe();

    public override char Character => '"';
    public override string Name => "The Amulet of Abdul Alhazred";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Cha => true;
    public override int Cost => 90000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.AmuletOfAbdulAlhazred;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Abdul Alhazred";
    public override bool HasOwnType => true;
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Infra => true;
    public override bool InstaArt => true;
    public override int Level => 65;
    public override int Pval => 3;
    public override int Rarity => 30;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool SeeInvis => true;
    public override int ToA => 0;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 3;
    public override bool Wis => true;
}
