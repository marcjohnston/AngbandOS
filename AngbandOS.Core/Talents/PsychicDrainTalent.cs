﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents;

[Serializable]
internal class PsychicDrainTalent : Talent
{
    private PsychicDrainTalent(Game game) : base(game) { }
    public override string Name => "Psychic Drain";
    public override int Level => 25;
    public override int ManaCost => 10;
    public override int BaseFailure => 40;

    public override void Use()
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        int i = Game.DiceRoll(Game.ExperienceLevel.Value / 2, 6);
        if (Game.FireBall(Game.SingletonRepository.Projectiles.Get(nameof(PsiDrainProjectile)), dir, i, 0 + ((Game.ExperienceLevel.Value - 25) / 10)))
        {
            Game.Energy -= Game.DieRoll(150);
        }
    }

    protected override string Comment()
    {
        return $"dam {Game.ExperienceLevel.Value / 2}d6";
    }
}