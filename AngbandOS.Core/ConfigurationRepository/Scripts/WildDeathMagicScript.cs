// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class WildDeathMagicScript : Script, IScriptIntInt
{
    private WildDeathMagicScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScriptIntInt(int spell, int subCategory)
    {
        if (subCategory == 3 && SaveGame.DieRoll(2) == 1)
        {
            SaveGame.Monsters[0].SanityBlast(true);
        }
        else
        {
            SaveGame.MsgPrint("It hurts!");
            SaveGame.TakeHit(SaveGame.DiceRoll(subCategory + 1, 6), "a miscast Death spell");
            if (spell > 15 && SaveGame.DieRoll(6) == 1 && !SaveGame.HasHoldLife)
            {
                SaveGame.LoseExperience(spell * 250);
            }
        }
    }
}
