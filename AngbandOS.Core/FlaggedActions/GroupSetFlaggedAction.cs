
namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class GroupSetFlaggedAction : FlaggedAction
{
    private FlaggedAction[] RedrawActions { get; }
    public GroupSetFlaggedAction(SaveGame saveGame, params FlaggedAction[] redrawActions) : base(saveGame)
    {
        RedrawActions = redrawActions;
    }
    public override bool IsSet => RedrawActions.Any(_redrawAction => _redrawAction.IsSet);
    public override void Set() => Array.ForEach<FlaggedAction>(RedrawActions, _redrawAction => _redrawAction.Set());
    public override void Clear() => Array.ForEach<FlaggedAction>(RedrawActions, _redrawAction => _redrawAction.Clear());
    protected override void Execute() => Array.ForEach<FlaggedAction>(RedrawActions, _redrawAction => _redrawAction.Check(true));
}
