using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class AzogKingOfTheUrukHaiMonsterRace : MonsterRace
    {
        public override char Character => 'o';
        public override Colour Colour => Colour.Red;
        public override string Name => "Azog, King of the Uruk-Hai";

        public override int ArmourClass => 80;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 5, 5),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 5, 5),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 5, 5),
        };
        public override bool BashDoor => true;
        public override string Description => "He is also known as the King of Khazad-dum. His ego is renowned to be bigger than his head.";
        public override bool Drop_2D2 => true;
        public override bool DropGood => true;
        public override bool Escorted => true;
        public override bool EscortsGroup => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Azog, King of the Uruk-Hai";
        public override int Hdice => 90;
        public override int Hside => 10;
        public override bool ImmunePoison => true;
        public override int LevelFound => 23;
        public override bool Male => true;
        public override int Mexp => 1111;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Orc => true;
        public override int Rarity => 5;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "    Azog    ";
        public override bool Unique => true;
    }
}
