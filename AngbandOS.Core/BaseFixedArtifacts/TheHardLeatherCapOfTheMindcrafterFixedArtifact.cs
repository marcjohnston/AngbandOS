using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class TheHardLeatherCapOfTheMindcrafterFixedArtifact : Base2FixedArtifact
{
    public override char Character => ']';
    public override Colour Colour => Colour.Brown;
    public override string Name => "The Hard Leather Cap of the Mindcrafter";
    public override int Ac => 2;
    public override int Cost => 50000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.CapOfTheMindcrafter;
    public override string FriendlyName => "of the Mindcrafter";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    public override int Level => 20;
    public override int Pval => 2;
    public override int Rarity => 2;
    public override bool ResBlind => true;
    public override int Sval => 2;
    public override bool Telepathy => true;
    public override int ToA => 10;
    public override int ToD => 0;
    public override int ToH => 0;
    public override ItemCategory Tval => ItemCategory.Helm;
    public override int Weight => 15;
    public override bool Wis => true;
}
