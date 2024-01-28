// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal abstract class DragonScaleMailArmorItem : ArmorItem
{
    public DragonScaleMailArmorItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }

    /// <summary>
    /// Applies special magic to dragon scale mail armor.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="level"></param>
    /// <param name="power"></param>
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        if (power != 0)
        {
            // Apply the standard armor characteristics.
            base.ApplyMagic(level, power, null);

            SaveGame.TreasureRating += 30;
        }
    }
}