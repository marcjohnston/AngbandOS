// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BallOfFire50r2AndResistFire1d20p20Script : Script, IDirectionalActivationScript
{
    private BallOfFire50r2AndResistFire1d20p20Script(Game game) : base(game) { }

    public UsedResult ExecuteDirectionalActivationScript(Item item, int direction) // This is run by an item activation
    {
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile)), direction, 50, 2);
        Game.FireResistanceTimer.AddTimer(Game.DieRoll(20) + 20);
        return new UsedResult(true);
    }
}
