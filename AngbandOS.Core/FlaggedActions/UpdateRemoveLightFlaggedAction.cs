
namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class UpdateRemoveLightFlaggedAction : FlaggedAction
    {
        public UpdateRemoveLightFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
