[Serializable]
internal class CultistNatureAwarenessNatureSpell : ClassSpell
{
    private CultistNatureAwarenessNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellNatureAwareness);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 12;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 6;
}