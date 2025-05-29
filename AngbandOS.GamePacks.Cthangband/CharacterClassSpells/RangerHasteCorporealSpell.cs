// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RangerHasteCorporealSpell : CharacterClassSpellGameConfiguration
{
    public override string SpellName => nameof(SpellsEnum.HasteCorporealSpell);
    public override string CharacterClassName => nameof(CharacterClassesEnum.RangerCharacterClass);
    public override int Level => 34;
    public override int ManaCost => 35;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 4;
}