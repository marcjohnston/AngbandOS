// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class ColdBallsRodItemFactory : RodItemFactory
{
    private ColdBallsRodItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override bool RequiresAiming => true;
    protected override string SymbolName => nameof(MinusSignSymbol);
    public override string Name => "Cold Balls";

    public override int Cost => 4500;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Cold Balls";
    public override int LevelNormallyFound => 60;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int[] Locale => new int[] { 60, 0, 0, 0 };
    public override int Weight => 15;
    public override int RodRechargeTime => 25;
    public override void Execute(ZapRodEvent zapRodEvent)
    {
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ColdProjectile)), zapRodEvent.Dir.Value, 48, 2);
        zapRodEvent.Identified = true;
        zapRodEvent.Item.RodRechargeTimeRemaining = RodRechargeTime;
    }
    public override Item CreateItem() => new Item(Game, this);
}
