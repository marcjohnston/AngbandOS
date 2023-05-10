internal class MonkDoomBoltChaosSpell : ClassSpell
{
    private MonkDoomBoltChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellDoomBolt);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 29;
    public override int ManaCost => 30;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 11;
}