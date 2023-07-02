// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class AugmentationPotionItemFactory : PotionItemFactory
{
    private AugmentationPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<ExclamationPointSymbol>();
    public override string Name => "Augmentation";

    public override int[] Chance => new int[] { 16, 0, 0, 0 };
    public override int Cost => 60000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Augmentation";
    public override int Level => 40;
    public override int[] Locale => new int[] { 40, 0, 0, 0 };
    public override int Weight => 4;
    public override bool Quaff(SaveGame saveGame)
    {
        bool identified = false;

        // Augmentation increases all ability scores
        if (saveGame.Player.TryIncreasingAbilityScore(Ability.Strength))
        {
            identified = true;
        }
        if (saveGame.Player.TryIncreasingAbilityScore(Ability.Intelligence))
        {
            identified = true;
        }
        if (saveGame.Player.TryIncreasingAbilityScore(Ability.Wisdom))
        {
            identified = true;
        }
        if (saveGame.Player.TryIncreasingAbilityScore(Ability.Dexterity))
        {
            identified = true;
        }
        if (saveGame.Player.TryIncreasingAbilityScore(Ability.Constitution))
        {
            identified = true;
        }
        if (saveGame.Player.TryIncreasingAbilityScore(Ability.Charisma))
        {
            identified = true;
        }

        return identified;
    }
    public override Item CreateItem() => new AugmentationPotionItem(SaveGame);
}
