internal class PriestNatureAwarenessNatureSpell : ClassSpell
{
    private PriestNatureAwarenessNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellNatureAwareness);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 10;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 6;
}