// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class LordlyProtectionRingItemFactory : RingItemFactory
{
    private LordlyProtectionRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(EqualSignSymbol));
    public override string Name => "Lordly Protection";

    public override int[] Chance => new int[] { 5, 0, 0, 0 };
    public override int Cost => 100000;
    public override bool FreeAct => true;
    public override string FriendlyName => "Lordly Protection";
    public override bool HoldLife => true;
    public override int Level => 100;
    public override int[] Locale => new int[] { 100, 0, 0, 0 };
    public override bool ResDisen => true;
    public override bool ResPois => true;
    public override int Weight => 2;
    public override Item CreateItem() => new LordlyProtectionRingItem(SaveGame);
}
