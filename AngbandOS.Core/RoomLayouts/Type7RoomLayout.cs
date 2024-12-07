// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RoomLayouts;

[Serializable]
internal class Type7RoomLayout : RoomLayout
{
    private Type7RoomLayout(Game game) : base(game) { }
    public override int Type => 7;
    public override int Dy1 => -1;
    public override int Dy2 => 2;
    public override int Dx1 => -2;
    public override int Dx2 => 3;
    public override int Level => 10;
    public override void Build(int yval, int xval)
    {
        Vault vPtr = Game.SingletonRepository.Get<Vault>(0);
        int dummy = 0;
        while (dummy < Game.SafeMaxAttempts)
        {
            dummy++;
            vPtr = Game.SingletonRepository.ToWeightedRandom<Vault>().ChooseOrDefault();
            if (vPtr.Category == 7)
            {
                var minX = xval - (vPtr.Width / 2);
                var maxX = xval + (vPtr.Width / 2);
                var minY = yval - (vPtr.Height / 2);
                var maxY = yval + (vPtr.Height / 2);
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
        Game.DangerRating += vPtr.Rating;
        if (Game.Difficulty <= 50 || Game.DieRoll(((Game.Difficulty - 40) * (Game.Difficulty - 40)) + 50) < 400)
        {
            Game.SpecialDanger = true;
        }
        BuildVault(yval, xval, vPtr.Height, vPtr.Width, vPtr.Text);
    }
}
