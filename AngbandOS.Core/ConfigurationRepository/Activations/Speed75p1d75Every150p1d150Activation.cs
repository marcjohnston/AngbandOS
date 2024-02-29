// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Give us temporary haste.
/// </summary>
[Serializable]
internal class Speed75p1d75Every150p1d150Activation : Activation
{
    private Speed75p1d75Every150p1d150Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 25;

    public override string? PreActivationMessage => "The {0} glows brightly...";

    protected override bool OnActivate(Item item)
    {
        if (SaveGame.TimedHaste.TurnsRemaining == 0)
        {
            SaveGame.TimedHaste.SetTimer(SaveGame.DieRoll(75) + 75);
        }
        else
        {
            SaveGame.TimedHaste.AddTimer(5);
        }
        return true;
    }

    public override int RechargeTime() => SaveGame.RandomLessThan(150) + 150;

    public override int Value => 20000;

    public override string Name => "Haste self (75+d75)";

    public override string Frequency => "200";
}
