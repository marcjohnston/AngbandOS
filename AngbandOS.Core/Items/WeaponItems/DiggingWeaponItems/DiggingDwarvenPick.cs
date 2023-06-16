// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class DiggingDwarvenPick : DiggingItemClass
{
    private DiggingDwarvenPick(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '\\';
    public override Colour Colour => Colour.Blue;
    public override string Name => "Dwarven Pick";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 600;
    public override int Dd => 1;
    public override int Ds => 4;
    public override string FriendlyName => "& Dwarven Pick~";
    public override int Level => 50;
    public override int[] Locale => new int[] { 50, 0, 0, 0 };
    public override int Pval => 3;
    public override bool ShowMods => true;
    public override bool Tunnel => true;
    public override int Weight => 200;
    public override Item CreateItem() => new DwarvenPickDiggingWeaponItem(SaveGame);
}
