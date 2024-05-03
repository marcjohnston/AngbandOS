// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SpeedRodItemFactory : RodItemFactory
{
    private SpeedRodItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override bool RequiresAiming => false;
    protected override string SymbolName => nameof(MinusSignSymbol);
    public override string Name => "Speed";

    public override int Cost => 50000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string FriendlyName => "Speed";
    public override int LevelNormallyFound => 95;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (95, 16)
    };
    public override int Weight => 15;
    public override int RodRechargeTime => 99;
    public override void Execute(ZapRodEvent zapRodEvent)
    {
        if (Game.HasteTimer.Value == 0)
        {
            if (Game.HasteTimer.SetTimer(Game.DieRoll(30) + 15))
            {
                zapRodEvent.Identified = true;
            }
        }
        else
        {
            Game.HasteTimer.AddTimer(5);
        }
        zapRodEvent.Item.RodRechargeTimeRemaining = RodRechargeTime;
    }
}
