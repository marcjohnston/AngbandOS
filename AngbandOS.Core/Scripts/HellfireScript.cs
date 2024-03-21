// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class HellfireScript : Script, IScript
{
    private HellfireScript(Game game) : base(game) { }

    /// <summary>
    /// Fires a ball of hellfire in a chosen direction with 666 damage and radius of 3; also, causing between 50 and 100 points of damage to the player.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Game.FireBall(Game.SingletonRepository.Projectiles.Get(nameof(HellfireProjectile)), dir, 666, 3);
        Game.TakeHit(50 + Game.DieRoll(50), "the strain of casting Hellfire");
    }
}
