// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class StarlightStaffItemFactory : StaffItemFactory
{
    private StarlightStaffItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UnderscoreSymbol));
    public override string Name => "Starlight";

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        item.TypeSpecificValue = SaveGame.DieRoll(5) + 6;
    }

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 800;
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "Starlight";
    public override int Level => 20;
    public override int[] Locale => new int[] { 20, 0, 0, 0 };
    public override int Weight => 50;

    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (SaveGame.TimedBlindness.TurnsRemaining == 0)
        {
            SaveGame.MsgPrint("The end of the staff glows brightly...");
        }
        for (int k = 0; k < 8; k++)
        {
            SaveGame.LightLine(SaveGame.OrderedDirection[k]);
        }
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}
