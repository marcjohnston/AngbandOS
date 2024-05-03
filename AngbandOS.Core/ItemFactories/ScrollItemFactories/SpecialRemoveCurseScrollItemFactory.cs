// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SpecialRemoveCurseScrollItemFactory : ScrollItemFactory
{
    private SpecialRemoveCurseScrollItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override string Name => "*Remove Curse*";

    public override int Cost => 8000;
    public override string FriendlyName => "*Remove Curse*";
    public override int LevelNormallyFound => 50;
    public override int[] Chance => new int[] { 2, 2, 2, 1 };
    public override int[] Locale => new int[] { 50, 75, 85, 95 };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        Game.RunScript(nameof(RemoveAllCurseScript));
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new Item(Game, this);
}
