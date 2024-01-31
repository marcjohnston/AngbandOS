// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.JsonModels;

/// <summary>
/// 
/// </summary>
/// <remarks>
/// 102 Properties
/// </remarks>
internal class JsonMonsterRace : IJsonModel<MonsterRaceDefinition>
{
    public virtual string? Key { get; set; }
    public virtual string[]? SpellNames { get; set; } = null;
    public virtual string? SymbolName { get; set; }
    public virtual ColorEnum? Color { get; set; } = ColorEnum.White;
    public virtual string? Name { get; set; }
    public virtual bool? Animal { get; set; } = false;
    public virtual int? ArmorClass { get; set; }
    public virtual MonsterAttackDefinition[]? AttackDefinitions { get; set; } = null;
    public virtual bool? AttrAny { get; set; } = false;
    public virtual bool? AttrClear { get; set; } = false;
    public virtual bool? AttrMulti { get; set; } = false;
    public virtual bool? BashDoor { get; set; } = false;
    public virtual bool? CharClear { get; set; } = false;
    public virtual bool? CharMulti { get; set; } = false;
    public virtual bool? ColdBlood { get; set; } = false;
    public virtual bool? Cthuloid { get; set; } = false;
    public virtual bool? Demon { get; set; } = false;
    public virtual string? Description { get; set; }
    public virtual bool? Dragon { get; set; } = false;
    public virtual bool? Drop_1D2 { get; set; } = false;
    public virtual bool? Drop_2D2 { get; set; } = false;
    public virtual bool? Drop_3D2 { get; set; } = false;
    public virtual bool? Drop_4D2 { get; set; } = false;
    public virtual bool? Drop60 { get; set; } = false;
    public virtual bool? Drop90 { get; set; } = false;
    public virtual bool? DropGood { get; set; } = false;
    public virtual bool? DropGreat { get; set; } = false;
    public virtual bool? EldritchHorror { get; set; } = false;
    public virtual bool? EmptyMind { get; set; } = false;
    public virtual bool? Escorted { get; set; } = false;
    public virtual bool? EscortsGroup { get; set; } = false;
    public virtual bool? Evil { get; set; } = false;
    public virtual bool? Female { get; set; } = false;
    public virtual bool? FireAura { get; set; } = false;
    public virtual bool? ForceMaxHp { get; set; } = false;
    public virtual bool? ForceSleep { get; set; } = false;
    public virtual int? FreqInate { get; set; }
    public virtual int? FreqSpell { get; set; }
    public virtual string? FriendlyName { get; set; }
    public virtual bool? Friends { get; set; } = false;
    public virtual bool? Giant { get; set; } = false;
    public virtual bool? Good { get; set; } = false;
    public virtual bool? GreatOldOne { get; set; } = false;
    public virtual int? Hdice { get; set; }
    public virtual int? Hside { get; set; }
    public virtual bool? HurtByCold { get; set; } = false;
    public virtual bool? HurtByFire { get; set; } = false;
    public virtual bool? HurtByLight { get; set; } = false;
    public virtual bool? HurtByRock { get; set; } = false;
    public virtual bool? ImmuneAcid { get; set; } = false;
    public virtual bool? ImmuneCold { get; set; } = false;
    public virtual bool? ImmuneConfusion { get; set; } = false;
    public virtual bool? ImmuneFear { get; set; } = false;
    public virtual bool? ImmuneFire { get; set; } = false;
    public virtual bool? ImmuneLightning { get; set; } = false;
    public virtual bool? ImmunePoison { get; set; } = false;
    public virtual bool? ImmuneSleep { get; set; } = false;
    public virtual bool? ImmuneStun { get; set; } = false;
    public virtual bool? Invisible { get; set; } = false;
    public virtual bool? KillBody { get; set; } = false;
    public virtual bool? KillItem { get; set; } = false;
    public virtual bool? KillWall { get; set; } = false;
    public virtual int? LevelFound { get; set; }
    public virtual bool? LightningAura { get; set; } = false;
    public virtual bool? Male { get; set; } = false;
    public virtual int? Mexp { get; set; }
    public virtual bool? MoveBody { get; set; } = false;
    public virtual bool? Multiply { get; set; } = false;
    public virtual bool? NeverAttack { get; set; } = false;
    public virtual bool? NeverMove { get; set; } = false;
    public virtual bool? Nonliving { get; set; } = false;
    public virtual int? NoticeRange { get; set; }
    public virtual bool? OnlyDropGold { get; set; } = false;
    public virtual bool? OnlyDropItem { get; set; } = false;
    public virtual bool? OpenDoor { get; set; } = false;
    public virtual bool? Orc { get; set; } = false;
    public virtual bool? PassWall { get; set; } = false;
    public virtual bool? Powerful { get; set; } = false;
    public virtual bool? RandomMove25 { get; set; } = false;
    public virtual bool? RandomMove50 { get; set; } = false;
    public virtual int? Rarity { get; set; }
    public virtual bool? Reflecting { get; set; } = false;
    public virtual bool? Regenerate { get; set; } = false;
    public virtual bool? ResistDisenchant { get; set; } = false;
    public virtual bool? ResistNether { get; set; } = false;
    public virtual bool? ResistNexus { get; set; } = false;
    public virtual bool? ResistPlasma { get; set; } = false;
    public virtual bool? ResistTeleport { get; set; } = false;
    public virtual bool? ResistWater { get; set; } = false;
    public virtual bool? Shapechanger { get; set; } = false;
    public virtual int? Sleep { get; set; }
    public virtual bool? Smart { get; set; } = false;
    public virtual int? Speed { get; set; }
    public virtual string? SplitName1 { get; set; }
    public virtual string? SplitName2 { get; set; }
    public virtual string? SplitName3 { get; set; }
    public virtual bool? Stupid { get; set; } = false;
    public virtual bool? TakeItem { get; set; } = false;
    public virtual bool? Troll { get; set; } = false;
    public virtual bool? Undead { get; set; } = false;
    public virtual bool? Unique { get; set; } = false;
    public virtual bool? WeirdMind { get; set; } = false;
    public MonsterRaceDefinition? ToDefinition()
    {
        // 100 Properties Required
        if (Key == null || 
            SymbolName == null || 
            Color == null || 
            Name == null || 
            Animal == null || 
            ArmorClass == null ||  
            AttrAny == null || 
            AttrClear == null || 
            AttrMulti == null || 
            BashDoor == null || 
            CharClear == null ||  
            CharMulti == null || 
            ColdBlood == null || 
            Cthuloid == null || 
            Demon == null || 
            Description == null || 
            Dragon == null || 
            Drop_1D2 == null || 
            Drop_2D2 == null || 
            Drop_3D2 == null || 
            Drop_4D2 == null || 
            Drop60 == null || 
            Drop90 == null || 
            DropGood == null || 
            DropGreat == null || 
            EldritchHorror == null || 
            EmptyMind == null || 
            Escorted == null || 
            EscortsGroup == null || 
            Evil == null || 
            Female == null || 
            FireAura == null ||  
            ForceMaxHp == null || 
            ForceSleep == null || 
            FreqInate == null || 
            FreqSpell == null || 
            FriendlyName == null || 
            Friends == null || 
            Giant == null || 
            Good == null || 
            GreatOldOne == null || 
            Hdice == null || 
            Hside == null ||  
            HurtByCold == null || 
            HurtByFire == null || 
            HurtByLight == null || 
            HurtByRock == null || 
            ImmuneAcid == null || 
            ImmuneCold == null || 
            ImmuneConfusion == null || 
            ImmuneFear == null || 
            ImmuneFire == null || 
            ImmuneLightning == null || 
            ImmunePoison == null || 
            ImmuneSleep == null || 
            ImmuneStun == null ||
            Invisible == null || 
            KillBody == null || 
            KillItem == null || 
            KillWall == null || 
            LevelFound == null ||
            LightningAura == null || 
            Male == null || 
            Mexp == null || 
            MoveBody == null || 
            Multiply == null || 
            NeverAttack == null || 
            NeverMove == null || 
            Nonliving == null || 
            NoticeRange == null || 
            OnlyDropGold == null ||
            OnlyDropItem == null || 
            OpenDoor == null || 
            Orc == null ||
            PassWall == null || 
            Powerful == null ||
            RandomMove25 == null || 
            RandomMove50 == null || 
            Rarity == null || 
            Reflecting == null || 
            Regenerate == null || 
            ResistDisenchant == null || 
            ResistNether == null || 
            ResistNexus == null || 
            ResistPlasma == null || 
            ResistTeleport == null || 
            ResistWater == null || 
            Shapechanger == null || 
            Sleep == null || 
            Smart == null || 
            Speed == null || 
            SplitName1 == null || 
            SplitName2 == null || 
            SplitName3 == null ||
            Stupid == null || 
            TakeItem == null || 
            Troll == null || 
            Undead == null || 
            Unique == null || 
            WeirdMind == null)
            return null;
        return new MonsterRaceDefinition()
        { // 102 Properties
            Key = Key,
            SpellNames = SpellNames,
            SymbolName = SymbolName,
            Color = Color.Value,
            Name = Name,
            Animal = Animal.Value,
            ArmorClass = ArmorClass.Value,
            AttackDefinitions = AttackDefinitions,
            AttrAny = AttrAny.Value,
            AttrClear = AttrClear.Value,
            AttrMulti = AttrMulti.Value,
            BashDoor = BashDoor.Value,
            CharClear = CharClear.Value,
            CharMulti = CharMulti.Value,
            ColdBlood = ColdBlood.Value,
            Cthuloid = Cthuloid.Value,
            Demon = Demon.Value,
            Description = Description,
            Dragon = Dragon.Value,
            Drop_1D2 = Drop_1D2.Value,
            Drop_2D2 = Drop_2D2.Value,
            Drop_3D2 = Drop_3D2.Value,
            Drop_4D2 = Drop_4D2.Value,
            Drop60 = Drop60.Value,
            Drop90 = Drop90.Value,
            DropGood = DropGood.Value,
            DropGreat = DropGreat.Value,
            EldritchHorror = EldritchHorror.Value,
            EmptyMind = EmptyMind.Value,
            Escorted = Escorted.Value,
            EscortsGroup = EscortsGroup.Value,
            Evil = Evil.Value,
            Female = Female.Value,
            FireAura = FireAura.Value,
            ForceMaxHp = ForceMaxHp.Value,
            ForceSleep = ForceSleep.Value,
            FreqInate = FreqInate.Value,
            FreqSpell = FreqSpell.Value,
            FriendlyName = FriendlyName,
            Friends = Friends.Value,
            Giant = Giant.Value,
            Good = Good.Value,
            GreatOldOne = GreatOldOne.Value,
            Hdice = Hdice.Value,
            Hside = Hside.Value,
            HurtByCold = HurtByCold.Value,
            HurtByFire = HurtByFire.Value,
            HurtByLight = HurtByLight.Value,
            HurtByRock = HurtByRock.Value,
            ImmuneAcid = ImmuneAcid.Value,
            ImmuneCold = ImmuneCold.Value,
            ImmuneConfusion = ImmuneConfusion.Value,
            ImmuneFear = ImmuneFear.Value,
            ImmuneFire = ImmuneFire.Value,
            ImmuneLightning = ImmuneLightning.Value,
            ImmunePoison = ImmunePoison.Value,
            ImmuneSleep = ImmuneSleep.Value,
            ImmuneStun = ImmuneStun.Value,
            Invisible = Invisible.Value,
            KillBody = KillBody.Value,
            KillItem = KillItem.Value,
            KillWall = KillWall.Value,
            LevelFound = LevelFound.Value,
            LightningAura = LightningAura.Value,
            Male = Male.Value,
            Mexp = Mexp.Value,
            MoveBody = MoveBody.Value,
            Multiply = Multiply.Value,
            NeverAttack = NeverAttack.Value,
            NeverMove = NeverMove.Value,
            Nonliving = Nonliving.Value,
            NoticeRange = NoticeRange.Value,
            OnlyDropGold = OnlyDropGold.Value,
            OnlyDropItem = OnlyDropItem.Value,
            OpenDoor = OpenDoor.Value,
            Orc = Orc.Value,
            PassWall = PassWall.Value,
            Powerful = Powerful.Value,
            RandomMove25 = RandomMove25.Value,
            RandomMove50 = RandomMove50.Value,
            Rarity = Rarity.Value,
            Reflecting = Reflecting.Value,
            Regenerate = Regenerate.Value,
            ResistDisenchant = ResistDisenchant.Value,
            ResistNether = ResistNether.Value,
            ResistNexus = ResistNexus.Value,
            ResistPlasma = ResistPlasma.Value,
            ResistTeleport = ResistTeleport.Value,
            ResistWater = ResistWater.Value,
            Shapechanger = Shapechanger.Value,
            Sleep = Sleep.Value,
            Smart = Smart.Value,
            Speed = Speed.Value,
            SplitName1 = SplitName1,
            SplitName2 = SplitName2,
            SplitName3 = SplitName3,
            Stupid = Stupid.Value,
            TakeItem = TakeItem.Value,
            Troll = Troll.Value,
            Undead = Undead.Value,
            Unique = Unique.Value,
            WeirdMind = WeirdMind.Value
        };
    }
}