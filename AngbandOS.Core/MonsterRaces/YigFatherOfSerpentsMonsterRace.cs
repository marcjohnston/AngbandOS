using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class YigFatherOfSerpentsMonsterRace : MonsterRace
    {
        public override char Character => 'J';
        public override Colour Colour => Colour.Green;
        public override string Name => "Yig, Father of Serpents";

        public override int ArmourClass => 185;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new PoisonAttackEffect(), 5, 10),
            new MonsterAttack(AttackType.Claw, new PoisonAttackEffect(), 5, 10),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 20, 10),
            new MonsterAttack(AttackType.Crush, new UnBonusAttackEffect(), 5, 12)
        };
        public override bool BashDoor => true;
        public override bool BreatheAcid => true;
        public override bool BreatheDisenchant => true;
        public override bool BreathePoison => true;
        public override string Description => "A humanoid snake, Yig is one of the most poisonous entities in existance.";
        public override bool Drop_2D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Escorted => true;
        public override bool EscortsGroup => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Yig, Father of Serpents";
        public override bool GreatOldOne => true;
        public override int Hdice => 85;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 84;
        public override int Mexp => 35000;
        public override bool MoveBody => true;
        public override int NoticeRange => 50;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 2;
        public override bool ResistDisenchant => true;
        public override bool ResistPlasma => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 20;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "    Yig     ";
        public override bool Unique => true;
    }
}