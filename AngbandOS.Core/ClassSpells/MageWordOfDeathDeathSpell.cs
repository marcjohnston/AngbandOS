[Serializable]
internal class MageWordOfDeathDeathSpell : ClassSpell
{
    private MageWordOfDeathDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellWordOfDeath);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 35;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 40;
}