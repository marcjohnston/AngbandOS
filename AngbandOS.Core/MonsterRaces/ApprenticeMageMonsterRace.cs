using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class ApprenticeMageMonsterRace : MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Apprentice mage";

        public override int ArmourClass => 6;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 4),
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool Blink => true;
        public override bool Confuse => true;
        public override string Description => "He is leaving behind a trail of dropped spell components.";
        public override bool Drop60 => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 12;
        public override int FreqSpell => 12;
        public override string FriendlyName => "Apprentice mage";
        public override bool Friends => true;
        public override int Hdice => 6;
        public override int Hside => 4;
        public override int LevelFound => 5;
        public override bool MagicMissile => true;
        public override bool Male => true;
        public override int Mexp => 7;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "Apprentice";
        public override string SplitName3 => "    mage    ";
    }
}