// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GremlinMonsterRace : MonsterRace
{
    protected GremlinMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(LowerUSymbol));
    public override ColorEnum Color => ColorEnum.BrightChartreuse;
    public override string Name => "Gremlin";

    public override int ArmorClass => 30;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(ClawAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(EatFoodAttackEffect)), 1, 2),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(ClawAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(EatFoodAttackEffect)), 1, 2),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(EatFoodAttackEffect)), 1, 3),
    };
    public override bool Demon => true;
    public override string Description => "Don't feed them after midnight!";
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Gremlin";
    public override int Hdice => 5;
    public override int Hside => 5;
    public override bool HurtByLight => true;
    public override bool ImmunePoison => true;
    public override int LevelFound => 8;
    public override int Mexp => 6;
    public override bool Multiply => true;
    public override int NoticeRange => 30;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override int Sleep => 20;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "  Gremlin   ";
    public override bool TakeItem => true;
}
