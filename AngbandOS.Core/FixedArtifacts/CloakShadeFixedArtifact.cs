using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class CloakShadeFixedArtifact : BaseFixedArtifact
{
    public override ItemClass BaseItemCategory => new Cloak();

    public override char Character => '(';
    public override Colour Colour => Colour.Green;
    public override string Name => "The Cloak 'Shade'";
    public override int Ac => 1;
    public override int Cost => 8000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.CloakShade;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Shade'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 5;
    public override int Pval => 0;
    public override int Rarity => 20;
    public override bool ResAcid => true;
    public override bool SeeInvis => true;
    public override int ToA => 10;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 10;
}