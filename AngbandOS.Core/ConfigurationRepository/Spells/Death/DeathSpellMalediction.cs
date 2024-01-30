// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death;

[Serializable]
internal class DeathSpellMalediction : Spell
{
    private DeathSpellMalediction(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(HellFireProjectile)), dir,
            SaveGame.Rng.DiceRoll(3 + ((SaveGame.ExperienceLevel - 1) / 5), 3), 0);
        if (SaveGame.Rng.DieRoll(5) != 1)
        {
            return;
        }
        int dummy = SaveGame.Rng.DieRoll(1000);
        if (dummy == 666)
        {
            SaveGame.FireBolt(SaveGame.SingletonRepository.Projectiles.Get(nameof(DeathRayProjectile)), dir, SaveGame.ExperienceLevel);
        }
        if (dummy < 500)
        {
            SaveGame.FireBolt(SaveGame.SingletonRepository.Projectiles.Get(nameof(TurnAllProjectile)), dir, SaveGame.ExperienceLevel);
        }
        if (dummy < 800)
        {
            SaveGame.FireBolt(SaveGame.SingletonRepository.Projectiles.Get(nameof(OldConfProjectile)), dir, SaveGame.ExperienceLevel);
        }
        SaveGame.FireBolt(SaveGame.SingletonRepository.Projectiles.Get(nameof(StunProjectile)), dir, SaveGame.ExperienceLevel);
    }

    public override void CastFailed()
    {
        DoWildDeathMagic(1, 0);
    }

    public override string Name => "Malediction";

    protected override string LearnedDetails => $"dam {3 + ((SaveGame.ExperienceLevel - 1) / 5)}d3";
}