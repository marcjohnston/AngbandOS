// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Chaos;

[Serializable]
internal class ChaosSpellMeteorSwarm : Spell
{
    private ChaosSpellMeteorSwarm(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        int x = SaveGame.Player.MapX;
        int y = SaveGame.Player.MapY;
        int count = 0;
        int b = 10 + Program.Rng.DieRoll(10);
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
                x = SaveGame.Player.MapX - 5 + Program.Rng.DieRoll(10);
                y = SaveGame.Player.MapY - 5 + Program.Rng.DieRoll(10);
                int dx = SaveGame.Player.MapX > x ? SaveGame.Player.MapX - x : x - SaveGame.Player.MapX;
                int dy = SaveGame.Player.MapY > y ? SaveGame.Player.MapY - y : y - SaveGame.Player.MapY;
                d = dy > dx ? dy + (dx >> 1) : dx + (dy >> 1);
            } while (d > 5 || !SaveGame.Level.PlayerHasLosBold(y, x));
            if (count > 1000)
            {
                break;
            }
            count = 0;
            SaveGame.Project(0, 2, y, x, SaveGame.Player.Level * 3 / 2, SaveGame.SingletonRepository.Projectiles.Get<MeteorProjectile>(),
                ProjectionFlag.ProjectKill | ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem);
        }
    }

    public override string Name => "Meteor Swarm";
    
    protected override string? Info()
    {
        return $"dam {3 * SaveGame.Player.Level / 2} each";
    }
}