
namespace AngbandOS.Core.RedrawActions
{
    [Serializable]
    internal class GroupSetRedrawAction : RedrawAction
    {
        private RedrawAction[] RedrawActions { get; }
        public GroupSetRedrawAction(SaveGame saveGame, params RedrawAction[] redrawActions) : base(saveGame)
        {
            RedrawActions = redrawActions;
        }
        public override bool IsSet => RedrawActions.Any(_redrawAction => _redrawAction.IsSet);
        public override void Set() => Array.ForEach<RedrawAction>(RedrawActions, _redrawAction => _redrawAction.Set());
        public override void Clear() => Array.ForEach<RedrawAction>(RedrawActions, _redrawAction => _redrawAction.Clear());
        protected override void Draw() => Array.ForEach<RedrawAction>(RedrawActions, _redrawAction => _redrawAction.Redraw(true));
    }
}
