// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ScrollRumour : ScrollItemClass
{
    private ScrollRumour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '?';
    public override string Name => "Rumour";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 10;
    public override string FriendlyName => "Rumour";
    public override int Level => 1;
    public override int[] Locale => new int[] { 1, 0, 0, 0 };
    public override int? SubCategory => 51;
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        eventArgs.SaveGame.MsgPrint("There is message on the scroll. It says:");
        eventArgs.SaveGame.MsgPrint(null);
        eventArgs.SaveGame.GetRumour();
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new RumourScrollItem(SaveGame);
}
