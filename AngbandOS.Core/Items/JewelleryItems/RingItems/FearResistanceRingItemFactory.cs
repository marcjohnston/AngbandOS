// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class FearResistanceRingItemFactory : RingItemFactory
{
    private FearResistanceRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '=';
    public override string Name => "Fear Resistance";

    public override int[] Chance => new int[] { 2, 0, 0, 0 };
    public override int Cost => 300;
    public override bool EasyKnow => true;
    public override string FriendlyName => "Fear Resistance";
    public override int Level => 10;
    public override int[] Locale => new int[] { 10, 0, 0, 0 };
    public override bool ResFear => true;
    public override int Weight => 2;
    public override Item CreateItem() => new FearResistanceRingItem(SaveGame);
}
