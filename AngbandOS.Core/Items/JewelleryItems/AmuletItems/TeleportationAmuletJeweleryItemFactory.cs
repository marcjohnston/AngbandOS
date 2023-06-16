// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class TeleportationAmuletJeweleryItemFactory : AmuletJeweleryItemFactory
{
    private TeleportationAmuletJeweleryItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '"';
    public override string Name => "Teleportation";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 250;
    public override bool Cursed => true;
    public override bool EasyKnow => true;
    public override string FriendlyName => "Teleportation";
    public override int Level => 15;
    public override int[] Locale => new int[] { 15, 0, 0, 0 };
    public override bool Teleport => true;
    public override int Weight => 3;
    public override Item CreateItem() => new TeleportationAmuletJeweleryItem(SaveGame);
}
