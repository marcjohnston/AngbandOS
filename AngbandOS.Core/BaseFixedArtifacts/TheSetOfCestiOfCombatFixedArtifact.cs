using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;

namespace AngbandOS.Core;

[Serializable]
internal class TheSetOfCestiOfCombatFixedArtifact : Base2FixedArtifact
{
    public override ItemClass BaseItemCategory => new GlovesSetOfCesti();

    public override char Character => ']';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "The Set of Cesti of Combat";
    public override int Ac => 5;
    public override bool Activate => true;
    public override int Cost => 110000;
    public override int Dd => 1;
    public override bool Dex => true;
    public override int Ds => 1;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.CestiOfCombat;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Combat";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 40;
    public override int Pval => 4;
    public override int Rarity => 15;
    public override bool ResAcid => true;
    public override bool ShowMods => true;
    public override int ToA => 20;
    public override int ToD => 10;
    public override int ToH => 10;
    public override int Weight => 40;
}
