[Serializable]
internal class PaladinHorrifyDeathSpell : ClassSpell
{
    private PaladinHorrifyDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellHorrify);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 12;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}