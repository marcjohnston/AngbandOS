namespace AngbandOS.Core.AlterActions;

[Serializable]
internal class BashAlterAction : AlterAction
{
    public override void Execute(AlterEventArgs alterEventArgs)
    {
        alterEventArgs.More = alterEventArgs.SaveGame.BashClosedDoor(alterEventArgs.Y, alterEventArgs.X);
    }
}
