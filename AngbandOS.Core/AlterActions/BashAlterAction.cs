namespace AngbandOS.Core.AlterActions
{
    [Serializable]
    internal class BashAlterAction : AlterAction
    {
        public override void Execute(AlterEventArgs alterEventArgs)
        {
            alterEventArgs.Disturbed = true;
            alterEventArgs.SaveGame.BashClosedDoor(alterEventArgs.Y, alterEventArgs.X);
        }
    }
}
