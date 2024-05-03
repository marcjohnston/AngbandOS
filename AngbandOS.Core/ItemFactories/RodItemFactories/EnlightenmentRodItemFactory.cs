// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class EnlightenmentRodItemFactory : RodItemFactory
{
    private EnlightenmentRodItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override bool RequiresAiming => false;
    protected override string SymbolName => nameof(MinusSignSymbol);
    public override string Name => "Enlightenment";

    public override int Cost => 10000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Enlightenment";
    public override int LevelNormallyFound => 65;
    public override int[] Chance => new int[] { 4, 0, 0, 0 };
    public override int[] Locale => new int[] { 65, 0, 0, 0 };
    public override int Weight => 15;
    public override int RodRechargeTime => 99;
    public override void Execute(ZapRodEvent zapRodEvent)
    {
        Game.RunScript(nameof(MapAreaScript));
        zapRodEvent.Identified = true;
        zapRodEvent.Item.RodRechargeTimeRemaining = RodRechargeTime;
    }
    public override Item CreateItem() => new Item(Game, this);
}
