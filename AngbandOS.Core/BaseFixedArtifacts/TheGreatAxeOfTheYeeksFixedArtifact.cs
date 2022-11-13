using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class TheGreatAxeOfTheYeeksFixedArtifact : Base2FixedArtifact
{
    public override ItemClass BaseItemCategory => new PolearmGreatAxe();

    public override char Character => '/';
    public override Colour Colour => Colour.Grey;
    public override string Name => "The Great Axe of the Yeeks";
    public override int Ac => 0;
    public override bool Con => true;
    public override int Cost => 150000;
    public override int Dd => 4;
    public override int Ds => 4;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.AxeOfTheYeeks;
    public override bool FreeAct => true;
    public override string FriendlyName => "of the Yeeks";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool KillDragon => true;
    public override int Level => 30;
    public override int Pval => 3;
    public override int Rarity => 90;
    public override bool ResAcid => true;
    public override bool ResChaos => true;
    public override bool ResDark => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool ShowMods => true;
    public override bool SlayDemon => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override int ToA => 15;
    public override int ToD => 20;
    public override int ToH => 10;
    public override int Weight => 230;
}
