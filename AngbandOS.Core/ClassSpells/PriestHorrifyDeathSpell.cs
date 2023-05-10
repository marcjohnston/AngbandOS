[Serializable]
internal class PriestHorrifyDeathSpell : ClassSpell
{
    private PriestHorrifyDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellHorrify);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 11;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}