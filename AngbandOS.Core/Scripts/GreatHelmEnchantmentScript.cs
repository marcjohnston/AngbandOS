// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class GreatHelmEnchantmentScript : Script, IEnhancementScript
{
    private GreatHelmEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.Characteristics.BonusArmorClass += item.GetBonusValue(10, level);

        if (Game.DieRoll(20) == 1)
        {
            item.CreateRandomArtifact(false);
        }
        else
        {
            switch (Game.DieRoll(14))
            {
                case 1:
                case 2:
                    item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(HatOfIntelligenceItemEnhancement));
                    break;
                case 3:
                case 4:
                    item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(HatOfWisdomItemEnhancement));
                    break;
                case 5:
                case 6:
                    item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(HatOfBeautyItemEnhancement));
                    break;
                case 7:
                case 8:
                    item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(HatOfSeeingItemEnhancement));
                    if (Game.DieRoll(7) == 1)
                    {
                        item.Characteristics.Telepathy = true;
                    }
                    break;
                case 9:
                case 10:
                    item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(HatOfLightItemEnhancement));
                    break;
                case 11:
                case 12:
                case 13:
                case 14:
                    item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(HatOfInfravisionItemEnhancement));
                    break;
            }
        }
    }
}
