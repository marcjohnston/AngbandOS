// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class AcquirementScrollItemFactory : ScrollItemFactory
{
    private AcquirementScrollItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Get<Symbol>(nameof(QuestionMarkSymbol));
    public override string Name => "Acquirement";

    public override int[] Chance => new int[] { 8, 0, 0, 0 };
    public override int Cost => 100000;
    public override string FriendlyName => "Acquirement";
    public override int LevelNormallyFound => 20;
    public override int[] Locale => new int[] { 20, 0, 0, 0 };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        Game.Acquirement(Game.MapY.IntValue, Game.MapX.IntValue, 1, true);
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new Item(Game, this);
}
