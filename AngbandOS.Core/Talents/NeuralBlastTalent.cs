// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.GamePacks.Cthangband;

namespace AngbandOS.Core.Talents;

[Serializable]
internal class NeuralBlastTalent : Talent
{
    private NeuralBlastTalent(Game game) : base(game) { }
    public override string Name => "Neural Blast";
    public override int Level => 2;
    public override int ManaCost => 1;
    public override int BaseFailure => 20;

    public override void Use()
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        if (Game.DieRoll(100) < Game.ExperienceLevel.IntValue * 2)
        {
            Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(PsiProjectile));
            projectile.TargetedFire(dir, Game.DiceRoll(3 + ((Game.ExperienceLevel.IntValue - 1) / 4), 3 + (Game.ExperienceLevel.IntValue / 15)), 0, beam: true, kill: true, jump: false, stop: false, grid: false, item: false, thru: true, hide: false);
        }
        else
        {
            Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(PsiProjectile)), dir,
                Game.DiceRoll(3 + ((Game.ExperienceLevel.IntValue - 1) / 4), 3 + (Game.ExperienceLevel.IntValue / 15)), 0);
        }
    }

    protected override string LearnedDetails()
    {
        return $"dam {3 + ((Game.ExperienceLevel.IntValue - 1) / 4)}d{3 + (Game.ExperienceLevel.IntValue / 15)}";
    }
}