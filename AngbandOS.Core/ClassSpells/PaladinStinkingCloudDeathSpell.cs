internal class PaladinStinkingCloudDeathSpell : ClassSpell
{
    private PaladinStinkingCloudDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellStinkingCloud);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 6;
    public override int ManaCost => 5;
    public override int BaseFailure => 27;
    public override int FirstCastExperience => 4;
}