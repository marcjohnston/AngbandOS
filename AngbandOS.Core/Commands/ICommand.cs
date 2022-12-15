namespace AngbandOS.Commands
{
    internal interface ICommand // TODO: Convert this to a class
    {
        char Key { get; }

        /// <summary>
        /// Return 0, if the command should not be repeatable via a CommandArgument/Count; otherwise, return null, to indicate that the command allows
        /// the player to specify a CommandArgument/Count; or a value greater than 0, to indicate that the command is repeatable but if the player does not
        /// specify a CommandArgument/Count, default the count to the value being returned.
        /// </summary>
        int? Repeat { get; }

        bool IsEnabled { get; }

        void Execute(SaveGame saveGame);
    }
}
