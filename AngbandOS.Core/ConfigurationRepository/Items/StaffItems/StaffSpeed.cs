// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class StaffSpeed : StaffItemClass
{
    private StaffSpeed(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UnderscoreSymbol>();
    public override string Name => "Speed";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 1000;
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "Speed";
    public override int Level => 40;
    public override int[] Locale => new int[] { 40, 0, 0, 0 };
    public override int Weight => 50;

    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (SaveGame.TimedHaste.TurnsRemaining == 0)
        {
            if (SaveGame.TimedHaste.SetTimer(SaveGame.Rng.DieRoll(30) + 15))
            {
                eventArgs.Identified = true;
            }
        }
        else
        {
            SaveGame.TimedHaste.AddTimer(5);
        }
    }
    public override Item CreateItem() => new SpeedStaffItem(SaveGame);
}