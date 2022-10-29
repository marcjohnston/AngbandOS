using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class TheLightCrossbowOfDeathFixedArtifact : Base2FixedArtifact
{
    public override char Character => '}';
    public override Colour Colour => Colour.Grey;
    public override string Name => "The Light Crossbow of Death";
    public override int Ac => 0;
    public override bool Activate => true;
    public override int Cost => 50000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.CrossbowOfDeath;
    public override string FriendlyName => "of Death";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 50;
    public override int Pval => 10;
    public override int Rarity => 25;
    public override bool ResFire => true;
    public override bool ShowMods => true;
    public override bool Speed => true;
    public override int Sval => 23;
    public override int ToA => 0;
    public override int ToD => 14;
    public override int ToH => 10;
    public override ItemCategory Tval => ItemCategory.Bow;
    public override int Weight => 110;
    public override bool XtraMight => true;
}
