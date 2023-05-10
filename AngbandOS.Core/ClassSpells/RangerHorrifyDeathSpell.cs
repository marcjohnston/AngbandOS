[Serializable]
internal class RangerHorrifyDeathSpell : ClassSpell
{
    private RangerHorrifyDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellHorrify);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 19;
    public override int ManaCost => 19;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 3;
}