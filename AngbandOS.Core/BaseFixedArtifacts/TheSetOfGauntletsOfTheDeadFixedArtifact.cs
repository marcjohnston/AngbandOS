using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;

namespace AngbandOS.Core;

[Serializable]
internal class TheSetOfGauntletsOfTheDeadFixedArtifact : Base2FixedArtifact
{
    public override BaseItemCategory BaseItemCategory => new GlovesSetOfGauntlets();

    public override char Character => ']';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "The Set of Gauntlets of the Dead";
    public override int Ac => 2;
    public override bool Activate => true;
    public override int Cost => 12000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.GauntletsOfTheDead;
    public override string FriendlyName => "of the Dead";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 10;
    public override int Pval => 0;
    public override int Rarity => 20;
    public override bool ResAcid => true;
    public override int ToA => 15;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 25;
}
