﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projectiles;

[Serializable]
internal class ElectricityProjectile : Projectile
{
    private ElectricityProjectile(Game game) : base(game) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => Game.SingletonRepository.Get<ProjectileGraphic>(nameof(BrightYellowBoltProjectileGraphic));

    protected override Animation EffectAnimation => Game.SingletonRepository.Get<Animation>(nameof(BrightYellowCloudAnimation));

    protected override bool AffectItem(int who, int y, int x)
    {
        GridTile cPtr = Game.Map.Grid[y][x];
        bool obvious = false;
        string oName = "";
        foreach (Item oPtr in cPtr.Items)
        {
            bool ignore = false;
            bool plural = false;
            bool doKill = false;
            string noteKill = null;
            ItemCharacteristics mergedCharacteristics = oPtr.GetMergedCharacteristics();
            if (oPtr.StackCount > 1)
            {
                plural = true;
            }
            if (oPtr.HatesElectricity)
            {
                doKill = true;
                noteKill = plural ? " are destroyed!" : " is destroyed!";
                if (mergedCharacteristics.IgnoreElec)
                {
                    ignore = true;
                }
            }
            if (!doKill)
            {
                continue;
            }
            if (oPtr.WasNoticed)
            {
                obvious = true;
                oName = oPtr.GetDescription(false);
            }
            if (oPtr.IsArtifact || ignore)
            {
                if (!oPtr.WasNoticed)
                {
                    continue;
                }
                string s = plural ? "are" : "is";
                Game.MsgPrint($"The {oName} {s} unaffected!");
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
        return obvious;
    }

    protected override string AffectMonsterScriptBindingKey => nameof(ElectricityMonsterEffect);

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
            Game.MsgPrint("You are hit by lightning!");
        }
        Game.ElecDam(dam, killer);
        return true;
    }
}