// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Corporeal;

[Serializable]
internal class CorporealSpellHaste : Spell
{
    private CorporealSpellHaste(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        if (SaveGame.TimedHaste.TurnsRemaining == 0)
        {
            SaveGame.TimedHaste.SetTimer(Program.Rng.DieRoll(20 + SaveGame.ExperienceLevel) + SaveGame.ExperienceLevel);
        }
        else
        {
            SaveGame.TimedHaste.AddTimer(Program.Rng.DieRoll(5));
        }
    }

    public override string Name => "Haste";
    
    protected override string? Info()
    {
        return $"dur {SaveGame.ExperienceLevel}+d{20 + SaveGame.ExperienceLevel}";
    }
}