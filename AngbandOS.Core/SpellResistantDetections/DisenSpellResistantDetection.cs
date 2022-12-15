namespace AngbandOS.Core.SpellResistantDetections
{
    internal class DisenSpellResistantDetection : SpellResistantDetection
    {
        public override void Learn(SaveGame saveGame, Monster monster)
        {
            if (saveGame.Player.HasDisenchantResistance)
            {
                monster.Mind |= Constants.SmResDisen;
            }
        }
    }
}
