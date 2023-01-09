
namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class UpdateLightFlaggedAction : FlaggedAction
    {
        public UpdateLightFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
