// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projectiles;

[Serializable]
internal class OldSleepProjectile : Projectile
{
    private OldSleepProjectile(Game game) : base(game) { }

    protected override Animation EffectAnimation => Game.SingletonRepository.Get<Animation>(nameof(YellowSparkleAnimation));

    protected override string AffectMonsterScriptBindingKey => nameof(OldSleepMonsterEffect);

    protected override bool AffectPlayer(int who, int r, int y, int x, int dam, int aRad)
    {
        bool blind = Game.BlindnessTimer.Value != 0;
        if (dam > 1600)
        {
            dam = 1600;
        }
        dam = (dam + r) / (r + 1);
        if (Game.HasFreeAction)
        {
            return false;
        }
        if (blind)
        {
            Game.MsgPrint("You fall asleep!");
        }
        Game.ParalysisTimer.AddTimer(dam);
        return true;
    }
}