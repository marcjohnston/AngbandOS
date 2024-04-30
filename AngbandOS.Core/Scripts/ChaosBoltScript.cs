// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ChaosBoltScript : Script, IScript
{
    private ChaosBoltScript(Game game) : base(game) { }

    /// <summary>
    /// Fires a bolt or a beam of chaos in a chosen direction.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int beam;
        switch (Game.BaseCharacterClass.ID)
        {
            case CharacterClass.Mage:
                beam = Game.ExperienceLevel.IntValue;
                break;

            case CharacterClass.HighMage:
                beam = Game.ExperienceLevel.IntValue + 10;
                break;

            default:
                beam = Game.ExperienceLevel.IntValue / 2;
                break;
        }
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Game.FireBoltOrBeam(beam, Game.SingletonRepository.Get<Projectile>(nameof(ChaosProjectile)), dir, Game.DiceRoll(10 + ((Game.ExperienceLevel.IntValue - 5) / 4), 8));
    }
}
