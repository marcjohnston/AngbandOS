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
    public GenericGameCommand(Game game, GameCommandGameConfiguration gameCommandGameConfiguration) : base(game)
    {
        Key = gameCommandGameConfiguration.Key ?? gameCommandGameConfiguration.GetType().Name;
        KeyChar = gameCommandGameConfiguration.KeyChar;
        IsEnabled = gameCommandGameConfiguration.IsEnabled;
        Repeat = gameCommandGameConfiguration.Repeat;
        ExecuteScriptName = gameCommandGameConfiguration.ExecuteScriptName;
    }

    public override string Key { get; }
    public override char KeyChar { get; }
    public override bool IsEnabled { get; }
    public override int? Repeat { get; }
    protected override string ExecuteScriptName { get; }
}
