﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class WandItemFactory : ItemFactory, IFlavour
{
    public WandItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get(nameof(WandsItemClass));

    /// <summary>
    /// Returns the factory that this item was created by; casted as an IFlavour.
    /// </summary>
    public IFlavour FlavourFactory => (IFlavour)this;

    public override string GetVerboseDescription(Item item)
    {
        string s = "";
        if (item.IsKnown())
        {
            s += $" ({item.TypeSpecificValue} {Pluralize("charge", item.TypeSpecificValue)})";
        }
        s += base.GetVerboseDescription(item);
        return s;
    }
    public override string GetDescription(Item item, bool includeCountPrefix, bool isFlavourAware)
    {
        string flavour = item.IdentityIsStoreBought ? "" : $"{FlavourFactory.Flavor.Name} ";
        string ofName = isFlavourAware ? $" of {FriendlyName}" : "";
        string name = $"{flavour}{Pluralize("Wand", item.Count)}{ofName}";
        return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
    }

    public override int? GetBonusRealValue(Item item, int value)
    {
        return value / 20 * item.TypeSpecificValue;
    }

    /// <summary>
    /// Returns the want flavours repository because wands have flavours that need to be identified.
    /// </summary>
    public IEnumerable<Flavour>? GetFlavorRepository() => SaveGame.SingletonRepository.WandFlavours;

    /// <inheritdoc/>
    public Flavour Flavor { get; set; }
    public override int PercentageBreakageChance => 25;
    public override bool IsRechargable => true;

    public override int PackSort => 14;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Wand;
    public abstract bool ExecuteActivation(SaveGame saveGame, int dir);
    public override int BaseValue => 50;
    public override bool CanBeAimed => true;
    public override bool HatesElectricity => true;

    //public override bool IsCharged => true;
    public override ColorEnum Color => ColorEnum.Chartreuse;
}