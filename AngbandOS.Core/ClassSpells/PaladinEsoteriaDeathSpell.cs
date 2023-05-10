internal class PaladinEsoteriaDeathSpell : ClassSpell
{
    private PaladinEsoteriaDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellEsoteria);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 38;
    public override int ManaCost => 45;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 250;
}