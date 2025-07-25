// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PriestRemoveFearLifeSpell : CharacterClassSpellGameConfiguration
{
    public override string SpellName => nameof(SpellsEnum.RemoveFearLifeSpell);
    public override string CharacterClassName => nameof(CharacterClassesEnum.PriestCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 2;
    public override int BaseFailure => 25;
    public override int FirstCastExperience => 1;
}