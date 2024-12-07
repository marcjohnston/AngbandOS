// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class GenericGameCommand : GameCommand
{
    public GenericGameCommand(Game game, GameCommandGameConfiguration gameCommandDefinition) : base(game)
    {
        Key = gameCommandDefinition.Key;
        KeyChar = gameCommandDefinition.KeyChar;
        IsEnabled = gameCommandDefinition.IsEnabled;
        Repeat = gameCommandDefinition.Repeat;
        ExecuteScriptName = gameCommandDefinition.ExecuteScriptName;
    }

    public override string Key { get; }
    public override char KeyChar { get; }
    public override bool IsEnabled { get; }
    public override int? Repeat { get; }
    protected override string ExecuteScriptName { get; }
}
