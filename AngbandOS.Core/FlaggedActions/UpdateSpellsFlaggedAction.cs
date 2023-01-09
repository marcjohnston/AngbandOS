
namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class UpdateSpellsFlaggedAction : FlaggedAction
    {
        public UpdateSpellsFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            throw new NotImplementedException();
        }

    }
}
