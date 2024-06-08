// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Charm multiple monsters.
/// </summary>
[Serializable]
internal class MassCharmEvery750Activation : Activation
{
    private MassCharmEvery750Activation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "";

    protected override bool OnActivate(Item item)
    {
        Game.RunScript(nameof(CharmOthersScript));
        return true;
    }

    public override int RechargeTime() => 750;

    public override int Value => 17500;

    public override string Name => "Mass charm";

    public override string Frequency => "750";
}
