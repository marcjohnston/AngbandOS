// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ClassSpells;

[Serializable]
internal class RangerDetectObjectsFolkSpell : ClassSpell
{
    private RangerDetectObjectsFolkSpell(Game game) : base(game) { }
    public override string SpellName => nameof(FolkSpellDetectObjects);
    public override string CharacterClassName => nameof(RangerCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 13;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}