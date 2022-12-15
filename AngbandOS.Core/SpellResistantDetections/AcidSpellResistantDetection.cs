namespace AngbandOS.Core.SpellResistantDetections
{
    internal class AcidSpellResistantDetection : SpellResistantDetection 
    {
        public override void Learn(SaveGame saveGame, Monster monster)
        {
            if (saveGame.Player.HasAcidResistance)
            {
                monster.Mind |= Constants.SmResAcid;
            }
            if (saveGame.Player.TimedAcidResistance != 0)
            {
                monster.Mind |= Constants.SmOppAcid;
            }
            if (saveGame.Player.HasAcidImmunity)
            {
                monster.Mind |= Constants.SmImmAcid;
            }
        }
    }
}
