// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawSpeedFlaggedAction : FlaggedAction
{
    private const int ColSpeed = 43;
    private const int RowSpeed = 44;
    private RedrawSpeedFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        int i = SaveGame.Speed;
        ColourEnum attr = ColourEnum.White;
        string buf = "";
        if (SaveGame.IsSearching)
        {
            i += 10;
        }
        int energy = Constants.ExtractEnergy[i];
        if (i > 110)
        {
            attr = ColourEnum.BrightGreen;
            buf = $"Fast {energy / 10.0}";
        }
        else if (i < 110)
        {
            attr = ColourEnum.BrightBrown;
            buf = $"Slow {energy / 10.0}";
        }
        SaveGame.Screen.Print(attr, buf.PadRight(14), RowSpeed, ColSpeed);
    }
}
