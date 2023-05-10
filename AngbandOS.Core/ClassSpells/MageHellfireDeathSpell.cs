internal class MageHellfireDeathSpell : ClassSpell
{
    private MageHellfireDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellHellfire);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 120;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 250;
}