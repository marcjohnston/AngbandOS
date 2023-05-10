internal class CultistIdentifyTrueSorcerySpell : ClassSpell
{
    private CultistIdentifyTrueSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellIdentifyTrue);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 40;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 20;
}