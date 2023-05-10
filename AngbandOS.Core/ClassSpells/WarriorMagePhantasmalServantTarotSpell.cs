[Serializable]
internal class WarriorMagePhantasmalServantTarotSpell : ClassSpell
{
    private WarriorMagePhantasmalServantTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellPhantasmalServant);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 31;
    public override int ManaCost => 26;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 8;
}