// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class AggravateMonsterScrollItemFactory : ScrollItemFactory
{
    private AggravateMonsterScrollItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override string Name => "Aggravate Monster";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override string FriendlyName => "Aggravate Monster";
    public override int LevelNormallyFound => 5;
    public override int[] Locale => new int[] { 5, 0, 0, 0 };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        Game.MsgPrint("There is a high pitched humming noise.");
        Game.AggravateMonsters();
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new Item(Game, this);
}
