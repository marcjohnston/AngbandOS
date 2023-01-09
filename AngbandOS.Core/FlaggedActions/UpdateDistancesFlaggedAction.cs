
namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class UpdateDistancesFlaggedAction : FlaggedAction
    {
        public UpdateDistancesFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
