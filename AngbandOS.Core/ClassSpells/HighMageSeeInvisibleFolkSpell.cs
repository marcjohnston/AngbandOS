// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ClassSpells;

[Serializable]
internal class HighMageSeeInvisibleFolkSpell : ClassSpell
{
    private HighMageSeeInvisibleFolkSpell(Game game) : base(game) { }
    public override string SpellName => nameof(SeeInvisibleFolkSpell);
    public override string CharacterClassName => nameof(HighMageCharacterClass);
    public override int Level => 22;
    public override int ManaCost => 18;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 13;
}