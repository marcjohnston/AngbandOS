namespace AngbandOS.Core.RedrawActions
{
    [Serializable]
    internal class PrEquippyRedrawAction : RedrawAction
    {
        public PrEquippyRedrawAction(SaveGame saveGame) : base(saveGame) { }

        /// <summary>
        /// Display the 'Equippy' characters (the visual representation of a character's equipment)
        /// in the default location on the main game screen
        /// </summary>
        /// <param name="player"> The player whose equippy characters should be displayed </param>
        protected override void Draw()
        {
            CharacterViewer.DisplayPlayerEquippy(SaveGame, ScreenLocation.RowEquippy, ScreenLocation.ColEquippy);
        }
    }
}
