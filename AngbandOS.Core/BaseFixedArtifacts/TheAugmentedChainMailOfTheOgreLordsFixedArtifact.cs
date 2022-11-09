using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;

namespace AngbandOS.Core;

[Serializable]
internal class TheAugmentedChainMailOfTheOgreLordsFixedArtifact : Base2FixedArtifact
{
    public override ItemClass BaseItemCategory => new AmuletBrilliance();

    public override char Character => '[';
    public override Colour Colour => Colour.Grey;
    public override string Name => "The Augmented Chain Mail of the Ogre Lords";
    public override int Ac => 16;
    public override bool Activate => true;
    public override bool Con => true;
    public override int Cost => 40000;
    public override int Dd => 1;
    public override int Ds => 4;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.ArmourOfTheOgreLords;
    public override string FriendlyName => "of the Ogre Lords";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    public override int Level => 25;
    public override int Pval => 3;
    public override int Rarity => 9;
    public override bool ResAcid => true;
    public override bool ResConf => true;
    public override bool ResPois => true;
    public override int ToA => 20;
    public override int ToD => 0;
    public override int ToH => -2;
    public override int Weight => 270;
    public override bool Wis => true;
}
