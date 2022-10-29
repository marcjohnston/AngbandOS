using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class TheCloakShifterFixedArtifact : Base2FixedArtifact
{
    public override char Character => '(';
    public override Colour Colour => Colour.Green;
    public override string Name => "The Cloak 'Shifter'";
    public override int Ac => 1;
    public override bool Activate => true;
    public override int Cost => 11000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.CloakShifter;
    public override string FriendlyName => "'Shifter'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 3;
    public override int Pval => 3;
    public override int Rarity => 10;
    public override bool ResAcid => true;
    public override bool Stealth => true;
    public override int Sval => 1;
    public override int ToA => 15;
    public override int ToD => 0;
    public override int ToH => 0;
    public override ItemCategory Tval => ItemCategory.Cloak;
    public override int Weight => 10;
}
