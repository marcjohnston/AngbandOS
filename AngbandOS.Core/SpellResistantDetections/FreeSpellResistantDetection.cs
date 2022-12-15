namespace AngbandOS.Core.SpellResistantDetections
{
    internal class FreeSpellResistantDetection : SpellResistantDetection
    {
        public override void Learn(SaveGame saveGame, Monster monster)
        {
            if (saveGame.Player.HasFreeAction)
            {
                monster.Mind |= Constants.SmImmFree;
            }
        }
    }
}
