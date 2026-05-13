// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class MonsterCharacteristics : IMonsterCharacteristics, IGameSerialize
{
    public MonsterCharacteristics()
    {
        AttrClear = false;
        AttrMulti = false;
        CharClear = false;
        CharMulti = false;
        Drop_1D2 = false;
        Drop_2D2 = false;
        Drop_3D2 = false;
        Drop_4D2 = false;
        Drop60 = false;
        Drop90 = false;
        DropGood = false;
        DropGreat = false;
        Escorted = false;
        EscortsGroup = false;
        Female = false;
        ForceMaxHp = false;
        ForceSleep = false;
        Friends = false;
        Male = false;
        NeverAttack = false;
        NeverMove = false;
        OnlyDropGold = false;
        OnlyDropItem = false;
        RandomMove25 = false;
        RandomMove50 = false;
        Unique = false;

        AttrAny = false;
        BashDoor = false;
        ColdBlood = false;
        EldritchHorror = false;
        EmptyMind = false;
        FireAura = false;
        Invisible = false;
        KillBody = false;
        KillItem = false;
        KillWall = false;
        LightningAura = false;
        MoveBody = false;
        Multiply = false;
        OpenDoor = false;
        PassWall = false;
        Powerful = false;
        Reflecting = false;
        Regenerate = false;
        Shapechanger = false;
        Smart = false;
        Stupid = false;
        TakeItem = false;
        WeirdMind = false;

        Animal = false;
        Cthuloid = false;
        Demon = false;
        Dragon = false;
        Evil = false;
        Giant = false;
        Good = false;
        GreatOldOne = false;
        HurtByCold = false;
        HurtByFire = false;
        HurtByLight = false;
        HurtByRock = false;
        ImmuneAcid = false;
        ImmuneCold = false;
        ImmuneConfusion = false;
        ImmuneFear = false;
        ImmuneFire = false;
        ImmuneLightning = false;
        ImmunePoison = false;
        ImmuneSleep = false;
        ImmuneStun = false;
        Nonliving = false;
        Orc = false;
        ResistDisenchant = false;
        ResistNether = false;
        ResistNexus = false;
        ResistPlasma = false;
        ResistTeleport = false;
        ResistWater = false;
        Troll = false;
        Undead = false;
    }
    public MonsterCharacteristics(Game game, RestoreGameState restoreGameState)
    {
        AttrClear = restoreGameState.GetByKey(nameof(AttrClear)).GetBool();
        AttrMulti = restoreGameState.GetByKey(nameof(AttrMulti)).GetBool();
        CharClear = restoreGameState.GetByKey(nameof(CharClear)).GetBool();
        CharMulti = restoreGameState.GetByKey(nameof(CharMulti)).GetBool();
        Drop_1D2 = restoreGameState.GetByKey(nameof(Drop_1D2)).GetBool();
        Drop_2D2 = restoreGameState.GetByKey(nameof(Drop_2D2)).GetBool();
        Drop_3D2 = restoreGameState.GetByKey(nameof(Drop_3D2)).GetBool();
        Drop_4D2 = restoreGameState.GetByKey(nameof(Drop_4D2)).GetBool();
        Drop60 = restoreGameState.GetByKey(nameof(Drop60)).GetBool();
        Drop90 = restoreGameState.GetByKey(nameof(Drop90)).GetBool();
        DropGood = restoreGameState.GetByKey(nameof(DropGood)).GetBool();
        DropGreat = restoreGameState.GetByKey(nameof(DropGreat)).GetBool();
        Escorted = restoreGameState.GetByKey(nameof(Escorted)).GetBool();
        EscortsGroup = restoreGameState.GetByKey(nameof(EscortsGroup)).GetBool();
        Female = restoreGameState.GetByKey(nameof(Female)).GetBool();
        ForceMaxHp = restoreGameState.GetByKey(nameof(ForceMaxHp)).GetBool();
        ForceSleep = restoreGameState.GetByKey(nameof(ForceSleep)).GetBool();
        Friends = restoreGameState.GetByKey(nameof(Friends)).GetBool();
        Male = restoreGameState.GetByKey(nameof(Male)).GetBool();
        NeverAttack = restoreGameState.GetByKey(nameof(NeverAttack)).GetBool();
        NeverMove = restoreGameState.GetByKey(nameof(NeverMove)).GetBool();
        OnlyDropGold = restoreGameState.GetByKey(nameof(OnlyDropGold)).GetBool();
        OnlyDropItem = restoreGameState.GetByKey(nameof(OnlyDropItem)).GetBool();
        RandomMove25 = restoreGameState.GetByKey(nameof(RandomMove25)).GetBool();
        RandomMove50 = restoreGameState.GetByKey(nameof(RandomMove50)).GetBool();
        Unique = restoreGameState.GetByKey(nameof(Unique)).GetBool();
        AttrAny = restoreGameState.GetByKey(nameof(AttrAny)).GetBool();
        BashDoor = restoreGameState.GetByKey(nameof(BashDoor)).GetBool();
        ColdBlood = restoreGameState.GetByKey(nameof(ColdBlood)).GetBool();
        EldritchHorror = restoreGameState.GetByKey(nameof(EldritchHorror)).GetBool();
        EmptyMind = restoreGameState.GetByKey(nameof(EmptyMind)).GetBool();
        FireAura = restoreGameState.GetByKey(nameof(FireAura)).GetBool();
        Invisible = restoreGameState.GetByKey(nameof(Invisible)).GetBool();
        KillBody = restoreGameState.GetByKey(nameof(KillBody)).GetBool();
        KillItem = restoreGameState.GetByKey(nameof(KillItem)).GetBool();
        KillWall = restoreGameState.GetByKey(nameof(KillWall)).GetBool();
        LightningAura = restoreGameState.GetByKey(nameof(LightningAura)).GetBool();
        MoveBody = restoreGameState.GetByKey(nameof(MoveBody)).GetBool();
        Multiply = restoreGameState.GetByKey(nameof(Multiply)).GetBool();
        OpenDoor = restoreGameState.GetByKey(nameof(OpenDoor)).GetBool();
        PassWall = restoreGameState.GetByKey(nameof(PassWall)).GetBool();
        Powerful = restoreGameState.GetByKey(nameof(Powerful)).GetBool();
        Reflecting = restoreGameState.GetByKey(nameof(Reflecting)).GetBool();
        Regenerate = restoreGameState.GetByKey(nameof(Regenerate)).GetBool();
        Shapechanger = restoreGameState.GetByKey(nameof(Shapechanger)).GetBool();
        Smart = restoreGameState.GetByKey(nameof(Smart)).GetBool();
        Stupid = restoreGameState.GetByKey(nameof(Stupid)).GetBool();
        TakeItem = restoreGameState.GetByKey(nameof(TakeItem)).GetBool();
        WeirdMind = restoreGameState.GetByKey(nameof(WeirdMind)).GetBool();
        Animal = restoreGameState.GetByKey(nameof(Animal)).GetBool();
        Cthuloid = restoreGameState.GetByKey(nameof(Cthuloid)).GetBool();
        Demon = restoreGameState.GetByKey(nameof(Demon)).GetBool();
        Dragon = restoreGameState.GetByKey(nameof(Dragon)).GetBool();
        Evil = restoreGameState.GetByKey(nameof(Evil)).GetBool();
        Giant = restoreGameState.GetByKey(nameof(Giant)).GetBool();
        Good = restoreGameState.GetByKey(nameof(Good)).GetBool();
        GreatOldOne = restoreGameState.GetByKey(nameof(GreatOldOne)).GetBool();
        HurtByCold = restoreGameState.GetByKey(nameof(HurtByCold)).GetBool();
        HurtByFire = restoreGameState.GetByKey(nameof(HurtByFire)).GetBool();
        HurtByLight = restoreGameState.GetByKey(nameof(HurtByLight)).GetBool();
        HurtByRock = restoreGameState.GetByKey(nameof(HurtByRock)).GetBool();
        ImmuneAcid = restoreGameState.GetByKey(nameof(ImmuneAcid)).GetBool();
        ImmuneCold = restoreGameState.GetByKey(nameof(ImmuneCold)).GetBool();
        ImmuneConfusion = restoreGameState.GetByKey(nameof(ImmuneConfusion)).GetBool();
        ImmuneFear = restoreGameState.GetByKey(nameof(ImmuneFear)).GetBool();
        ImmuneFire = restoreGameState.GetByKey(nameof(ImmuneFire)).GetBool();
        ImmuneLightning = restoreGameState.GetByKey(nameof(ImmuneLightning)).GetBool();
        ImmunePoison = restoreGameState.GetByKey(nameof(ImmunePoison)).GetBool();
        ImmuneSleep = restoreGameState.GetByKey(nameof(ImmuneSleep)).GetBool();
        ImmuneStun = restoreGameState.GetByKey(nameof(ImmuneStun)).GetBool();
        Nonliving = restoreGameState.GetByKey(nameof(Nonliving)).GetBool();
        Orc = restoreGameState.GetByKey(nameof(Orc)).GetBool();
        ResistDisenchant = restoreGameState.GetByKey(nameof(ResistDisenchant)).GetBool();
        ResistNether = restoreGameState.GetByKey(nameof(ResistNether)).GetBool();
        ResistNexus = restoreGameState.GetByKey(nameof(ResistNexus)).GetBool();
        ResistPlasma = restoreGameState.GetByKey(nameof(ResistPlasma)).GetBool();
        ResistTeleport = restoreGameState.GetByKey(nameof(ResistTeleport)).GetBool();
        ResistWater = restoreGameState.GetByKey(nameof(ResistWater)).GetBool();
        Troll = restoreGameState.GetByKey(nameof(Troll)).GetBool();
        Undead = restoreGameState.GetByKey(nameof(Undead)).GetBool();
    }

    public MonsterCharacteristics(IMonsterCharacteristics copyFrom)
    {
        AttrClear = copyFrom.AttrClear;
        AttrMulti = copyFrom.AttrMulti;
        CharClear = copyFrom.CharClear;
        CharMulti = copyFrom.CharMulti;
        Drop_1D2 = copyFrom.Drop_1D2;
        Drop_2D2 = copyFrom.Drop_2D2;
        Drop_3D2 = copyFrom.Drop_3D2;
        Drop_4D2 = copyFrom.Drop_4D2;
        Drop60 = copyFrom.Drop60;
        Drop90 = copyFrom.Drop90;
        DropGood = copyFrom.DropGood;
        DropGreat = copyFrom.DropGreat;
        Escorted = copyFrom.Escorted;
        EscortsGroup = copyFrom.EscortsGroup;
        Female = copyFrom.Female;
        ForceMaxHp = copyFrom.ForceMaxHp;
        ForceSleep = copyFrom.ForceSleep;
        Friends = copyFrom.Friends;
        Male = copyFrom.Male;
        NeverAttack = copyFrom.NeverAttack;
        NeverMove = copyFrom.NeverMove;
        OnlyDropGold = copyFrom.OnlyDropGold;
        OnlyDropItem = copyFrom.OnlyDropItem;
        RandomMove25 = copyFrom.RandomMove25;
        RandomMove50 = copyFrom.RandomMove50;
        Unique = copyFrom.Unique;
        AttrAny = copyFrom.AttrAny;
        BashDoor = copyFrom.BashDoor;
        ColdBlood = copyFrom.ColdBlood;
        EldritchHorror = copyFrom.EldritchHorror;
        EmptyMind = copyFrom.EmptyMind;
        FireAura = copyFrom.FireAura;
        Invisible = copyFrom.Invisible;
        KillBody = copyFrom.KillBody;
        KillItem = copyFrom.KillItem;
        KillWall = copyFrom.KillWall;
        LightningAura = copyFrom.LightningAura;
        MoveBody = copyFrom.MoveBody;
        Multiply = copyFrom.Multiply;
        OpenDoor = copyFrom.OpenDoor;
        PassWall = copyFrom.PassWall;
        Powerful = copyFrom.Powerful;
        Reflecting = copyFrom.Reflecting;
        Regenerate = copyFrom.Regenerate;
        Shapechanger = copyFrom.Shapechanger;
        Smart = copyFrom.Smart;
        Stupid = copyFrom.Stupid;
        TakeItem = copyFrom.TakeItem;
        WeirdMind = copyFrom.WeirdMind;
        Animal = copyFrom.Animal;
        Cthuloid = copyFrom.Cthuloid;
        Demon = copyFrom.Demon;
        Dragon = copyFrom.Dragon;
        Evil = copyFrom.Evil;
        Giant = copyFrom.Giant;
        Good = copyFrom.Good;
        GreatOldOne = copyFrom.GreatOldOne;
        HurtByCold = copyFrom.HurtByCold;
        HurtByFire = copyFrom.HurtByFire;
        HurtByLight = copyFrom.HurtByLight;
        HurtByRock = copyFrom.HurtByRock;
        ImmuneAcid = copyFrom.ImmuneAcid;
        ImmuneCold = copyFrom.ImmuneCold;
        ImmuneConfusion = copyFrom.ImmuneConfusion;
        ImmuneFear = copyFrom.ImmuneFear;
        ImmuneFire = copyFrom.ImmuneFire;
        ImmuneLightning = copyFrom.ImmuneLightning;
        ImmunePoison = copyFrom.ImmunePoison;
        ImmuneSleep = copyFrom.ImmuneSleep;
        ImmuneStun = copyFrom.ImmuneStun;
        Nonliving = copyFrom.Nonliving;
        Orc = copyFrom.Orc;
        ResistDisenchant = copyFrom.ResistDisenchant;
        ResistNether = copyFrom.ResistNether;
        ResistNexus = copyFrom.ResistNexus;
        ResistPlasma = copyFrom.ResistPlasma;
        ResistTeleport = copyFrom.ResistTeleport;
        ResistWater = copyFrom.ResistWater;
        Troll = copyFrom.Troll;
        Undead = copyFrom.Undead;
    }

    public GameStateBag? Serialize(SaveGameState saveGameState)
    {
        return new DictionaryGameStateBag(
            (nameof(AttrClear), saveGameState.CreateGameStateBag(AttrClear)),
            (nameof(AttrMulti), saveGameState.CreateGameStateBag(AttrMulti)),
            (nameof(CharClear), saveGameState.CreateGameStateBag(CharClear)),
            (nameof(CharMulti), saveGameState.CreateGameStateBag(CharMulti)),
            (nameof(Drop_1D2), saveGameState.CreateGameStateBag(Drop_1D2)),
            (nameof(Drop_2D2), saveGameState.CreateGameStateBag(Drop_2D2)),
            (nameof(Drop_3D2), saveGameState.CreateGameStateBag(Drop_3D2)),
            (nameof(Drop_4D2), saveGameState.CreateGameStateBag(Drop_4D2)),
            (nameof(Drop60), saveGameState.CreateGameStateBag(Drop60)),
            (nameof(Drop90), saveGameState.CreateGameStateBag(Drop90)),
            (nameof(DropGood), saveGameState.CreateGameStateBag(DropGood)),
            (nameof(DropGreat), saveGameState.CreateGameStateBag(DropGreat)),
            (nameof(Escorted), saveGameState.CreateGameStateBag(Escorted)),
            (nameof(EscortsGroup), saveGameState.CreateGameStateBag(EscortsGroup)),
            (nameof(Female), saveGameState.CreateGameStateBag(Female)),
            (nameof(ForceMaxHp), saveGameState.CreateGameStateBag(ForceMaxHp)),
            (nameof(ForceSleep), saveGameState.CreateGameStateBag(ForceSleep)),
            (nameof(Friends), saveGameState.CreateGameStateBag(Friends)),
            (nameof(Male), saveGameState.CreateGameStateBag(Male)),
            (nameof(NeverAttack), saveGameState.CreateGameStateBag(NeverAttack)),
            (nameof(NeverMove), saveGameState.CreateGameStateBag(NeverMove)),
            (nameof(OnlyDropGold), saveGameState.CreateGameStateBag(OnlyDropGold)),
            (nameof(OnlyDropItem), saveGameState.CreateGameStateBag(OnlyDropItem)),
            (nameof(RandomMove25), saveGameState.CreateGameStateBag(RandomMove25)),
            (nameof(RandomMove50), saveGameState.CreateGameStateBag(RandomMove50)),
            (nameof(Unique), saveGameState.CreateGameStateBag(Unique)),
            (nameof(AttrAny), saveGameState.CreateGameStateBag(AttrAny)),
            (nameof(BashDoor), saveGameState.CreateGameStateBag(BashDoor)),
            (nameof(ColdBlood), saveGameState.CreateGameStateBag(ColdBlood)),
            (nameof(EldritchHorror), saveGameState.CreateGameStateBag(EldritchHorror)),
            (nameof(EmptyMind), saveGameState.CreateGameStateBag(EmptyMind)),
            (nameof(FireAura), saveGameState.CreateGameStateBag(FireAura)),
            (nameof(Invisible), saveGameState.CreateGameStateBag(Invisible)),
            (nameof(KillBody), saveGameState.CreateGameStateBag(KillBody)),
            (nameof(KillItem), saveGameState.CreateGameStateBag(KillItem)),
            (nameof(KillWall), saveGameState.CreateGameStateBag(KillWall)),
            (nameof(LightningAura), saveGameState.CreateGameStateBag(LightningAura)),
            (nameof(MoveBody), saveGameState.CreateGameStateBag(MoveBody)),
            (nameof(Multiply), saveGameState.CreateGameStateBag(Multiply)),
            (nameof(OpenDoor), saveGameState.CreateGameStateBag(OpenDoor)),
            (nameof(PassWall), saveGameState.CreateGameStateBag(PassWall)),
            (nameof(Powerful), saveGameState.CreateGameStateBag(Powerful)),
            (nameof(Reflecting), saveGameState.CreateGameStateBag(Reflecting)),
            (nameof(Regenerate), saveGameState.CreateGameStateBag(Regenerate)),
            (nameof(Shapechanger), saveGameState.CreateGameStateBag(Shapechanger)),
            (nameof(Smart), saveGameState.CreateGameStateBag(Smart)),
            (nameof(Stupid), saveGameState.CreateGameStateBag(Stupid)),
            (nameof(TakeItem), saveGameState.CreateGameStateBag(TakeItem)),
            (nameof(WeirdMind), saveGameState.CreateGameStateBag(WeirdMind)),
            (nameof(Animal), saveGameState.CreateGameStateBag(Animal)),
            (nameof(Cthuloid), saveGameState.CreateGameStateBag(Cthuloid)),
            (nameof(Demon), saveGameState.CreateGameStateBag(Demon)),
            (nameof(Dragon), saveGameState.CreateGameStateBag(Dragon)),
            (nameof(Evil), saveGameState.CreateGameStateBag(Evil)),
            (nameof(Giant), saveGameState.CreateGameStateBag(Giant)),
            (nameof(Good), saveGameState.CreateGameStateBag(Good)),
            (nameof(GreatOldOne), saveGameState.CreateGameStateBag(GreatOldOne)),
            (nameof(HurtByCold), saveGameState.CreateGameStateBag(HurtByCold)),
            (nameof(HurtByFire), saveGameState.CreateGameStateBag(HurtByFire)),
            (nameof(HurtByLight), saveGameState.CreateGameStateBag(HurtByLight)),
            (nameof(HurtByRock), saveGameState.CreateGameStateBag(HurtByRock)),
            (nameof(ImmuneAcid), saveGameState.CreateGameStateBag(ImmuneAcid)),
            (nameof(ImmuneCold), saveGameState.CreateGameStateBag(ImmuneCold)),
            (nameof(ImmuneConfusion), saveGameState.CreateGameStateBag(ImmuneConfusion)),
            (nameof(ImmuneFear), saveGameState.CreateGameStateBag(ImmuneFear)),
            (nameof(ImmuneFire), saveGameState.CreateGameStateBag(ImmuneFire)),
            (nameof(ImmuneLightning), saveGameState.CreateGameStateBag(ImmuneLightning)),
            (nameof(ImmunePoison), saveGameState.CreateGameStateBag(ImmunePoison)),
            (nameof(ImmuneSleep), saveGameState.CreateGameStateBag(ImmuneSleep)),
            (nameof(ImmuneStun), saveGameState.CreateGameStateBag(ImmuneStun)),
            (nameof(Nonliving), saveGameState.CreateGameStateBag(Nonliving)),
            (nameof(Orc), saveGameState.CreateGameStateBag(Orc)),
            (nameof(ResistDisenchant), saveGameState.CreateGameStateBag(ResistDisenchant)),
            (nameof(ResistNether), saveGameState.CreateGameStateBag(ResistNether)),
            (nameof(ResistNexus), saveGameState.CreateGameStateBag(ResistNexus)),
            (nameof(ResistPlasma), saveGameState.CreateGameStateBag(ResistPlasma)),
            (nameof(ResistTeleport), saveGameState.CreateGameStateBag(ResistTeleport)),
            (nameof(ResistWater), saveGameState.CreateGameStateBag(ResistWater)),
            (nameof(Troll), saveGameState.CreateGameStateBag(Troll)),
            (nameof(Undead), saveGameState.CreateGameStateBag(Undead))
        );
    }

    public MonsterCharacteristics(IMonsterCharacteristics copyFrom, IMonsterCharacteristics unionWith)
    {
        AttrClear = copyFrom.AttrClear & unionWith.AttrClear;
        AttrMulti = copyFrom.AttrMulti & unionWith.AttrMulti;
        CharClear = copyFrom.CharClear & unionWith.CharClear;
        CharMulti = copyFrom.CharMulti & unionWith.CharMulti;
        Drop_1D2 = copyFrom.Drop_1D2 & unionWith.Drop_1D2;
        Drop_2D2 = copyFrom.Drop_2D2 & unionWith.Drop_2D2;
        Drop_3D2 = copyFrom.Drop_3D2 & unionWith.Drop_3D2;
        Drop_4D2 = copyFrom.Drop_4D2 & unionWith.Drop_4D2;
        Drop60 = copyFrom.Drop60 & unionWith.Drop60;
        Drop90 = copyFrom.Drop90 & unionWith.Drop90;
        DropGood = copyFrom.DropGood & unionWith.DropGood;
        DropGreat = copyFrom.DropGreat & unionWith.DropGreat;
        Escorted = copyFrom.Escorted & unionWith.Escorted;
        EscortsGroup = copyFrom.EscortsGroup & unionWith.EscortsGroup;
        Female = copyFrom.Female & unionWith.Female;
        ForceMaxHp = copyFrom.ForceMaxHp & unionWith.ForceMaxHp;
        ForceSleep = copyFrom.ForceSleep & unionWith.ForceSleep;
        Friends = copyFrom.Friends & unionWith.Friends;
        Male = copyFrom.Male & unionWith.Male;
        NeverAttack = copyFrom.NeverAttack & unionWith.NeverAttack;
        NeverMove = copyFrom.NeverMove & unionWith.NeverMove;
        OnlyDropGold = copyFrom.OnlyDropGold & unionWith.OnlyDropGold;
        OnlyDropItem = copyFrom.OnlyDropItem & unionWith.OnlyDropItem;
        RandomMove25 = copyFrom.RandomMove25 & unionWith.RandomMove25;
        RandomMove50 = copyFrom.RandomMove50 & unionWith.RandomMove50;
        Unique = copyFrom.Unique & unionWith.Unique;
        AttrAny = copyFrom.AttrAny & unionWith.AttrAny;
        BashDoor = copyFrom.BashDoor & unionWith.BashDoor;
        ColdBlood = copyFrom.ColdBlood & unionWith.ColdBlood;
        EldritchHorror = copyFrom.EldritchHorror & unionWith.EldritchHorror;
        EmptyMind = copyFrom.EmptyMind & unionWith.EmptyMind;
        FireAura = copyFrom.FireAura & unionWith.FireAura;
        Invisible = copyFrom.Invisible & unionWith.Invisible;
        KillBody = copyFrom.KillBody & unionWith.KillBody;
        KillItem = copyFrom.KillItem & unionWith.KillItem;
        KillWall = copyFrom.KillWall & unionWith.KillWall;
        LightningAura = copyFrom.LightningAura & unionWith.LightningAura;
        MoveBody = copyFrom.MoveBody & unionWith.MoveBody;
        Multiply = copyFrom.Multiply & unionWith.Multiply;
        OpenDoor = copyFrom.OpenDoor & unionWith.OpenDoor;
        PassWall = copyFrom.PassWall & unionWith.PassWall;
        Powerful = copyFrom.Powerful & unionWith.Powerful;
        Reflecting = copyFrom.Reflecting & unionWith.Reflecting;
        Regenerate = copyFrom.Regenerate & unionWith.Regenerate;
        Shapechanger = copyFrom.Shapechanger & unionWith.Shapechanger;
        Smart = copyFrom.Smart & unionWith.Smart;
        Stupid = copyFrom.Stupid & unionWith.Stupid;
        TakeItem = copyFrom.TakeItem & unionWith.TakeItem;
        WeirdMind = copyFrom.WeirdMind & unionWith.WeirdMind;
        Animal = copyFrom.Animal & unionWith.Animal;
        Cthuloid = copyFrom.Cthuloid & unionWith.Cthuloid;
        Demon = copyFrom.Demon & unionWith.Demon;
        Dragon = copyFrom.Dragon & unionWith.Dragon;
        Evil = copyFrom.Evil & unionWith.Evil;
        Giant = copyFrom.Giant & unionWith.Giant;
        Good = copyFrom.Good & unionWith.Good;
        GreatOldOne = copyFrom.GreatOldOne & unionWith.GreatOldOne;
        HurtByCold = copyFrom.HurtByCold & unionWith.HurtByCold;
        HurtByFire = copyFrom.HurtByFire & unionWith.HurtByFire;
        HurtByLight = copyFrom.HurtByLight & unionWith.HurtByLight;
        HurtByRock = copyFrom.HurtByRock & unionWith.HurtByRock;
        ImmuneAcid = copyFrom.ImmuneAcid & unionWith.ImmuneAcid;
        ImmuneCold = copyFrom.ImmuneCold & unionWith.ImmuneCold;
        ImmuneConfusion = copyFrom.ImmuneConfusion & unionWith.ImmuneConfusion;
        ImmuneFear = copyFrom.ImmuneFear & unionWith.ImmuneFear;
        ImmuneFire = copyFrom.ImmuneFire & unionWith.ImmuneFire;
        ImmuneLightning = copyFrom.ImmuneLightning & unionWith.ImmuneLightning;
        ImmunePoison = copyFrom.ImmunePoison & unionWith.ImmunePoison;
        ImmuneSleep = copyFrom.ImmuneSleep & unionWith.ImmuneSleep;
        ImmuneStun = copyFrom.ImmuneStun & unionWith.ImmuneStun;
        Nonliving = copyFrom.Nonliving & unionWith.Nonliving;
        Orc = copyFrom.Orc & unionWith.Orc;
        ResistDisenchant = copyFrom.ResistDisenchant & unionWith.ResistDisenchant;
        ResistNether = copyFrom.ResistNether & unionWith.ResistNether;
        ResistNexus = copyFrom.ResistNexus & unionWith.ResistNexus;
        ResistPlasma = copyFrom.ResistPlasma & unionWith.ResistPlasma;
        ResistTeleport = copyFrom.ResistTeleport & unionWith.ResistTeleport;
        ResistWater = copyFrom.ResistWater & unionWith.ResistWater;
        Troll = copyFrom.Troll & unionWith.Troll;
        Undead = copyFrom.Undead & unionWith.Undead;
    }

    public bool AttrClear { get; set; }
    public bool AttrMulti { get; set; }
    public bool CharClear { get; set; }
    public bool CharMulti { get; set; }
    public bool Drop_1D2 { get; set; }
    public bool Drop_2D2 { get; set; }
    public bool Drop_3D2 { get; set; }
    public bool Drop_4D2 { get; set; }
    public bool Drop60 { get; set; }
    public bool Drop90 { get; set; }
    public bool DropGood { get; set; }
    public bool DropGreat { get; set; }
    public bool Escorted { get; set; }
    public bool EscortsGroup { get; set; }
    public bool Female { get; set; }
    public bool ForceMaxHp { get; set; }
    public bool ForceSleep { get; set; }
    public bool Friends { get; set; }
    public bool Male { get; set; }
    public bool NeverAttack { get; set; }
    public bool NeverMove { get; set; }
    public bool OnlyDropGold { get; set; }
    public bool OnlyDropItem { get; set; }
    public bool RandomMove25 { get; set; }
    public bool RandomMove50 { get; set; }
    public bool Unique { get; set; }

    public bool AttrAny { get; set; }
    public bool BashDoor { get; set; }
    public bool ColdBlood { get; set; }
    public bool EldritchHorror { get; set; }
    public bool EmptyMind { get; set; }
    public bool FireAura { get; set; }
    public bool Invisible { get; set; }
    public bool KillBody { get; set; }
    public bool KillItem { get; set; }
    public bool KillWall { get; set; }
    public bool LightningAura { get; set; }
    public bool MoveBody { get; set; }
    public bool Multiply { get; set; }
    public bool OpenDoor { get; set; }
    public bool PassWall { get; set; }
    public bool Powerful { get; set; }
    public bool Reflecting { get; set; }
    public bool Regenerate { get; set; }
    public bool Shapechanger { get; set; }
    public bool Smart { get; set; }
    public bool Stupid { get; set; }
    public bool TakeItem { get; set; }
    public bool WeirdMind { get; set; }

    public bool Animal { get; set; }
    public bool Cthuloid { get; set; }
    public bool Demon { get; set; }
    public bool Dragon { get; set; }
    public bool Evil { get; set; }
    public bool Giant { get; set; }
    public bool Good { get; set; }
    public bool GreatOldOne { get; set; }
    public bool HurtByCold { get; set; }
    public bool HurtByFire { get; set; }
    public bool HurtByLight { get; set; }
    public bool HurtByRock { get; set; }
    public bool ImmuneAcid { get; set; }
    public bool ImmuneCold { get; set; }
    public bool ImmuneConfusion { get; set; }
    public bool ImmuneFear { get; set; }
    public bool ImmuneFire { get; set; }
    public bool ImmuneLightning { get; set; }
    public bool ImmunePoison { get; set; }
    public bool ImmuneSleep { get; set; }
    public bool ImmuneStun { get; set; }
    public bool Nonliving { get; set; }
    public bool Orc { get; set; }
    public bool ResistDisenchant { get; set; }
    public bool ResistNether { get; set; }
    public bool ResistNexus { get; set; }
    public bool ResistPlasma { get; set; }
    public bool ResistTeleport { get; set; }
    public bool ResistWater { get; set; }
    public bool Troll { get; set; }
    public bool Undead { get; set; }
}
