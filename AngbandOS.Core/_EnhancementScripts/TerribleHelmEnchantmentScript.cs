﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class TerribleHelmEnchantmentScript : Script, IEnhancementScript
{
    private TerribleHelmEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.EnchantmentItemProperties.BonusArmorClass -= item.GetBonusValue(10, level);
        if (item.EnchantmentItemProperties.BonusArmorClass < 0)
        {
            item.EnchantmentItemProperties.IsCursed = true;
        }

        item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(HelmPoorItemEnhancementWeightedRandom)).ChooseOrDefault());
    }
}
