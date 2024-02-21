// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SignOfChaosChaosBookItemFactory : ChaosBookItemFactory
{
    private SignOfChaosChaosBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(QuestionMarkSymbol));
    public override ColorEnum Color => ColorEnum.BrightRed;
    public override string Name => "[Sign of Chaos]";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 100;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "[Sign of Chaos]";
    public override int LevelNormallyFound => 10;
    public override int[] Locale => new int[] { 10, 0, 0, 0 };
    public override int Weight => 30;
    public override bool KindIsGood => false;

    public override Spell[] Spells => new Spell[]
    {
        SaveGame.SingletonRepository.Spells.Get(nameof(ChaosSpellMagicMissile)),
        SaveGame.SingletonRepository.Spells.Get(nameof(ChaosSpellTrapAndDoorDestruction)),
        SaveGame.SingletonRepository.Spells.Get(nameof(ChaosSpellFlashOfLight)),
        SaveGame.SingletonRepository.Spells.Get(nameof(ChaosSpellTouchOfConfusion)),
        SaveGame.SingletonRepository.Spells.Get(nameof(ChaosSpellManaBurst)),
        SaveGame.SingletonRepository.Spells.Get(nameof(ChaosSpellFireBolt)),
        SaveGame.SingletonRepository.Spells.Get(nameof(ChaosSpellFistOfForce)),
        SaveGame.SingletonRepository.Spells.Get(nameof(ChaosSpellTeleportSelf))
    };

    public override Item CreateItem() => new Item(SaveGame, this);
}
