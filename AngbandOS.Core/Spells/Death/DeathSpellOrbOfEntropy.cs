// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death;

[Serializable]
internal class DeathSpellOrbOfEntropy : Spell
{
    private DeathSpellOrbOfEntropy(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<OldDrainProjectile>(), dir,
            SaveGame.Rng.DiceRoll(3, 6) + SaveGame.ExperienceLevel + (SaveGame.ExperienceLevel /
            (SaveGame.BaseCharacterClass.ID == CharacterClass.Mage || SaveGame.BaseCharacterClass.ID == CharacterClass.HighMage ? 2 : 4)),
            SaveGame.ExperienceLevel < 30 ? 2 : 3);
    }

    public override void CastFailed()
    {
        DoWildDeathMagic(8, 1);
    }

    public override string Name => "Orb of Entropy";
    
    protected override string? Info()
    {
        int s = SaveGame.ExperienceLevel + (SaveGame.ExperienceLevel / (SaveGame.BaseCharacterClass.ID == CharacterClass.Mage || SaveGame.BaseCharacterClass.ID == CharacterClass.HighMage ? 2 : 4));
        return $"dam 3d6+{s}";
    }
}