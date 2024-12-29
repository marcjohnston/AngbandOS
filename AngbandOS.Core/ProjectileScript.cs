// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal abstract class ProjectileScript : Script, IDirectionalCancellableScriptItem
{
    public ProjectileScript(Game game) : base(game) { }

    public override void Bind()
    {
        base.Bind();
        Projectile = Game.SingletonRepository.Get<Projectile>(ProjectileBindingKey);
        DamageRoll = Game.ParseRollExpression(DamageRollExpression);
        RadiusRoll = Game.ParseRollExpression(RadiusRollExpression);
    }

    protected virtual string ProjectileBindingKey { get; }

    public Projectile Projectile { get; protected set; }

    /// <summary>
    /// Returns a roll expression for the amount of damage the projectile produces.
    /// </summary>
    protected abstract string DamageRollExpression { get; }

    public Roll DamageRoll { get; protected set; }

    /// <summary>
    /// Returns a roll expression for the radius of damage the projectile produces.  A radius of 0 represents a bolt.  A radius >0 represents a ball and a radius <0 represents breathe.
    /// Returns zero by default.
    /// </summary>
    protected virtual string RadiusRollExpression => "0";

    public Roll RadiusRoll { get; protected set; }

    public bool ExecuteCancellableScriptItem(Item item, int direction) // This is run by an item activation
    {
        int radius = RadiusRoll.Get(Game.UseRandom);
        int damage = DamageRoll.Get(Game.UseRandom);
        if (radius == 0)
        {
            bool hitSuccess = Projectile.TargetedFire(direction, damage, stop: true, kill: true); // TODO: We do not do anything with the return value.
        }
        else
        {
            Game.FireBall(Projectile, direction, damage, radius); // TODO: We do not do anything with the return value.
        }
        return true; // Return true because the script was not cancelled.
    }
}
