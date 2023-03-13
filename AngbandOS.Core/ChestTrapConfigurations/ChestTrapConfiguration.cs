namespace AngbandOS.Core.ChestTrapConfigurations
{
    [Serializable]
    internal abstract class ChestTrapConfiguration
    {
        protected SaveGame SaveGame;
        protected ChestTrapConfiguration(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }

        public abstract BaseChestTrap[] Traps { get; }
        public bool NotTrapped => Traps.Length == 0;
        public bool IsTrapped => Traps.Length > 0;
        public string Description
        {
            get
            {
                if (NotTrapped)
                {
                    return "(Locked)";
                }
                else if (Traps.Length > 1)
                {
                    return "(Multiple Traps)";
                }
                else
                {
                    return Traps[0].Description;
                }
            }
        }
        public void Activate(SaveGame saveGame, Item chestItem)
        {
            foreach (BaseChestTrap trap in Traps)
            {
                ActivateChestTrapEventArgs eventArgs = new ActivateChestTrapEventArgs(saveGame, saveGame.Player.MapX, saveGame.Player.MapY);
                trap.Activate(eventArgs);

                if (eventArgs.DestroysContents)
                {
                    eventArgs.SaveGame.MsgPrint("Everything inside the chest is destroyed!");
                    chestItem.TypeSpecificValue = 0;
                }
            }
        }
    }
}