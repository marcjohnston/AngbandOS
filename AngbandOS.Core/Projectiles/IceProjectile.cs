﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projectiles;

[Serializable]
internal class IceProjectile : Projectile
{
    private IceProjectile(Game game) : base(game) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => Game.SingletonRepository.Get<ProjectileGraphic>(nameof(DiamondBoltProjectileGraphic));

    protected override ProjectileGraphic? ImpactProjectileGraphic => Game.SingletonRepository.Get<ProjectileGraphic>(nameof(DiamondSplatProjectileGraphic));

    protected override bool AffectItem(int who, int y, int x)
    {
        GridTile cPtr = Game.Map.Grid[y][x];
        bool obvious = false;
        string oName = "";
        foreach (Item oPtr in cPtr.Items)
        {
            bool plural = false;
            bool doKill = false;
            string noteKill = null;
            if (oPtr.StackCount > 1)
            {
                plural = true;
            }
            if (oPtr.HatesCold)
            {
                noteKill = plural ? " shatter!" : " shatters!";
                doKill = true;
            }
            if (doKill)
            {
                if (oPtr.WasNoticed)
                {
                    obvious = true;
                    oName = oPtr.GetDescription(false);
                }
                if (oPtr.IsArtifact)
                {
                    if (oPtr.WasNoticed)
                    {
                        string s = plural ? "are" : "is";
                        Game.MsgPrint($"The {oName} {s} unaffected!");
                    }
                }
                else
                {
                    if (oPtr.WasNoticed && string.IsNullOrEmpty(noteKill))
                    {
                        Game.MsgPrint($"The {oName}{noteKill}");
                    }
                    bool isPotion = oPtr.QuaffTuple != null;
                    Game.DeleteObject(oPtr);
                    if (isPotion)
                    {
                        oPtr.Smash(who, y, x);
                    }
                    Game.MainForm.RefreshMapLocation(y, x);
                }
            }
        }
        return obvious;
    }

    protected override string AffectMonsterScriptBindingKey => nameof(IceMonsterEffect);

    protected override bool AffectPlayer(int who, int r, int y, int x, int dam, int aRad)
    {
        bool blind = Game.BlindnessTimer.Value != 0;
        if (dam > 1600)
        {
            dam = 1600;
        }
        dam = (dam + r) / (r + 1);
        Monster mPtr = Game.Monsters[who];
        string killer = mPtr.IndefiniteVisibleName;
        if (blind)
        {
            Game.MsgPrint("You are hit by something sharp and cold!");
        }
        Game.ColdDam(dam, killer);
        if (!Game.HasShardResistance)
        {
            Game.BleedingTimer.AddTimer(Game.DiceRoll(5, 8));
        }
        if (!Game.HasSoundResistance)
        {
            Game.StunTimer.AddTimer(Game.DieRoll(15));
        }
        if (!(Game.HasColdResistance || Game.ColdResistanceTimer.Value != 0) || Game.DieRoll(12) == 1)
        {
            if (!Game.HasColdImmunity)
            {
                Game.InvenDamage(Game.SetColdDestroy, 3);
            }
        }
        return true;
    }
}