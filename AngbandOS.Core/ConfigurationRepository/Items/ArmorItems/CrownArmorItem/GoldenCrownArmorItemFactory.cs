// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class GoldenCrownArmorItemFactory : CrownArmorItemFactory
{
    private GoldenCrownArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<CloseBraceSymbol>();
    public override ColourEnum Colour => ColourEnum.Gold;
    public override string Name => "Golden Crown";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 1000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "& Golden Crown~";
    public override bool IgnoreAcid => true;
    public override int Level => 45;
    public override int[] Locale => new int[] { 45, 0, 0, 0 };
    public override int Weight => 30;
    public override Item CreateItem() => new GoldenCrownArmorItem(SaveGame);
}
