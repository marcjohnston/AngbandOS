﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BoltOfFire9d8Every1d8p8DirectionalActivation : ActivationGameConfiguration
{

    public override string? PreActivationMessage => "Your {0} are covered in fire...";
    public override string RechargeTimeRollExpression => "1d8+8";

    public override string ActivationCancellableScriptItemBindingKey => nameof(Fire9d8ProjectileScript);

    public override int Value => 5000;

    public override string Name => "Fire bolt (9d8)";

}

