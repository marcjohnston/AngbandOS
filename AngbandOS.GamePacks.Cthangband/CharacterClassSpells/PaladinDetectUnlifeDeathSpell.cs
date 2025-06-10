// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PaladinDetectUnlifeDeathSpell : CharacterClassSpellGameConfiguration
{
    public override string SpellName => nameof(SpellsEnum.DetectUnlifeDeathSpell);
    public override string CharacterClassName => nameof(CharacterClassesEnum.PaladinCharacterClass);
    public override int Level => 1;
    public override int ManaCost => 1;
    public override int BaseFailure => 24;
    public override int FirstCastExperience => 4;
}