// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class SustainWisdomRingItemFactory : RingItemFactory
{
    private SustainWisdomRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<EqualSignSymbol>();
    public override string Name => "Sustain Wisdom";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 600;
    public override bool EasyKnow => true;
    public override string FriendlyName => "Sustain Wisdom";
    public override int Level => 30;
    public override int[] Locale => new int[] { 30, 0, 0, 0 };
    public override bool SustWis => true;
    public override int Weight => 2;
    public override Item CreateItem() => new SustainWisdomRingItem(SaveGame);
}