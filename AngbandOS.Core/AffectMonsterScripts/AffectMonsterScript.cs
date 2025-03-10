// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.AffectMonsterScripts;

[Serializable]
internal abstract class AffectMonsterScript : IGetKey
{
    protected readonly Game Game;

    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind() { }

    public string ToJson()
    {
        return "";
    }

    protected AffectMonsterScript(Game game)
    {
        Game = game;
    }

    protected void ApplyProjectileDamageToMonster(int who, Monster mPtr, int dam, string? note)
    {
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, null, 0);
    }

    protected void ApplyProjectileDamageToMonster(int who, Monster mPtr, int dam, string? note, string noteDies)
    {
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, noteDies, 0);
    }

    protected void ApplyProjectileDamageToMonster(int who, Monster mPtr, int dam, string? note, int addFear)
    {
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, null, addFear);
    }

    /// <summary>
    /// Returns true, if the projectile angers a monster and will turn it from being friendly to attacking the player.  Returns true, by default, in
    /// that all friends will be affected and turn against the player. Return false, to disable the functionality of friends turning against the
    /// player for all attacks with the projectile.
    /// </summary>
    /// <param name="mPtr"></param>
    /// <returns></returns>
    protected virtual bool ProjectileAngersMonster(Monster mPtr) // TODO: This return value should be combined with the potion smash and IUnfriendlyScript
    {
        return true;
    }

    /// <summary>
    /// Attempt to join all of the projectile affect monsters with common framework.
    /// </summary>
    /// <param name="who"></param>
    /// <param name="mPtr"></param>
    /// <param name="dam"></param>
    /// <param name="note"></param>
    protected void ApplyProjectileDamageToMonster(int who, Monster mPtr, int dam, string? note, string? noteDies, int addFear)
    {
        if (addFear != 0)
        {
            int tmp = mPtr.FearLevel + addFear;
            mPtr.FearLevel = tmp < 200 ? tmp : 200;
        }

        string mName = mPtr.Name;
        GridTile cPtr = Game.Map.Grid[mPtr.MapY][mPtr.MapX];
        MonsterRace rPtr = mPtr.Race;

        if (noteDies == null)
        {
            noteDies = rPtr.DeathNote();
        }
        if (rPtr.Guardian && who != 0 && dam > mPtr.Health)
        {
            dam = mPtr.Health;
        }
        if (dam > mPtr.Health)
        {
            note = noteDies;
        }
        if (who != 0)
        {
            mPtr.SleepLevel = 0;
            mPtr.Health -= dam;
            if (mPtr.Health < 0)
            {
                bool sad = mPtr.IsPet && !mPtr.IsVisible;
                Game.MonsterDeath(mPtr);
                Game.DeleteMonsterByIndex(cPtr.MonsterIndex, true);
                if (string.IsNullOrEmpty(note) == false)
                {
                    Game.MsgPrint($"{mName}{note}");
                }
                if (sad)
                {
                    Game.MsgPrint("You feel sad for a moment.");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(note) == false && mPtr.IsVisible)
                {
                    Game.MsgPrint($"{mName}{note}");
                }
                else if (dam > 0)
                {
                    Game.MessagePain(mPtr, dam);
                }
            }
        }
        else
        {
            if (Game.DamageMonster(cPtr.MonsterIndex, dam, out bool fear, noteDies))
            {
            }
            else
            {
                if (string.IsNullOrEmpty(note) == false && mPtr.IsVisible)
                {
                    Game.MsgPrint($"{mName}{note}");
                }
                else if (dam > 0)
                {
                    Game.MessagePain(mPtr, dam);
                }
                if ((fear || addFear > 0) && mPtr.IsVisible)
                {
                    Game.PlaySound(SoundEffectEnum.MonsterFlees);
                    Game.MsgPrint($"{mName} flees in terror!");
                }
            }
        }
    }

    protected abstract bool Apply(int who, Monster mPtr, int dam, int r);

    public bool AffectMonster(int who, int r, int y, int x, int dam, ref int projectMn, ref int projectMx, ref int projectMy)
    {
        // Get the grid tile for the location in question.
        GridTile cPtr = Game.Map.Grid[y][x];

        // Check to see if there is a monster at this location.
        if (cPtr.MonsterIndex == 0)
        {
            return false;
        }

        // Check to see if the monster/player is the monster/player performing the action.
        if (who != 0 && cPtr.MonsterIndex == who)
        {
            return false;
        }

        // Get a reference to the monster in question.
        Monster mPtr = Game.Monsters[cPtr.MonsterIndex];

        // Modify the damage based on the distance from the attacker.
        dam = (dam + r) / (r + 1);

        // Attempt to turn friendly monsters against their owner, if the owner attacks them.
        bool isFriendly = mPtr.IsPet;
        if (who == 0 && isFriendly && ProjectileAngersMonster(mPtr))
        {
            string mName = mPtr.Name;
            Game.MsgPrint($"{mName} gets angry!");
            mPtr.IsPet = false;
        }

        bool notice = Apply(who, mPtr, dam, r);

        GridTile newGridTile = Game.Map.Grid[mPtr.MapY][mPtr.MapX];
        Game.UpdateMonsterVisibility(newGridTile.MonsterIndex, false);
        Game.MainForm.RefreshMapLocation(y, x);
        projectMn++;
        projectMx = mPtr.MapX;
        projectMy = mPtr.MapY;

        return notice;
    }
}
