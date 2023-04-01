namespace AngbandOS.Core.RoomTypes
{
    internal class RoomType8 : RoomType
    {
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
                    if (minX >= 1 && minY >= 1 && maxX < saveGame.Level.CurWid - 1 && maxY < saveGame.Level.CurHgt - 1)
                    {
                        break;
                    }
                }
            }
            if (dummy >= SaveGame.SafeMaxAttempts)
            {
                return;
            }
            saveGame.Level.DangerRating += vPtr.Rating;
            if (saveGame.Difficulty <= 50 || Program.Rng.DieRoll(((saveGame.Difficulty - 40) * (saveGame.Difficulty - 40)) + 50) < 400)
            {
                saveGame.Level.SpecialDanger = true;
            }
            BuildVault(saveGame, yval, xval, vPtr.Height, vPtr.Width, vPtr.Text);
        }
    }
}
