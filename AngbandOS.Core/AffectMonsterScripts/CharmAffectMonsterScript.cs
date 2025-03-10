// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.AffectMonsterScripts;

[Serializable]
internal class CharmAffectMonsterScript : AffectMonsterScript
{
    private CharmAffectMonsterScript(Game game) : base(game) { } // This object is a singleton.

    protected override bool ProjectileAngersMonster(Monster mPtr)
    {
        return false;
    }

    protected override bool Apply(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        string? note = null;
        dam += Game.AbilityScores[AbilityEnum.Charisma].ConRecoverySpeed - 1;
        if (seen)
        {
            obvious = true;
        }
        if (rPtr.Unique || rPtr.ImmuneConfusion || rPtr.Level > Game.DieRoll(dam - 10 < 1 ? 1 : dam - 10) + 5)
        {
            if (rPtr.ImmuneConfusion)
            {
                if (seen)
                {
                    rPtr.Knowledge.Characteristics.ImmuneConfusion = true;
                }
            }
            note = " is unaffected!";
            obvious = false;
        }
        else if (Game.HasAggravation || rPtr.Guardian)
        {
            note = " hates you too much!";
        }
        else
        {
            note = " suddenly seems friendly!";
            mPtr.IsPet = true;
        }
        dam = 0; // Don't do any damage to the charmed monster.
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, null, 0);
        return obvious;
    }
}
