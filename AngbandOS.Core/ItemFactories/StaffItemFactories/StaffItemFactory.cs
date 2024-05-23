// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Threading;

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class StaffItemFactory : ItemFactory
{
    public StaffItemFactory(Game game) : base(game) { }
    protected override string ItemClassName => nameof(StaffsItemClass);

    public abstract int StaffChargeCount { get; }

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        item.StaffChargesRemaining = StaffChargeCount;
    }

    public override void Recharge(Item oPtr, int num)
    {
        int i, t;
        i = (100 - LevelNormallyFound + num) / 5;
        if (i < 1)
        {
            i = 1;
        }
        if (Game.RandomLessThan(i) == 0)
        {
            Game.MsgPrint("The recharge backfires, draining the rod further!");
            if (oPtr.StaffChargesRemaining < 10000)
            {
                oPtr.StaffChargesRemaining = (oPtr.StaffChargesRemaining + 100) * 2;
            }
        }
        else
        {
            t = num * Game.DiceRoll(2, 4);
            if (oPtr.StaffChargesRemaining > t)
            {
                oPtr.StaffChargesRemaining -= t;
            }
            else
            {
                oPtr.StaffChargesRemaining = 0;
            }
        }
        Game.SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
    }

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

    public override string GetVerboseDescription(Item item)
    {
        string s = "";
        if (item.IsKnown())
        {
            s += $" ({item.StaffChargesRemaining} {Game.CountPluralize("charge", item.StaffChargesRemaining)})";
        }
        s += base.GetVerboseDescription(item);
        return s;
    }

    public override void EatMagic(Item oPtr)
    {
        if (oPtr.StaffChargesRemaining > 0)
        {
            Game.Mana.IntValue += oPtr.StaffChargesRemaining * LevelNormallyFound;
            oPtr.StaffChargesRemaining = 0;
        }
        else
        {
            Game.MsgPrint("There's no energy there to absorb!");
        }
        oPtr.IdentEmpty = true;
    }

    public override string GetDescription(Item item, bool includeCountPrefix, bool isFlavorAware)
    {
        string flavor = item.IdentityIsStoreBought ? "" : $"{Flavor.Name} ";
        string ofName = isFlavorAware ? $" of {FriendlyName}" : "";
        string name = $"{flavor}{Game.CountPluralize("Staff", item.Count)}{ofName}";
        return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
    }

    public override int? GetBonusRealValue(Item item, int value)
    {
        return value / 20 * item.StaffChargesRemaining;
    }

    /// <summary>
    /// Returns the staff flavors repository because staves have flavors that need to be identified.
    /// </summary>
    public override IEnumerable<Flavor>? GetFlavorRepository => Game.SingletonRepository.Get<StaffReadableFlavor>();

    public override bool CanBeUsed => true;

    public override bool IsRechargable => true;

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

    //public override bool IsCharged => true;
    public override ColorEnum Color => ColorEnum.Purple;
}
