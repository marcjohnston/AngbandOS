[Serializable]
internal class MageChaosBoltChaosSpell : ClassSpell
{
    private MageChaosBoltChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellChaosBolt);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 19;
    public override int ManaCost => 12;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 9;
}