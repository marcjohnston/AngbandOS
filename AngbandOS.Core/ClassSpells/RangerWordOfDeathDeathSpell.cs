[Serializable]
internal class RangerWordOfDeathDeathSpell : ClassSpell
{
    private RangerWordOfDeathDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellWordOfDeath);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 50;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 75;
}