[Serializable]
internal class CultistSenseUnseenLifeSpell : ClassSpell
{
    private CultistSenseUnseenLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellSenseUnseen);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 24;
    public override int ManaCost => 24;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 4;
}