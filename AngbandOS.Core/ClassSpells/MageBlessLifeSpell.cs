[Serializable]
internal class MageBlessLifeSpell : ClassSpell
{
    private MageBlessLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellBless);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 3;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 4;
}