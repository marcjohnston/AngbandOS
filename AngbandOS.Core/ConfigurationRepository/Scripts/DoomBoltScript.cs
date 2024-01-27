// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DoomBoltScript : Script, IScript
{
    private DoomBoltScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Fires a beam of mana in a chosen direction.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.FireBeam(SaveGame.SingletonRepository.Projectiles.Get(nameof(ManaProjectile)), dir, SaveGame.Rng.DiceRoll(11 + ((SaveGame.ExperienceLevel - 5) / 4), 8));
    }
}
