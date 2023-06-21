// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class StaffHoliness : StaffItemClass
{
    private StaffHoliness(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '_';
    public override string Name => "Holiness";

    public override int[] Chance => new int[] { 2, 0, 0, 0 };
    public override int Cost => 4500;
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "Holiness";
    public override int Level => 70;
    public override int[] Locale => new int[] { 70, 0, 0, 0 };
    public override int Weight => 50;
    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (eventArgs.SaveGame.DispelEvil(120))
        {
            eventArgs.Identified = true;
        }
        int k = 3 * eventArgs.SaveGame.Player.Level;
        if (eventArgs.SaveGame.Player.TimedProtectionFromEvil.AddTimer(Program.Rng.DieRoll(25) + k))
        {
            eventArgs.Identified = true;
        }
        if (eventArgs.SaveGame.Player.TimedPoison.ResetTimer())
        {
            eventArgs.Identified = true;
        }
        if (eventArgs.SaveGame.Player.TimedFear.ResetTimer())
        {
            eventArgs.Identified = true;
        }
        if (eventArgs.SaveGame.Player.RestoreHealth(50))
        {
            eventArgs.Identified = true;
        }
        if (eventArgs.SaveGame.Player.TimedStun.ResetTimer())
        {
            eventArgs.Identified = true;
        }
        if (eventArgs.SaveGame.Player.TimedBleeding.ResetTimer())
        {
            eventArgs.Identified = true;
        }
    }
    public override Item CreateItem() => new HolinessStaffItem(SaveGame);
}
