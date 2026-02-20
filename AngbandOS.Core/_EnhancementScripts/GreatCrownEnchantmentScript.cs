// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Reflection.PortableExecutable;

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class GreatCrownEnchantmentScript : Script, IEnhancementScript
{
    private GreatCrownEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.EffectiveAttributeSet.BonusArmorClass += item.GetBonusValue(10, level);
        if (Game.DieRoll(20) == 1)
        {
            item.CreateRandomArtifact(false);
        }
        else
        {
            switch (Game.DieRoll(8))
            {
                case 1:
                    item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(HatOfTheMagiItemEnhancement)));
                    item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(FixedArtifactItemEnhancementWeightedRandom)));
                    break;
                case 2:
                    item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(HatOfMightItemEnhancement)));
                    item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(FixedArtifactItemEnhancementWeightedRandom)));
                    break;
                case 3:
                    item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(HatOfTelepathyItemEnhancement)));
                    break;
                case 4:
                    item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(HatOfRegenerationItemEnhancement)));
                    break;
                case 5:
                case 6:
                    item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(HatOfLordlinessItemEnhancement)));
                    item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(FixedArtifactItemEnhancementWeightedRandom)));
                    break;
                case 7:
                case 8:
                    item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(HatOfSeeingItemEnhancement)));
                    if (Game.DieRoll(3) == 1)
                    {
                        item.EffectiveAttributeSet.Telepathy = true;
                    }
                    break;
            }
        }
    }
}
