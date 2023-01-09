
namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class UpdateMonstersFlaggedAction : FlaggedAction
    {
        public UpdateMonstersFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
