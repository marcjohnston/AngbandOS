// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Give temporary telepathy.
/// </summary>
[Serializable]
internal class EspActivation : Activation
{
    private EspActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 85;

    public override string? PreActivationMessage => "";

    public override bool Activate()
    {
        SaveGame.RunScript(nameof(AddTelepathy1d30p25Script));
        return true;
    }

    public override int RechargeTime() => 200;

    public override int Value => 1500;

    public override string Name => "temporary ESP (dur 25+d30)";

    public override string Description => $"{Name} every 200 turns";
}
