[Serializable]
internal class PriestAlterRealityChaosSpell : ClassSpell
{
    private PriestAlterRealityChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellAlterReality);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 30;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 150;
}