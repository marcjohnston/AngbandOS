// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class TameMonsterWandItemFactory : WandItemFactory
{
    private TameMonsterWandItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(MinusSignSymbol);
    public override string Name => "Tame Monster";

    public override int[] Chance => new int[] { 2, 0, 0, 0 };
    public override int RodChargeCount => Game.DieRoll(6) + 2;
    public override int Cost => 1500;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Tame Monster";
    public override int LevelNormallyFound => 30;
    public override int[] Locale => new int[] { 30, 0, 0, 0 };
    public override int Weight => 10;
    public override bool ExecuteActivation(Game game, int dir)
    {
        return game.CharmMonster(dir, 45);
    }
    public override Item CreateItem() => new Item(Game, this);
}
