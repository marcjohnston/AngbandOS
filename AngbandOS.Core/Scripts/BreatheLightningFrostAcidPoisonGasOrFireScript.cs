// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BreatheLightningFrostAcidPoisonGasOrFireScript : Script, IScript
{
    private BreatheLightningFrostAcidPoisonGasOrFireScript(Game game) : base(game) { }

    /// <summary>
    /// Allows a direction to be chosen, then fires a chaos ball projectile with a damage that matches the players health with a radius of -2.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        int chance = Game.RandomLessThan(5);
        string element = chance == 1 ? "lightning" : (chance == 2 ? "frost" : (chance == 3 ? "acid" : (chance == 4 ? "poison gas" : "fire")));
        Game.MsgPrint($"You breathe {element}.");
        switch (chance)
        {
            case 0:
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile)), dir, 250, -2);
                return;
            case 1:
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ElecProjectile)), dir, 250, -2);
                return;

            case 2:
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ColdProjectile)), dir, 250, -2);
                return;

            case 3:
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile)), dir, 250, -2);
                return;

            case 4:
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(PoisProjectile)), dir, 250, -2);
                return;
        }
    }
}
