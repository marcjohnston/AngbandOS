// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death;

[Serializable]
internal class DeathSpellHorrify : Spell
{
    private DeathSpellHorrify(SaveGame saveGame) : base(saveGame) { }
    protected override string? CastScriptName => nameof(HorrifyScript);

    protected override string? CastFailedScriptName => nameof(WildDeathMagicScript);

    public override string Name => "Horrify";
}