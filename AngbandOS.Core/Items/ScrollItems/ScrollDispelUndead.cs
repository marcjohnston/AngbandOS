// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ScrollDispelUndead : ScrollItemClass
{
    private ScrollDispelUndead(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '?';
    public override string Name => "Dispel Undead";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 200;
    public override string FriendlyName => "Dispel Undead";
    public override int Level => 40;
    public override int[] Locale => new int[] { 40, 0, 0, 0 };
    public override int? SubCategory => 42;
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        if (eventArgs.SaveGame.DispelUndead(60))
        {
            eventArgs.Identified = true;
        }
    }
    public override Item CreateItem() => new DispelUndeadScrollItem(SaveGame);
}
