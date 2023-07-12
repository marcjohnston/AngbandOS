// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class RestoringMushroomFoodItemFactory : MushroomFoodItemFactory
{
    private RestoringMushroomFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<CommaSymbol>();
    public override string Name => "Restoring";

    public override int[] Chance => new int[] { 8, 4, 1, 0 };
    public override int Cost => 1000;
    public override string FriendlyName => "Restoring";
    public override int Level => 20;
    public override int[] Locale => new int[] { 20, 30, 40, 0 };
    public override int Pval => 500;
    public override int Weight => 1;
    public override bool Eat()
    {
        SaveGame.PlaySound(SoundEffectEnum.Eat);
        bool ident = false;
        if (SaveGame.Player.TryRestoringAbilityScore(Ability.Strength))
        {
            ident = true;
        }
        if (SaveGame.Player.TryRestoringAbilityScore(Ability.Intelligence))
        {
            ident = true;
        }
        if (SaveGame.Player.TryRestoringAbilityScore(Ability.Wisdom))
        {
            ident = true;
        }
        if (SaveGame.Player.TryRestoringAbilityScore(Ability.Dexterity))
        {
            ident = true;
        }
        if (SaveGame.Player.TryRestoringAbilityScore(Ability.Constitution))
        {
            ident = true;
        }
        if (SaveGame.Player.TryRestoringAbilityScore(Ability.Charisma))
        {
            ident = true;
        }
        return ident;
    }
    public override Item CreateItem() => new RestoringMushroomFoodItem(SaveGame);
}
