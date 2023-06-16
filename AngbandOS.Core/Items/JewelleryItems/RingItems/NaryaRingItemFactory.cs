// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class NaryaRingItemFactory : RingItemFactory
{
    private NaryaRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '=';
    public override string Name => "Narya";

    public override int Cost => 100000;
    public override string FriendlyName => "& Ring~"; // TODO: This appears to cause a defect in identification
    public override bool InstaArt => true;
    public override int Level => 80;
    public override int? SubCategory => 34;
    public override int Weight => 2;
    public override Item CreateItem() => new NaryaRingItem(SaveGame);
}
