// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Sorcery;

[Serializable]
internal class SenseMindsSorcerySpell : Spell
{
    private SenseMindsSorcerySpell(Game game) : base(game) { }
    protected override string[]? CastScriptNames => new string[] { nameof(AddTelepathy25p1d30Script) };

    public override string Name => "Sense Minds";

    protected override string LearnedDetails => "dur 25+d30";
}