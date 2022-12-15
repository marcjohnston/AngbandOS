namespace AngbandOS.Core.SpellResistantDetections
{
    internal class FearSpellResistantDetection : SpellResistantDetection
    {
        public override void Learn(SaveGame saveGame, Monster monster)
        {
            if (saveGame.Player.HasFearResistance)
            {
                monster.SmResFear = true;
            }
        }
    }
}
