// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BallOfChaos200r2Script : Script, IDirectionalCancellableScriptItem
{
    private BallOfChaos200r2Script(Game game) : base(game) { }

    public bool ExecuteCancellableScriptItem(Item item, int direction) // This is run by an item activation
    {
        int chance = Game.RandomLessThan(2);
        string element = chance == 1 ? "chaos" : "disenchantment";
        Game.MsgPrint($"You breathe {element}.");
        Game.FireBall(projectile: chance == 1 ? (Projectile)Game.SingletonRepository.Get<Projectile>(nameof(ChaosProjectile)) : Game.SingletonRepository.Get<Projectile>(nameof(DisenchantProjectile)), direction, 220, -2);
        return true;
    }
}
