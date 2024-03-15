// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents;

[Serializable]
internal class NeuralBlastTalent : Talent
{
    private NeuralBlastTalent(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Neural Blast";
    public override int Level => 2;
    public override int ManaCost => 1;
    public override int BaseFailure => 20;

    public override void Use()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        if (SaveGame.DieRoll(100) < SaveGame.ExperienceLevel.Value * 2)
        {
            SaveGame.FireBeam(SaveGame.SingletonRepository.Projectiles.Get(nameof(PsiProjectile)), dir,
                SaveGame.DiceRoll(3 + ((SaveGame.ExperienceLevel.Value - 1) / 4), 3 + (SaveGame.ExperienceLevel.Value / 15)));
        }
        else
        {
            SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(PsiProjectile)), dir,
                SaveGame.DiceRoll(3 + ((SaveGame.ExperienceLevel.Value - 1) / 4), 3 + (SaveGame.ExperienceLevel.Value / 15)), 0);
        }
    }

    protected override string Comment()
    {
        return $"dam {3 + ((SaveGame.ExperienceLevel.Value - 1) / 4)}d{3 + (SaveGame.ExperienceLevel.Value / 15)}";
    }
}