using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class ThePairOfMetalShodBootsOfTheBlackReaverFixedArtifact : Base2FixedArtifact
{
    public override char Character => ']';
    public override Colour Colour => Colour.Grey;
    public override string Name => "The Pair of Metal Shod Boots of the Black Reaver";
    public override int Ac => 6;
    public override bool Aggravate => true;
    public override bool Con => true;
    public override int Cost => 15000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.BootsOfTheBlackReaver;
    public override string FriendlyName => "of the Black Reaver";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 30;
    public override int Pval => 10;
    public override int Rarity => 25;
    public override bool Speed => true;
    public override bool Str => true;
    public override int Sval => 6;
    public override int ToA => 20;
    public override int ToD => 0;
    public override int ToH => 0;
    public override ItemCategory Tval => ItemCategory.Boots;
    public override int Weight => 80;
}
