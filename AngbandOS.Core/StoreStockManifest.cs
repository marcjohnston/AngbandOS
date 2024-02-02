// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class StoreStockManifest
{
    public ItemFactory ItemFactory { get; }
    public int Weight { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="itemFactory"></param>
    /// <param name="weight">Specify the weight for the item.  A value of 0, means the item cannot be selected.  
    /// All item weights are summed to provide a full 1-in-chance of selected.</param>
    public StoreStockManifest(ItemFactory itemFactory, int weight = 1)
    {
        ItemFactory = itemFactory;
        Weight = weight;
    }
}