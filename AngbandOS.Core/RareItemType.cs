// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core;
using AngbandOS.Enumerations;
using AngbandOS.StaticData;
using System;

namespace AngbandOS
{
    [Serializable]
    internal class RareItemType
    {
        public readonly FlagSet Flags1 = new FlagSet();
        public readonly FlagSet Flags2 = new FlagSet();
        public readonly FlagSet Flags3 = new FlagSet();
        public readonly ItemCharacteristics RareItemCharacteristics = new ItemCharacteristics();
        public int Cost;
        public int Level;
        public int MaxPval;
        public int MaxToA;
        public int MaxToD;
        public int MaxToH;
        public string Name;
        public int Rarity;
        public int Rating;
        public int Slot;
        public readonly Base2RareItemType BaseRareItemType;

        public RareItemType(Base2RareItemType baseRareItemType)
        {
            BaseRareItemType = baseRareItemType;
            Flags1 = new FlagSet();
            Flags2 = new FlagSet();
            Flags3 = new FlagSet();
            Cost = baseRareItemType.Cost;
            Level = baseRareItemType.Level;
            MaxPval = baseRareItemType.MaxPval;
            MaxToA = baseRareItemType.MaxToA;
            MaxToD = baseRareItemType.MaxToD;
            MaxToH = baseRareItemType.MaxToH;
            Name = baseRareItemType.FriendlyName;
            Rarity = baseRareItemType.Rarity;
            Rating = baseRareItemType.Rating;
            Slot = baseRareItemType.Slot;
            RareItemCharacteristics.Merge(baseRareItemType);
            Flags1.Set(baseRareItemType.Blows ? ItemFlag1.Blows : 0);
            Flags1.Set(baseRareItemType.BrandAcid ? ItemFlag1.BrandAcid : 0);
            Flags1.Set(baseRareItemType.BrandCold ? ItemFlag1.BrandCold : 0);
            Flags1.Set(baseRareItemType.BrandElec ? ItemFlag1.BrandElec : 0);
            Flags1.Set(baseRareItemType.BrandFire ? ItemFlag1.BrandFire : 0);
            Flags1.Set(baseRareItemType.BrandPois ? ItemFlag1.BrandPois : 0);
            Flags1.Set(baseRareItemType.Cha ? ItemFlag1.Cha : 0);
            Flags1.Set(baseRareItemType.Chaotic ? ItemFlag1.Chaotic : 0);
            Flags1.Set(baseRareItemType.Con ? ItemFlag1.Con : 0);
            Flags1.Set(baseRareItemType.Dex ? ItemFlag1.Dex : 0);
            Flags1.Set(baseRareItemType.Impact ? ItemFlag1.Impact : 0);
            Flags1.Set(baseRareItemType.Infra ? ItemFlag1.Infra : 0);
            Flags1.Set(baseRareItemType.Int ? ItemFlag1.Int : 0);
            Flags1.Set(baseRareItemType.KillDragon ? ItemFlag1.KillDragon : 0);
            Flags1.Set(baseRareItemType.Search ? ItemFlag1.Search : 0);
            Flags1.Set(baseRareItemType.SlayAnimal ? ItemFlag1.SlayAnimal : 0);
            Flags1.Set(baseRareItemType.SlayDemon ? ItemFlag1.SlayDemon : 0);
            Flags1.Set(baseRareItemType.SlayDragon ? ItemFlag1.SlayDragon : 0);
            Flags1.Set(baseRareItemType.SlayEvil ? ItemFlag1.SlayEvil : 0);
            Flags1.Set(baseRareItemType.SlayGiant ? ItemFlag1.SlayGiant : 0);
            Flags1.Set(baseRareItemType.SlayOrc ? ItemFlag1.SlayOrc : 0);
            Flags1.Set(baseRareItemType.SlayTroll ? ItemFlag1.SlayTroll : 0);
            Flags1.Set(baseRareItemType.SlayUndead ? ItemFlag1.SlayUndead : 0);
            Flags1.Set(baseRareItemType.Speed ? ItemFlag1.Speed : 0);
            Flags1.Set(baseRareItemType.Stealth ? ItemFlag1.Stealth : 0);
            Flags1.Set(baseRareItemType.Str ? ItemFlag1.Str : 0);
            Flags1.Set(baseRareItemType.Tunnel ? ItemFlag1.Tunnel : 0);
            Flags1.Set(baseRareItemType.Vampiric ? ItemFlag1.Vampiric : 0);
            Flags1.Set(baseRareItemType.Vorpal ? ItemFlag1.Vorpal : 0);
            Flags1.Set(baseRareItemType.Wis ? ItemFlag1.Wis : 0);
            Flags2.Set(baseRareItemType.FreeAct ? ItemFlag2.FreeAct : 0);
            Flags2.Set(baseRareItemType.HoldLife ? ItemFlag2.HoldLife : 0);
            Flags2.Set(baseRareItemType.ImAcid ? ItemFlag2.ImAcid : 0);
            Flags2.Set(baseRareItemType.ImCold ? ItemFlag2.ImCold : 0);
            Flags2.Set(baseRareItemType.ImElec ? ItemFlag2.ImElec : 0);
            Flags2.Set(baseRareItemType.ImFire ? ItemFlag2.ImFire : 0);
            Flags2.Set(baseRareItemType.Reflect ? ItemFlag2.Reflect : 0);
            Flags2.Set(baseRareItemType.ResAcid ? ItemFlag2.ResAcid : 0);
            Flags2.Set(baseRareItemType.ResBlind ? ItemFlag2.ResBlind : 0);
            Flags2.Set(baseRareItemType.ResChaos ? ItemFlag2.ResChaos : 0);
            Flags2.Set(baseRareItemType.ResCold ? ItemFlag2.ResCold : 0);
            Flags2.Set(baseRareItemType.ResConf ? ItemFlag2.ResConf : 0);
            Flags2.Set(baseRareItemType.ResDark ? ItemFlag2.ResDark : 0);
            Flags2.Set(baseRareItemType.ResDisen ? ItemFlag2.ResDisen : 0);
            Flags2.Set(baseRareItemType.ResElec ? ItemFlag2.ResElec : 0);
            Flags2.Set(baseRareItemType.ResFear ? ItemFlag2.ResFear : 0);
            Flags2.Set(baseRareItemType.ResFire ? ItemFlag2.ResFire : 0);
            Flags2.Set(baseRareItemType.ResLight ? ItemFlag2.ResLight : 0);
            Flags2.Set(baseRareItemType.ResNether ? ItemFlag2.ResNether : 0);
            Flags2.Set(baseRareItemType.ResNexus ? ItemFlag2.ResNexus : 0);
            Flags2.Set(baseRareItemType.ResPois ? ItemFlag2.ResPois : 0);
            Flags2.Set(baseRareItemType.ResShards ? ItemFlag2.ResShards : 0);
            Flags2.Set(baseRareItemType.ResSound ? ItemFlag2.ResSound : 0);
            Flags2.Set(baseRareItemType.SustCha ? ItemFlag2.SustCha : 0);
            Flags2.Set(baseRareItemType.SustCon ? ItemFlag2.SustCon : 0);
            Flags2.Set(baseRareItemType.SustDex ? ItemFlag2.SustDex : 0);
            Flags2.Set(baseRareItemType.SustInt ? ItemFlag2.SustInt : 0);
            Flags2.Set(baseRareItemType.SustStr ? ItemFlag2.SustStr : 0);
            Flags2.Set(baseRareItemType.SustWis ? ItemFlag2.SustWis : 0);
            Flags3.Set(baseRareItemType.Activate ? ItemFlag3.Activate : 0);
            Flags3.Set(baseRareItemType.Aggravate ? ItemFlag3.Aggravate : 0);
            Flags3.Set(baseRareItemType.Blessed ? ItemFlag3.Blessed : 0);
            Flags3.Set(baseRareItemType.Cursed ? ItemFlag3.Cursed : 0);
            Flags3.Set(baseRareItemType.DrainExp ? ItemFlag3.DrainExp : 0);
            Flags3.Set(baseRareItemType.DreadCurse ? ItemFlag3.DreadCurse : 0);
            Flags3.Set(baseRareItemType.EasyKnow ? ItemFlag3.EasyKnow : 0);
            Flags3.Set(baseRareItemType.Feather ? ItemFlag3.Feather : 0);
            Flags3.Set(baseRareItemType.HeavyCurse ? ItemFlag3.HeavyCurse : 0);
            Flags3.Set(baseRareItemType.HideType ? ItemFlag3.HideType : 0);
            Flags3.Set(baseRareItemType.IgnoreAcid ? ItemFlag3.IgnoreAcid : 0);
            Flags3.Set(baseRareItemType.IgnoreCold ? ItemFlag3.IgnoreCold : 0);
            Flags3.Set(baseRareItemType.IgnoreElec ? ItemFlag3.IgnoreElec : 0);
            Flags3.Set(baseRareItemType.IgnoreFire ? ItemFlag3.IgnoreFire : 0);
            Flags3.Set(baseRareItemType.InstaArt ? ItemFlag3.InstaArt : 0);
            Flags3.Set(baseRareItemType.Lightsource ? ItemFlag3.Lightsource : 0);
            Flags3.Set(baseRareItemType.NoMagic ? ItemFlag3.NoMagic : 0);
            Flags3.Set(baseRareItemType.NoTele ? ItemFlag3.NoTele : 0);
            Flags3.Set(baseRareItemType.PermaCurse ? ItemFlag3.PermaCurse : 0);
            Flags3.Set(baseRareItemType.Regen ? ItemFlag3.Regen : 0);
            Flags3.Set(baseRareItemType.SeeInvis ? ItemFlag3.SeeInvis : 0);
            Flags3.Set(baseRareItemType.ShElec ? ItemFlag3.ShElec : 0);
            Flags3.Set(baseRareItemType.ShFire ? ItemFlag3.ShFire : 0);
            Flags3.Set(baseRareItemType.ShowMods ? ItemFlag3.ShowMods : 0);
            Flags3.Set(baseRareItemType.SlowDigest ? ItemFlag3.SlowDigest : 0);
            Flags3.Set(baseRareItemType.Telepathy ? ItemFlag3.Telepathy : 0);
            Flags3.Set(baseRareItemType.Teleport ? ItemFlag3.Teleport : 0);
            Flags3.Set(baseRareItemType.Wraith ? ItemFlag3.Wraith : 0);
            Flags3.Set(baseRareItemType.XtraMight ? ItemFlag3.XtraMight : 0);
            Flags3.Set(baseRareItemType.XtraShots ? ItemFlag3.XtraShots : 0);
        }
    }
}