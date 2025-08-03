// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class GreatGlovesEnchantmentScript : Script, IEnhancementScript
{
    private GreatGlovesEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.EffectivePropertySet.BonusArmorClass += item.GetBonusValue(10, level);

        if (Game.DieRoll(20) == 1)
        {
            item.CreateRandomArtifact(false);
        }
        else
        {
            switch (Game.DieRoll(10))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(GlovesOfFreeActionItemEnhancement)));
                    break;
                case 5:
                case 6:
                case 7:
                    item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(GlovesOfSlayingItemEnhancement)));
                    break;
                case 8:
                case 9:
                    item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(GlovesOfAgilityItemEnhancement)));
                    break;
                case 10:
                    item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(GlovesOfPowerItemEnhancement)));
                    item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(FixedArtifactItemEnhancementWeightedRandom)));
                    break;
            }
        }
    }
}
