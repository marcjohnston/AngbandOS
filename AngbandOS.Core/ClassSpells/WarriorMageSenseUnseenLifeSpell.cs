[Serializable]
internal class WarriorMageSenseUnseenLifeSpell : ClassSpell
{
    private WarriorMageSenseUnseenLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellSenseUnseen);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 24;
    public override int ManaCost => 24;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 4;
}