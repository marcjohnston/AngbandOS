[Serializable]
internal class WarriorMageStasisSorcerySpell : ClassSpell
{
    private WarriorMageStasisSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellStasis);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 12;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 20;
}