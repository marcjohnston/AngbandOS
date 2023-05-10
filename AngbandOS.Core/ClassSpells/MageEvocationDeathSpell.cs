[Serializable]
internal class MageEvocationDeathSpell : ClassSpell
{
    private MageEvocationDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellEvocation);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 37;
    public override int ManaCost => 35;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 70;
}