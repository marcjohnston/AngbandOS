// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ClassSpells;

[Serializable]
internal class CultistHellfireDeathSpell : ClassSpell
{
    private CultistHellfireDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellHellfire);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 50;
    public override int ManaCost => 135;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 250;
}