// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class SteelBoltAmmunitionItemFactory : BoltAmmunitionItemFactory
{
    private SteelBoltAmmunitionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<OpenBracketSymbol>();
    public override ColourEnum Colour => ColourEnum.Grey;
    public override string Name => "Bolt";

    public override int[] Chance => new int[] { 1, 1, 0, 0 };
    public override int Cost => 2;
    public override int Dd => 1;
    public override int Ds => 5;
    public override string FriendlyName => "& Bolt~";
    public override int Level => 3;
    public override int[] Locale => new int[] { 3, 25, 0, 0 };
    public override bool ShowMods => true;
    public override int Weight => 3;
    public override Item CreateItem() => new SteelBoltAmmunitionItem(SaveGame);
}
