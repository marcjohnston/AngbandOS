internal class PriestEsoteriaDeathSpell : ClassSpell
{
    private PriestEsoteriaDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellEsoteria);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 45;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 250;
}