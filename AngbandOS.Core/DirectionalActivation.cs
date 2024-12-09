// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
/// <summary>
/// Provides base functionality for an ArtifactPower that needs a direction/aiming.  This object inherits the base ArtifactPower but addings a GetDirectionWithAim
/// to the activation functionality.
/// </summary>
internal abstract class DirectionalActivation : Activation
{
    protected DirectionalActivation(Game game) : base(game) { }

    /// <summary>
    /// Returns the message to be displayed to the player, after the player has selected a direction.  No message is rendered, if empty or null.  Returns null, by default.
    /// </summary>
    protected virtual string? PostAimingMessage => null;

    protected override bool OnActivate(Item item)
    {
        if (!Game.GetDirectionWithAim(out int direction))
        {
            return false;
        }
        if (!String.IsNullOrEmpty(PostAimingMessage))
        {
            Game.MsgPrint(PostAimingMessage);
        }
        return Activate(direction);
    }

    /// <summary>
    /// Activates the artifact with directional/aiming functionality and returns false, if the activation was cancelled; true, otherwise.
    /// </summary>
    /// <param name="player"></param>
    /// <param name="level"></param>
    /// <param name="item"></param>
    /// <param name="direction"></param>
    protected abstract bool Activate(int direction);
}
