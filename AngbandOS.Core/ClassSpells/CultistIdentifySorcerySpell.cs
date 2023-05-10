internal class CultistIdentifySorcerySpell : ClassSpell
{
    private CultistIdentifySorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellIdentify);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 10;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 8;
}