// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EatBlindnessScript : Script, IIdentifiedScript
{
    private EatBlindnessScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteIdentifiedScript()
    {
        Game.PlaySound(SoundEffectEnum.Eat);
        if (!Game.HasBlindnessResistance)
        {
            if (Game.BlindnessTimer.AddTimer(Game.RandomLessThan(200) + 200))
            {
                return true;
            }
        }
        return false;
    }
}
