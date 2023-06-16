namespace AngbandOS.Core.SpellResistantDetections;

internal class ManaSpellResistantDetection : SpellResistantDetection
{
    public override void Learn(SaveGame saveGame, Monster monster)
    {
        if (saveGame.Player.MaxMana == 0)
        {
            monster.SmImmMana = true;
        }
    }
}
