// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ScrollSpecialAcquirement : ScrollItemClass
{
    private ScrollSpecialAcquirement(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '?';
    public override string Name => "*Acquirement*";

    public override int[] Chance => new int[] { 16, 0, 0, 0 };
    public override int Cost => 200000;
    public override string FriendlyName => "*Acquirement*";
    public override int Level => 60;
    public override int[] Locale => new int[] { 60, 0, 0, 0 };
    public override int? SubCategory => 47;
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        eventArgs.SaveGame.Level.Acquirement(eventArgs.SaveGame.Player.MapY, eventArgs.SaveGame.Player.MapX, Program.Rng.DieRoll(2) + 1, true);
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new SpecialAcquirementScrollItem(SaveGame);
}
