[Serializable]
internal class WarriorMageSonicBoomChaosSpell : ClassSpell
{
    private WarriorMageSonicBoomChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellSonicBoom);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 27;
    public override int ManaCost => 25;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 20;
}