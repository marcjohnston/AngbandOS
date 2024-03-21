// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawHungerFlaggedAction : FlaggedAction
{
    private const int ColHungry = 0;
    private const int RowHungry = 44;
    private RedrawHungerFlaggedAction(Game game) : base(game) { }
    protected override void Execute()
    {
        if (Game.Food.Value < Constants.PyFoodFaint)
        {
            Game.Screen.Print(ColorEnum.Red, "Weak  ", RowHungry, ColHungry);
        }
        else if (Game.Food.Value < Constants.PyFoodWeak)
        {
            Game.Screen.Print(ColorEnum.Orange, "Weak  ", RowHungry, ColHungry);
        }
        else if (Game.Food.Value < Constants.PyFoodAlert)
        {
            Game.Screen.Print(ColorEnum.Yellow, "Hungry", RowHungry, ColHungry);
        }
        else if (Game.Food.Value < Constants.PyFoodFull)
        {
            Game.Screen.Print(ColorEnum.BrightGreen, "      ", RowHungry, ColHungry);
        }
        else if (Game.Food.Value < Constants.PyFoodMax)
        {
            Game.Screen.Print(ColorEnum.BrightGreen, "Full  ", RowHungry, ColHungry);
        }
        else
        {
            Game.Screen.Print(ColorEnum.Green, "Gorged", RowHungry, ColHungry);
        }
    }
}
