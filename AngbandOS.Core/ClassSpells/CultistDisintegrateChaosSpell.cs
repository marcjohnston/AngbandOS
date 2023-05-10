internal class CultistDisintegrateChaosSpell : ClassSpell
{
    private CultistDisintegrateChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellDisintegrate);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 21;
    public override int ManaCost => 21;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 100;
}