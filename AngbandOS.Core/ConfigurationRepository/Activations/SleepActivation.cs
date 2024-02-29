// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Activate sleep on touch.
/// </summary>
[Serializable]
internal class SleepActivation : Activation
{
    private SleepActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 101;

    public override string? PreActivationMessage => "Your {0} glows deep blue...";

    public override int RechargeTime() => 55;

    protected override bool OnActivate(Item item)
    {
        SaveGame.SleepMonstersTouch();
        return true;
    }

    public override int Value => 750;

    public override string Name => "Sleep nearby monsters";

    public override string Frequency => "55";
}
