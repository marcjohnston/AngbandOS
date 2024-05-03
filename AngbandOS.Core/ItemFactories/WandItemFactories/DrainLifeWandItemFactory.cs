// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DrainLifeWandItemFactory : WandItemFactory
{
    private DrainLifeWandItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(MinusSignSymbol);
    public override string Name => "Drain Life";

    public override int RodChargeCount => Game.DieRoll(3) + 3;
    public override int Cost => 1200;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Drain Life";
    public override int LevelNormallyFound => 50;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (50, 1)
    };
    public override int Weight => 10;
    public override bool ExecuteActivation(Game game, int dir)
    {
        return game.DrainLife(dir, 75);
    }
    public override Item CreateItem() => new Item(Game, this);
}
