using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class TheWitchKingOfAngmarMonsterRace : Base2MonsterRace
    {
        public override char Character => 'W';
        public override Colour Colour => Colour.Black;
        public override string Name => "The Witch-King of Angmar";

        public override int ArmourClass => 120;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 10, 10),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 10, 10),
            new MonsterAttack(AttackType.Hit, new Exp80AttackEffect(), 5, 5),
            new MonsterAttack(AttackType.Hit, new Exp80AttackEffect(), 5, 5)
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BrainSmash => true;
        public override bool CauseCriticalWounds => true;
        public override bool ColdBlood => true;
        public override string Description => "The Chief of the Ringwraiths. A fell being of devastating power. His spells are lethal and his combat blows crushingly hard. He moves at speed, and commands legions of evil to do his bidding. It is said that he is fated never to die by the hand of mortal man.";
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "The Witch-King of Angmar";
        public override int Hdice => 60;
        public override bool Hold => true;
        public override int Hside => 100;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 80;
        public override bool Male => true;
        public override bool ManaBolt => true;
        public override int Mexp => 42000;
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
        public override int Speed => 130;
        public override string SplitName1 => "    The     ";
        public override string SplitName2 => "Witch-King o";
        public override string SplitName3 => "   Angmar   ";
        public override bool SummonHiDragon => true;
        public override bool SummonHiUndead => true;
        public override bool SummonKin => true;
        public override bool SummonMonsters => true;
        public override bool TeleportAway => true;
        public override bool Undead => true;
        public override bool Unique => true;
    }
}
