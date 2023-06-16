// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ScrollRuneOfProtection : ScrollItemClass
{
    private ScrollRuneOfProtection(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '?';
    public override string Name => "Rune of Protection";

    public override int[] Chance => new int[] { 2, 4, 0, 0 };
    public override int Cost => 500;
    public override string FriendlyName => "Rune of Protection";
    public override int Level => 50;
    public override int[] Locale => new int[] { 50, 90, 0, 0 };
    public override int? SubCategory => 38;
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        eventArgs.SaveGame.ElderSign();
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new RuneOfProtectionScrollItem(SaveGame);
}
