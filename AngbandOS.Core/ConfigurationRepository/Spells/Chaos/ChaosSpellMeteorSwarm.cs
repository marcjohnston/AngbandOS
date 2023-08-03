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
            SaveGame.Project(0, 2, y, x, SaveGame.ExperienceLevel * 3 / 2, SaveGame.SingletonRepository.Projectiles.Get<MeteorProjectile>(),
                ProjectionFlag.ProjectKill | ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem);
        }
    }

    public override void CastFailed()
    {
        DoWildChaoticMagic(25);
    }

    public override string Name => "Meteor Swarm";
    
    protected override string? Info()
    {
        return $"dam {3 * SaveGame.ExperienceLevel / 2} each";
    }
}