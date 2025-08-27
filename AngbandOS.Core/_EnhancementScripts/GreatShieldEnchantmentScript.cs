// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class GreatShieldEnchantmentScript : Script, IEnhancementScript
{
    private GreatShieldEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.EffectivePropertySet.BonusArmorClass += item.GetBonusValue(10, level);

        switch (Game.DieRoll(23))
        {
            case 1:
            case 11:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(ShieldOfResistAcidItemEnhancement)));
                break;
            case 2:
            case 3:
            case 4:
            case 12:
            case 13:
            case 14:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(ShieldOfResistLightningItemEnhancement)));
                break;
            case 5:
            case 6:
            case 15:
            case 16:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(ShieldOfResistFireItemEnhancement)));
                break;
            case 7:
            case 8:
            case 9:
            case 17:
            case 18:
            case 19:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(ShieldOfResistColdItemEnhancement)));
                break;
            case 10:
            case 20:
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(ResistanceAndBiasItemEnhancementWeightedRandom)));
                if (Game.DieRoll(4) == 1)
                {
                    item.EffectivePropertySet.SetBoolAttributeValue(AttributeEnum.ResPois, true);
                }
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(ShieldOfResistanceItemEnhancement)));
                break;
            case 21:
            case 22:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(ShieldOfReflectionItemEnhancement)));
                break;
            case 23:
                item.CreateRandomArtifact(false);
                break;
        }
    }
}
