// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class CuringStaffItemFactory : StaffItemFactory
{
    private CuringStaffItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UnderscoreSymbol));
    public override string Name => "Curing";

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        item.TypeSpecificValue = SaveGame.DieRoll(3) + 4;
    }

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 1000;
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "Curing";
    public override int LevelNormallyFound => 25;
    public override int[] Locale => new int[] { 25, 0, 0, 0 };
    public override int Weight => 50;

    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (SaveGame.TimedBlindness.ResetTimer())
        {
            eventArgs.Identified = true;
        }
        if (SaveGame.TimedPoison.ResetTimer())
        {
            eventArgs.Identified = true;
        }
        if (SaveGame.TimedConfusion.ResetTimer())
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
        if (SaveGame.TimedHallucinations.ResetTimer())
        {
            eventArgs.Identified = true;
        }
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}
