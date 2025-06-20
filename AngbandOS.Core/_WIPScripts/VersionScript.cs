﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Reflection;
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class VersionScript : Script, IScript, ICastSpellScript, IGameCommandScript
{
    private VersionScript(Game game) : base(game) { }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the version script and returns false.
    /// </summary>
    /// <returns></returns>
    public RepeatableResult ExecuteGameCommandScript()
    {
        ExecuteScript();
        return new RepeatableResult(false);
    }

    /// <summary>
    /// Executes the version script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        AssemblyName assembly = Assembly.GetExecutingAssembly().GetName();
        Game.MsgPrint($"You are playing {assembly.Name} {assembly.Version}.");
    }
}
