using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class TrollThaumaturgistMonsterRace : MonsterRace
    {
        public override char Character => 'T';
        public override Colour Colour => Colour.BrightPurple;
        public override string Name => "Troll thaumaturgist";

        public override int ArmourClass => 50;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 8),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 8),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 3, 4),
        };
        public override bool BashDoor => true;
        public override bool Blink => true;
        public override bool CauseLightWounds => true;
        public override bool Darkness => true;
        public override string Description => "A troll who is so bright he knows how to read.";
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Troll thaumaturgist";
        public override int Hdice => 30;
        public override int Hside => 10;
        public override bool HurtByLight => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 25;
        public override bool MagicMissile => true;
        public override bool Male => true;
        public override int Mexp => 100;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override bool Scare => true;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Troll    ";
        public override string SplitName3 => "thaumaturgis";
        public override bool Troll => true;
    }
}