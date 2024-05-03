// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class ProbingRodItemFactory : RodItemFactory
{
    private ProbingRodItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override bool RequiresAiming => false;
    protected override string SymbolName => nameof(MinusSignSymbol);
    public override string Name => "Probing";

    public override int Cost => 4000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Probing";
    public override int LevelNormallyFound => 40;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (40, 4)
    };
    public override int Weight => 15;
    public override int RodRechargeTime => 50;
    public override void Execute(ZapRodEvent zapRodEvent)
    {
        Game.Probing();
        zapRodEvent.Identified = true;
        zapRodEvent.Item.RodRechargeTimeRemaining = RodRechargeTime;
    }
    public override Item CreateItem() => new Item(Game, this);
}
