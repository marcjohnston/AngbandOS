[Serializable]
internal class PaladinBlessLifeSpell : ClassSpell
{
    private PaladinBlessLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellBless);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 3;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 4;
}