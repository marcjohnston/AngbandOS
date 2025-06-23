// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DestroyAdjacentDoorsScript : Script, IScript, ICastSpellScript, IEatOrQuaffScript, IActivateItemScript
{
    private DestroyAdjacentDoorsScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Runs the successful script and returns false because the player cannot cancel the script.
    /// </summary>
    /// <returns></returns>
    public UsedResult ExecuteActivateItemScript(Item item)
    {
        ExecuteEatOrQuaffScript();
        return new UsedResult(false);
    }

    /// <summary>
    /// Projects the kill door to the current location with a radius of 1 to destory all doors that are adjacent to the player.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResultEnum ExecuteEatOrQuaffScript()
    {
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(DestroyTrapOrDoorProjectile));
        bool isIdentified = projectile.Fire(0, 1, Game.MapY.IntValue, Game.MapX.IntValue, 0, grid: true, item: true, hide: true, jump: false, beam: false, thru: false, kill: false, stop: false);
        return isIdentified ? IdentifiedResultEnum.True : IdentifiedResultEnum.False;
    }

    /// <summary>
    /// Executes the successful script and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteEatOrQuaffScript();
    }
    public string LearnedDetails => "";
}
