﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterEffects;

[Serializable]
internal class GravityMonsterEffect : MonsterEffect
{
    private GravityMonsterEffect(Game game) : base(game) { } // This object is a singleton.

    protected override IdentifiedResultEnum Apply(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        int doStun = 0;
        string? note = null;
        bool resistTele = false;
        if (seen)
        {
            obvious = true;
        }
        if (rPtr.ResistTeleport)
        {
            if (rPtr.Unique)
            {
                if (seen)
                {
                    rPtr.Knowledge.Characteristics.ResistTeleport = true;
                }
                note = " is unaffected!";
                resistTele = true;
            }
            else if (rPtr.Level > Game.DieRoll(100))
            {
                if (seen)
                {
                    rPtr.Knowledge.Characteristics.ResistTeleport = true;
                }
                note = " resists!";
                resistTele = true;
            }
        }
        int doDist = resistTele ? 0 : 10;
        if (rPtr.BreatheGravity)
        {
            note = " resists.";
            dam *= 3;
            dam /= Game.DieRoll(6) + 6;
            doDist = 0;
        }
        else
        {
            if (rPtr.Unique || rPtr.Level > Game.DieRoll(dam - 10 < 1 ? 1 : dam - 10) + 10)
            {
                obvious = false;
            }
            else
            {
                if (mPtr.Speed > 60)
                {
                    mPtr.Speed -= 10;
                }
                note = " starts moving slower.";
            }
            doStun = Game.DiceRoll((Game.ExperienceLevel.IntValue / 10) + 3, dam) + 1;
            if (rPtr.Unique || rPtr.Level > Game.DieRoll(dam - 10 < 1 ? 1 : dam - 10) + 10)
            {
                doStun = 0;
                note = " is unaffected!";
                obvious = false;
            }
        }
        if (doDist != 0)
        {
            if (seen)
            {
                obvious = true;
            }
            note = " disappears!";
            mPtr.TeleportAway(doDist);
        }
        else if (doStun != 0 && !rPtr.BreatheSound && !rPtr.BreatheForce)
        {
            if (seen)
            {
                obvious = true;
            }
            int tmp;
            if (mPtr.StunLevel != 0)
            {
                note = " is more dazed.";
                tmp = mPtr.StunLevel + (doStun / 2);
            }
            else
            {
                note = " is dazed.";
                tmp = doStun;
            }
            mPtr.StunLevel = tmp < 200 ? tmp : 200;
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, null, 0);
        return obvious ? IdentifiedResultEnum.True : IdentifiedResultEnum.False;
    }
}
