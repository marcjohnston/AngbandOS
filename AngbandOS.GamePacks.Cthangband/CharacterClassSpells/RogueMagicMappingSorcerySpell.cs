// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RogueMagicMappingSorcerySpell : CharacterClassSpellGameConfiguration
{
    public override string SpellName => nameof(SpellsEnum.MagicMappingSorcerySpell);
    public override string CharacterClassName => nameof(CharacterClassesEnum.RogueCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 14;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 1;
}