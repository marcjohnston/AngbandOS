// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class HavocRodItemFactory : RodItemFactory
{
    private HavocRodItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override bool RequiresAiming => true;
    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(MinusSignSymbol));
    public override string Name => "Havoc";

    public override int[] Chance => new int[] { 16, 0, 0, 0 };
    public override int Cost => 150000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Havoc";
    public override int LevelNormallyFound => 95;
    public override int[] Locale => new int[] { 100, 0, 0, 0 };
    public override int Weight => 15;
    public override void Execute(ZapRodEvent zapRodEvent)
    {
        Game.RunScript(nameof(CallChaosScript));
        zapRodEvent.Identified = true;
        zapRodEvent.Item.TypeSpecificValue = 250;
    }
    public override Item CreateItem() => new Item(Game, this);
}
