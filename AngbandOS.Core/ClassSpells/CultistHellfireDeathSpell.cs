internal class CultistHellfireDeathSpell : ClassSpell
{
    private CultistHellfireDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellHellfire);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 50;
    public override int ManaCost => 135;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 250;
}