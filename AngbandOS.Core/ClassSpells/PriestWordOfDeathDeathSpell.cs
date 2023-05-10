[Serializable]
internal class PriestWordOfDeathDeathSpell : ClassSpell
{
    private PriestWordOfDeathDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellWordOfDeath);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 40;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 40;
}