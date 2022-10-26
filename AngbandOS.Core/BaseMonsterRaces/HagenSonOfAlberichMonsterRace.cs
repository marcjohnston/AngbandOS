using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class HagenSonOfAlberichMonsterRace : Base2MonsterRace
    {
        public override char Character => 'h';
        public override Colour Colour => Colour.Orange;
        public override string Name => "Hagen, son of Alberich";

        public override int ArmourClass => 80;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 7),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 7),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 7),
            new MonsterAttack(AttackType.Hit, new UnBonusAttackEffect(), 0, 0)
        };
        public override bool BashDoor => true;
        public override string Description => "Alberich's son, born of a mortal woman won with gold.";
        public override bool Drop_1D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool FireBolt => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "Hagen, son of Alberich";
        public override bool Haste => true;
        public override int Hdice => 82;
        public override bool Heal => true;
        public override int Hside => 10;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneSleep => true;
        public override int Level => 24;
        public override bool Male => true;
        public override int Mexp => 300;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override bool ResistTeleport => true;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Hagen    ";
        public override bool Unique => true;
    }
}
