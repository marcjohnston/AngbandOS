// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

[Serializable]
internal class BreatheChaosDisenchantSoundOrShardsActivation : DirectionalActivation
{
    private BreatheChaosDisenchantSoundOrShardsActivation(Game game) : base(game) { }

    protected override string RechargeTimeRollExpression => "1d300+300";

    protected override bool Activate(int direction)
    {
        int chance = Game.RandomLessThan(4);
        string element = chance == 1 ? "chaos" : (chance == 2 ? "disenchantment" : (chance == 3 ? "sound" : "shards"));
        Game.MsgPrint($"You breathe {element}.");
        Game.FireBall(chance == 1 ? Game.SingletonRepository.Get<Projectile>(nameof(ChaosProjectile)) : (chance == 2 ? Game.SingletonRepository.Get<Projectile>(nameof(DisenchantProjectile)) : (chance == 3 ? (Projectile)Game.SingletonRepository.Get<Projectile>(nameof(SoundProjectile)) : Game.SingletonRepository.Get<Projectile>(nameof(ExplodeProjectile)))), direction, 250, -2);
        return true;
    }

    public override int Value => 10000;

    public override string Name => "Breathe balance (250)";

    public override string Frequency => "300+d300";
}

