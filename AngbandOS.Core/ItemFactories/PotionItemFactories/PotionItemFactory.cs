// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class PotionItemFactory : ItemFactory
{
    public PotionItemFactory(Game game) : base(game) { }
    protected override string ItemClassName => nameof(PotionsItemClass);

    public override string GetDescription(Item item, bool includeCountPrefix, bool isFlavorAware)
    {
        string flavor = item.IdentityIsStoreBought ? "" : $"{Flavor.Name} ";
        string ofName = isFlavorAware ? $" of {FriendlyName}" : "";
        string name = $"{flavor}{Game.CountPluralize("Potion", item.Count)}{ofName}";
        return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
    }

    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (60, "3d5-3"),
        (240, "1d5-1")
    };

    public override int PercentageBreakageChance => 100;
    public override bool CanBeQuaffed => true;

    public override bool EasyKnow => true;
    public override int PackSort => 11;

    /// <summary>
    /// Activates the potion effect and returns true, if the effect is noticed; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public abstract bool Quaff();

    /// <summary>
    /// Perform a smash effect for the potion.
    /// </summary>
    /// <param name="game"></param>
    /// <param name="who"></param>
    /// <param name="y"></param>
    /// <param name="x"></param>
    /// <returns>Returns whether or not the action causes pets to become angry and turn against their owner.  Returns false, by default.</returns>
    public virtual bool Smash(int who, int y, int x)
    {
        return false;
    }

    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Potion;
    public override int BaseValue => 20;
    public override bool HatesCold => true;
    public override ColorEnum Color => ColorEnum.Blue;

}
