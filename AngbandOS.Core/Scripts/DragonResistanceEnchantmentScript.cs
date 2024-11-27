// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DragonResistanceEnchantmentScript : Script, IEnhancementScript
{
    private DragonResistanceEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        do
        {
            if (Game.DieRoll(4) == 1)
            {
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(NaturalAndPoisonResistanceItemEnhancementWeightedRandom)));
            }
            else
            {
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(FixedArtifactEnhancementBundleWeightedRandom)));
            }
        } while (Game.DieRoll(2) == 1);
    }
}
