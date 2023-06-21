// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ShadowCloakArmorItemFactory : CloakArmorItemFactory
{
    private ShadowCloakArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '(';
    public override Colour Colour => Colour.Black;
    public override string Name => "Shadow Cloak";

    public override int Ac => 6;
    public override int[] Chance => new int[] { 5, 0, 0, 0 };
    public override int Cost => 7500;
    public override string FriendlyName => "& Shadow Cloak~";
    public override int Level => 60;
    public override int[] Locale => new int[] { 75, 0, 0, 0 };
    public override bool ResDark => true;
    public override bool ResLight => true;
    public override int ToA => 4;
    public override int Weight => 5;
    public override Item CreateItem() => new ShadowCloakArmorItem(SaveGame);
}
