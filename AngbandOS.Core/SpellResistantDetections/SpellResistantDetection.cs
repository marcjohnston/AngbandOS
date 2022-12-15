namespace AngbandOS.Core.SpellResistantDetections
{
    internal abstract class SpellResistantDetection
    {
        public abstract void Learn(SaveGame saveGame, Monster monster);
    }
}
