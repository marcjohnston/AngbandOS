// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class GroupSetFlaggedAction : FlaggedAction
{
    protected FlaggedAction[] RedrawActions;
    protected GroupSetFlaggedAction(Game game) : base(game) { }
    public override bool IsSet => RedrawActions.Any(_redrawAction => _redrawAction.IsSet);
    public override void Set() => Array.ForEach<FlaggedAction>(RedrawActions, _redrawAction => _redrawAction.Set());
    public override void Clear() => Array.ForEach<FlaggedAction>(RedrawActions, _redrawAction => _redrawAction.Clear());
    protected override void Execute() => Array.ForEach<FlaggedAction>(RedrawActions, _redrawAction => _redrawAction.Check(true));
}
