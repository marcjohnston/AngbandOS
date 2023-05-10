internal class MageStinkingCloudDeathSpell : ClassSpell
{
    private MageStinkingCloudDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellStinkingCloud);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 3;
    public override int BaseFailure => 27;
    public override int FirstCastExperience => 3;
}