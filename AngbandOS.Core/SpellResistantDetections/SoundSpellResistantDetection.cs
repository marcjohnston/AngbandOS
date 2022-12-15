namespace AngbandOS.Core.SpellResistantDetections
{
    internal class SoundSpellResistantDetection : SpellResistantDetection
    {
        public override void Learn(SaveGame saveGame, Monster monster)
        {
            if (saveGame.Player.HasSoundResistance)
            {
                monster.Mind |= Constants.SmResSound;
            }
        }
    }
}
