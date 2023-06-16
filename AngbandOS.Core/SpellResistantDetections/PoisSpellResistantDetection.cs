namespace AngbandOS.Core.SpellResistantDetections;

internal class PoisSpellResistantDetection : SpellResistantDetection
{
    public override void Learn(SaveGame saveGame, Monster monster)
    {
        if (saveGame.Player.HasPoisonResistance)
        {
            monster.SmResPois = true;
        }
        if (saveGame.Player.TimedPoisonResistance.TurnsRemaining != 0)
        {
            monster.SmOppPois = true;
        }
    }
}
