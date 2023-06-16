// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class RestoreIntelligencePotionItemFactory : PotionItemFactory
{
    private RestoreIntelligencePotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '!';
    public override string Name => "Restore Intelligence";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 300;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Restore Intelligence";
    public override int Level => 25;
    public override int[] Locale => new int[] { 25, 0, 0, 0 };
    public override int? SubCategory => (int)PotionType.ResInt;
    public override int Weight => 4;
    public override bool Quaff(SaveGame saveGame)
    {
        // Restore intelligence restores your intelligence
        return saveGame.Player.TryRestoringAbilityScore(Ability.Intelligence);
    }
    public override Item CreateItem() => new RestoreIntelligencePotionItem(SaveGame);
}
