// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”


namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CyclopsRacialPowerProjectileScript : ProjectileScriptGameConfiguration
{
    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => false;
    public override bool Item => false;
    public override bool Thru => true;
    public override bool Hide => false;
    public override string ProjectileBindingKey => nameof(MissileProjectile);
    public override NonDirectionalProjectileModeEnum NonDirectionalProjectileMode => NonDirectionalProjectileModeEnum.PlayerSpecified;
    public override string DamageRollExpression => "3*x/2";
    public override string? PreMessage => "You throw a huge boulder.";
}

[Serializable]
public class DarkElfBoltRacialPowerProjectileScript : ProjectileScriptGameConfiguration
{
    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => false;
    public override bool Item => false;
    public override bool Thru => true;
    public override bool Hide => false;
    public override string ProjectileBindingKey => nameof(MissileProjectile);
    public override NonDirectionalProjectileModeEnum NonDirectionalProjectileMode => NonDirectionalProjectileModeEnum.PlayerSpecified;
    public override string DamageRollExpression => "(3 + ((X - 1) / 5))d4";
    public override string? PreMessage => "You cast a magic missile.";
}

[Serializable]
public class DarkElfBeamRacialPowerProjectileScript : ProjectileScriptGameConfiguration
{
    public override bool Stop => false;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => true;
    public override bool Grid => false;
    public override bool Item => false;
    public override bool Thru => true;
    public override bool Hide => false;
    public override string ProjectileBindingKey => nameof(MissileProjectile);
    public override NonDirectionalProjectileModeEnum NonDirectionalProjectileMode => NonDirectionalProjectileModeEnum.PlayerSpecified;
    public override string DamageRollExpression => "(3 + ((X - 1) / 5))d4";
    public override string? PreMessage => "You cast a magic missile.";
}

[Serializable]
public class DraconianRacialPowerColdBallProjectileScript : ProjectileScriptGameConfiguration
{
    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Thru => true;
    public override bool Hide => false;
    public override string RadiusRollExpression => "-(X / 15) + 1";
    public override string ProjectileBindingKey => nameof(ColdProjectile);
    public override NonDirectionalProjectileModeEnum NonDirectionalProjectileMode => NonDirectionalProjectileModeEnum.PlayerSpecified;
    public override string DamageRollExpression => "2 * X";
    public override string? PreMessage => "You breathe cold.";
}

[Serializable]
public class DraconianRacialPowerFireBallProjectileScript : ProjectileScriptGameConfiguration
{
    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Thru => true;
    public override bool Hide => false;
    public override string RadiusRollExpression => "-(X / 15) + 1";
    public override string ProjectileBindingKey => nameof(FireProjectile);
    public override NonDirectionalProjectileModeEnum NonDirectionalProjectileMode => NonDirectionalProjectileModeEnum.PlayerSpecified;
    public override string DamageRollExpression => "2 * X";
    public override string? PreMessage => "You breathe fire.";
}

[Serializable]
public class DraconianRacialPowerMissileBallProjectileScript : ProjectileScriptGameConfiguration
{
    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Thru => true;
    public override bool Hide => false;
    public override string RadiusRollExpression => "-(X / 15) + 1";
    public override string ProjectileBindingKey => nameof(MissileProjectile);
    public override NonDirectionalProjectileModeEnum NonDirectionalProjectileMode => NonDirectionalProjectileModeEnum.PlayerSpecified;
    public override string DamageRollExpression => "2 * X";
    public override string? PreMessage => "You breathe the elements.";
}

[Serializable]
public class DraconianRacialPowerExplodeBallProjectileScript : ProjectileScriptGameConfiguration
{
    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Thru => true;
    public override bool Hide => false;
    public override string RadiusRollExpression => "-(X / 15) + 1";
    public override string ProjectileBindingKey => nameof(ExplodeProjectile);
    public override NonDirectionalProjectileModeEnum NonDirectionalProjectileMode => NonDirectionalProjectileModeEnum.PlayerSpecified;
    public override string DamageRollExpression => "2 * X";
    public override string? PreMessage => "You breathe shards.";
}

[Serializable]
public class DraconianRacialPowerManaBallProjectileScript : ProjectileScriptGameConfiguration
{
    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Thru => true;
    public override bool Hide => false;
    public override string RadiusRollExpression => "-(X / 15) + 1";
    public override string ProjectileBindingKey => nameof(ManaProjectile);
    public override NonDirectionalProjectileModeEnum NonDirectionalProjectileMode => NonDirectionalProjectileModeEnum.PlayerSpecified;
    public override string DamageRollExpression => "2 * X";
    public override string? PreMessage => "You breathe mana.";
}

[Serializable]
public class DraconianRacialPowerDisenchantmentBallProjectileScript : ProjectileScriptGameConfiguration
{
    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Thru => true;
    public override bool Hide => false;
    public override string RadiusRollExpression => "-(X / 15) + 1";
    public override string ProjectileBindingKey => nameof(DisenchantProjectile);
    public override NonDirectionalProjectileModeEnum NonDirectionalProjectileMode => NonDirectionalProjectileModeEnum.PlayerSpecified;
    public override string DamageRollExpression => "2 * X";
    public override string? PreMessage => "You breathe disenchantment.";
}

[Serializable]
public class DraconianRacialPowerConfusionBallProjectileScript : ProjectileScriptGameConfiguration
{
    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Thru => true;
    public override bool Hide => false;
    public override string RadiusRollExpression => "-(X / 15) + 1";
    public override string ProjectileBindingKey => nameof(ConfusionProjectile);
    public override NonDirectionalProjectileModeEnum NonDirectionalProjectileMode => NonDirectionalProjectileModeEnum.PlayerSpecified;
    public override string DamageRollExpression => "2 * X";
    public override string? PreMessage => "You breathe confusion.";
}

[Serializable]
public class DraconianRacialPowerChaosBallProjectileScript : ProjectileScriptGameConfiguration
{
    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Thru => true;
    public override bool Hide => false;
    public override string RadiusRollExpression => "-(X / 15) + 1";
    public override string ProjectileBindingKey => nameof(ChaosProjectile);
    public override NonDirectionalProjectileModeEnum NonDirectionalProjectileMode => NonDirectionalProjectileModeEnum.PlayerSpecified;
    public override string DamageRollExpression => "2 * X";
    public override string? PreMessage => "You breathe chaos.";
}

[Serializable]
public class DraconianRacialPowerSoundBallProjectileScript : ProjectileScriptGameConfiguration
{
    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Thru => true;
    public override bool Hide => false;
    public override string RadiusRollExpression => "-(X / 15) + 1";
    public override string ProjectileBindingKey => nameof(SoundProjectile);
    public override NonDirectionalProjectileModeEnum NonDirectionalProjectileMode => NonDirectionalProjectileModeEnum.PlayerSpecified;
    public override string DamageRollExpression => "2 * X";
    public override string? PreMessage => "You breathe sound.";
}

[Serializable]
public class DraconianRacialPowerPsiBallProjectileScript : ProjectileScriptGameConfiguration
{
    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Thru => true;
    public override bool Hide => false;
    public override string RadiusRollExpression => "-(X / 15) + 1";
    public override string ProjectileBindingKey => nameof(PsiProjectile);
    public override NonDirectionalProjectileModeEnum NonDirectionalProjectileMode => NonDirectionalProjectileModeEnum.PlayerSpecified;
    public override string DamageRollExpression => "2 * X";
    public override string? PreMessage => "You breathe mental energy.";
}

[Serializable]
public class DraconianRacialPowerHellFireBallProjectileScript : ProjectileScriptGameConfiguration
{
    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Thru => true;
    public override bool Hide => false;
    public override string RadiusRollExpression => "-(X / 15) + 1";
    public override string ProjectileBindingKey => nameof(HellfireProjectile);
    public override NonDirectionalProjectileModeEnum NonDirectionalProjectileMode => NonDirectionalProjectileModeEnum.PlayerSpecified;
    public override string DamageRollExpression => "2 * X";
    public override string? PreMessage => "You breathe hellfire.";
}

[Serializable]
public class DraconianRacialPowerHolyFireBallProjectileScript : ProjectileScriptGameConfiguration
{
    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Thru => true;
    public override bool Hide => false;
    public override string RadiusRollExpression => "-(X / 15) + 1";
    public override string ProjectileBindingKey => nameof(HolyFireProjectile);
    public override NonDirectionalProjectileModeEnum NonDirectionalProjectileMode => NonDirectionalProjectileModeEnum.PlayerSpecified;
    public override string DamageRollExpression => "2 * X";
    public override string? PreMessage => "You breathe holy fire.";
}

[Serializable]
public class DraconianRacialPowerDarknessBallProjectileScript : ProjectileScriptGameConfiguration
{
    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Thru => true;
    public override bool Hide => false;
    public override string RadiusRollExpression => "-(X / 15) + 1";
    public override string ProjectileBindingKey => nameof(DarknessProjectile);
    public override NonDirectionalProjectileModeEnum NonDirectionalProjectileMode => NonDirectionalProjectileModeEnum.PlayerSpecified;
    public override string DamageRollExpression => "2 * X";
    public override string? PreMessage => "You breathe darkness.";
}

[Serializable]
public class DraconianRacialPowerPoisonBallProjectileScript : ProjectileScriptGameConfiguration
{
    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Thru => true;
    public override bool Hide => false;
    public override string RadiusRollExpression => "-(X / 15) + 1";
    public override string ProjectileBindingKey => nameof(PoisonGasProjectile);
    public override NonDirectionalProjectileModeEnum NonDirectionalProjectileMode => NonDirectionalProjectileModeEnum.PlayerSpecified;
    public override string DamageRollExpression => "2 * X";
    public override string? PreMessage => "You breathe poison.";
}
