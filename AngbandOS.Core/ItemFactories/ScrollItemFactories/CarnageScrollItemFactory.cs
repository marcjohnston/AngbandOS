// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class CarnageScrollItemFactory : ScrollItemFactory
{
    private CarnageScrollItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Get<Symbol>(nameof(QuestionMarkSymbol));
    public override string Name => "Carnage";

    public override int[] Chance => new int[] { 4, 4, 0, 0 };
    public override int Cost => 750;
    public override string FriendlyName => "Carnage";
    public override int LevelNormallyFound => 40;
    public override int[] Locale => new int[] { 40, 80, 0, 0 };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        Game.RunScript(nameof(GenocideScript));
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new Item(Game, this);
}
