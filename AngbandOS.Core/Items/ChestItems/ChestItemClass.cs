// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class ChestItemClass : ItemFactory
{
    public ChestItemClass(SaveGame saveGame) : base(saveGame) { }
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Chest;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;

    /// <summary>
    /// Returns whether or not the chest is small.  Small chests have a 75% chance that the items in the chest are gold.  Large chest always return items.
    /// </summary>
    public abstract bool IsSmall { get; }
    public override int PackSort => 36;
    public abstract int NumberOfItemsContained { get; }

    public override ColourEnum Colour => ColourEnum.Grey;
}
