// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class RestoreLifeLevelsPotionItemFactory : PotionItemFactory
{
    private RestoreLifeLevelsPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<ExclamationPointSymbol>();
    public override string Name => "Restore Life Levels";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 400;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Restore Life Levels";
    public override int Level => 40;
    public override int[] Locale => new int[] { 40, 0, 0, 0 };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Restore life levels restores any lost experience
        return SaveGame.RestoreLevel();
    }
    public override Item CreateItem() => new RestoreLifeLevelsPotionItem(SaveGame);
}