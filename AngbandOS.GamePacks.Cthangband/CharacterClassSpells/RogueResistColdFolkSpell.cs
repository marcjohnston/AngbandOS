// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RogueResistColdFolkSpell : CharacterClassSpellGameConfiguration
{
    public override string SpellName => nameof(SpellsEnum.ResistColdFolkSpell);
    public override string CharacterClassName => nameof(CharacterClassesEnum.RogueCharacterClass);
    public override int Level => 16;
    public override int ManaCost => 15;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}