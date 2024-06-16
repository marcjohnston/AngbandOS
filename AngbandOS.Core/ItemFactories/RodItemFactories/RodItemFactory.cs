// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class RodItemFactory : ItemFactory
{
    public RodItemFactory(Game game) : base(game) { }
    protected override string ItemClassName => nameof(RodsItemClass);

    public abstract int RodRechargeTime { get; }

    private void ProcessWorld(Item oPtr)
    {
        if (oPtr.RodRechargeTimeRemaining != 0)
        {
            oPtr.RodRechargeTimeRemaining--;
            if (oPtr.RodRechargeTimeRemaining == 0)
            {
                Game.SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineFlaggedAction)).Set();
            }
        }
    }
    protected override string? RechargeScriptName => nameof(RechargeRodScript);

    public override void GridProcessWorld(Item item, GridTile gridTile)
    {
        ProcessWorld(item);
    }

    public override void MonsterProcessWorld(Item item, Monster mPtr)
    {
        ProcessWorld(item);
    }

    public override void EquipmentProcessWorld(Item item)
    {
        ProcessWorld(item);
    }

    public override void PackProcessWorld(Item item)
    {
        ProcessWorld(item);
    }

    public override void EatMagic(Item oPtr)
    {
        if (oPtr.RodRechargeTimeRemaining > 0)
        {
            Game.MsgPrint("You can't absorb energy from a discharged rod.");
        }
        else
        {
            Game.Mana.IntValue += 2 * LevelNormallyFound;
            oPtr.RodRechargeTimeRemaining = 500;
        }
    }

    public override string GetVerboseDescription(Item item)
    {
        string s = "";
        if (item.IsKnown() && item.RodRechargeTimeRemaining != 0)
        {
            s += $" (charging)";
        }
        s += base.GetVerboseDescription(item);
        return s;
    }

    /// <summary>
    /// Returns true, because rods are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;
    public override bool CanBeZapped => true;
    public abstract bool RequiresAiming { get; }
    public override bool EasyKnow => true;
    public override int PackSort => 13;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Rod;
    public override int BaseValue => 90;
    public override ColorEnum Color => ColorEnum.Turquoise;
    public abstract void Execute(ZapRodEvent zapRodEvent);
}
