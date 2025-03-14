// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projectiles;

[Serializable]
internal class GravityProjectile : Projectile
{
    private GravityProjectile(Game game) : base(game) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => Game.SingletonRepository.Get<ProjectileGraphic>(nameof(TurquoiseBoltProjectileGraphic));

    protected override ProjectileGraphic? ImpactProjectileGraphic => Game.SingletonRepository.Get<ProjectileGraphic>(nameof(TurquoiseSplatProjectileGraphic));

    protected override string AffectMonsterScriptBindingKey => nameof(GravityMonsterEffect);

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
            Game.MsgPrint("You are hit by something heavy!");
        }
        Game.MsgPrint("Gravity warps around you.");
        Game.RunScriptInt(nameof(TeleportSelfScript), 5);
        if (!Game.HasFeatherFall)
        {
            Game.SlowTimer.AddTimer(Game.RandomLessThan(4) + 4);
        }
        if (!(Game.HasSoundResistance || Game.HasFeatherFall))
        {
            int kk = Game.DieRoll(dam > 90 ? 35 : (dam / 3) + 5);
            Game.StunTimer.AddTimer(kk);
        }
        if (Game.HasFeatherFall)
        {
            dam = dam * 2 / 3;
        }
        if (!Game.HasFeatherFall || Game.DieRoll(13) == 1)
        {
            Game.InvenDamage(Game.SetColdDestroy, 2);
        }
        Game.TakeHit(dam, killer);
        return true;
    }
}