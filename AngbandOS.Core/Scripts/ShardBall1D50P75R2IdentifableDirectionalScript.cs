// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ShardBall1D50P75R2IdentifableDirectionalScript : Script, IIdentifableDirectionalScript
{
    private ShardBall1D50P75R2IdentifableDirectionalScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteIdentifableDirectionalScript(int dir)
    {
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ShardProjectile)), dir, 75 + Game.DieRoll(50), 2);
        return true;
    }
}
