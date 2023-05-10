internal class PriestSonicBoomChaosSpell : ClassSpell
{
    private PriestSonicBoomChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellSonicBoom);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 23;
    public override int ManaCost => 18;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 20;
}