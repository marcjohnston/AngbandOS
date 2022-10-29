using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class TheSpearGaeBulgFixedArtifact : Base2FixedArtifact
{
    public override char Character => '/';
    public override Colour Colour => Colour.Grey;
    public override string Name => "The Spear 'Gae Bulg'";
    public override int Ac => 0;
    public override bool BrandCold => true;
    public override int Cost => 30000;
    public override int Dd => 1;
    public override int Ds => 6;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.SpearGaeBulg;
    public override string FriendlyName => "'Gae Bulg'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Infra => true;
    public override int Level => 15;
    public override int Pval => 3;
    public override int Rarity => 12;
    public override bool ResCold => true;
    public override bool ResDark => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayUndead => true;
    public override bool Speed => true;
    public override bool Stealth => true;
    public override int Sval => 2;
    public override int ToA => 0;
    public override int ToD => 13;
    public override int ToH => 11;
    public override ItemCategory Tval => ItemCategory.Polearm;
    public override int Weight => 50;
}
