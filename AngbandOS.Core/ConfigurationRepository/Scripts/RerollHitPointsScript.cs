// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RerollHitPointsScript : Script, IScript
{
    private RerollHitPointsScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int i;
        PlayerHp[0] = HitDie;
        int lastroll = HitDie;
        for (i = 1; i < Constants.PyMaxLevel; i++)
        {
            PlayerHp[i] = lastroll;
            lastroll--;
            if (lastroll < 1)
            {
                lastroll = HitDie;
            }
        }
        for (i = 1; i < Constants.PyMaxLevel; i++)
        {
            int j = Rng.DieRoll(Constants.PyMaxLevel - 1);
            lastroll = PlayerHp[i];
            PlayerHp[i] = PlayerHp[j];
            PlayerHp[j] = lastroll;
        }
        for (i = 1; i < Constants.PyMaxLevel; i++)
        {
            PlayerHp[i] = PlayerHp[i - 1] + PlayerHp[i];
        }
        SingletonRepository.FlaggedActions.Get(nameof(UpdateHealthFlaggedAction)).Set();
        SingletonRepository.FlaggedActions.Get(nameof(RedrawHpFlaggedAction)).Set();
        HandleStuff();
    }
}
