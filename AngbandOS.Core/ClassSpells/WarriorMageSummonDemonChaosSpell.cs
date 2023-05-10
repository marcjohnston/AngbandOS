[Serializable]
internal class WarriorMageSummonDemonChaosSpell : ClassSpell
{
    private WarriorMageSummonDemonChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellSummonDemon);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 50;
    public override int ManaCost => 111;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 250;
}