// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System;

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class WandItemFactory : ItemFactory, IFlavorFactory
{
    public WandItemFactory(Game game) : base(game) { }
    public override ItemClass ItemClass => Game.SingletonRepository.Get<ItemClass>(nameof(WandsItemClass));

    /// <summary>
    /// Returns the factory that this item was created by; casted as an IFlavor.
    /// </summary>
    public IFlavorFactory FlavorFactory => (IFlavorFactory)this;

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        item.WandChargesRemaining = RodChargeCount;
    }
    public abstract int RodChargeCount { get; }

    public override string GetVerboseDescription(Item item)
    {
        string s = "";
        if (item.IsKnown())
        {
            s += $" ({item.WandChargesRemaining} {Game.CountPluralize("charge", item.WandChargesRemaining)})";
        }
        s += base.GetVerboseDescription(item);
        return s;
    }

    public override void Recharge(Item oPtr, int num)
    {
        int i, t;
        i = (num + 100 - LevelNormallyFound - (10 * oPtr.TypeSpecificValue)) / 15;
        if (i < 1)
        {
            i = 1;
        }
        if (Game.RandomLessThan(i) == 0)
        {
            Game.MsgPrint("There is a bright flash of light.");
            oPtr.ItemIncrease(-999);
            oPtr.ItemDescribe();
            oPtr.ItemOptimize();
        }
        else
        {
            t = (num / (LevelNormallyFound + 2)) + 1;
            if (t > 0)
            {
                oPtr.TypeSpecificValue += 2 + Game.DieRoll(t);
            }
            oPtr.IdentKnown = false;
            oPtr.IdentEmpty = false;
        }
        Game.SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
    }

    public override void EatMagic(Item oPtr)
    {
        if (oPtr.WandChargesRemaining > 0)
        {
            Game.Mana.IntValue += oPtr.WandChargesRemaining * LevelNormallyFound;
            oPtr.WandChargesRemaining = 0;
        }
        else
        {
            Game.MsgPrint("There's no energy there to absorb!");
        }
        oPtr.IdentEmpty = true;
    }

    public override string GetDescription(Item item, bool includeCountPrefix, bool isFlavorAware)
    {
        string flavor = item.IdentityIsStoreBought ? "" : $"{FlavorFactory.Flavor.Name} ";
        string ofName = isFlavorAware ? $" of {FriendlyName}" : "";
        string name = $"{flavor}{Game.CountPluralize("Wand", item.Count)}{ofName}";
        return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
    }

    public override int? GetBonusRealValue(Item item, int value)
    {
        return value / 20 * item.WandChargesRemaining;
    }

    /// <summary>
    /// Returns the want flavors repository because wands have flavors that need to be identified.
    /// </summary>
    public IEnumerable<Flavor>? GetFlavorRepository() => Game.SingletonRepository.Get<WandReadableFlavor>();

    /// <inheritdoc/>
    public Flavor Flavor { get; set; }
    public override int PercentageBreakageChance => 25;
    public override bool IsRechargable => true;

    public override int PackSort => 14;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Wand;
    public abstract bool ExecuteActivation(Game game, int dir);
    public override int BaseValue => 50;
    public override bool CanBeAimed => true;
    public override bool HatesElectricity => true;

    //public override bool IsCharged => true;
    public override ColorEnum Color => ColorEnum.Chartreuse;
}
