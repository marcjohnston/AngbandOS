// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class StaffSlowMonsters : StaffItemClass
{
    private StaffSlowMonsters(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '_';
    public override string Name => "Slow Monsters";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 800;
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "Slow Monsters";
    public override int Level => 10;
    public override int[] Locale => new int[] { 10, 0, 0, 0 };
    public override int? SubCategory => 21;
    public override int Weight => 50;
    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (eventArgs.SaveGame.SlowMonsters())
        {
            eventArgs.Identified = true;
        }
    }
    public override Item CreateItem() => new SlowMonstersStaffItem(SaveGame);
}
