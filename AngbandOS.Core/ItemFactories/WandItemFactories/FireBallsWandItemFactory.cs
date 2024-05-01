// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class FireBallsWandItemFactory : WandItemFactory
{
    private FireBallsWandItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Get<Symbol>(nameof(MinusSignSymbol));
    public override string Name => "Fire Balls";

    public override int RodChargeCount => Game.DieRoll(4) + 2;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 1800;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Fire Balls";
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 50;
    public override int[] Locale => new int[] { 50, 0, 0, 0 };
    public override int Weight => 10;
    public override bool ExecuteActivation(Game game, int dir)
    {
        game.FireBall(game.SingletonRepository.Get<Projectile>(nameof(FireProjectile)), dir, 72, 2);
        return true;
    }
    public override Item CreateItem() => new Item(Game, this);
}
