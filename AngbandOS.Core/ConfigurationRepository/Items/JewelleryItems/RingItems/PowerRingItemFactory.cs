// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class PowerRingItemFactory : RingItemFactory
{
    private PowerRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<EqualSignSymbol>();
    public override ColourEnum Colour => ColourEnum.Yellow;
    public override string Name => "Power";

    public override int Cost => 5000000;
    public override string FriendlyName => "Power";
    public override bool InstaArt => true;
    public override int Level => 110;
    public override int Weight => 2;
    public override Item CreateItem() => new PowerRingItem(SaveGame);
}