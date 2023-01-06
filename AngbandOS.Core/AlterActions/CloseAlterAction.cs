namespace AngbandOS.Core.AlterActions
{
    [Serializable]
    internal class CloseAlterAction : AlterAction
    {
        public override void Execute(AlterEventArgs alterEventArgs)
        {
            alterEventArgs.Disturbed = true;
            alterEventArgs.SaveGame.CloseDoor(alterEventArgs.Y, alterEventArgs.X);
        }
    }
}
