// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class LordlyProtectionRingItemFactory : RingItemFactory
{
    private LordlyProtectionRingItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(EqualSignSymbol);
    public override string Name => "Lordly Protection";

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        IArtifactBias artifactBias = null;
        do
        {
            item.ApplyRandomResistance(ref artifactBias, Game.DieRoll(20) + 18);
        } while (Game.DieRoll(4) == 1);
        item.BonusArmorClass = 10 + Game.DieRoll(5) + item.GetBonusValue(10, level);
        Game.TreasureRating += 5;
    }
    public override int[] Chance => new int[] { 5, 0, 0, 0 };
    public override int Cost => 100000;
    public override bool FreeAct => true;
    public override string FriendlyName => "Lordly Protection";
    public override bool HoldLife => true;
    public override int LevelNormallyFound => 100;
    public override int[] Locale => new int[] { 100, 0, 0, 0 };
    public override bool ResDisen => true;
    public override bool ResPois => true;
    public override int Weight => 2;
    public override Item CreateItem() => new Item(Game, this);
}
