﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class PoorBootsEnchantmentScript : Script, IEnhancementScript
{
    private PoorBootsEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.Characteristics.BonusArmorClass -= Game.DieRoll(5) + item.GetBonusValue(5, level);
        if (item.Characteristics.BonusArmorClass < 0)
        {
            item.IsCursed = true;
        }
    }
}