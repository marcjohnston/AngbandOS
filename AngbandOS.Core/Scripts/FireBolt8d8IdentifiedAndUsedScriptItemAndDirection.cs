// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class FireBolt8d8IdentifiedAndUsedScriptItemAndDirection : Script, IIdentifiedAndUsedScriptItemDirection
{
    private FireBolt8d8IdentifiedAndUsedScriptItemAndDirection(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifiedAndUsedScriptItemDirection(Item item, int dir)
    {
        Game.FireBoltOrBeam(10, Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile)), dir, Game.DiceRoll(8, 8));
        return (true, true);
    }
}
