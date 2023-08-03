// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Items;

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class AntiTeleportationAmuletJeweleryItemFactory : AmuletJeweleryItemFactory
{
    private AntiTeleportationAmuletJeweleryItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<DoubleQuoteSymbol>();
    public override string Name => "Anti-Teleportation";

    public override int[] Chance => new int[] { 4, 0, 0, 0 };
    public override int Cost => 15000;
    public override string FriendlyName => "Anti-Teleportation";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 30;
    public override int[] Locale => new int[] { 30, 0, 0, 0 };
    public override bool NoTele => true;
    public override int Weight => 3;

    public override Item CreateItem() => new AntiTeleportationAmuletJeweleryItem(SaveGame);
}
