using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class FireVampireMonsterRace : MonsterRace
    {
        public override char Character => 'A';
        public override Colour Colour => Colour.Red;
        public override string Name => "Fire vampire";

        public override int ArmourClass => 6;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Touch, new FireAttackEffect(), 1, 4),
        };
        public override bool BashDoor => true;
        public override bool Blink => true;
        public override bool Cthuloid => true;
        public override string Description => "A burning point of light, floating through the air and flickering with sinister purpose.";
        public override bool FireAura => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Fire vampire";
        public override bool Friends => true;
        public override int Hdice => 2;
        public override int Hside => 5;
        public override bool ImmuneFire => true;
        public override int LevelFound => 14;
        public override int Mexp => 23;
        public override int NoticeRange => 8;
        public override bool RandomMove50 => true;
        public override int Rarity => 2;
        public override int Sleep => 6;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Fire    ";
        public override string SplitName3 => "  vampire   ";
    }
}