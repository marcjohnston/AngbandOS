// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class TrapDetectionScrollItemFactory : ScrollItemFactory
{
    private TrapDetectionScrollItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(QuestionMarkSymbol));
    public override string Name => "Trap Detection";

    public override int[] Chance => new int[] { 1, 1, 0, 0 };
    public override int Cost => 35;
    public override string FriendlyName => "Trap Detection";
    public override int LevelNormallyFound => 5;
    public override int[] Locale => new int[] { 5, 10, 0, 0 };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        if (SaveGame.DetectTraps())
        {
            eventArgs.Identified = true;
        }
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}
