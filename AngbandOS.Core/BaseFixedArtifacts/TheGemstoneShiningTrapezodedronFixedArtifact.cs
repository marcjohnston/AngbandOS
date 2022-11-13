using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class TheGemstoneShiningTrapezodedronFixedArtifact : Base2FixedArtifact
{
    public override ItemClass BaseItemCategory => new LightGemstone();

    public override char Character => '*';
    public override Colour Colour => Colour.Red;
    public override string Name => "The Gemstone 'Shining Trapezodedron'";
    public override int Ac => 0;
    public override bool Activate => true;
    public override int Cost => 150000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.ShiningTrapezohedron;
    public override string FriendlyName => "'Shining Trapezodedron'";
    public override bool HasOwnType => true;
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool InstaArt => true;
    public override bool Int => true;
    public override int Level => 50;
    public override int Pval => 3;
    public override int Rarity => 50;
    public override bool ResChaos => true;
    public override bool SeeInvis => true;
    public override bool Speed => true;
    public override int ToA => 0;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 5;
    public override bool Wis => true;
}
