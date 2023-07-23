// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Chaos;

[Serializable]
internal class ChaosSpellManaBurst : Spell
{
    private ChaosSpellManaBurst(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<MissileProjectile>(), dir, SaveGame.Rng.DiceRoll(3, 5) + SaveGame.ExperienceLevel + (SaveGame.ExperienceLevel /
            (SaveGame.BaseCharacterClass.ID == CharacterClass.Mage || SaveGame.BaseCharacterClass.ID == CharacterClass.HighMage ? 2 : 4)),
            SaveGame.ExperienceLevel < 30 ? 2 : 3);
    }

    public override void CastFailed()
    {
        DoWildChaoticMagic(4);
    }
    public override string Name => "Mana Burst";
    
    protected override string? Info() // TODO: Player to SaveGame
    {
        int i = SaveGame.ExperienceLevel + (SaveGame.ExperienceLevel / (SaveGame.BaseCharacterClass.ID == CharacterClass.Mage || SaveGame.BaseCharacterClass.ID == CharacterClass.HighMage ? 2 : 4));
        return $"dam 3d5+{i}";
    }
}