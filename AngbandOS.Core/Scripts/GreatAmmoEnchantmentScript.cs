// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class GreatAmmoEnchantmentScript : Script, IEnhancementScript
{
    private GreatAmmoEnchantmentScript(Game game) : base(game) { }

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
        switch (Game.DieRoll(12))
        {
            case 1:
            case 2:
            case 3:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(AmmoOfWoundingItemEnhancement));
                break;
            case 4:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(AmmoOfFlameItemEnhancement));
                break;
            case 5:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(AmmoOfFrostItemEnhancement));
                break;
            case 6:
            case 7:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(AmmoOfHurtAnimalItemEnhancement));
                break;
            case 8:
            case 9:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(AmmoOfHurtEvilItemEnhancement));
                break;
            case 10:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(AmmoOfHurtDragonItemEnhancement));
                break;
            case 11:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(AmmoOfShockingItemEnhancement));
                break;
            case 12:
                item.RareItem = Game.SingletonRepository.Get<ItemEnhancement>(nameof(AmmoOfSlayingItemEnhancement));
                item.DamageDice++;
                break;
        }
        while (Game.RandomLessThan(10 * item.DamageDice * item.DamageSides) == 0)
        {
            item.DamageDice++;
        }
        if (item.DamageDice > 9)
        {
            item.DamageDice = 9;
        }
    }
}
