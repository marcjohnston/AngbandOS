// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HighMageWordOfDeathDeathSpell : CharacterClassSpellGameConfiguration
{
    public override string SpellName => nameof(SpellsEnum.WordOfDeathDeathSpell);
    public override string CharacterClassName => nameof(CharacterClassesEnum.HighMageCharacterClass);
    public override int Level => 29;
    public override int ManaCost => 30;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 40;
}