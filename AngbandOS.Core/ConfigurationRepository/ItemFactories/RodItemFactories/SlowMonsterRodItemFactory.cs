// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SlowMonsterRodItemFactory : RodItemFactory
{
    private SlowMonsterRodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override bool RequiresAiming => true;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(MinusSignSymbol));
    public override string Name => "Slow Monster";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 1500;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Slow Monster";
    public override int Level => 30;
    public override int[] Locale => new int[] { 30, 0, 0, 0 };
    public override int Weight => 15;
    public override void Execute(ZapRodEvent zapRodEvent)
    {
        if (SaveGame.SlowMonster(zapRodEvent.Dir.Value))
        {
            zapRodEvent.Identified = true;
        }
        zapRodEvent.Item.TypeSpecificValue = 20;
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}