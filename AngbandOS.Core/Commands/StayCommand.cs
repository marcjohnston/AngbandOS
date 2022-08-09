using Cthangband.UI;
using System;

namespace Cthangband.Commands
{
    /// <summary>
    /// Stand still for a turn and pick up any items
    /// </summary>
    [Serializable]
    internal class StayAndPickupCommand : ICommand
    {
        public char Key => ',';

        public int? Repeat => null;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            StayCommand.DoCmdStay(saveGame, true);
        }
    }

    /// <summary>
    /// Stand still for a turn without picking up any items
    /// </summary>
    [Serializable]
    internal class StayCommand : ICommand
    {
        public char Key => 'g';

        public int? Repeat => null;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            DoCmdStay(saveGame, false);
        }

        /// <param name="pickup"> Whether or not we should pick up an object in our location </param>
        public static void DoCmdStay(SaveGame saveGame, bool pickup)
        {
            // Standing still takes a turn
            saveGame.EnergyUse = 100;
            // Periodically search if we're not actively in search mode
            if (saveGame.Player.SkillSearchFrequency >= 50 || 0 == Program.Rng.RandomLessThan(50 - saveGame.Player.SkillSearchFrequency))
            {
                saveGame.Search();
            }
            // Always search if we are actively in search mode
            if (saveGame.Player.IsSearching)
            {
                saveGame.Search();
            }
            // Pick up items if we should
            saveGame.PickUpItems(pickup);
            // If we're in a shop doorway, enter the shop
            GridTile tile = saveGame.Level.Grid[saveGame.Player.MapY][saveGame.Player.MapX];
            if (tile.FeatureType.IsShop)
            {
                saveGame.Disturb(false);
                Gui.QueuedCommand = '_';
            }
        }
    }
}
