// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class VampiricDrainScript : Script, IScript
{
    private VampiricDrainScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Drains the health of a monster in a chosen direction and adds the same amount of health to the player.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        int dummy = SaveGame.ExperienceLevel + (SaveGame.Rng.DieRoll(SaveGame.ExperienceLevel) * Math.Max(1, SaveGame.ExperienceLevel / 10));
        if (!SaveGame.DrainLife(dir, dummy))
        {
            return;
        }
        SaveGame.RestoreHealth(dummy);
        dummy = SaveGame.Food + Math.Min(5000, 100 * dummy);
        if (SaveGame.Food < Constants.PyFoodMax)
        {
            SaveGame.SetFood(dummy >= Constants.PyFoodMax ? Constants.PyFoodMax - 1 : dummy);
        }
    }
}
