using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class PoltergeistMonsterRace : MonsterRace
    {
        public override char Character => 'G';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Poltergeist";

        public override int ArmourClass => 15;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Touch, new TerrifyAttackEffect(), 0, 0),
        };
        public override bool Blink => true;
        public override bool ColdBlood => true;
        public override string Description => "It is a ghastly, ghostly form.";
        public override bool Drop60 => true;
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override int FreqInate => 16;
        public override int FreqSpell => 16;
        public override string FriendlyName => "Poltergeist";
        public override int Hdice => 2;
        public override int Hside => 5;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 3;
        public override int Mexp => 8;
        public override int NoticeRange => 8;
        public override bool PassWall => true;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "Poltergeist ";
        public override bool TakeItem => true;
        public override bool Undead => true;
    }
}