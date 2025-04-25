// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents;

[Serializable]
internal class DominationTalent : Talent
{
    private DominationTalent(Game game) : base(game) { }
    public override string Name => "Domination";
    public override int Level => 9;
    public override int ManaCost => 7;
    public override int BaseFailure => 50;

    public override void Use()
    {
        if (Game.ExperienceLevel.IntValue < 30)
        {
            if (!Game.GetDirectionWithAim(out int dir))
            {
                return;
            }
            Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(DominationProjectile)), dir, Game.ExperienceLevel.IntValue, 0);
        }
        else
        {
            Game.RunScript(nameof(ControlAnimalAtLos2xProjectileScript));
        }
    }

    protected override string Comment()
    {
        return string.Empty;
    }
}