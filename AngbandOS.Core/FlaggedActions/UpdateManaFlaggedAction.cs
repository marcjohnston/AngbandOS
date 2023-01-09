
namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class UpdateManaFlaggedAction : FlaggedAction
    {
        public UpdateManaFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            throw new NotImplementedException();
        }

    }
}
