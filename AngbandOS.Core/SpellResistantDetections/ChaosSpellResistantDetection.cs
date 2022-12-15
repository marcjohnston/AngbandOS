namespace AngbandOS.Core.SpellResistantDetections
{
    internal class ChaosSpellResistantDetection : SpellResistantDetection
    {
        public override void Learn(SaveGame saveGame, Monster monster)
        {
            if (saveGame.Player.HasChaosResistance)
            {
                monster.SmResChaos = true;
            }
        }
    }
}
