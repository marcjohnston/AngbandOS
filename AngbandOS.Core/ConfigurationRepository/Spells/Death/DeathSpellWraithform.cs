// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death;

[Serializable]
internal class DeathSpellWraithform : Spell
{
    private DeathSpellWraithform(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.TimedEtherealness.AddTimer(SaveGame.Rng.DieRoll(SaveGame.ExperienceLevel / 2) + (SaveGame.ExperienceLevel / 2));
    }

    public override void CastFailed()
    {
        DoWildDeathMagic(31, 3);
    }

    public override string Name => "Wraithform";

    protected override string LearnedDetails => $"dur {SaveGame.ExperienceLevel / 2}+d{SaveGame.ExperienceLevel / 2}";
}