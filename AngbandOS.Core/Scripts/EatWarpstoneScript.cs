// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EatWarpstoneScript : Script, IIdentifiedScript
{
    private EatWarpstoneScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResult ExecuteIdentifiedScript()
    {
        Game.PlaySound(SoundEffectEnum.Eat);
        Game.MsgPrint("That tastes... funky.");
        Game.RunScript(nameof(GainMutationScript));
        if (Game.DieRoll(3) == 1)
        {
            Game.RunScript(nameof(GainMutationScript));
        }
        if (Game.DieRoll(3) == 1)
        {
            Game.RunScript(nameof(GainMutationScript));
        }
        return new IdentifiedResult(true);
    }
}
