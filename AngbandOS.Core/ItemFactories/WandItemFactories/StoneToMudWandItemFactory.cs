// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class StoneToMudWandItemFactory : WandItemFactory
{
    private StoneToMudWandItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(MinusSignSymbol));
    public override string Name => "Stone to Mud";

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        item.TypeSpecificValue = Game.DieRoll(8) + 3;
    }

    public override int[] Chance => new int[] { 1, 1, 1, 0 };
    public override int Cost => 300;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Stone to Mud";
    public override int LevelNormallyFound => 10;
    public override int[] Locale => new int[] { 10, 40, 80, 0 };
    public override int Weight => 10;
    public override bool ExecuteActivation(Game game, int dir)
    {
        return game.WallToMud(dir);
    }
    public override Item CreateItem() => new Item(Game, this);
}