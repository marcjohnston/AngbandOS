// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents;

[Serializable]
internal class PulveriseTalent : Talent
{
    private PulveriseTalent(Game game) : base(game) { }
    public override string Name => "Pulverise";
    public override int Level => 11;
    public override int ManaCost => 7;
    public override int BaseFailure => 30;

    public override void Use()
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(SoundProjectile)), dir,
            Game.DiceRoll(8 + ((Game.ExperienceLevel.IntValue - 5) / 4), 8), Game.ExperienceLevel.IntValue > 20 ? ((Game.ExperienceLevel.IntValue - 20) / 8) + 1 : 0);
    }

    protected override string Comment()
    {
        return $"dam {8 + ((Game.ExperienceLevel.IntValue - 5) / 4)}d8";
        ;
    }
}