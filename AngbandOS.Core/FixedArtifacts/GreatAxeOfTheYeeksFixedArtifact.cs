// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class GreatAxeOfTheYeeksFixedArtifact : FixedArtifact
{
    private readonly ItemFactory _baseItemCategory;
    private GreatAxeOfTheYeeksFixedArtifact(SaveGame saveGame) : base(saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemFactories.Get<PolearmGreatAxe>();
    }

    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override char Character => '/';
    public override Colour Colour => Colour.Grey;
    public override string Name => "The Great Axe of the Yeeks";
    public override int Ac => 0;
    public override bool Con => true;
    public override int Cost => 150000;
    public override int Dd => 4;
    public override int Ds => 4;
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
