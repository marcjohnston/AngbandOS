// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ResistColdRingItemFactory : RingItemFactory
{
    private ResistColdRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(EqualSignSymbol));
    public override string Name => "Resist Cold";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 250;
    public override bool EasyKnow => true;
    public override string FriendlyName => "Resist Cold";
    public override bool IgnoreCold => true;
    public override int Level => 10;
    public override int[] Locale => new int[] { 10, 0, 0, 0 };
    public override bool ResCold => true;
    public override int Weight => 2;
    public override Item CreateItem() => new ResistColdRingItem(SaveGame);
}
