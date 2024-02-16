// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ClassSpells;

[Serializable]
internal class PriestSatisfyHungerLifeSpell : ClassSpell
{
    private PriestSatisfyHungerLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override string SpellName => nameof(LifeSpellSatisfyHunger);
    public override string CharacterClassName => nameof(PriestCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 5;
    public override int BaseFailure => 38;
    public override int FirstCastExperience => 4;
}