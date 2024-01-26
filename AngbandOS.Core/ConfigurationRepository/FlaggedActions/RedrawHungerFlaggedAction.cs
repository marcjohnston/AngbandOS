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
    private RedrawHungerFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        if (SaveGame.Food < Constants.PyFoodFaint)
        {
            SaveGame.Screen.Print(ColorEnum.Red, "Weak  ", RowHungry, ColHungry);
        }
        else if (SaveGame.Food < Constants.PyFoodWeak)
        {
            SaveGame.Screen.Print(ColorEnum.Orange, "Weak  ", RowHungry, ColHungry);
        }
        else if (SaveGame.Food < Constants.PyFoodAlert)
        {
            SaveGame.Screen.Print(ColorEnum.Yellow, "Hungry", RowHungry, ColHungry);
        }
        else if (SaveGame.Food < Constants.PyFoodFull)
        {
            SaveGame.Screen.Print(ColorEnum.BrightGreen, "      ", RowHungry, ColHungry);
        }
        else if (SaveGame.Food < Constants.PyFoodMax)
        {
            SaveGame.Screen.Print(ColorEnum.BrightGreen, "Full  ", RowHungry, ColHungry);
        }
        else
        {
            SaveGame.Screen.Print(ColorEnum.Green, "Gorged", RowHungry, ColHungry);
        }
    }
}
