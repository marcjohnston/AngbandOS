using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class OozeElementalMonsterRace : MonsterRace
    {
        public override char Character => 'E';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Ooze elemental";

        public override bool AcidBall => true;
        public override bool AcidBolt => true;
        public override int ArmourClass => 80;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Touch, new AcidAttackEffect(), 1, 10),
            new MonsterAttack(AttackType.Touch, new AcidAttackEffect(), 1, 10),
            new MonsterAttack(AttackType.Touch, new AcidAttackEffect(), 1, 10),
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "It is a towering mass of filth, an eyesore of ooze.";
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Ooze elemental";
        public override int Hdice => 13;
        public override int Hside => 10;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool KillBody => true;
        public override bool KillItem => true;
        public override int LevelFound => 35;
        public override int Mexp => 300;
        public override int NoticeRange => 10;
        public override bool Powerful => true;
        public override int Rarity => 3;
        public override int Sleep => 90;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Ooze    ";
        public override string SplitName3 => " elemental  ";
    }
}