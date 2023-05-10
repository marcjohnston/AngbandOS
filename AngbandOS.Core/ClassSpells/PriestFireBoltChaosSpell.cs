internal class PriestFireBoltChaosSpell : ClassSpell
{
    private PriestFireBoltChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFireBolt);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 6;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}