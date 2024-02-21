// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SlowPoisonPotionItemFactory : PotionItemFactory
{
    private SlowPoisonPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(ExclamationPointSymbol));
    public override string Name => "Slow Poison";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 25;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Slow Poison";
    public override int LevelNormallyFound => 1;
    public override int[] Locale => new int[] { 1, 0, 0, 0 };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Slow poison halves the remaining duration of any poison you have
        return SaveGame.TimedPoison.SetTimer(SaveGame.TimedPoison.TurnsRemaining / 2);
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}
