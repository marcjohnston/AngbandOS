// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DragonsBreathIdentifableDirectionalScript : Script, IIdentifableDirectionalScript
{
    private DragonsBreathIdentifableDirectionalScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteIdentifableDirectionalScript(int dir)
    {
        switch (Game.RandomLessThan(5))
        {
            case 0:
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile)), dir, 100, -3);
                break;
            case 1:
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ElecProjectile)), dir, 80, -3);
                break;
            case 2:
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile)), dir, 100, -3);
                break;
            case 3:
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ColdProjectile)), dir, 80, -3);
                break;
            case 4:
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(PoisProjectile)), dir, 60, -3);
                break;
            default:
                throw new Exception("Internal error.");
        }
        return true;
    }
}
