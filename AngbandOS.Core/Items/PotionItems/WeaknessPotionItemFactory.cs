// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class WeaknessPotionItemFactory : PotionItemFactory
{
    private WeaknessPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '!';
    public override string Name => "Weakness";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Dd => 3;
    public override int Ds => 12;
    public override string FriendlyName => "Weakness";
    public override int Level => 3;
    public override int[] Locale => new int[] { 3, 0, 0, 0 };
    public override int Weight => 4;
    public override bool Quaff(SaveGame saveGame)
    {
        // Weakness tries to reduce your strength
        return saveGame.Player.TryDecreasingAbilityScore(Ability.Strength);
    }
    public override bool Smash(SaveGame saveGame, int who, int y, int x)
    {
        return true;
    }
    public override Item CreateItem() => new WeaknessPotionItem(SaveGame);
}
