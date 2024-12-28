// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BreatheChaosDisenchantSoundOrShardsScript : Script, IDirectionalCancellableScriptItem
{
    private BreatheChaosDisenchantSoundOrShardsScript(Game game) : base(game) { }

    public bool ExecuteCancellableScriptItem(Item item, int direction) // This is run by an item activation
    {
        int chance = Game.RandomLessThan(4);
        string element = chance == 1 ? "chaos" : (chance == 2 ? "disenchantment" : (chance == 3 ? "sound" : "shards"));
        Game.MsgPrint($"You breathe {element}.");
        Game.FireBall(chance == 1 ? Game.SingletonRepository.Get<Projectile>(nameof(ChaosProjectile)) : (chance == 2 ? Game.SingletonRepository.Get<Projectile>(nameof(DisenchantProjectile)) : (chance == 3 ? (Projectile)Game.SingletonRepository.Get<Projectile>(nameof(SoundProjectile)) : Game.SingletonRepository.Get<Projectile>(nameof(ExplodeProjectile)))), direction, 250, -2);
        return true;
    }
}
