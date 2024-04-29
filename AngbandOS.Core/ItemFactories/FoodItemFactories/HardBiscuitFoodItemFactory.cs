// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class HardBiscuitFoodItemFactory : FoodItemFactory
{
    private HardBiscuitFoodItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Get<Symbol>(nameof(CommaSymbol));
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Hard Biscuit";

    public override int Cost => 1;
    public override string FriendlyName => "& Hard Biscuit~";
    public override int InitialTypeSpecificValue => 500;
    public override int Weight => 2;
    public override bool Eat()
    {
        Game.PlaySound(SoundEffectEnum.Eat);
        Game.MsgPrint("That tastes good.");
        return true;
    }

    /// <summary>
    /// Returns true because biscuits vanish when a skeleton tries to eat it.
    /// </summary>
    public override bool VanishesWhenEatenBySkeletons => true;

    public override Item CreateItem() => new Item(Game, this);
}
