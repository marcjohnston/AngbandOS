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
    private Type8RoomLayout(SaveGame saveGame) : base(saveGame) { }
    public override int Type => 8;
    public override void Build(int yval, int xval)
    {
        Vault vPtr = SaveGame.SingletonRepository.Vaults[0];
        int dummy = 0;
        while (dummy < SaveGame.SafeMaxAttempts)
        {
            dummy++;
            vPtr = SaveGame.SingletonRepository.Vaults.ToWeightedRandom().Choose();
            if (vPtr.Category == 8)
            {
                var minX = xval - (vPtr.Width / 2);
                var maxX = xval + (vPtr.Width / 2);
                var minY = yval - (vPtr.Height / 2);
                var maxY = yval + (vPtr.Height / 2);
                if (minX >= 1 && minY >= 1 && maxX < SaveGame.CurWid - 1 && maxY < SaveGame.CurHgt - 1)
                {
                    break;
                }
            }
        }
        if (dummy >= SaveGame.SafeMaxAttempts)
        {
            return;
        }
        SaveGame.DangerRating += vPtr.Rating;
        if (SaveGame.Difficulty <= 50 || Program.Rng.DieRoll(((SaveGame.Difficulty - 40) * (SaveGame.Difficulty - 40)) + 50) < 400)
        {
            SaveGame.SpecialDanger = true;
        }
        BuildVault(yval, xval, vPtr.Height, vPtr.Width, vPtr.Text);
    }
}
