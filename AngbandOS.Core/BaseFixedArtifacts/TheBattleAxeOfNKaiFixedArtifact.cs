using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class TheBattleAxeOfNKaiFixedArtifact : Base2FixedArtifact
{
    public override ItemClass BaseItemCategory => new PolearmBattleAxe();

    public override char Character => '/';
    public override Colour Colour => Colour.Grey;
    public override string Name => "The Battle Axe of N'Kai";
    public override int Ac => 0;
    public override bool Con => true;
    public override int Cost => 90000;
    public override int Dd => 3;
    public override int Ds => 8;
    public override bool Feather => true;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.AxeOfNKai;
    public override bool FreeAct => true;
    public override string FriendlyName => "of N'Kai";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 30;
    public override int Pval => 3;
    public override int Rarity => 15;
    public override bool Regen => true;
    public override bool ResAcid => true;
    public override bool ResBlind => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayDemon => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool Stealth => true;
    public override bool Str => true;
    public override int ToA => 5;
    public override int ToD => 11;
    public override int ToH => 8;
    public override int Weight => 170;
}
