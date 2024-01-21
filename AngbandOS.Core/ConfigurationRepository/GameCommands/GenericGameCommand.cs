// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interface.Definitions;

namespace AngbandOS.Core.Commands;

internal class GenericGameCommand : GameCommand
{
    private readonly string _key;
    private readonly char _keyChar;
    private readonly bool _isEnabled;
    private readonly int? _repeat;
    private readonly string _executeScriptName;

    public GenericGameCommand(SaveGame saveGame, GameCommandDefinition gameCommandDefinition) : base(saveGame)
    {
        _key = gameCommandDefinition.Key;
        _keyChar = gameCommandDefinition.KeyChar;
        _isEnabled = gameCommandDefinition.IsEnabled;
        _repeat = gameCommandDefinition.Repeat;
        _executeScriptName = gameCommandDefinition.ExecuteScriptName;
    }

    public override string Key => _key;
    public override char KeyChar => _keyChar;
    public override bool IsEnabled => _isEnabled;
    public override int? Repeat => _repeat;
    protected override string ExecuteScriptName => _executeScriptName;
}
