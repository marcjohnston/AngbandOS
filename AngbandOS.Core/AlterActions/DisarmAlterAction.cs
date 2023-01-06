namespace AngbandOS.Core.AlterActions
{
    [Serializable]
    internal class DisarmAlterAction : AlterAction
    {
        public override void Execute(AlterEventArgs alterEventArgs)
        {
            alterEventArgs.Disturbed = true;
            alterEventArgs.SaveGame.DisarmTrap(alterEventArgs.Y, alterEventArgs.X);
        }
    }
}
