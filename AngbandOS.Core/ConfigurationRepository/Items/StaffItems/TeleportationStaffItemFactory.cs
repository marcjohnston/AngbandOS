// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class TeleportationStaffItemFactory : StaffItemFactory
{
    private TeleportationStaffItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UnderscoreSymbol));
    public override string Name => "Teleportation";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 2000;
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "Teleportation";
    public override int Level => 20;
    public override int[] Locale => new int[] { 20, 0, 0, 0 };
    public override int Weight => 50;
    public override void UseStaff(UseStaffEvent eventArgs)
    {
        SaveGame.TeleportPlayer(100);
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new TeleportationStaffItem(SaveGame);
}