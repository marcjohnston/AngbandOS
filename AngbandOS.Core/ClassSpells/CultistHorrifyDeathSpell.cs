internal class CultistHorrifyDeathSpell : ClassSpell
{
    private CultistHorrifyDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellHorrify);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 10;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}