[Serializable]
internal class PriestBlessLifeSpell : ClassSpell
{
    private PriestBlessLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellBless);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 1;
    public override int ManaCost => 2;
    public override int BaseFailure => 20;
    public override int FirstCastExperience => 4;
}