// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class SwordBastardSword : SwordItemClass
{
    private SwordBastardSword(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Bastard Sword";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 350;
    public override int Dd => 3;
    public override int Ds => 4;
    public override string FriendlyName => "& Bastard Sword~";
    public override int Level => 15;
    public override int[] Locale => new int[] { 15, 0, 0, 0 };
    public override bool ShowMods => true;
    public override int Weight => 140;
    public override Item CreateItem() => new BastardSwordWeaponItem(SaveGame);
}
