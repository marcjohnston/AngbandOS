// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class TrapLocationRodItemFactory : RodItemFactory
{
    private TrapLocationRodItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override bool RequiresAiming => false;
    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(MinusSignSymbol));
    public override string Name => "Trap Location";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 100;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Trap Location";
    public override int LevelNormallyFound => 5;
    public override int[] Locale => new int[] { 5, 0, 0, 0 };
    public override int Weight => 15;
    public override void Execute(ZapRodEvent zapRodEvent)
    {
        if (Game.DetectTraps())
        {
            zapRodEvent.Identified = true;
        }
        zapRodEvent.Item.TypeSpecificValue = 10 + Game.DieRoll(10);
    }
    public override Item CreateItem() => new Item(Game, this);
}