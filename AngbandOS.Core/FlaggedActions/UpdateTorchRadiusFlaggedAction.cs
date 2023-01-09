
namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class UpdateTorchRadiusFlaggedAction : FlaggedAction
    {
        public UpdateTorchRadiusFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        /// <summary>
        /// Compute the level of light.  The player may be wielding multiple sources of light.
        /// </summary>
        protected override void Execute()
        {
            throw new NotImplementedException();
        }

    }
}
