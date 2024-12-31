// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ProjectileScripts;

[Serializable]
internal class Chaos250rm2ProjectileScript : ProjectileScript
{
    private Chaos250rm2ProjectileScript(Game game) : base(game) { }

    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Thru => true;
    public override bool Hide => false;
    protected override string ProjectileBindingKey => nameof(ChaosProjectile);
    protected override string DamageRollExpression => "250";
    protected override string RadiusRollExpression => "-2";
    public override string? PreMessage => "You breathe chaos.";
}

[Serializable]
internal class Fire250rm2ProjectileScript : ProjectileScript
{
    private Fire250rm2ProjectileScript(Game game) : base(game) { }

    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Thru => true;
    public override bool Hide => false;
    protected override string ProjectileBindingKey => nameof(FireProjectile);
    protected override string DamageRollExpression => "250";
    protected override string RadiusRollExpression => "-2";
    public override string? PreMessage => "You breathe fire.";
}

[Serializable]
internal class Electricity250rm2ProjectileScript : ProjectileScript
{
    private Electricity250rm2ProjectileScript(Game game) : base(game) { }

    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Thru => true;
    public override bool Hide => false;
    protected override string ProjectileBindingKey => nameof(ElectricityProjectile);
    protected override string DamageRollExpression => "250";
    protected override string RadiusRollExpression => "-2";
    public override string? PreMessage => "You breathe lightning.";
}

[Serializable]
internal class Cold250rm2ProjectileScript : ProjectileScript
{
    private Cold250rm2ProjectileScript(Game game) : base(game) { }

    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Thru => true;
    public override bool Hide => false;
    protected override string ProjectileBindingKey => nameof(ColdProjectile);
    protected override string DamageRollExpression => "250";
    protected override string RadiusRollExpression => "-2";
    public override string? PreMessage => "You breathe frost.";
}

[Serializable]
internal class Acid250rm2ProjectileScript : ProjectileScript
{
    private Acid250rm2ProjectileScript(Game game) : base(game) { }

    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Thru => true;
    public override bool Hide => false;
    protected override string ProjectileBindingKey => nameof(AcidProjectile);
    protected override string DamageRollExpression => "250";
    protected override string RadiusRollExpression => "-2";
    public override string? PreMessage => "You breathe acid.";
}

[Serializable]
internal class PoisonGas250rm2ProjectileScript : ProjectileScript
{
    private PoisonGas250rm2ProjectileScript(Game game) : base(game) { }

    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Thru => true;
    public override bool Hide => false;
    protected override string ProjectileBindingKey => nameof(PoisonGasProjectile);
    protected override string DamageRollExpression => "250";
    protected override string RadiusRollExpression => "-2";
    public override string? PreMessage => "You breathe poison gas.";
}
