﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.DirectionalActivations;

[Serializable]
internal class BreatheSoundOrShards230r2Every1d300p300DirectionalActivation : Activation
{
    private BreatheSoundOrShards230r2Every1d300p300DirectionalActivation(Game game) : base(game) { }

    protected override string RechargeTimeRollExpression => "1d300+300";

    protected override string ActivationCancellableScriptItemBindingKey => nameof(SoundOrExplode230rm2ProjectileWeightedRandom);

    public override int Value => 5000;

    public override string Name => "Breathe sound/shards (230)";

}
