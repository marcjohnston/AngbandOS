using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class AvatarOfNyarlathotepMonsterRace : MonsterRace
    {
        protected AvatarOfNyarlathotepMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'p';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Avatar of Nyarlathotep";

        public override int ArmourClass => 70;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 5, 5),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 5, 5),
        };
        public override bool BashDoor => true;
        public override bool Cthuloid => true;
        public override string Description => "The Crawling Chaos with 1000 forms. Nyarlathotep is amused at yourpuny attempts to kill him, and will keep coming back for another go, until he gets bored with the game.";
        public override bool EldritchHorror => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Avatar of Nyarlathotep";
        public override int Hdice => 25;
        public override int Hside => 25;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 45;
        public override bool Male => true;
        public override int Mexp => 500;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override bool Shapechanger => true;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "   Avatar   ";
        public override string SplitName2 => "     of     ";
        public override string SplitName3 => "Nyarlathotep";
    }
}
