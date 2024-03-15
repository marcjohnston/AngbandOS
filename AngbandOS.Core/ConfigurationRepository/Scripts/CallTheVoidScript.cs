// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CallTheVoidScript : Script, IScript
{
    private CallTheVoidScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Blast energy in all directions.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        // Make sure we're not next to a wall
        if (SaveGame.GridPassable(SaveGame.MapY - 1, SaveGame.MapX - 1) && SaveGame.GridPassable(SaveGame.MapY - 1, SaveGame.MapX) &&
            SaveGame.GridPassable(SaveGame.MapY - 1, SaveGame.MapX + 1) && SaveGame.GridPassable(SaveGame.MapY, SaveGame.MapX - 1) &&
            SaveGame.GridPassable(SaveGame.MapY, SaveGame.MapX + 1) && SaveGame.GridPassable(SaveGame.MapY + 1, SaveGame.MapX - 1) &&
            SaveGame.GridPassable(SaveGame.MapY + 1, SaveGame.MapX) && SaveGame.GridPassable(SaveGame.MapY + 1, SaveGame.MapX + 1))
        {
            // Fire area effect shards, mana, and nukes in all directions
            int i;
            for (i = 1; i < 10; i++)
            {
                if (i - 5 != 0)
                {
                    SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(ShardProjectile)), i, 175, 2);
                }
            }
            for (i = 1; i < 10; i++)
            {
                if (i - 5 != 0)
                {
                    SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(ManaProjectile)), i, 175, 3);
                }
            }
            for (i = 1; i < 10; i++)
            {
                if (i - 5 != 0)
                {
                    SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(NukeProjectile)), i, 175, 4);
                }
            }
        }
        else
        {
            // We were too close to a wall, so earthquake instead
            string cast = SaveGame.BaseCharacterClass.CastVerb;
            string spell = SaveGame.BaseCharacterClass.SpellNoun;
            SaveGame.MsgPrint($"You {cast} the {spell} too close to a wall!");
            SaveGame.MsgPrint("There is a loud explosion!");
            SaveGame.DestroyArea(SaveGame.MapY, SaveGame.MapX, 20 + SaveGame.ExperienceLevel);
            SaveGame.MsgPrint("The dungeon collapses...");
            SaveGame.TakeHit(100 + SaveGame.DieRoll(150), "a suicidal Call the Void");
        }
    }
}
