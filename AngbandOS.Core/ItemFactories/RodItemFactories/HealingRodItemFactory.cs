// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class HealingRodItemFactory : RodItemFactory
{
    private HealingRodItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override bool RequiresAiming => false;
    protected override string SymbolName => nameof(MinusSignSymbol);
    public override string Name => "Healing";

    public override int Cost => 20000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string FriendlyName => "Healing";
    public override int LevelNormallyFound => 80;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (80, 8)
    };
    public override int Weight => 15;
    public override int RodRechargeTime => 999;
    public override void Execute(ZapRodEvent zapRodEvent)
    {
        if (Game.RestoreHealth(500))
        {
            zapRodEvent.Identified = true;
        }
        if (Game.StunTimer.ResetTimer())
        {
            zapRodEvent.Identified = true;
        }
        if (Game.BleedingTimer.ResetTimer())
        {
            zapRodEvent.Identified = true;
        }
        zapRodEvent.Item.RodRechargeTimeRemaining = RodRechargeTime;
    }
}
