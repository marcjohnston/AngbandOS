// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents;

[Serializable]
internal class PsychicDrainTalent : Talent
{
    private PsychicDrainTalent(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Psychic Drain";
    public override void Initialize(int characterClass)
    {
        Level = 25;
        ManaCost = 10;
        BaseFailure = 40;
    }

    public override void Use(SaveGame saveGame)
    {
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        int i = Program.Rng.DiceRoll(saveGame.Player.ExperienceLevel / 2, 6);
        if (saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get<PsiDrainProjectile>(), dir, i, 0 + ((saveGame.Player.ExperienceLevel - 25) / 10)))
        {
            saveGame.Player.Energy -= Program.Rng.DieRoll(150);
        }
    }

    protected override string Comment(Player player)
    {
        return $"dam {player.ExperienceLevel / 2}d6";
    }
}