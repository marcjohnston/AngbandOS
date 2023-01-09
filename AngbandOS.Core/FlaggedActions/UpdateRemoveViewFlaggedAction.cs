
namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class UpdateRemoveViewFlaggedAction : FlaggedAction
    {
        public UpdateRemoveViewFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            throw new NotImplementedException();
        }

    }
}
