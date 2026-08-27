// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.FlaggedActions;

internal class RedrawSpeedFlaggedAction : FlaggedAction
{
    private const int ColSpeed = 43;
    private const int RowSpeed = 44;
    private RedrawSpeedFlaggedAction(Game game) : base(game) { }
    protected override void Execute()
    {
        int currentSpeed = Game.Speed - Game.SpeedHidden;
        ColorEnum attr = ColorEnum.White;
        string buf = "";
        int energy = Game.ExtractEnergy[currentSpeed]; // TODO: This causes a runtime error for out of bounds
        if (currentSpeed > 110)
        {
            attr = ColorEnum.BrightGreen;
            buf = $"Fast {energy / 10.0}";
        }
        else if (currentSpeed < 110)
        {
            attr = ColorEnum.BrightBrown;
            buf = $"Slow {energy / 10.0}";
        }
        Game.Screen.Print(attr, buf.PadRight(14), RowSpeed, ColSpeed);
    }
}
