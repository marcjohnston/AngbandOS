// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class GreatRangedWeaponEnchantmentScript : Script, IEnhancementScript
{
    private GreatRangedWeaponEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        switch (Game.DieRoll(21))
        {
            case 1:
            case 11:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(BowOfExtraMightItemEnhancement));
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(ResistanceAndBiasItemEnhancementWeightedRandom)));
                break;
            case 2:
            case 12:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(BowOfExtraShotsItemEnhancement));
                break;
            case 3:
            case 4:
            case 5:
            case 6:
            case 13:
            case 14:
            case 15:
            case 16:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(BowOfVelocityItemEnhancement));
                break;
            case 7:
            case 8:
            case 9:
            case 10:
            case 17:
            case 18:
            case 19:
            case 20:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(BowOfAccuracyItemEnhancement));
                break;
            case 21:
                item.CreateRandomArtifact(false);
                break;
        }
    }
}
