// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ResistanceAmuletJeweleryItemFactory : AmuletJeweleryItemFactory
{
    private ResistanceAmuletJeweleryItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '"';
    public override string Name => "Resistance";

    public override int[] Chance => new int[] { 4, 0, 0, 0 };
    public override int Cost => 25000;
    public override string FriendlyName => "Resistance";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 50;
    public override int[] Locale => new int[] { 50, 0, 0, 0 };
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override int Weight => 3;
    public override bool KindIsGood => true;
    public override Item CreateItem() => new ResistanceAmuletJeweleryItem(SaveGame);
}
