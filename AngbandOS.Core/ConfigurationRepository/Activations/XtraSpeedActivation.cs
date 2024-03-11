// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Give us extra haste for a long time.
/// </summary>
[Serializable]
internal class XtraSpeedActivation : Activation
{
    private XtraSpeedActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 10;

    public override string? PreActivationMessage => "Your {0} glows brightly...";

    protected override bool OnActivate(Item item)
    {
        if (SaveGame.TimedHaste.Value == 0)
        {
            SaveGame.TimedHaste.SetTimer(SaveGame.DieRoll(75) + 75);
        }
        else
        {
            SaveGame.TimedHaste.AddTimer(5);
        }
        return true;
    }

    public override int RechargeTime() => SaveGame.RandomLessThan(200) + 200;

    public override int Value => 25000;

    public override string Name => "Speed (75+d75)";

    public override string Frequency => "200+d200";
}
