// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class Mana10d10ProjectileFriendlyScript : Script, IUnfriendlyScript
{
    private Mana10d10ProjectileFriendlyScript(Game game) : base(game) { }

    public bool ExecuteUnfriendlyScript(int who, int y, int x)
    {
        Game.Project(who, 1, y, x, Game.DiceRoll(10, 10), Game.SingletonRepository.Get<Projectile>(nameof(ManaProjectile)), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return false;
    }
}
