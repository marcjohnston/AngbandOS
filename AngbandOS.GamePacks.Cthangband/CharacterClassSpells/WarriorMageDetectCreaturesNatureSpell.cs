// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WarriorMageDetectCreaturesNatureSpell : CharacterClassSpellGameConfiguration
{
    public override string SpellName => nameof(SpellsEnum.DetectCreaturesNatureSpell);
    public override string CharacterClassName => nameof(CharacterClassesEnum.WarriorMageCharacterClass);
    public override int Level => 2;
    public override int ManaCost => 2;
    public override int BaseFailure => 23;
    public override int FirstCastExperience => 4;
}