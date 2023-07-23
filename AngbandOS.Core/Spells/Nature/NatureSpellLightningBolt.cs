// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Nature;

[Serializable]
internal class NatureSpellLightningBolt : Spell
{
    private NatureSpellLightningBolt(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        int beam;
        switch (SaveGame.BaseCharacterClass.ID)
        {
            case CharacterClass.Mage:
                beam = SaveGame.ExperienceLevel;
                break;

            case CharacterClass.HighMage:
                beam = SaveGame.ExperienceLevel + 10;
                break;

            default:
                beam = SaveGame.ExperienceLevel / 2;
                break;
        }
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.FireBoltOrBeam(beam - 10, SaveGame.SingletonRepository.Projectiles.Get<ElecProjectile>(), dir,
            SaveGame.Rng.DiceRoll(3 + ((SaveGame.ExperienceLevel - 5) / 4), 8));
    }

    public override string Name => "Lightning Bolt";
    
    protected override string? Info()
    {
        return $"dam {3 + ((SaveGame.ExperienceLevel - 5) / 4)}d8";
    }
}