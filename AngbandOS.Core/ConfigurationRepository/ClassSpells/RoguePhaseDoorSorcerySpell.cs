// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ClassSpells;

[Serializable]
internal class RoguePhaseDoorSorcerySpell : ClassSpell
{
    private RoguePhaseDoorSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellPhaseDoor);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 2;
    public override int BaseFailure => 55;
    public override int FirstCastExperience => 1;
}