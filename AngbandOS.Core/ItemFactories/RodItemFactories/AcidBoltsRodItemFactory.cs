// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class AcidBoltsRodItemFactory : RodItemFactory
{
    private AcidBoltsRodItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override bool RequiresAiming => true;
    protected override string SymbolName => nameof(MinusSignSymbol);
    public override string Name => "Acid Bolts";

    public override int Cost => 3500;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string CodedName => "Acid Bolts";
    public override int LevelNormallyFound => 40;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (40, 1)
    };
    public override int Weight => 15;
    public override int RodRechargeTime => 12;
    public override void Execute(ZapRodEvent zapRodEvent)
    {
        Game.FireBoltOrBeam(10, Game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile)), zapRodEvent.Dir.Value, Game.DiceRoll(6, 8));
        zapRodEvent.Identified = true;
        zapRodEvent.Item.RodRechargeTimeRemaining = RodRechargeTime;
    }
}
