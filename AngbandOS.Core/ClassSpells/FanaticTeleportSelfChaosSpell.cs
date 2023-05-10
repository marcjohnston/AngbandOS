[Serializable]
internal class FanaticTeleportSelfChaosSpell : ClassSpell
{
    private FanaticTeleportSelfChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellTeleportSelf);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 16;
    public override int ManaCost => 10;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 5;
}