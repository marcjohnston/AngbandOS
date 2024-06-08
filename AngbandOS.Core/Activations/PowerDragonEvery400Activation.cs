// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

[Serializable]
internal class PowerDragonEvery400Activation : DirectionalActivation
{
    private PowerDragonEvery400Activation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "You breathe the elements...";

    public override int RechargeTime() => 400;

    protected override bool Activate(int direction)
    {
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(MissileProjectile)), direction, 300, 4);
        Game.MsgPrint("Your armor glows many colors...");
        Game.FearTimer.ResetTimer();
        Game.SuperheroismTimer.AddTimer(base.Game.DieRoll(50) + 50);
        Game.RestoreHealth(30);
        Game.BlessingTimer.AddTimer(base.Game.DieRoll(50) + 50);
        Game.AcidResistanceTimer.AddTimer(base.Game.DieRoll(50) + 50);
        Game.LightningResistanceTimer.AddTimer(base.Game.DieRoll(50) + 50);
        Game.FireResistanceTimer.AddTimer(base.Game.DieRoll(50) + 50);
        Game.ColdResistanceTimer.AddTimer(base.Game.DieRoll(50) + 50);
        Game.PoisonResistanceTimer.AddTimer(base.Game.DieRoll(50) + 50);
        return true;
    }

    public override int Value => 100000;

    public override string Name => "Breathe elements (300), berserk rage, bless, and resistance";

    public override string Frequency => "400";
}
