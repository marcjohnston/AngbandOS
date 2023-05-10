internal class PaladinBanishLifeSpell : ClassSpell
{
    private PaladinBanishLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellBanish);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 55;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 115;
}