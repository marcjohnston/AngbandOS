// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ProjectileScripts;

[Serializable]
internal class _template_ball : ProjectileScript
{
    private _template_ball(Game game) : base(game) { }

    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Thru => true;
    public override bool Hide => false;
    protected override string ProjectileBindingKey => nameof(ColdProjectile);
    protected override string DamageRollExpression => "100";
    protected override string RadiusRollExpression => "2";
}

[Serializable]
internal class _template_bolt : ProjectileScript
{
    private _template_bolt(Game game) : base(game) { }

    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => false;
    public override bool Item => false;
    public override bool Thru => true;
    public override bool Hide => false;
    protected override string ProjectileBindingKey => nameof(AcidProjectile);
    protected override string DamageRollExpression => "5d8";
}

[Serializable]
internal class _template_los : ProjectileScript
{
    private _template_los(Game game) : base(game) { }

    public override bool Stop => false;
    public override bool Kill => true;
    public override bool Jump => true;
    public override bool Beam => false;
    public override bool Grid => false;
    public override bool Item => false;
    public override bool Thru => false;
    public override bool Hide => true;
    protected override string ProjectileBindingKey => nameof(OldSpeedProjectile);
    protected override string DamageRollExpression => "1d1xX";
    public override NonDirectionalProjectileModeEnum NonDirectionalProjectileMode => NonDirectionalProjectileModeEnum.AllMonstersInLos;
    public override bool? Identified => null;
}

[Serializable]
internal class MakeTrapr1ProjectileScript : ProjectileScript
{
    private MakeTrapr1ProjectileScript(Game game) : base(game) { }

    public override bool Stop => false;
    public override bool Kill => false;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Thru => true;
    public override bool Hide => true;
    protected override string ProjectileBindingKey => nameof(MakeTrapProjectile);
    protected override string DamageRollExpression => "0";
    protected override string RadiusRollExpression => "1";
}
