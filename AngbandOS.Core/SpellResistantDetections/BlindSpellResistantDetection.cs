namespace AngbandOS.Core.SpellResistantDetections
{
    internal class BlindSpellResistantDetection : SpellResistantDetection
    {
        public override void Learn(SaveGame saveGame, Monster monster)
        {
            if (saveGame.Player.HasBlindnessResistance)
            {
                monster.Mind |= Constants.SmResBlind;
            }
        }
    }
}
