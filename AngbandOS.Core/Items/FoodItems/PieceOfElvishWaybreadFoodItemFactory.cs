// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class PieceOfElvishWaybreadFoodItemFactory : FoodItemFactory
{
    private PieceOfElvishWaybreadFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<CommaSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightBlue;
    public override string Name => "Piece of Elvish Waybread";

    public override int[] Chance => new int[] { 1, 1, 1, 0 };
    public override int Cost => 10;
    public override string FriendlyName => "& Piece~ of Elvish Waybread";
    public override int Level => 5;
    public override int[] Locale => new int[] { 5, 10, 20, 0 };
    public override int Pval => 7500;
    public override int Weight => 3;
    public override bool Eat()
    {
        SaveGame.PlaySound(SoundEffectEnum.Eat);
        SaveGame.MsgPrint("That tastes good.");
        SaveGame.TimedPoison.ResetTimer();
        SaveGame.RestoreHealth(Program.Rng.DiceRoll(4, 8));
        return true;
    }

    /// <summary>
    /// Returns true because waybread vanishes when a skeleton tries to eat it.
    /// </summary>
    public override bool VanishesWhenEatenBySkeletons => true;
    
    public override Item CreateItem() => new PieceOfElvishWaybreadFoodItem(SaveGame);
}
