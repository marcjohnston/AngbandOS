// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Give us temporary invulnerabliity.
/// </summary>
[Serializable]
internal class InvulnActivation : Activation
{
    private InvulnActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 5;

    public override string? PreActivationMessage => "";

    protected override bool OnActivate(Item item)
    {
        SaveGame.InvulnerabilityTimer.AddTimer(SaveGame.DieRoll(8) + 8);
        return true;
    }

    public override int RechargeTime() => 1000;

    public override int Value => 25000;

    public override string Name => "Invulnerability (8+d8)";

    public override string Frequency => "1000";
}
