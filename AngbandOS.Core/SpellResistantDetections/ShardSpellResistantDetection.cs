namespace AngbandOS.Core.SpellResistantDetections;

internal class ShardSpellResistantDetection : SpellResistantDetection
{
    public override void Learn(SaveGame saveGame, Monster monster)
    {
        if (saveGame.Player.HasShardResistance)
        {
            monster.SmResShard = true;
        }
    }
}
