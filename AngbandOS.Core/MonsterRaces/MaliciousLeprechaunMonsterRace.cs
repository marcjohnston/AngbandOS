using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class MaliciousLeprechaunMonsterRace : MonsterRace
    {
        public override char Character => 'h';
        public override Colour Colour => Colour.Chartreuse;
        public override string Name => "Malicious leprechaun";

        public override int ArmourClass => 13;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Touch, new EatGoldAttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Touch, new EatItemAttackEffect(), 0, 0),
        };
        public override bool Blink => true;
        public override bool CauseLightWounds => true;
        public override bool ColdBlood => true;
        public override string Description => "This little creature has a fiendish gleam in its eyes.";
        public override bool Evil => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Malicious leprechaun";
        public override int Hdice => 4;
        public override int Hside => 5;
        public override bool HurtByLight => true;
        public override bool Invisible => true;
        public override int LevelFound => 35;
        public override bool Male => true;
        public override int Mexp => 85;
        public override bool Multiply => true;
        public override int NoticeRange => 8;
        public override bool OpenDoor => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 4;
        public override int Sleep => 8;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => " Malicious  ";
        public override string SplitName3 => " leprechaun ";
        public override bool TakeItem => true;
        public override bool TeleportSelf => true;
        public override bool TeleportTo => true;
    }
}
