﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Reflection;
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class VersionScript : UniversalScript, IGetKey
{
    private VersionScript(Game game) : base(game) { }

    /// <summary>
    /// Returns the entity serialized into a Json string.  Returns an empty string by default.
    /// </summary>
    /// <returns></returns>

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    /// <summary>
    /// Executes the version script.
    /// </summary>
    /// <returns></returns>
    public override void ExecuteScript()
    {
        AssemblyName assembly = Assembly.GetExecutingAssembly().GetName();
        Game.MsgPrint($"You are playing {assembly.Name} {assembly.Version}.");
    }
}
