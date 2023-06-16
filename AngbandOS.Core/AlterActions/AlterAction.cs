namespace AngbandOS.Core.AlterActions;

[Serializable]
internal abstract class AlterAction
{
    public abstract void Execute(AlterEventArgs alterEventArgs);
}
