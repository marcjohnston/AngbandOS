using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class OrfaxSonOfBoldorMonsterRace : MonsterRace
    {
        public override char Character => 'y';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Orfax, Son of Boldor";

        public override bool Animal => true;
        public override int ArmourClass => 20;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 9),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 8),
            new MonsterAttack(AttackType.Insult, null, 0, 0),
            new MonsterAttack(AttackType.Insult, null, 0, 0)
        };
        public override bool BashDoor => true;
        public override bool Blink => true;
        public override bool Confuse => true;
        public override string Description => "He's just like daddy! He knows mighty spells, but fortunately he is a yeek.";
        public override bool Drop90 => true;
        public override bool DropGood => true;
        public override bool Escorted => true;
        public override bool EscortsGroup => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Orfax, Son of Boldor";
        public override int Hdice => 12;
        public override bool Heal => true;
        public override int Hside => 10;
        public override bool ImmuneAcid => true;
        public override int LevelFound => 10;
        public override bool Male => true;
        public override int Mexp => 80;
        public override int NoticeRange => 18;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 10;
        public override bool Slow => true;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Orfax    ";
        public override bool SummonMonster => true;
        public override bool TeleportTo => true;
        public override bool Unique => true;
    }
}
