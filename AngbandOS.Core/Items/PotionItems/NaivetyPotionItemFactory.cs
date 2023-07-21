// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class NaivetyPotionItemFactory : PotionItemFactory
{
    private NaivetyPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<ExclamationPointSymbol>();
    public override string Name => "Naivety";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Naivety";
    public override int Level => 20;
    public override int[] Locale => new int[] { 20, 0, 0, 0 };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Naivety tries to reduce your wisdom
        return SaveGame.Player.TryDecreasingAbilityScore(Ability.Wisdom);
    }
    public override bool Smash(int who, int y, int x)
    {
        return true;
    }
    public override Item CreateItem() => new NaivetyPotionItem(SaveGame);
}
