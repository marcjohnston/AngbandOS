// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class EnlightenmentPotionItemFactory : PotionItemFactory
{
    private EnlightenmentPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<ExclamationPointSymbol>();
    public override string Name => "Enlightenment";

    public override int[] Chance => new int[] { 1, 1, 1, 0 };
    public override int Cost => 800;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Enlightenment";
    public override int Level => 25;
    public override int[] Locale => new int[] { 25, 50, 100, 0 };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Enlightenment shows you the whole level
        SaveGame.MsgPrint("An image of your surroundings forms in your mind...");
        SaveGame.WizLight();
        return true;
    }
    public override Item CreateItem() => new EnlightenmentPotionItem(SaveGame);
}