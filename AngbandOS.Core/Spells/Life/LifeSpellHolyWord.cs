// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Life;

[Serializable]
internal class LifeSpellHolyWord : Spell
{
    private LifeSpellHolyWord(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.DispelEvil(SaveGame.Player.ExperienceLevel * 4);
        SaveGame.Player.RestoreHealth(1000);
        SaveGame.Player.TimedFear.ResetTimer();
        SaveGame.Player.TimedPoison.ResetTimer();
        SaveGame.Player.TimedStun.ResetTimer();
        SaveGame.Player.TimedBleeding.ResetTimer();
    }

    public override string Name => "Holy Word";
    
    protected override string? Info()
    {
        return $"d {4 * SaveGame.Player.ExperienceLevel}/h 1000";
    }
}