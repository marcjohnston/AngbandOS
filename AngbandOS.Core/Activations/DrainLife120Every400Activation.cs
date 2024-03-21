// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Drain up to 120 life from an opponent.
/// </summary>
[Serializable]
internal class DrainLife120Every400Activation : DirectionalActivation
{
    private DrainLife120Every400Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 66;

    public override string? PreActivationMessage => "Your {0} glows black...";

    public override int RechargeTime() => 400;

    protected override bool Activate(int direction)
    {
        SaveGame.DrainLife(direction, 120);
        return true;
    }

    public override int Value => 750;

    public override string Name => "Drain life (120)";

    public override string Frequency => "400";
}
