internal class WarriorMageNatureAwarenessNatureSpell : ClassSpell
{
    private WarriorMageNatureAwarenessNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellNatureAwareness);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 12;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 6;
}