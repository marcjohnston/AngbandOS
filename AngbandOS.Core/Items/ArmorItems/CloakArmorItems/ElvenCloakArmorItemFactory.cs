// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ElvenCloakArmorItemFactory : CloakArmorItemFactory
{
    private ElvenCloakArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '(';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "Elven Cloak";

    public override int Ac => 4;
    public override int[] Chance => new int[] { 4, 0, 0, 0 };
    public override int Cost => 1500;
    public override string FriendlyName => "& Elven Cloak~";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 30;
    public override int[] Locale => new int[] { 30, 0, 0, 0 };
    public override bool Search => true;
    public override bool Stealth => true;
    public override int? SubCategory => 2;
    public override int ToA => 4;
    public override int Weight => 5;
    public override Item CreateItem() => new ElvenCloakArmorItem(SaveGame);
}
