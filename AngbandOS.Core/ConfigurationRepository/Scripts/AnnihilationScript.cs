// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class AnnihilationScript : Script, IScript
{
    private AnnihilationScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        SaveGame.Mana -= 100;
        for (int i = 1; i < SaveGame.MMax; i++)
        {
            Monster mPtr = SaveGame.Monsters[i];
            MonsterRace rPtr = mPtr.Race;
            if (mPtr.Race == null)
            {
                continue;
            }
            if (rPtr.Unique)
            {
                continue;
            }
            if (rPtr.Guardian)
            {
                continue;
            }
            SaveGame.DeleteMonsterByIndex(i, true);
            SaveGame.TakeHit(SaveGame.Rng.DieRoll(4), "the strain of casting Annihilation");
            SaveGame.Mana++;
            SaveGame.MoveCursorRelative(SaveGame.MapY, SaveGame.MapX);
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawHpFlaggedAction)).Set();
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawManaFlaggedAction)).Set();
            SaveGame.HandleStuff();
            SaveGame.UpdateScreen();
            SaveGame.Pause(Constants.DelayFactorInMilliseconds);
        }
        SaveGame.Mana += 100;
    }
}
