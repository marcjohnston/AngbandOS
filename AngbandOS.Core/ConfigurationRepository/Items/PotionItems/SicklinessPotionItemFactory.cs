// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class SicklinessPotionItemFactory : PotionItemFactory
{
    private SicklinessPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<ExclamationPointSymbol>();
    public override string Name => "Sickliness";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Sickliness";
    public override int Level => 10;
    public override int[] Locale => new int[] { 10, 0, 0, 0 };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Sickliness tries to reduce your constitution
        return SaveGame.TryDecreasingAbilityScore(Ability.Constitution);
    }
    public override bool Smash(int who, int y, int x)
    {
        return true;
    }
    public override Item CreateItem() => new SicklinessPotionItem(SaveGame);
}