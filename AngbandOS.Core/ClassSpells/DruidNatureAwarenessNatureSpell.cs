[Serializable]
internal class DruidNatureAwarenessNatureSpell : ClassSpell
{
    private DruidNatureAwarenessNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellNatureAwareness);
    public override Type CharacterClass => typeof(DruidCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 5;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 6;
}