// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.GamePacks.Cthangband;

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CallTheVoidScript : Script, IScript, ICastSpellScript
{
    private CallTheVoidScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Blast energy in all directions.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        // Make sure we're not next to a wall
        if (Game.GridPassable(Game.MapY.IntValue - 1, Game.MapX.IntValue - 1) && Game.GridPassable(Game.MapY.IntValue - 1, Game.MapX.IntValue) &&
            Game.GridPassable(Game.MapY.IntValue - 1, Game.MapX.IntValue + 1) && Game.GridPassable(Game.MapY.IntValue, Game.MapX.IntValue - 1) &&
            Game.GridPassable(Game.MapY.IntValue, Game.MapX.IntValue + 1) && Game.GridPassable(Game.MapY.IntValue + 1, Game.MapX.IntValue - 1) &&
            Game.GridPassable(Game.MapY.IntValue + 1, Game.MapX.IntValue) && Game.GridPassable(Game.MapY.IntValue + 1, Game.MapX.IntValue + 1))
        {
            // Fire area effect shards, mana, and nukes in all directions
            int i;
            for (i = 1; i < 10; i++)
            {
                if (i - 5 != 0)
                {
                    Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(ShardProjectile));
                    projectile.TargetedFire(i, 175, 2, grid: true, item: true, kill: true, jump: false, beam: false, thru: true, hide: false, stop: true);
                }
            }
            for (i = 1; i < 10; i++)
            {
                if (i - 5 != 0)
                {
                    Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(ManaProjectile));
                    projectile.TargetedFire(i, 175, 3, grid: true, item: true, kill: true, jump: false, beam: false, thru: true, hide: false, stop: true);
                }
            }
            for (i = 1; i < 10; i++)
            {
                if (i - 5 != 0)
                {
                    Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(NukeProjectile));
                    projectile.TargetedFire(i, 175, 4, grid: true, item: true, kill: true, jump: false, beam: false, thru: true, hide: false, stop: true);
                }
            }
        }
        else
        {
            // We were too close to a wall, so earthquake instead
            string cast = Game.CharacterClass.CastVerb;
            string spell = Game.CharacterClass.SpellNoun;
            Game.MsgPrint($"You {cast} the {spell} too close to a wall!");
            Game.MsgPrint("There is a loud explosion!");
            Game.DestroyArea(Game.MapY.IntValue, Game.MapX.IntValue, 20 + Game.ExperienceLevel.IntValue);
            Game.MsgPrint("The dungeon collapses...");
            Game.TakeHit(100 + Game.DieRoll(150), "a suicidal Call the Void");
        }
    }
    public string LearnedDetails => "dam 3 * 175";
}
