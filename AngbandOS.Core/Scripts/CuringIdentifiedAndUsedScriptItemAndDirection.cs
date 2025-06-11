// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CuringIdentifiedAndUsedScriptItemAndDirection : Script, IZapRodScript
{
    private CuringIdentifiedAndUsedScriptItemAndDirection(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public IdentifiedAndUsedResult ExecuteZapRodScript(Item item, int dir)
    {
        bool isIdentified = false;
        if (Game.BlindnessTimer.ResetTimer())
        {
            isIdentified = true;
        }
        if (Game.PoisonTimer.ResetTimer())
        {
            isIdentified = true;
        }
        if (Game.ConfusionTimer.ResetTimer())
        {
            isIdentified = true;
        }
        if (Game.StunTimer.ResetTimer())
        {
            isIdentified = true;
        }
        if (Game.BleedingTimer.ResetTimer())
        {
            isIdentified = true;
        }
        if (Game.HallucinationsTimer.ResetTimer())
        {
            isIdentified = true;
        }
        return new IdentifiedAndUsedResult(isIdentified, true);
    }
}
