// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BallOfAcid50r2AndResistAcid1d20p20Script : Script, IUsedScriptItemDirection
{
    private BallOfAcid50r2AndResistAcid1d20p20Script(Game game) : base(game) { }

    public bool ExecuteUsedScriptItemDirection(Item item, int direction) // This is run by an item activation
    {
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile)), direction, 50, 2);
        Game.AcidResistanceTimer.AddTimer(Game.DieRoll(20) + 20);
        return true;
    }
}
