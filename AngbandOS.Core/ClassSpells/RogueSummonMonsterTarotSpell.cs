[Serializable]
internal class RogueSummonMonsterTarotSpell : ClassSpell
{
    private RogueSummonMonsterTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonMonster);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 32;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 9;
}