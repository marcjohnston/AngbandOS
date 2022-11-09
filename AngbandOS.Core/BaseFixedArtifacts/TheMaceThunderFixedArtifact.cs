using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;

namespace AngbandOS.Core;

[Serializable]
internal class TheMaceThunderFixedArtifact : Base2FixedArtifact
{
    public override ItemClass BaseItemCategory => new HaftedMace();

    public override char Character => '\\';
    public override Colour Colour => Colour.Black;
    public override string Name => "The Mace 'Thunder'";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool BrandElec => true;
    public override int Cost => 50000;
    public override int Dd => 3;
    public override int Ds => 4;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.MaceThunder;
    public override string FriendlyName => "'Thunder'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImElec => true;
    public override bool KillDragon => true;
    public override int Level => 20;
    public override int Pval => 0;
    public override int Rarity => 15;
    public override bool ShowMods => true;
    public override int ToA => 0;
    public override int ToD => 12;
    public override int ToH => 12;
    public override int Weight => 200;
}
