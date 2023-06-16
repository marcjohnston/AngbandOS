namespace AngbandOS.Core.SpellResistantDetections;

internal class DarkSpellResistantDetection : SpellResistantDetection
{
    public override void Learn(SaveGame saveGame, Monster monster)
    {
        if (saveGame.Player.HasDarkResistance)
        {
            monster.SmResDark = true;
        }
    }
}
