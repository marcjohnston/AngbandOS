using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class ChaosHoundMonsterRace : MonsterRace
    {
        public override char Character => 'Z';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Chaos hound";

        public override bool Animal => true;
        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 3, 3)
        };
        public override bool AttrAny => true;
        public override bool AttrMulti => true;
        public override bool BashDoor => true;
        public override bool BreatheChaos => true;
        public override string Description => "A constantly changing canine form, this hound rushes towards you as if expecting mayhem and chaos ahead. It appears to have an almost kamikaze relish for combat. You suspect all may not be as it seems.";
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Chaos hound";
        public override bool Friends => true;
        public override int Hdice => 60;
        public override int Hside => 30;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 65;
        public override int Mexp => 10000;
        public override int NoticeRange => 30;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Chaos    ";
        public override string SplitName3 => "   hound    ";
    }
}