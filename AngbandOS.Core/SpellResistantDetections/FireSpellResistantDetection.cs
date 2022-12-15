namespace AngbandOS.Core.SpellResistantDetections
{
    internal class FireSpellResistantDetection : SpellResistantDetection
    {
        public override void Learn(SaveGame saveGame, Monster monster)
        {
            if (saveGame.Player.HasFireResistance)
            {
                monster.SmResFire = true;
            }
            if (saveGame.Player.TimedFireResistance != 0)
            {
                monster.SmOppFire = true;
            }
            if (saveGame.Player.HasFireImmunity)
            {
                monster.SmImmFire = true;
            }
        }
    }
}
