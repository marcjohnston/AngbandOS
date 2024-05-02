// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class RemoveCurseScrollItemFactory : ScrollItemFactory
{
    private RemoveCurseScrollItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override string Name => "Remove Curse";

    public override int[] Chance => new int[] { 1, 2, 2, 0 };
    public override int Cost => 100;
    public override string FriendlyName => "Remove Curse";
    public override int LevelNormallyFound => 10;
    public override int[] Locale => new int[] { 10, 20, 40, 0 };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        if (Game.RunSuccessfulScript(nameof(RemoveCurseScript)))
        {
            Game.MsgPrint("You feel as if someone is watching over you.");
            eventArgs.Identified = true;
        }
    }
    public override Item CreateItem() => new Item(Game, this);
}
