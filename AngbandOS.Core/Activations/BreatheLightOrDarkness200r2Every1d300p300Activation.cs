// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

[Serializable]
internal class BreatheLightOrDarkness200r2Every1d300p300Activation : DirectionalActivation
{
    private BreatheLightOrDarkness200r2Every1d300p300Activation(Game game) : base(game) { }

    public override string? PreActivationMessage => "You breathe the elements.";
    protected override string RechargeTimeRollExpression => "1d300+300";

    protected override bool Activate(int direction)
    {
        int chance = Game.RandomLessThan(2);
        string element = chance == 0 ? "light" : "darkness";
        Game.MsgPrint($"You breathe {element}.");
        Game.FireBall(chance == 0 ? (Projectile)Game.SingletonRepository.Get<Projectile>(nameof(LightProjectile)) : Game.SingletonRepository.Get<Projectile>(nameof(DarkProjectile)), direction, 200, -2);
        return true;
    }

    public override int Value => 5000;

    public override string Name => "Breathe light/darkness (200)";

    public override string Frequency => "300+d300";
}

