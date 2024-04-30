// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ElementalBallScript : Script, IScript
{
    private ElementalBallScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Projectile dummy;
        switch (Game.DieRoll(4))
        {
            case 1:
                dummy = Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile));
                break;

            case 2:
                dummy = Game.SingletonRepository.Get<Projectile>(nameof(ElecProjectile));
                break;

            case 3:
                dummy = Game.SingletonRepository.Get<Projectile>(nameof(ColdProjectile));
                break;

            default:
                dummy = Game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile));
                break;
        }
        Game.FireBall(dummy, dir, 75 + Game.ExperienceLevel.IntValue, 2);
    }
}
