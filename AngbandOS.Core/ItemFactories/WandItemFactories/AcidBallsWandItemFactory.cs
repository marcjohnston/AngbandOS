// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class AcidBallsWandItemFactory : WandItemFactory
{
    private AcidBallsWandItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override int RodChargeCount => Game.DieRoll(5) + 2;
    protected override string SymbolName => nameof(MinusSignSymbol);
    public override string Name => "Acid Balls";

    public override int Cost => 1650;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Acid Balls";
    public override bool IgnoreAcid => true;
    public override int LevelNormallyFound => 50;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int[] Locale => new int[] { 50, 0, 0, 0 };
    public override int Weight => 10;
    public override bool ExecuteActivation(Game game, int dir)
    {
        game.FireBall(game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile)), dir, 60, 2);
        return true;
    }
    public override Item CreateItem() => new Item(Game, this);
}
