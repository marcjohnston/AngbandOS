internal class PriestChaosBoltChaosSpell : ClassSpell
{
    private PriestChaosBoltChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellChaosBolt);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 21;
    public override int ManaCost => 16;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 9;
}