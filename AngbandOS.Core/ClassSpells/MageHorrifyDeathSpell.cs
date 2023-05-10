internal class MageHorrifyDeathSpell : ClassSpell
{
    private MageHorrifyDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellHorrify);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 9;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}