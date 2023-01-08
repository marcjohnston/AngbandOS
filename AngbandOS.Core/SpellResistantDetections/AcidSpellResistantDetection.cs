namespace AngbandOS.Core.SpellResistantDetections
{
    internal class AcidSpellResistantDetection : SpellResistantDetection 
    {
        public override void Learn(SaveGame saveGame, Monster monster)
        {
            if (saveGame.Player.HasAcidResistance)
            {
                monster.SmResAcid = true;
            }
            if (saveGame.Player.TimedAcidResistance.TimeRemaining != 0)
            {
                monster.SmOppAcid = true;
            }
            if (saveGame.Player.HasAcidImmunity)
            {
                monster.SmImmAcid = true;
            }
        }
    }
}
