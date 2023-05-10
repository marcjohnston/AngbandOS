internal class MageMaledictionDeathSpell : ClassSpell
{
    private MageMaledictionDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellMalediction);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 2;
    public override int ManaCost => 2;
    public override int BaseFailure => 25;
    public override int FirstCastExperience => 4;
}