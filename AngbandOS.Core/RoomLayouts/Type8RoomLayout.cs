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
    private Type8RoomLayout(Game game) : base(game) { }
    public override int Type => 8;
    public override int Dy1 => 0;
    public override int Dy2 => 1;
    public override int Dx1 => -1;
    public override int Dx2 => 1;
    public override int Level => 1;
    public override void Build(int yval, int xval)
    {
        Vault vault = Game.SingletonRepository.Vaults[0];
        int dummy = 0;
        while (dummy < Game.SafeMaxAttempts)
        {
            dummy++;
            vault = Game.SingletonRepository.Vaults.ToWeightedRandom().ChooseOrDefault();
            if (vault.Category == 8)
            {
                var minX = xval - (vault.Width / 2);
                var maxX = xval + (vault.Width / 2);
                var minY = yval - (vault.Height / 2);
                var maxY = yval + (vault.Height / 2);
                if (minX >= 1 && minY >= 1 && maxX < Game.CurWid - 1 && maxY < Game.CurHgt - 1)
                {
                    break;
                }
            }
        }
        if (dummy >= Game.SafeMaxAttempts)
        {
            return;
        }
        Game.DangerRating += vault.Rating;
        if (Game.Difficulty <= 50 || Game.DieRoll(((Game.Difficulty - 40) * (Game.Difficulty - 40)) + 50) < 400)
        {
            Game.SpecialDanger = true;
        }
        BuildVault(yval, xval, vault.Height, vault.Width, vault.Text);
    }
}
