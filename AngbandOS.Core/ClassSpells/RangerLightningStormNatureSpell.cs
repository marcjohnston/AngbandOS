// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ClassSpells;

[Serializable]
internal class RangerLightningStormNatureSpell : ClassSpell
{
    private RangerLightningStormNatureSpell(Game game) : base(game) { }
    public override string SpellName => nameof(NatureSpellLightningStorm);
    public override string CharacterClassName => nameof(RangerCharacterClass);
    public override int Level => 32;
    public override int ManaCost => 29;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 35;
}