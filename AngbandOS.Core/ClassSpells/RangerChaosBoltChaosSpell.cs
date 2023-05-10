internal class RangerChaosBoltChaosSpell : ClassSpell
{
    private RangerChaosBoltChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellChaosBolt);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 25;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 8;
}