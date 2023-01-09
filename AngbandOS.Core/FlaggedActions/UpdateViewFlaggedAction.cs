
namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class UpdateViewFlaggedAction : FlaggedAction
    {
        public UpdateViewFlaggedAction(SaveGame saveGame) : base(saveGame) { }

        protected override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
