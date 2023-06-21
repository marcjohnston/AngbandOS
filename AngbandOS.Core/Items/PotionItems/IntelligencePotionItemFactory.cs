// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class IntelligencePotionItemFactory : PotionItemFactory
{
    private IntelligencePotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '!';
    public override string Name => "Intelligence";

    public override int[] Chance => new int[] { 6, 3, 1, 0 };
    public override int Cost => 8000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Intelligence";
    public override int Level => 20;
    public override int[] Locale => new int[] { 20, 25, 30, 0 };
    public override int Weight => 4;
    public override bool Quaff(SaveGame saveGame)
    {
        // Intelligence increases your intelligence
        return saveGame.Player.TryIncreasingAbilityScore(Ability.Intelligence);
    }
    public override Item CreateItem() => new IntelligencePotionItem(SaveGame);
}
