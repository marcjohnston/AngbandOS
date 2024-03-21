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
    private MagicMissleScript(Game game) : base(game) { }

    /// <summary>
    /// Fires a bolt or beam of missle in a chosen direction.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int beam;
        switch (Game.BaseCharacterClass.ID)
        {
            case CharacterClass.Mage:
                beam = Game.ExperienceLevel.Value;
                break;

            case CharacterClass.HighMage:
                beam = Game.ExperienceLevel.Value + 10;
                break;

            default:
                beam = Game.ExperienceLevel.Value / 2;
                break;
        }
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Game.FireBoltOrBeam(beam - 10, Game.SingletonRepository.Projectiles.Get(nameof(MissileProjectile)), dir, Game.DiceRoll(3 + ((Game.ExperienceLevel.Value - 1) / 5), 4));
    }
}
