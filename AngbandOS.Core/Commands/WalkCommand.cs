namespace AngbandOS.Commands
{
    [Serializable]
    internal class WalkWithoutPickupCommand : ICommand
    {
        private WalkWithoutPickupCommand() { } // This object is a singleton.

        public char Key => '-';

        public int? Repeat => null;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            WalkAndPickupCommand.DoCmdWalk(saveGame, true);
        }
    }

    //[Serializable]
    //internal abstract class RepeatableCommand : ICommand
    //{
    //    private ICommand Command { get; }
    //    public abstract char Key { get; }

    //    public int? Repeatable => 0;

    //    public abstract bool IsEnabled { get; }

    //    public void Execute(SaveGame saveGame)
    //    {
    //        if (saveGame.CommandArgument > 0)
    //        {
    //            saveGame.Command.CommandRepeat = saveGame.CommandArgument - 1;
    //            player.RedrawNeeded.Set(RedrawFlag.PrState);
    //            saveGame.CommandArgument = 0;
    //        }
    //        Command.Execute(player, level);
    //    }

    //    public RepeatableCommand(ICommand command)
    //    {
    //        if (command == null) 
    //            throw new ArgumentNullException(nameof(command));

    //        Command = command;
    //    }
    //}

    [Serializable]
    internal class WalkAndPickupCommand : ICommand
    {
        private WalkAndPickupCommand() { } // This object is a singleton.

        public char Key => ';';

        public int? Repeat => null;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            DoCmdWalk(saveGame, false);
        }

        public static void DoCmdWalk(SaveGame saveGame, bool dontPickup)
        {
            bool disturb = false;
            // If we don't already have a direction, get one
            if (saveGame.GetDirectionNoAim(out int dir))
            {
                // Walking takes a full turn
                saveGame.EnergyUse = 100;
                saveGame.MovePlayer(dir, dontPickup);
                disturb = true;
            }
            // We will have been disturbed, unless we cancelled the direction prompt
            if (!disturb)
            {
                saveGame.Disturb(false);
            }
        }
    }
}
