// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class StaffCarnage : StaffItemClass
{
    private StaffCarnage(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UnderscoreSymbol>();
    public override string Name => "Carnage";

    public override int[] Chance => new int[] { 4, 0, 0, 0 };
    public override int Cost => 3500;
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "Carnage";
    public override int Level => 70;
    public override int[] Locale => new int[] { 70, 0, 0, 0 };
    public override int Weight => 50;
    public override void UseStaff(UseStaffEvent eventArgs)
    {
        eventArgs.SaveGame.Carnage(true);
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new CarnageStaffItem(SaveGame);
}
