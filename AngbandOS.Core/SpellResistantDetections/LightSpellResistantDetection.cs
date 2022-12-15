namespace AngbandOS.Core.SpellResistantDetections
{
    internal class LightSpellResistantDetection : SpellResistantDetection
    {
        public override void Learn(SaveGame saveGame, Monster monster)
        {
            if (saveGame.Player.HasLightResistance)
            {
                monster.SmResLight = true;
            }
        }
    }
}
