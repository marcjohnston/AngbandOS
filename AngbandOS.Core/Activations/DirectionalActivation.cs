namespace AngbandOS.Core.Activations;

[Serializable]
/// <summary>
/// Provides base functionality for an ArtifactPower that needs a direction/aiming.  This object inherits the base ArtifactPower but addings a GetDirectionWithAim
/// to the activation functionality.
/// </summary>
internal abstract class DirectionalActivation : Activation
{
    protected DirectionalActivation(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Returns the message to be displayed to the player, after the player has selected a direction.  No message is rendered, if empty or null.  Returns null, by default.
    /// </summary>
    protected virtual string? PostAimingMessage => null;

    public override bool Activate()
    {
        if (!SaveGame.GetDirectionWithAim(out int direction))
        {
            return false;
        }
        if (!String.IsNullOrEmpty(PostAimingMessage))
        {
            SaveGame.MsgPrint(PostAimingMessage);
        }
        return Activate(direction);
    }

    /// <summary>
    /// Activates the Artifact with directional/aiming functionality.
    /// </summary>
    /// <param name="player"></param>
    /// <param name="level"></param>
    /// <param name="item"></param>
    /// <param name="direction"></param>
    protected abstract bool Activate(int direction);
}
