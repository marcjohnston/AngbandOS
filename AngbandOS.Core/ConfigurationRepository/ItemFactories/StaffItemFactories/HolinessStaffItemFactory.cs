// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class HolinessStaffItemFactory : StaffItemFactory
{
    private HolinessStaffItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UnderscoreSymbol));
    public override string Name => "Holiness";

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        item.TypeSpecificValue = SaveGame.DieRoll(2) + 2;
    }
    public override int[] Chance => new int[] { 2, 0, 0, 0 };
    public override int Cost => 4500;
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "Holiness";
    public override int LevelNormallyFound => 70;
    public override int[] Locale => new int[] { 70, 0, 0, 0 };
    public override int Weight => 50;
    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (SaveGame.RunSuccessfulScriptInt(nameof(DispelEvilScript), 120))
        {
            eventArgs.Identified = true;
        }
        int k = 3 * SaveGame.ExperienceLevel;
        if (SaveGame.TimedProtectionFromEvil.AddTimer(SaveGame.DieRoll(25) + k))
        {
            eventArgs.Identified = true;
        }
        if (SaveGame.TimedPoison.ResetTimer())
        {
            eventArgs.Identified = true;
        }
        if (SaveGame.TimedFear.ResetTimer())
        {
            eventArgs.Identified = true;
        }
        if (SaveGame.RestoreHealth(50))
        {
            eventArgs.Identified = true;
        }
        if (SaveGame.TimedStun.ResetTimer())
        {
            eventArgs.Identified = true;
        }
        if (SaveGame.TimedBleeding.ResetTimer())
        {
            eventArgs.Identified = true;
        }
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}
