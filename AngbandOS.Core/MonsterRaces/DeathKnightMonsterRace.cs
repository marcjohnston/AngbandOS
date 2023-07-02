// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class DeathKnightMonsterRace : MonsterRace
{
    protected DeathKnightMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BlindnessMonsterSpell(),
        new CauseCriticalWoundsMonsterSpell(),
        new NetherBoltMonsterSpell(),
        new ScareMonsterSpell(),
        new SummonMonstersMonsterSpell());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerPSymbol>();
    public override Colour Colour => Colour.Grey;
    public override string Name => "Death knight";

    public override int ArmourClass => 100;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 6, 5),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 5, 5),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 5, 5),
        new MonsterAttack(new HitAttackType(), new Exp20AttackEffect(), 0, 0)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "It is a humanoid form dressed in armour of an ancient form. From beneath its helmet, eyes glow a baleful red and seem to pierce you like lances of fire.";
    public override bool Drop_1D2 => true;
    public override bool Drop_2D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Death knight";
    public override int Hdice => 60;
    public override int Hside => 10;
    public override bool ImmuneCold => true;
    public override int LevelFound => 38;
    public override int Mexp => 1111;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Death    ";
    public override string SplitName3 => "   knight   ";
}
