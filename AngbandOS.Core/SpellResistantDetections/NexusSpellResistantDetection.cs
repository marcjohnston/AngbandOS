namespace AngbandOS.Core.SpellResistantDetections
{
    internal class NexusSpellResistantDetection : SpellResistantDetection
    {
        public override void Learn(SaveGame saveGame, Monster monster)
        {
            if (saveGame.Player.HasNexusResistance)
            {
                monster.Mind |= Constants.SmResNexus;
            }
        }
    }
}
