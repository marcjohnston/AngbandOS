// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class FrostBoltsWandItemFactory : WandItemFactory
{
    private FrostBoltsWandItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(MinusSignSymbol);
    public override string Name => "Frost Bolts";

    public override int RodChargeCount => Game.DieRoll(5) + 6;
    public override int Cost => 800;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Frost Bolts";
    public override int LevelNormallyFound => 20;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int[] Locale => new int[] { 20, 0, 0, 0 };
    public override int Weight => 10;
    public override bool ExecuteActivation(Game game, int dir)
    {
        game.FireBoltOrBeam(20, game.SingletonRepository.Get<Projectile>(nameof(ColdProjectile)), dir, Game.DiceRoll(3, 8));
        return true;
    }
    public override Item CreateItem() => new Item(Game, this);
}
