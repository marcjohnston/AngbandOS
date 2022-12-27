using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class BloodshotEyeMonsterRace : MonsterRace
    {
        protected BloodshotEyeMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new DrainManaMonsterSpell());
        public override char Character => 'e';
        public override Colour Colour => Colour.Red;
        public override string Name => "Bloodshot eye";

        public override int ArmourClass => 6;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new GazeAttackType(), new BlindAttackEffect(), 2, 6),
        };
        public override string Description => "A disembodied eye, bloodshot and nasty.";
        public override int FreqInate => 7;
        public override int FreqSpell => 7;
        public override string FriendlyName => "Bloodshot eye";
        public override int Hdice => 5;
        public override int Hside => 8;
        public override bool HurtByLight => true;
        public override bool ImmuneFear => true;
        public override int LevelFound => 7;
        public override int Mexp => 15;
        public override bool NeverMove => true;
        public override int NoticeRange => 2;
        public override int Rarity => 3;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => " Bloodshot  ";
        public override string SplitName3 => "    eye     ";
    }
}
