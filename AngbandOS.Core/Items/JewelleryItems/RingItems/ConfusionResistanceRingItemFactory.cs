// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ConfusionResistanceRingItemFactory : RingItemFactory
{
    private ConfusionResistanceRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '=';
    public override string Name => "Confusion Resistance";

    public override int[] Chance => new int[] { 2, 0, 0, 0 };
    public override int Cost => 3000;
    public override bool EasyKnow => true;
    public override string FriendlyName => "Confusion Resistance";
    public override int Level => 22;
    public override int[] Locale => new int[] { 22, 0, 0, 0 };
    public override bool ResConf => true;
    public override int? SubCategory => 43;
    public override int Weight => 2;
    public override Item CreateItem() => new ConfusionResistanceRingItem(SaveGame);
}
