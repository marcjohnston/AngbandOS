// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class TrapDoorDestructionWandItemFactory : WandItemFactory
{
    private TrapDoorDestructionWandItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(MinusSignSymbol);
    public override string Name => "Trap/Door Destruction";

    public override int RodChargeCount => Game.DieRoll(8) + 6;
    public override int Cost => 100;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Trap/Door Destruction";
    public override int LevelNormallyFound => 10;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int[] Locale => new int[] { 10, 0, 0, 0 };
    public override int Weight => 10;
    public override bool ExecuteActivation(Game game, int dir)
    {
        return game.DestroyDoor(dir);
    }
    public override Item CreateItem() => new Item(Game, this);
}
