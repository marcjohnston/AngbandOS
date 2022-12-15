namespace AngbandOS.Core.SpellResistantDetections
{
    internal class ReflectSpellResistantDetection : SpellResistantDetection
    {
        public override void Learn(SaveGame saveGame, Monster monster)
        {
            if (saveGame.Player.HasReflection)
            {
                monster.SmImmReflect = true;
            }
        }
    }
}
