using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class KhamulTheEasterlingMonsterRace : MonsterRace
    {
        public override char Character => 'W';
        public override Colour Colour => Colour.Black;
        public override string Name => "Khamul the Easterling";

        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 10, 10),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 5, 5),
            new MonsterAttack(AttackType.Touch, new Exp40AttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Touch, new Exp40AttackEffect(), 0, 0)
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool CauseCriticalWounds => true;
        public override bool CauseMortalWounds => true;
        public override bool ColdBall => true;
        public override bool ColdBlood => true;
        public override string Description => "A warrior-king of the East. Khamul is a powerful opponent, his skill in combat awesome and his form twisted by evil cunning.";
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool FireBall => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Khamul the Easterling";
        public override int Hdice => 35;
        public override bool Hold => true;
        public override int Hside => 100;
        public override bool HurtByLight => true;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 53;
        public override bool Male => true;
        public override bool ManaBolt => true;
        public override int Mexp => 50000;
        public override bool MoveBody => true;
        public override bool NetherBall => true;
        public override int NoticeRange => 90;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 10;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "   Khamul   ";
        public override string SplitName2 => "    the     ";
        public override string SplitName3 => " Easterling ";
        public override bool SummonKin => true;
        public override bool SummonUndead => true;
        public override bool TeleportLevel => true;
        public override bool Undead => true;
        public override bool Unique => true;
    }
}