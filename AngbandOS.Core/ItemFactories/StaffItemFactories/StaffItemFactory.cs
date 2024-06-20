// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class StaffItemFactory : ItemFactory
{
    public StaffItemFactory(Game game) : base(game) { }
    protected override string ItemClassName => nameof(StaffsItemClass);
    public override int StaffManaValue => 100;
    protected override string? RechargeScriptName => nameof(RechargeStaffScript);

    public override bool DrainChargesMonsterAttack(Item item, Monster monster, ref bool obvious) // TODO: obvious needs to be in an event 
    {
        if (item.StaffChargesRemaining == 0)
        {
            return false;
        }
        Game.MsgPrint("Energy drains from your pack!");
        obvious = true;
        int j = monster.Level;
        monster.Health += j * item.StaffChargesRemaining * item.Count;
        if (monster.Health > monster.MaxHealth)
        {
            monster.Health = monster.MaxHealth;
        }
        item.StaffChargesRemaining = 0;
        Game.SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
        return true;
    }

    protected override string? EatMagicScriptName => nameof(StaffEatMagicScript);

    public override bool CanBeUsed => true;

    /// <summary>
    /// Returns true, because staffs are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    /// <summary>
    /// Executes the staff action.  Returns true, if the usage identifies the staff.
    /// </summary>
    /// <param name="game"></param>
    /// <returns></returns>
    public abstract void UseStaff(UseStaffEvent eventArgs);

    public override int PackSort => 15;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Staff;
    public override int BaseValue => 70;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;

    public override ColorEnum Color => ColorEnum.Purple;
}
