// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class LightningBallsRodItemFactory : RodItemFactory
{
    private LightningBallsRodItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override bool RequiresAiming => true;
    protected override string SymbolName => nameof(MinusSignSymbol);
    public override string Name => "Lightning Balls";

    public override int Cost => 4000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string FriendlyName => "Lightning Balls";
    public override int LevelNormallyFound => 55;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (55, 1)
    };
    public override int Weight => 15;
    public override int RodRechargeTime => 23;
    public override void Execute(ZapRodEvent zapRodEvent)
    {
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ElecProjectile)), zapRodEvent.Dir.Value, 32, 2);
        zapRodEvent.Identified = true;
        zapRodEvent.Item.RodRechargeTimeRemaining = RodRechargeTime;
    }
}
