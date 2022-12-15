namespace AngbandOS.Core.SpellResistantDetections
{
    internal class FireSpellResistantDetection : SpellResistantDetection
    {
        public override void Learn(SaveGame saveGame, Monster monster)
        {
            if (saveGame.Player.HasFireResistance)
            {
                monster.Mind |= Constants.SmResFire;
            }
            if (saveGame.Player.TimedFireResistance != 0)
            {
                monster.Mind |= Constants.SmOppFire;
            }
            if (saveGame.Player.HasFireImmunity)
            {
                monster.Mind |= Constants.SmImmFire;
            }
        }
    }
}
