using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class LordOfChaosMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new ChaosBallMonsterSpell(),
            new MindBlastMonsterSpell(),
            new HealMonsterSpell(),
            new SummonDemonMonsterSpell(),
            new SummonHoundMonsterSpell(),
            new SummonSpiderMonsterSpell());
        public override char Character => 'p';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Lord of Chaos";

        public override int ArmourClass => 80;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Kick, new HurtAttackEffect(), 20, 2),
            new MonsterAttack(AttackType.Kick, new HurtAttackEffect(), 10, 2),
            new MonsterAttack(AttackType.Hit, new PoisonAttackEffect(), 20, 1),
            new MonsterAttack(AttackType.Hit, new LoseAllAttackEffect(), 15, 1)
        };
        public override bool AttrAny => true;
        public override bool AttrMulti => true;
        public override bool BashDoor => true;
        public override string Description => "He is one of the few true masters of the art, being extremely skillful in all forms of unarmed combat and controlling the chaos with disdainful ease.";
        public override bool Drop_4D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Lord of Chaos";
        public override int Hdice => 45;
        public override int Hside => 55;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 53;
        public override bool Male => true;
        public override int Mexp => 17500;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 3;
        public override bool Shapechanger => true;
        public override int Sleep => 5;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "    Lord    ";
        public override string SplitName2 => "     of     ";
        public override string SplitName3 => "   Chaos    ";
    }
}
