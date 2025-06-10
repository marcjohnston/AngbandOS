// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class GreatBootsEnchantmentScript : Script, IEnhancementScript
{
    private GreatBootsEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.EnchantmentItemProperties.BonusArmorClass += item.GetBonusValue(10, level);
        if (Game.DieRoll(20) == 1)
        {
            item.CreateRandomArtifact(false);
        }
        else
        {
            switch (Game.DieRoll(24))
            {
                case 1:
                    item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(BootsOfSpeedItemEnhancement));
                    break;
                case 2:
                case 3:
                case 4:
                case 5:
                    item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(BootsOfFreeActionItemEnhancement));
                    break;
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                    item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(BootsOfStealthItemEnhancement));
                    break;
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                    item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(BootsWingedItemEnhancement));
                    if (Game.DieRoll(2) == 1)
                    {
                        item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(FixedArtifactItemEnhancementWeightedRandom)));
                    }
                    break;
            }
        }
    }
}
