internal class PaladinRestorationLifeSpell : ClassSpell
{
    private PaladinRestorationLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellRestoration);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 80;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 225;
}