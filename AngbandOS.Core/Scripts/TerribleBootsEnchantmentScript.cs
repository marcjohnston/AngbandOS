// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class TerribleBootsEnchantmentScript : Script, IEnhancementScript
{
    private TerribleBootsEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.Characteristics.BonusArmorClass -= item.GetBonusValue(10, level);
        switch (Game.DieRoll(3))
        {
            case 1:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(BootsOfNoiseRareItem));
                break;
            case 2:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(BootsOfSlownessRareItem));
                break;
            case 3:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(BootsOfAnnoyanceRareItem));
                break;
        }
        if (item.Characteristics.BonusArmorClass < 0)
        {
            item.IsCursed = true;
        }
    }
}
