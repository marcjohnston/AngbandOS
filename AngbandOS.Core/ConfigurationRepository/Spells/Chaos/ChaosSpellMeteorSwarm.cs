// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Chaos;

[Serializable]
internal class ChaosSpellMeteorSwarm : Spell
{
    private ChaosSpellMeteorSwarm(SaveGame saveGame) : base(saveGame) { }
    protected override string? CastScriptName => nameof(MeteorStormScript);

    protected override string? CastFailedScriptName => nameof(WildChaoticMagicScript);

    public override string Name => "Meteor Swarm";

    protected override string LearnedDetails => $"dam {3 * SaveGame.ExperienceLevel / 2} each";
}