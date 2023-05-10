internal class PaladinWordOfDeathDeathSpell : ClassSpell
{
    private PaladinWordOfDeathDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellWordOfDeath);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 45;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 40;
}