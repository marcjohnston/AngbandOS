// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class PerceptionRodItemFactory : RodItemFactory
{
    private PerceptionRodItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override bool RequiresAiming => false;
    protected override string SymbolName => nameof(MinusSignSymbol);
    public override string Name => "Perception";

    public override int[] Chance => new int[] { 8, 8, 0, 0 };
    public override int Cost => 13000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Perception";
    public override int LevelNormallyFound => 50;
    public override int[] Locale => new int[] { 50, 100, 0, 0 };
    public override int Weight => 15;
    public override int RodRechargeTime => 10;
    public override void Execute(ZapRodEvent zapRodEvent)
    {
        zapRodEvent.Identified = true;
        if (!Game.RunSuccessfulScript(nameof(IdentifyItemScript)))
        {
            zapRodEvent.UseCharge = false;
        }
        zapRodEvent.Item.RodRechargeTimeRemaining = RodRechargeTime;
    }
    public override Item CreateItem() => new Item(Game, this);
}
