
namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class UpdateHealthFlaggedAction : FlaggedAction
    {
        public UpdateHealthFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
