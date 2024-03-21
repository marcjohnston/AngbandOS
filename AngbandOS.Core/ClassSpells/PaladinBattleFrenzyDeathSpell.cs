// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ClassSpells;

[Serializable]
internal class PaladinBattleFrenzyDeathSpell : ClassSpell
{
    private PaladinBattleFrenzyDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override string SpellName => nameof(DeathSpellBattleFrenzy);
    public override string CharacterClassName => nameof(PaladinCharacterClass);
    public override int Level => 38;
    public override int ManaCost => 38;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 50;
}