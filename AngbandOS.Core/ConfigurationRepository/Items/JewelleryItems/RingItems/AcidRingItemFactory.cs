// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class AcidRingItemFactory : RingItemFactory
{
    private AcidRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override string? DescribeActivationEffect => "ball of acid and resist acid";
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<EqualSignSymbol>();
    public override string Name => "Acid";

    public override bool Activate => true;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 3000;
    public override string FriendlyName => "Acid";
    public override bool IgnoreAcid => true;
    public override int Level => 50;
    public override int[] Locale => new int[] { 50, 0, 0, 0 };
    public override bool ResAcid => true;
    public override int ToA => 15;
    public override int Weight => 2;
    public override Item CreateItem() => new AcidRingItem(SaveGame);
}
