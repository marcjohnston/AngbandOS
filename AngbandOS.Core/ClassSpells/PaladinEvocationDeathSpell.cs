internal class PaladinEvocationDeathSpell : ClassSpell
{
    private PaladinEvocationDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellEvocation);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 47;
    public override int ManaCost => 45;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 70;
}