// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BreatheLightningFrostAcidPoisonGasOrFire250r2Script : Script, IDirectionalCancellableScriptItem
{
    private BreatheLightningFrostAcidPoisonGasOrFire250r2Script(Game game) : base(game) { }

    public bool ExecuteCancellableScriptItem(Item item, int direction) // This is run by an item activation
    {
        int chance = Game.RandomLessThan(5);
        string element = chance == 1 ? "lightning" : (chance == 2 ? "frost" : (chance == 3 ? "acid" : (chance == 4 ? "poison gas" : "fire")));
        Game.MsgPrint($"You breathe {element}.");
        switch (chance)
        {
            case 0:
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile)), direction, 250, -2);
                break;
            case 1:
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ElectricityProjectile)), direction, 250, -2);
                break;
            case 2:
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ColdProjectile)), direction, 250, -2);
                break;
            case 3:
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile)), direction, 250, -2);
                break;
            case 4:
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(PoisonProjectile)), direction, 250, -2);
                break;
        }
        return true;
    }
}
