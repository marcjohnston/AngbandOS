using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class TheAdamantitePlateMailSoulkeeperFixedArtifact : Base2FixedArtifact
{
    public override char Character => '[';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "The Adamantite Plate Mail 'Soulkeeper'";
    public override int Ac => 40;
    public override bool Activate => true;
    public override bool Con => true;
    public override int Cost => 300000;
    public override int Dd => 2;
    public override int Ds => 4;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.PlateMailSoulkeeper;
    public override string FriendlyName => "'Soulkeeper'";
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 75;
    public override int Pval => 2;
    public override int Rarity => 9;
    public override bool ResAcid => true;
    public override bool ResChaos => true;
    public override bool ResCold => true;
    public override bool ResDark => true;
    public override bool ResNether => true;
    public override bool ResNexus => true;
    public override bool SustCon => true;
    public override int Sval => 30;
    public override int ToA => 20;
    public override int ToD => 0;
    public override int ToH => -4;
    public override ItemCategory Tval => ItemCategory.HardArmor;
    public override int Weight => 420;
}
