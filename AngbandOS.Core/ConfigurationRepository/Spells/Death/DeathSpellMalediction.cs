// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death;

[Serializable]
internal class DeathSpellMalediction : Spell
{
    private DeathSpellMalediction(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.RunScript(nameof(MaledictionScript));
    }

    public override void CastFailed()
    {
        SaveGame.RunSpellScript(nameof(WildDeathMagicScript), this);
    }

    public override string Name => "Malediction";

    protected override string LearnedDetails => $"dam {3 + ((SaveGame.ExperienceLevel - 1) / 5)}d3";
}