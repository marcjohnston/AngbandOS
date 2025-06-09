// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class MeteorStormScript : Script, IScript, ICastSpellScript
{
    private MeteorStormScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Projects a meteor onto the location of the player.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int x = Game.MapX.IntValue;
        int y = Game.MapY.IntValue;
        int count = 0;
        int b = 10 + Game.DieRoll(10);
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
                x = Game.MapX.IntValue - 5 + Game.DieRoll(10);
                y = Game.MapY.IntValue - 5 + Game.DieRoll(10);
                int dx = Game.MapX.IntValue > x ? Game.MapX.IntValue - x : x - Game.MapX.IntValue;
                int dy = Game.MapY.IntValue > y ? Game.MapY.IntValue - y : y - Game.MapY.IntValue;
                d = dy > dx ? dy + (dx >> 1) : dx + (dy >> 1);
            } while (d > 5 || !Game.PlayerHasLosBold(y, x));
            if (count > 1000)
            {
                break;
            }
            count = 0;
            Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(MeteorProjectile));
            projectile.Fire(0, 2, y, x, Game.ExperienceLevel.IntValue * 3 / 2, kill: true, item: true, jump: true, beam: false, thru: false, hide: false, grid: false, stop: false);
        }
    }
    public string LearnedDetails => $"dam {3 * Game.ExperienceLevel.IntValue / 2} each";
}
