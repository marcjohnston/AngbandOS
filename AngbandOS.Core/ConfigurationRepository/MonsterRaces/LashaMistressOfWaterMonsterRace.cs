// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class LashaMistressOfWaterMonsterRace : MonsterRace
{
    protected LashaMistressOfWaterMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(ColdBallMonsterSpell),
        nameof(IceBoltMonsterSpell),
        nameof(WaterBallMonsterSpell),
        nameof(WaterBoltMonsterSpell)
    };

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperESymbol));
    public override ColorEnum Color => ColorEnum.Blue;
    public override string Name => "Lasha, Mistress of Water";

    public override int ArmorClass => 40;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(HitAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 5, 5),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(HitAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 5, 5),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(HitAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 5, 5),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(HitAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 5, 5)
    };
    public override bool BashDoor => true;
    public override string Description => "With the body of a beautiful mermaid, she hides her cruelnature well, until it is too late.";
    public override bool Evil => true;
    public override bool Female => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Lasha, Mistress of Water";
    public override int Hdice => 20;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool KillBody => true;
    public override bool KillItem => true;
    public override int LevelFound => 39;
    public override int Mexp => 3250;
    public override int NoticeRange => 12;
    public override bool Powerful => true;
    public override bool RandomMove25 => true;
    public override int Rarity => 3;
    public override int Sleep => 50;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "   Lasha    ";
    public override bool Unique => true;
}
