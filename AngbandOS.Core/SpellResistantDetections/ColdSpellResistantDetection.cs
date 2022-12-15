namespace AngbandOS.Core.SpellResistantDetections
{
    internal class ColdSpellResistantDetection : SpellResistantDetection
    {
        public override void Learn(SaveGame saveGame, Monster monster)
        {
            if (saveGame.Player.HasColdResistance)
            {
                monster.Mind |= Constants.SmResCold;
            }
            if (saveGame.Player.TimedColdResistance != 0)
            {
                monster.Mind |= Constants.SmOppCold;
            }
            if (saveGame.Player.HasColdImmunity)
            {
                monster.Mind |= Constants.SmImmCold;
            }
        }
    }
}
