// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class BattleAxeSpleenSlicerFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private ItemFactory _baseItemCategory;
    private BattleAxeSpleenSlicerFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Loaded()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get<PolearmBattleAxe>();
    }


    // Spleens Slicer heals you
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your battle axe radiates deep purple...");
        saveGame.RestoreHealth(SaveGame.Rng.DiceRoll(4, 8));
        saveGame.TimedBleeding.SetTimer((saveGame.TimedBleeding.TurnsRemaining / 2) - 50);
        item.RechargeTimeLeft = SaveGame.Rng.RandomLessThan(3) + 3;
    }
    public string DescribeActivationEffect() => "cure wounds (4d7) every 3+d3 turns";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(ForwardSlashSymbol));
    public override ColourEnum Colour => ColourEnum.Grey;
    public override string Name => "The Battle Axe 'Spleen Slicer'";
    public override int Ac => 0;
    public override bool Activate => true;
    public override int Cost => 21000;
    public override int Dd => 2;
    public override bool Dex => true;
    public override int Ds => 8;
    public override string FriendlyName => "'Spleen Slicer'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 30;
    public override int Pval => 1;
    public override int Rarity => 15;
    public override bool ShowMods => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool Str => true;
    public override int ToA => 0;
    public override int ToD => 3;
    public override int ToH => 4;
    public override int Weight => 170;
}
