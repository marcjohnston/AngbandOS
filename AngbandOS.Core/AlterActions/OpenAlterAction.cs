namespace AngbandOS.Core.AlterActions;

[Serializable]
internal class OpenAlterAction : AlterAction
{
    public override void Execute(AlterEventArgs alterEventArgs)
    {
        // Disturb the player, if the action did not fail.
        alterEventArgs.More = alterEventArgs.SaveGame.OpenDoor(alterEventArgs.Y, alterEventArgs.X);
    }
}
