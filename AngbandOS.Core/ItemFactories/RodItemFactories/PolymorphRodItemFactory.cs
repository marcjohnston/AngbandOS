// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class PolymorphRodItemFactory : RodItemFactory
{
    private PolymorphRodItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override bool RequiresAiming => true;
    public override Symbol Symbol => Game.SingletonRepository.Get<Symbol>(nameof(MinusSignSymbol));
    public override string Name => "Polymorph";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 1200;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Polymorph";
    public override int LevelNormallyFound => 35;
    public override int[] Locale => new int[] { 35, 0, 0, 0 };
    public override int Weight => 15;
    public override int RodRechargeTime => 25;
    public override void Execute(ZapRodEvent zapRodEvent)
    {
        if (Game.PolyMonster(zapRodEvent.Dir.Value))
        {
            zapRodEvent.Identified = true;
        }
        zapRodEvent.Item.RodRechargeTimeRemaining = RodRechargeTime;
    }
    public override Item CreateItem() => new Item(Game, this);
}
