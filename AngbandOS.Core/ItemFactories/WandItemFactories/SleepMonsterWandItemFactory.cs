// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SleepMonsterWandItemFactory : WandItemFactory
{
    private SleepMonsterWandItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(MinusSignSymbol);
    public override string Name => "Sleep Monster";

    public override int RodChargeCount => Game.DieRoll(15) + 8;
    public override int Cost => 500;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string FriendlyName => "Sleep Monster";
    public override int LevelNormallyFound => 5;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (5, 1)
    };
    public override int Weight => 10;
    public override bool ExecuteActivation(Game game, int dir)
    {
        return game.SleepMonster(dir);
    }
    public override Item CreateItem() => new Item(Game, this);
}
