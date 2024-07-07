// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class Curing50Script : Script, INoticeableScript
{
    private Curing50Script(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns true because the action is always noticed.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteNoticeableScript()
    {
        bool noticed = false;
        // Curing heals you 50 health, and cures blindness, confusion, stun, poison,
        // bleeding, and hallucinations
        if (Game.RestoreHealth(50))
        {
            noticed = true;
        }
        if (Game.BlindnessTimer.ResetTimer())
        {
            noticed = true;
        }
        if (Game.PoisonTimer.ResetTimer())
        {
            noticed = true;
        }
        if (Game.ConfusedTimer.ResetTimer())
        {
            noticed = true;
        }
        if (Game.StunTimer.ResetTimer())
        {
            noticed = true;
        }
        if (Game.BleedingTimer.ResetTimer())
        {
            noticed = true;
        }
        if (Game.HallucinationsTimer.ResetTimer())
        {
            noticed = true;
        }
        return noticed;
    }
}