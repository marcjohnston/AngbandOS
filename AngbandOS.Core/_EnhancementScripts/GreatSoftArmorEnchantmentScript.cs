// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class GreatSoftArmorEnchantmentScript : Script, IEnhancementScript
{
    private GreatSoftArmorEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.EffectivePropertySet.BonusArmorClass += item.GetBonusValue(10, level);

        switch (Game.DieRoll(21))
        {
            case 1:
            case 2:
            case 3:
            case 4:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(ArmorOfResistAcidItemEnhancement)));
                break;
            case 5:
            case 6:
            case 7:
            case 8:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(ArmorOfResistLightningItemEnhancement)));
                break;
            case 9:
            case 10:
            case 11:
            case 12:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(ArmorOfResistFireItemEnhancement)));
                break;
            case 13:
            case 14:
            case 15:
            case 16:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(ArmorOfResistColdItemEnhancement)));
                break;
            case 17:
            case 18:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(ArmorOfResistanceItemEnhancement)));
                if (Game.DieRoll(4) == 1)
                {
                    item.EffectivePropertySet.ResPois = true;
                }
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(FixedArtifactItemEnhancementWeightedRandom)));
                break;
            case 19:
                item.CreateRandomArtifact(false);
                break;
            case 20:
            case 21:
                item.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(ArmorOfYithItemEnhancement)));
                break;
        }
    }
}
