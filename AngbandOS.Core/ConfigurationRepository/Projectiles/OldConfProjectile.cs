﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class OldConfProjectile : Projectile
{
    private OldConfProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<GreySplatProjectileGraphic>();

    protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get<GreyQuestionAnimation>();

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        string? note = null;
        if (seen)
        {
            obvious = true;
        }
        int doConf = SaveGame.Rng.DiceRoll(3, dam / 2) + 1;
        if (rPtr.Unique || rPtr.ImmuneConfusion ||
            rPtr.Level > SaveGame.Rng.DieRoll(dam - 10 < 1 ? 1 : dam - 10) + 10)
        {
            if (rPtr.ImmuneConfusion)
            {
                if (seen)
                {
                    rPtr.Knowledge.Characteristics.ImmuneConfusion = true;
                }
            }
            doConf = 0;
            note = " is unaffected!";
            obvious = false;
        }
        dam = 0;
        if (doConf != 0 && !rPtr.ImmuneConfusion &&
                 !rPtr.BreatheConfusion && !rPtr.BreatheChaos)
        {
            if (seen)
            {
                obvious = true;
            }
            int tmp;
            if (mPtr.ConfusionLevel != 0)
            {
                note = " looks more confused.";
                tmp = mPtr.ConfusionLevel + (doConf / 2);
            }
            else
            {
                note = " looks confused.";
                tmp = doConf;
            }
            mPtr.ConfusionLevel = tmp < 200 ? tmp : 200;
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note);
        return obvious;
    }
}