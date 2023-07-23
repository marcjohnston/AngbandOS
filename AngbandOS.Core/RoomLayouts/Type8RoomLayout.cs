// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RoomTypes;

[Serializable]
internal class Type8RoomLayout : RoomLayout
{
    private Type8RoomLayout(SaveGame save) : base(save) { }
    public override int Type => 8;
    public override void Build(SaveGame saveGame, int yval, int xval)
    {
        Vault vPtr = saveGame.SingletonRepository.Vaults[0];
        int dummy = 0;
        while (dummy < SaveGame.SafeMaxAttempts)
        {
            dummy++;
            vPtr = saveGame.SingletonRepository.Vaults.ToWeightedRandom().Choose();
            if (vPtr.Category == 8)
            {
                var minX = xval - (vPtr.Width / 2);
                var maxX = xval + (vPtr.Width / 2);
                var minY = yval - (vPtr.Height / 2);
                var maxY = yval + (vPtr.Height / 2);
                if (minX >= 1 && minY >= 1 && maxX < saveGame.CurWid - 1 && maxY < saveGame.CurHgt - 1)
                {
                    break;
                }
            }
        }
        if (dummy >= SaveGame.SafeMaxAttempts)
        {
            return;
        }
        saveGame.DangerRating += vPtr.Rating;
        if (saveGame.Difficulty <= 50 || Program.Rng.DieRoll(((saveGame.Difficulty - 40) * (saveGame.Difficulty - 40)) + 50) < 400)
        {
            saveGame.SpecialDanger = true;
        }
        BuildVault(saveGame, yval, xval, vPtr.Height, vPtr.Width, vPtr.Text);
    }
}
