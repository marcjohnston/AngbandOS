// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class PieceOfWarpstoneFoodItemFactory : FoodItemFactory
{
    private PieceOfWarpstoneFoodItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(AsteriskSymbol));
    public override ColorEnum Color => ColorEnum.Purple;
    public override string Name => "Piece of Warpstone";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 1000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "& Piece~ of Warpstone";
    public override int LevelNormallyFound => 30;
    public override int[] Locale => new int[] { 50, 0, 0, 0 };
    public override int Weight => 1;
    public override bool Eat()
    {
        Game.PlaySound(SoundEffectEnum.Eat);
        Game.MsgPrint("That tastes... funky.");
        Game.RunScript(nameof(GainMutationScript));
        if (Game.DieRoll(3) == 1)
        {
            Game.RunScript(nameof(GainMutationScript));
        }
        if (Game.DieRoll(3) == 1)
        {
            Game.RunScript(nameof(GainMutationScript));
        }
        return true;
    }

    /// <summary>
    /// Returns true because warpstones vanish when a skeleton tries to eat it.
    /// </summary>
    public override bool VanishesWhenEatenBySkeletons => true;
    public override Item CreateItem() => new Item(Game, this);
}