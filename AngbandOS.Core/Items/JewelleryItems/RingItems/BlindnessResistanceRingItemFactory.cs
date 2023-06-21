// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class BlindnessResistanceRingItemFactory : RingItemFactory
{
    private BlindnessResistanceRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '=';
    public override string Name => "Blindness Resistance";

    public override int[] Chance => new int[] { 2, 0, 0, 0 };
    public override int Cost => 7500;
    public override bool EasyKnow => true;
    public override string FriendlyName => "Blindness Resistance";
    public override int Level => 60;
    public override int[] Locale => new int[] { 60, 0, 0, 0 };
    public override bool ResBlind => true;
    public override int Weight => 2;
    public override Item CreateItem() => new BlindnessResistanceRingItem(SaveGame);
}
