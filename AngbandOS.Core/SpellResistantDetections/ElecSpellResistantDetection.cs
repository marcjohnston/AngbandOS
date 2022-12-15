namespace AngbandOS.Core.SpellResistantDetections
{
    internal class ElecSpellResistantDetection : SpellResistantDetection
    {
        public override void Learn(SaveGame saveGame, Monster monster)
        {
            if (saveGame.Player.HasLightningResistance)
            {
                monster.Mind |= Constants.SmResElec;
            }
            if (saveGame.Player.TimedLightningResistance != 0)
            {
                monster.Mind |= Constants.SmOppElec;
            }
            if (saveGame.Player.HasLightningImmunity)
            {
                monster.Mind |= Constants.SmImmElec;
            }
        }
    }
}
