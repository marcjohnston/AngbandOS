using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class TheGoldenCrownOfTheSunFixedArtifact : Base2FixedArtifact
{
    public override char Character => ']';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "The Golden Crown of the Sun";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Con => true;
    public override int Cost => 125000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.CrownOfTheSun;
    public override string FriendlyName => "of the Sun";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 40;
    public override bool Lightsource => true;
    public override int Pval => 3;
    public override int Rarity => 40;
    public override bool Regen => true;
    public override bool ResBlind => true;
    public override bool ResChaos => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool SeeInvis => true;
    public override bool Speed => true;
    public override bool Str => true;
    public override int Sval => 11;
    public override int ToA => 15;
    public override int ToD => 0;
    public override int ToH => 0;
    public override ItemCategory Tval => ItemCategory.Crown;
    public override int Weight => 30;
    public override bool Wis => true;
}
