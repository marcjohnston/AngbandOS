// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

[Serializable]
internal class BreatheLightningFrostAcidPoisonGasOrFire250r2Every1d225p225Activation : DirectionalActivation
{
    private BreatheLightningFrostAcidPoisonGasOrFire250r2Every1d225p225Activation(Game game) : base(game) { }

    protected override string RechargeTimeRollExpression => "1d225+225";

    protected override bool Activate(int direction)
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
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ElecProjectile)), direction, 250, -2);
                break;
            case 2:
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ColdProjectile)), direction, 250, -2);
                break;
            case 3:
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile)), direction, 250, -2);
                break;
            case 4:
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(PoisProjectile)), direction, 250, -2);
                break;
        }
        return true;
    }

    public override int Value => 5000;

    public override string Name => "Breathe multi-hued (250)";

    public override string Frequency => "225+d225";
}

