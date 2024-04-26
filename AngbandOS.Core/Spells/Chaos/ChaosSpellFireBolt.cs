// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Chaos;

[Serializable]
internal class ChaosSpellFireBolt : Spell
{
    private ChaosSpellFireBolt(Game game) : base(game) { }
    protected override string? CastScriptName => nameof(FireBoltScript);

    protected override string? CastFailedScriptName => nameof(WildChaoticMagicScript);

    public override string Name => "Fire Bolt";

    protected override string LearnedDetails => $"dam {6 + ((Game.ExperienceLevel.IntValue - 5) / 4)}d8";
}