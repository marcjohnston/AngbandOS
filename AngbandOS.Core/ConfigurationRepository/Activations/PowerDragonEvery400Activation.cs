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
    private PowerDragonEvery400Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 5;

    public override string? PreActivationMessage => "You breathe the elements...";

    public override int RechargeTime() => 400;

    protected override bool Activate(int direction)
    {
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(MissileProjectile)), direction, 300, 4);
        SaveGame.MsgPrint("Your armor glows many colors...");
        SaveGame.FearTimer.ResetTimer();
        SaveGame.SuperheroismTimer.AddTimer(base.SaveGame.DieRoll(50) + 50);
        SaveGame.RestoreHealth(30);
        SaveGame.BlessingTimer.AddTimer(base.SaveGame.DieRoll(50) + 50);
        SaveGame.AcidResistanceTimer.AddTimer(base.SaveGame.DieRoll(50) + 50);
        SaveGame.LightningResistanceTimer.AddTimer(base.SaveGame.DieRoll(50) + 50);
        SaveGame.FireResistanceTimer.AddTimer(base.SaveGame.DieRoll(50) + 50);
        SaveGame.ColdResistanceTimer.AddTimer(base.SaveGame.DieRoll(50) + 50);
        SaveGame.PoisonResistanceTimer.AddTimer(base.SaveGame.DieRoll(50) + 50);
        return true;
    }

    public override int Value => 100000;

    public override string Name => "Breathe elements (300), berserk rage, bless, and resistance";

    public override string Frequency => "400";
}
