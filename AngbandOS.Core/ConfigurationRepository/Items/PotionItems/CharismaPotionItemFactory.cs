// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class CharismaPotionItemFactory : PotionItemFactory
{
    private CharismaPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<ExclamationPointSymbol>();
    public override string Name => "Charisma";

    public override int[] Chance => new int[] { 1, 1, 0, 0 };
    public override int Cost => 1000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Charisma";
    public override int Level => 20;
    public override int[] Locale => new int[] { 20, 25, 0, 0 };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Charisma increases your charisma
        return SaveGame.TryIncreasingAbilityScore(Ability.Charisma);
    }
    public override bool Smash(int who, int y, int x)
    {
        return true;
    }
    public override Item CreateItem() => new CharismaPotionItem(SaveGame);
}