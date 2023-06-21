// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class AggravateMonsterRingItemFactory : RingItemFactory
{
    private AggravateMonsterRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '=';
    public override string Name => "Aggravate Monster";

    public override bool Aggravate => true;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override bool Cursed => true;
    public override bool EasyKnow => true;
    public override string FriendlyName => "Aggravate Monster";
    public override int Level => 5;
    public override int[] Locale => new int[] { 5, 0, 0, 0 };
    public override int Weight => 2;
    public override Item CreateItem() => new AggravateMonsterRingItem(SaveGame);
}
