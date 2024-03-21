// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DarkBoltScript : Script, IScript
{
    private DarkBoltScript(Game game) : base(game) { }

    /// <summary>
    /// Fires a bolt or beam of dark in a chosen direction with damage equal to 1/2 the experience or for mages, 1x experience or for high mages, experience + 10.
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
        Game.FireBoltOrBeam(beam, Game.SingletonRepository.Projectiles.Get(nameof(DarkProjectile)), dir, Game.DiceRoll(4 + ((Game.ExperienceLevel.Value - 5) / 4), 8));
    }
}
