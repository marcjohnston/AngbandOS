namespace AngbandOS.Core.Items;

[Serializable]
internal abstract class DragonScaleMailArmorItem : ArmourItem
{
    public DragonScaleMailArmorItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
    public override int WieldSlot => InventorySlot.Body;

    public abstract void DoActivate();

    /// <summary>
    /// Applies special magic to dragon scale mail armour.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="level"></param>
    /// <param name="power"></param>
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        if (power != 0)
        {
            // Apply the standard armour characteristics.
            base.ApplyMagic(level, power, null);

            if (SaveGame.Level != null)
            {
                SaveGame.Level.TreasureRating += 30;
            }
        }
    }
}