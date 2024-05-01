// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class RodItemFactory : ItemFactory, IFlavorFactory
{
    public RodItemFactory(Game game) : base(game) { }
    public override ItemClass ItemClass => Game.SingletonRepository.Get<ItemClass>(nameof(RodsItemClass));

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

    /// <summary>
    /// Returns the factory that this item was created by; casted as an IFlavor.
    /// </summary>
    public IFlavorFactory FlavorFactory => (IFlavorFactory)this;

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

    public override string GetDescription(Item item, bool includeCountPrefix, bool isFlavorAware)
    {
        string flavor = item.IdentityIsStoreBought ? "" : $"{FlavorFactory.Flavor.Name} ";
        string ofName = isFlavorAware ? $" of {FriendlyName}" : "";
        string name = $"{flavor}{Game.CountPluralize("Rod", item.Count)}{ofName}";
        return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
    }

    /// <summary>
    /// Returns the rod flavors repository because rods have flavors that need to be identified.
    /// </summary>
    public IEnumerable<Flavor>? GetFlavorRepository() => Game.SingletonRepository.Get<RodReadableFlavor>();
    public override bool IsRechargable => true;
    public override bool CanBeZapped => true;

    /// <inheritdoc/>
    public Flavor Flavor { get; set; }

    public abstract bool RequiresAiming { get; }
    public override bool EasyKnow => true;
    public override int PackSort => 13;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Rod;
    public override int BaseValue => 90;
    public override ColorEnum Color => ColorEnum.Turquoise;
    public abstract void Execute(ZapRodEvent zapRodEvent);
}
