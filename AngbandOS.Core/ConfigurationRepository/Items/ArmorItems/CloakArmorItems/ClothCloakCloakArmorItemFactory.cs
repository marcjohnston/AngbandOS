// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ClothCloakCloakArmorItemFactory : CloakArmorItemFactory
{
    private ClothCloakCloakArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(OpenParenthesisSymbol));
    public override ColourEnum Colour => ColourEnum.Green;
    public override string Name => "Cloak";

    public override int Ac => 1;
    public override int[] Chance => new int[] { 1, 1, 0, 0 };
    public override int Cost => 3;
    public override string FriendlyName => "& Cloak~";
    public override int Level => 1;
    public override int[] Locale => new int[] { 1, 20, 0, 0 };
    public override int Weight => 10;
    public override Item CreateItem() => new ClothCloakCloakArmorItem(SaveGame);
}
