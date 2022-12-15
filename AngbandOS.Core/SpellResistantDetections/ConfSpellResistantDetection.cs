namespace AngbandOS.Core.SpellResistantDetections
{
    internal class ConfSpellResistantDetection : SpellResistantDetection
    {
        public override void Learn(SaveGame saveGame, Monster monster)
        {
            if (saveGame.Player.HasConfusionResistance)
            {
                monster.SmResConf = true;
            }
        }
    }
}
