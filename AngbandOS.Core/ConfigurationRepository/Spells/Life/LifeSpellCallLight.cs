// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Life;

[Serializable]
internal class LifeSpellCallLight : Spell
{
    private LifeSpellCallLight(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.LightArea(SaveGame.Rng.DiceRoll(2, SaveGame.ExperienceLevel / 2), (SaveGame.ExperienceLevel / 10) + 1);
    }

    public override string Name => "Call Light";
    
    protected override string? Info()
    {
        return $"dam {10 + (SaveGame.ExperienceLevel / 2)}";
    }
}