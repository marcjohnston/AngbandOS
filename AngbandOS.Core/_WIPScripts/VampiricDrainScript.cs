// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class VampiricDrainScript : Script, IScript, ICastSpellScript
{
    private VampiricDrainScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Drains the health of a monster in a chosen direction and adds the same amount of health to the player.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!Game.GetDirectionWithAim(out int direction))
        {
            return;
        }
        int damage = Game.ExperienceLevel.IntValue + (Game.DieRoll(Game.ExperienceLevel.IntValue) * Math.Max(1, Game.ExperienceLevel.IntValue / 10));
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(OldDrainLifeProjectile));
        IsNoticedEnum isNoticed = projectile.TargetedFire(direction, damage, 0, stop: true, kill: true, jump: false, beam: false, grid: false, item: false, thru: true, hide: false);
        if (isNoticed == IsNoticedEnum.False)
        {
            return;
        }
        Game.RestoreHealth(damage);
        damage = Game.Food.IntValue + Math.Min(5000, 100 * damage);
        if (Game.Food.IntValue < Constants.PyFoodMax)
        {
            Game.SetFood(damage >= Constants.PyFoodMax ? Constants.PyFoodMax - 1 : damage);
        }
    }
    public string LearnedDetails => $"dam {Math.Max(1, Game.ExperienceLevel.IntValue / 10)}d{Game.ExperienceLevel.IntValue}+{Game.ExperienceLevel.IntValue}";
}
