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
    private RerollHitPointsScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int i;
        Game.PlayerHp[0] = Game.HitDie;
        int lastroll = Game.HitDie;
        for (i = 1; i < Constants.PyMaxLevel; i++)
        {
            Game.PlayerHp[i] = lastroll;
            lastroll--;
            if (lastroll < 1)
            {
                lastroll = Game.HitDie;
            }
        }
        for (i = 1; i < Constants.PyMaxLevel; i++)
        {
            int j = Game.DieRoll(Constants.PyMaxLevel - 1);
            lastroll = Game.PlayerHp[i];
            Game.PlayerHp[i] = Game.PlayerHp[j];
            Game.PlayerHp[j] = lastroll;
        }
        for (i = 1; i < Constants.PyMaxLevel; i++)
        {
            Game.PlayerHp[i] = Game.PlayerHp[i - 1] + Game.PlayerHp[i];
        }
        Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateHealthFlaggedAction)).Set();
        Game.HandleStuff();
    }
}
