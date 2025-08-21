// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.GamePacks.Cthangband;

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class MindBlastActiveMutation : Mutation
{
    private MindBlastActiveMutation(Game game) : base(game) { }
    public override void Activate()
    {
        if (!Game.CheckIfRacialPowerWorks(5, 3, Game.WisdomAbility, 15))
        {
            return;
        }
        Game.MsgPrint("You concentrate...");
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(PsiProjectile));
        projectile.TargetedFire(dir, base.Game.DiceRoll(3 + ((Game.ExperienceLevel.IntValue - 1) / 5), 3), 0, stop: true, kill: true, jump: false, beam: false, grid: false, item: false, thru: true, hide: false);
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 5 ? "mind blast       (unusable until level 5)" : "mind blast       (cost 3, WIS based)";
    }

    public override int Frequency => 2;
    public override string GainMessage => "You gain the power of Mind Blast.";
    public override string HaveMessage => "You can Mind Blast your enemies.";
    public override string LoseMessage => "You lose the power of Mind Blast.";
}