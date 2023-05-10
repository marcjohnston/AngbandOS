[Serializable]
internal class RangerNatureAwarenessNatureSpell : ClassSpell
{
    private RangerNatureAwarenessNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellNatureAwareness);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 9;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 4;
}