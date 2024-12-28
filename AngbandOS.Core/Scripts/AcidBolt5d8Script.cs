// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class AcidBolt5d8Script : Script, IDirectionalCancellableScriptItem
{
    private AcidBolt5d8Script(Game game) : base(game) { }

    public bool ExecuteCancellableScriptItem(Item item, int direction) // This is run by an item activation
    {
        Game.FireBolt(Game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile)), direction, Game.DiceRoll(5, 8));
        return true;
    }
}
