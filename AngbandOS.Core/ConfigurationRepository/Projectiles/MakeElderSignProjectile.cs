﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class MakeElderSignProjectile : Projectile
{
    private MakeElderSignProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get<BrightGreenSparkleAnimation>();

    protected override bool AffectFloor(int y, int x)
    {
        if (!SaveGame.GridOpenNoItemOrCreature(y, x))
        {
            return false;
        }
        SaveGame.CaveSetFeat(y, x, "ElderSign");
        return false;
    }

    protected override bool ProjectileAngersMonster(Monster mPtr)
    {
        return false;
    }

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        string? note = null;
        ApplyProjectileDamageToMonster(who, mPtr, dam, note);
        return false;
    }
}