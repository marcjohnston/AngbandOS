// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class TerribleCrownEnchantmentScript : Script, IEnhancementScript
{
    private TerribleCrownEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass -= item.GetBonusValue(10, level);
        item.RareItem = Game.SingletonRepository.Get<RareItemWeightedRandom>(nameof(CrownPoorRareItemWeightedRandom)).ChooseOrDefault();
        if (item.BonusArmorClass < 0)
        {
            item.IsCursed = true;
        }
    }
}
