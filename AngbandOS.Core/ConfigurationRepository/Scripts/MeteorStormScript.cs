// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class MeteorStormScript : Script, IScript
{
    private MeteorStormScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Projects a meteor onto the location of the player.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int x = SaveGame.MapX;
        int y = SaveGame.MapY;
        int count = 0;
        int b = 10 + SaveGame.Rng.DieRoll(10);
        for (int i = 0; i < b; i++)
        {
            int d;
            do
            {
                count++;
                if (count > 1000)
                {
                    break;
                }
                x = SaveGame.MapX - 5 + SaveGame.Rng.DieRoll(10);
                y = SaveGame.MapY - 5 + SaveGame.Rng.DieRoll(10);
                int dx = SaveGame.MapX > x ? SaveGame.MapX - x : x - SaveGame.MapX;
                int dy = SaveGame.MapY > y ? SaveGame.MapY - y : y - SaveGame.MapY;
                d = dy > dx ? dy + (dx >> 1) : dx + (dy >> 1);
            } while (d > 5 || !SaveGame.PlayerHasLosBold(y, x));
            if (count > 1000)
            {
                break;
            }
            count = 0;
            SaveGame.Project(0, 2, y, x, SaveGame.ExperienceLevel * 3 / 2, SaveGame.SingletonRepository.Projectiles.Get(nameof(MeteorProjectile)), ProjectionFlag.ProjectKill | ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem);
        }
    }
}
