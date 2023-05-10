[Serializable]
internal class RangerFireBoltChaosSpell : ClassSpell
{
    private RangerFireBoltChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFireBolt);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 16;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}