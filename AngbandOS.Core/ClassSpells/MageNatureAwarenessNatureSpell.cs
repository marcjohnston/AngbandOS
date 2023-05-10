internal class MageNatureAwarenessNatureSpell : ClassSpell
{
    private MageNatureAwarenessNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellNatureAwareness);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 6;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 6;
}