
namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class UpdateBonusesFlaggedAction : FlaggedAction
    {
        public UpdateBonusesFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
