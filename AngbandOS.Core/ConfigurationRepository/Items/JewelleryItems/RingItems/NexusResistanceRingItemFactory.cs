// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class NexusResistanceRingItemFactory : RingItemFactory
{
    private NexusResistanceRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(EqualSignSymbol));
    public override string Name => "Nexus Resistance";

    public override int[] Chance => new int[] { 2, 0, 0, 0 };
    public override int Cost => 3000;
    public override bool EasyKnow => true;
    public override string FriendlyName => "Nexus Resistance";
    public override int Level => 24;
    public override int[] Locale => new int[] { 24, 0, 0, 0 };
    public override bool ResNexus => true;
    public override int Weight => 2;
    public override Item CreateItem() => new NexusResistanceRingItem(SaveGame);
}
