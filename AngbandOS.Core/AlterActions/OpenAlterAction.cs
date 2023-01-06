namespace AngbandOS.Core.AlterActions
{
    [Serializable]
    internal class OpenAlterAction : AlterAction
    {
        public override void Execute(AlterEventArgs alterEventArgs)
        {
            alterEventArgs.Disturbed = true;
            alterEventArgs.SaveGame.OpenDoor(alterEventArgs.Y, alterEventArgs.X);
        }
    }
}
