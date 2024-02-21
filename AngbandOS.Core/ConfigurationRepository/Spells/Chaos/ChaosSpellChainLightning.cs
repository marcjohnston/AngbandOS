// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Chaos;

[Serializable]
internal class ChaosSpellChainLightning : Spell
{
    private ChaosSpellChainLightning(SaveGame saveGame) : base(saveGame) { }
    protected override string? CastScriptName => nameof(ChainLightingScript);

    protected override string? CastFailedScriptName => nameof(WildChaoticMagicScript);

    public override string Name => "Chain Lightning";

    protected override string LearnedDetails => $"dam {5 + (SaveGame.ExperienceLevel / 10)}d8";
}