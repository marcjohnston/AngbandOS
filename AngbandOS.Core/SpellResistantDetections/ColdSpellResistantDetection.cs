namespace AngbandOS.Core.SpellResistantDetections
{
    internal class ColdSpellResistantDetection : SpellResistantDetection
    {
        public override void Learn(SaveGame saveGame, Monster monster)
        {
            if (saveGame.Player.HasColdResistance)
            {
                monster.SmResCold = true;
            }
            if (saveGame.Player.TimedColdResistance.TurnsRemaining != 0)
            {
                monster.SmOppCold = true;
            }
            if (saveGame.Player.HasColdImmunity)
            {
                monster.SmImmCold = true;
            }
        }
    }
}
