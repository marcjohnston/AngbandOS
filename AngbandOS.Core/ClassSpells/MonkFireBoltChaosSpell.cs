internal class MonkFireBoltChaosSpell : ClassSpell
{
    private MonkFireBoltChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFireBolt);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 11;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 5;
}