// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Interface.Definitions;

public class StoreStockManifestDefinition
{
    public virtual string ItemFactoryName { get; set; }
    public virtual int Weight { get; set; }

    public StoreStockManifestDefinition() { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="itemFactoryName"></param>
    /// <param name="weight">Specify the weight for the item.  A value of 0, means the item cannot be selected.  
    /// All item weights are summed to provide a full 1-in-chance of selected.</param>
    public StoreStockManifestDefinition(string itemFactoryName, int weight = 1)
    {
        ItemFactoryName = itemFactoryName;
        Weight = weight;
    }
}