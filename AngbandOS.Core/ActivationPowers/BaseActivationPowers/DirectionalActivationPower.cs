using System;

namespace Cthangband.ActivationPowers
{
    [Serializable]
    /// <summary>
    /// Provides base functionality for an ArtifactPower that needs a direction/aiming.  This object inherits the base ArtifactPower but addings a GetDirectionWithAim
    /// to the activation functionality.
    /// </summary>
    internal abstract class DirectionalActivationPower : ActivationPower
    {
        /// <summary>
        /// Returns the message to be displayed to the player, after the player has selected a direction.  No message is rendered, if empty or null.
        /// </summary>
        protected abstract string PostAimingMessage { get; }

        public override bool Activate(SaveGame saveGame)
        {
            TargetEngine targetEngine = new TargetEngine(saveGame);
            if (!targetEngine.GetDirectionWithAim(out int direction))
            {
                return false;
            }
            if (!String.IsNullOrEmpty(PostAimingMessage))
            {
                saveGame.MsgPrint(PostAimingMessage);
            }
            return Activate(saveGame, direction);
        }

        /// <summary>
        /// Activates the Artifact with directional/aiming functionality.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="level"></param>
        /// <param name="item"></param>
        /// <param name="direction"></param>
        protected abstract bool Activate(SaveGame saveGame, int direction);
    }
}
