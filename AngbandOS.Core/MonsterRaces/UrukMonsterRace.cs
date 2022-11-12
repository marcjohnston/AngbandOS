using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class UrukMonsterRace : MonsterRace
    {
        public override char Character => 'o';
        public override string Name => "Uruk";

        public override int ArmourClass => 50;
        public override bool Arrow1D6 => true;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 5),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 5),
        };
        public override bool BashDoor => true;
        public override string Description => "He is a cunning orc of power, as tall as a man, and stronger. He fears little.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 12;
        public override int FreqSpell => 12;
        public override string FriendlyName => "Uruk";
        public override bool Friends => true;
        public override int Hdice => 8;
        public override int Hside => 10;
        public override bool ImmunePoison => true;
        public override int LevelFound => 18;
        public override bool Male => true;
        public override int Mexp => 68;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override bool Orc => true;
        public override int Rarity => 1;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "    Uruk    ";
    }
}
