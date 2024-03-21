// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class PieceOfElvishWaybreadFoodItemFactory : FoodItemFactory
{
    private PieceOfElvishWaybreadFoodItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(CommaSymbol));
    public override ColorEnum Color => ColorEnum.BrightBlue;
    public override string Name => "Piece of Elvish Waybread";

    public override int[] Chance => new int[] { 1, 1, 1, 0 };
    public override int Cost => 10;
    public override string FriendlyName => "& Piece~ of Elvish Waybread";
    public override int LevelNormallyFound => 5;
    public override int[] Locale => new int[] { 5, 10, 20, 0 };
    public override int InitialTypeSpecificValue => 7500;
    public override int Weight => 3;
    public override bool Eat()
    {
        Game.PlaySound(SoundEffectEnum.Eat);
        Game.MsgPrint("That tastes good.");
        Game.PoisonTimer.ResetTimer();
        Game.RestoreHealth(Game.DiceRoll(4, 8));
        return true;
    }

    /// <summary>
    /// Returns true because waybread vanishes when a skeleton tries to eat it.
    /// </summary>
    public override bool VanishesWhenEatenBySkeletons => true;
    
    public override Item CreateItem() => new Item(Game, this);
}
