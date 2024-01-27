// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RestorationScript : Script, IScript, IStoreScript
{
    private RestorationScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the restoration script.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreScript(StoreCommandEvent storeCommandEvent)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the restoration script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!SaveGame.ServiceHaggle(750, out int price))
        {
            if (price > SaveGame.Gold)
            {
                SaveGame.MsgPrint("You do not have the gold!");
            }
            else
            {
                SaveGame.Gold -= price;
                SaveGame.SayComment_1();
                SaveGame.PlaySound(SoundEffectEnum.StoreTransaction);
                SaveGame.StorePrtGold();
                SaveGame.TryRestoringAbilityScore(Ability.Strength);
                SaveGame.TryRestoringAbilityScore(Ability.Intelligence);
                SaveGame.TryRestoringAbilityScore(Ability.Wisdom);
                SaveGame.TryRestoringAbilityScore(Ability.Dexterity);
                SaveGame.TryRestoringAbilityScore(Ability.Constitution);
                SaveGame.TryRestoringAbilityScore(Ability.Charisma);
                SaveGame.RunScript(nameof(RestoreLevelScript));
            }
            SaveGame.HandleStuff();
        }
    }
}
