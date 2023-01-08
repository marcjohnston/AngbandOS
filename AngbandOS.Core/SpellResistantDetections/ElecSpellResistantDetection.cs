namespace AngbandOS.Core.SpellResistantDetections
{
    internal class ElecSpellResistantDetection : SpellResistantDetection
    {
        public override void Learn(SaveGame saveGame, Monster monster)
        {
            if (saveGame.Player.HasLightningResistance)
            {
                monster.SmResElec = true;
            }
            if (saveGame.Player.TimedLightningResistance.TimeRemaining != 0)
            {
                monster.SmOppElec = true;
            }
            if (saveGame.Player.HasLightningImmunity)
            {
                monster.SmImmElec = true;
            }
        }
    }
}
