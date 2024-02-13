// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ManaBurstScript : Script, IScript
{
    private ManaBurstScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Fires a ball of missle in a chosen direction.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        int experienceDivisor = (SaveGame.BaseCharacterClass.ID == CharacterClass.Mage || SaveGame.BaseCharacterClass.ID == CharacterClass.HighMage ? 2 : 4);
        int damage = SaveGame.DiceRoll(3, 5) + SaveGame.ExperienceLevel + (SaveGame.ExperienceLevel / experienceDivisor);
        int radius = SaveGame.ExperienceLevel < 30 ? 2 : 3;
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(MissileProjectile)), dir, damage, radius);
    }
}
