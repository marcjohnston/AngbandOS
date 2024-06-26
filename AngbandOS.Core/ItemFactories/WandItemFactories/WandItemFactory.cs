// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class WandItemFactory : ItemFactory
{
    public WandItemFactory(Game game) : base(game) { }
    protected override string ItemClassName => nameof(WandsItemClass);

    public override bool DrainChargesMonsterAttack(Item item, Monster monster, ref bool obvious) // TODO: obvious needs to be in an event 
    {
        if (item.WandChargesRemaining == 0)
        {
            return false;
        }
        Game.MsgPrint("Energy drains from your pack!");
        obvious = true;
        int j = monster.Level;
        monster.Health += j * item.WandChargesRemaining * item.Count;
        if (monster.Health > monster.MaxHealth)
        {
            monster.Health = monster.MaxHealth;
        }
        item.WandChargesRemaining = 0;
        Game.SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
        return true;
    }

    protected override string? RechargeScriptName => nameof(RechargeWandScript);

    protected override string? EatMagicScriptName => nameof(WandEatMagicScript);

    /// <summary>
    /// Returns true, because wands are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    public override int PercentageBreakageChance => 25;
    public override int PackSort => 14;
    public override int BaseValue => 50;
    public override bool HatesElectricity => true;

    public override ColorEnum Color => ColorEnum.Chartreuse;
}
