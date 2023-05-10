[Serializable]
internal class WarriorMageBlessLifeSpell : ClassSpell
{
    private WarriorMageBlessLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellBless);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 5;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 4;
}