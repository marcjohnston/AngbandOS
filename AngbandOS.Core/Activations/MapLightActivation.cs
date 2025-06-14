﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Activations;

/// <summary>
/// Map the local area.
/// </summary>
[Serializable]
internal class MapLightActivation : Activation
{
    private MapLightActivation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} shines brightly...";

    protected override string ActivationCancellableScriptItemBindingKey => nameof(MapLightScript);

    protected override string RechargeTimeRollExpression => "1d50+50";

    public override int Value => 500;

    public override string Name => "Light (dam 2d15) & map area";

}
