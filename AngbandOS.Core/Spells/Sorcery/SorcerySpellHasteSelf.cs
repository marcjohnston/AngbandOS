// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Sorcery;

[Serializable]
internal class SorcerySpellHasteSelf : Spell
{
    private SorcerySpellHasteSelf(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        if (SaveGame.Player.TimedHaste.TurnsRemaining == 0)
        {
            SaveGame.Player.TimedHaste.SetTimer(Program.Rng.DieRoll(20 + SaveGame.Player.ExperienceLevel) + SaveGame.Player.ExperienceLevel);
        }
        else
        {
            SaveGame.Player.TimedHaste.AddTimer(Program.Rng.DieRoll(5));
        }
    }

    public override string Name => "Haste Self";
    
    protected override string? Info()
    {
        return $"dur {SaveGame.Player.ExperienceLevel}+d{SaveGame.Player.ExperienceLevel + 20}";
    }
}