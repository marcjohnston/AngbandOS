// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class MagicMissleScript : Script, IScript
{
    private MagicMissleScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Fires a bolt or beam of missle in a chosen direction.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
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
        SaveGame.FireBoltOrBeam(beam - 10, SaveGame.SingletonRepository.Projectiles.Get(nameof(MissileProjectile)), dir, SaveGame.Rng.DiceRoll(3 + ((SaveGame.ExperienceLevel - 1) / 5), 4));
    }
}
