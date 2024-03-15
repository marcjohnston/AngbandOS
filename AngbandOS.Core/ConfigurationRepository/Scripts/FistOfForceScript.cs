// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class FistOfForceScript : Script, IScript
{ 
    private FistOfForceScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Fires a ball of disintegrate in a chosen direction.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(DisintegrateProjectile)), dir, SaveGame.DiceRoll(8 + ((SaveGame.ExperienceLevel.Value - 5) / 4), 8), 0);
    }
}
