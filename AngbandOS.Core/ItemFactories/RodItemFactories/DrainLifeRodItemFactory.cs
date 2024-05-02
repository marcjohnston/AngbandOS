// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DrainLifeRodItemFactory : RodItemFactory
{
    private DrainLifeRodItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override bool RequiresAiming => true;
    protected override string SymbolName => nameof(MinusSignSymbol);
    public override string Name => "Drain Life";

    public override int[] Chance => new int[] { 4, 0, 0, 0 };
    public override int Cost => 3600;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Drain Life";
    public override int LevelNormallyFound => 75;
    public override int[] Locale => new int[] { 75, 0, 0, 0 };
    public override int Weight => 15;
    public override int RodRechargeTime => 23;
    public override void Execute(ZapRodEvent zapRodEvent)
    {
        if (Game.DrainLife(zapRodEvent.Dir.Value, 75))
        {
            zapRodEvent.Identified = true;
        }
        zapRodEvent.Item.RodRechargeTimeRemaining = RodRechargeTime;
    }
    public override Item CreateItem() => new Item(Game, this);
}
