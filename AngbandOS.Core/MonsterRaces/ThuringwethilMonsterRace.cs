using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class ThuringwethilMonsterRace : MonsterRace
    {
        public override char Character => 'V';
        public override Colour Colour => Colour.Black;
        public override string Name => "Thuringwethil";

        public override int ArmourClass => 145;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 5, 8),
            new MonsterAttack(AttackType.Bite, new Exp80AttackEffect(), 6, 6),
            new MonsterAttack(AttackType.Hit, new ConfuseAttackEffect(), 6, 6),
            new MonsterAttack(AttackType.Hit, new ConfuseAttackEffect(), 6, 6)
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BrainSmash => true;
        public override bool CauseCriticalWounds => true;
        public override bool CauseMortalWounds => true;
        public override bool ColdBlood => true;
        public override string Description => "Chief messenger between Sauron and Morgoth, she is surely the most deadly of her vampire race. At first she is charming to meet, but her wings and eyes give away her true form.";
        public override bool DrainMana => true;
        public override bool Drop_2D2 => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool Female => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Thuringwethil";
        public override int Hdice => 40;
        public override bool Hold => true;
        public override int Hside => 100;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 55;
        public override int Mexp => 23000;
        public override bool NetherBall => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 4;
        public override bool Regenerate => true;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 10;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "Thuringwethi";
        public override bool SummonKin => true;
        public override bool Undead => true;
        public override bool Unique => true;
    }
}