using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class DarkElvenDemonologistMonsterRace : MonsterRace
    {
        public override char Character => 'h';
        public override Colour Colour => Colour.Red;
        public override string Name => "Dark elven demonologist";

        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 9),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 10),
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool CauseSeriousWounds => true;
        public override bool Confuse => true;
        public override bool Darkness => true;
        public override string Description => "A dark elven figure, dressed all in black, chanting curses and waiting to deliver your soul to hell.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override bool Female => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Dark elven demonologist";
        public override int Hdice => 7;
        public override bool Heal => true;
        public override int Hside => 10;
        public override bool HurtByLight => true;
        public override int LevelFound => 12;
        public override bool MagicMissile => true;
        public override int Mexp => 50;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 30;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "    Dark    ";
        public override string SplitName2 => "   elven    ";
        public override string SplitName3 => "demonologist";
    }
}