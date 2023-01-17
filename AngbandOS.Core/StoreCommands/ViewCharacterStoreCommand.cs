namespace AngbandOS.StoreCommands
{
    /// <summary>
    /// View the character sheet
    /// </summary>
    [Serializable]
    internal class ViewCharacterStoreCommand : BaseStoreCommand
    {
        private ViewCharacterStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => 'C';

        public override string Description => "";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            SaveGame.DoCmdViewCharacter();
            storeCommandEvent.RequiresRerendering = true;
        }
    }
}
