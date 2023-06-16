namespace AngbandOS.Core.SpellResistantDetections;

internal class NethSpellResistantDetection : SpellResistantDetection
{
    public override void Learn(SaveGame saveGame, Monster monster)
    {
        if (saveGame.Player.HasNetherResistance)
        {
            monster.SmResNeth = true;
        }
    }
}
