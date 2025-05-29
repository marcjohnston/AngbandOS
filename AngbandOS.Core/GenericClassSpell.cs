// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class GenericClassSpell : CharacterClassSpell
{
    public GenericClassSpell(Game game, CharacterClassSpellGameConfiguration classSpellGameConfiguration) : base(game)
    {
        SpellName = classSpellGameConfiguration.SpellName;
        CharacterClassName = classSpellGameConfiguration.CharacterClassName;
        Level = classSpellGameConfiguration.Level;
        ManaCost = classSpellGameConfiguration.ManaCost;
        BaseFailure = classSpellGameConfiguration.BaseFailure;
        FirstCastExperience = classSpellGameConfiguration.FirstCastExperience;
    }
    public override string SpellName { get; }
    public override string CharacterClassName { get; }
    public override int Level { get; }
    public override int ManaCost { get; }
    public override int BaseFailure { get; }
    public override int FirstCastExperience { get; }

}
