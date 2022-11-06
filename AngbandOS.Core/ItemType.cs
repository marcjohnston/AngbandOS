// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;
using System;

namespace AngbandOS
{
    /// <summary>
    /// Represents different variations (ItemType) of item categories (ItemCategory).  E.g. different types of food that belong to the food category.  Several of the
    /// properties are modifyable.
    /// </summary>
    [Serializable]
    internal class ItemType
    {
        /// <summary>
        /// The group of flags (Flags1, Flags2 and Flags3) return a flags based value for numerous properties of the item categories.
        /// </summary>
        public readonly FlagSet Flags1 = new FlagSet();

        /// <summary>
        /// The group of flags (Flags1, Flags2 and Flags3) return a flags based value for numerous properties of the item categories.
        /// </summary>
        public readonly FlagSet Flags2 = new FlagSet();

        /// <summary>
        /// The group of flags (Flags1, Flags2 and Flags3) return a flags based value for numerous properties of the item categories.
        /// </summary>
        public readonly FlagSet Flags3 = new FlagSet();

        /// <summary>
        /// Deprecated.  This ItemType object will be refactored into the BaseItemCategory object.
        /// Returns the readonly scaffolded base item type.
        /// </summary>
        public BaseItemCategory BaseItemCategory;

        public ItemType(BaseItemCategory baseItemCategory)
        {
            BaseItemCategory = baseItemCategory; // Instantiate the ItemCategory that this ItemType is based from.

            Flags1.Set(baseItemCategory.Blows ? ItemFlag1.Blows : 0);
            Flags1.Set(baseItemCategory.BrandAcid ? ItemFlag1.BrandAcid : 0);
            Flags1.Set(baseItemCategory.BrandCold ? ItemFlag1.BrandCold : 0);
            Flags1.Set(baseItemCategory.BrandElec ? ItemFlag1.BrandElec : 0);
            Flags1.Set(baseItemCategory.BrandFire ? ItemFlag1.BrandFire : 0);
            Flags1.Set(baseItemCategory.BrandPois ? ItemFlag1.BrandPois : 0);
            Flags1.Set(baseItemCategory.Cha ? ItemFlag1.Cha : 0);
            Flags1.Set(baseItemCategory.Chaotic ? ItemFlag1.Chaotic : 0);
            Flags1.Set(baseItemCategory.Con ? ItemFlag1.Con : 0);
            Flags1.Set(baseItemCategory.Dex ? ItemFlag1.Dex : 0);
            Flags1.Set(baseItemCategory.Impact ? ItemFlag1.Impact : 0);
            Flags1.Set(baseItemCategory.Infra ? ItemFlag1.Infra : 0);
            Flags1.Set(baseItemCategory.Int ? ItemFlag1.Int : 0);
            Flags1.Set(baseItemCategory.KillDragon ? ItemFlag1.KillDragon : 0);
            Flags1.Set(baseItemCategory.Search ? ItemFlag1.Search : 0);
            Flags1.Set(baseItemCategory.SlayAnimal ? ItemFlag1.SlayAnimal : 0);
            Flags1.Set(baseItemCategory.SlayDemon ? ItemFlag1.SlayDemon : 0);
            Flags1.Set(baseItemCategory.SlayDragon ? ItemFlag1.SlayDragon : 0);
            Flags1.Set(baseItemCategory.SlayEvil ? ItemFlag1.SlayEvil : 0);
            Flags1.Set(baseItemCategory.SlayGiant ? ItemFlag1.SlayGiant : 0);
            Flags1.Set(baseItemCategory.SlayOrc ? ItemFlag1.SlayOrc : 0);
            Flags1.Set(baseItemCategory.SlayTroll ? ItemFlag1.SlayTroll : 0);
            Flags1.Set(baseItemCategory.SlayUndead ? ItemFlag1.SlayUndead : 0);
            Flags1.Set(baseItemCategory.Speed ? ItemFlag1.Speed : 0);
            Flags1.Set(baseItemCategory.Stealth ? ItemFlag1.Stealth : 0);
            Flags1.Set(baseItemCategory.Str ? ItemFlag1.Str : 0);
            Flags1.Set(baseItemCategory.Tunnel ? ItemFlag1.Tunnel : 0);
            Flags1.Set(baseItemCategory.Vampiric ? ItemFlag1.Vampiric : 0);
            Flags1.Set(baseItemCategory.Vorpal ? ItemFlag1.Vorpal : 0);
            Flags1.Set(baseItemCategory.Wis ? ItemFlag1.Wis : 0);
            Flags2.Set(baseItemCategory.FreeAct ? ItemFlag2.FreeAct : 0);
            Flags2.Set(baseItemCategory.HoldLife ? ItemFlag2.HoldLife : 0);
            Flags2.Set(baseItemCategory.ImAcid ? ItemFlag2.ImAcid : 0);
            Flags2.Set(baseItemCategory.ImCold ? ItemFlag2.ImCold : 0);
            Flags2.Set(baseItemCategory.ImElec ? ItemFlag2.ImElec : 0);
            Flags2.Set(baseItemCategory.ImFire ? ItemFlag2.ImFire : 0);
            Flags2.Set(baseItemCategory.Reflect ? ItemFlag2.Reflect : 0);
            Flags2.Set(baseItemCategory.ResAcid ? ItemFlag2.ResAcid : 0);
            Flags2.Set(baseItemCategory.ResBlind ? ItemFlag2.ResBlind : 0);
            Flags2.Set(baseItemCategory.ResChaos ? ItemFlag2.ResChaos : 0);
            Flags2.Set(baseItemCategory.ResCold ? ItemFlag2.ResCold : 0);
            Flags2.Set(baseItemCategory.ResConf ? ItemFlag2.ResConf : 0);
            Flags2.Set(baseItemCategory.ResDark ? ItemFlag2.ResDark : 0);
            Flags2.Set(baseItemCategory.ResDisen ? ItemFlag2.ResDisen : 0);
            Flags2.Set(baseItemCategory.ResElec ? ItemFlag2.ResElec : 0);
            Flags2.Set(baseItemCategory.ResFear ? ItemFlag2.ResFear : 0);
            Flags2.Set(baseItemCategory.ResFire ? ItemFlag2.ResFire : 0);
            Flags2.Set(baseItemCategory.ResLight ? ItemFlag2.ResLight : 0);
            Flags2.Set(baseItemCategory.ResNether ? ItemFlag2.ResNether : 0);
            Flags2.Set(baseItemCategory.ResNexus ? ItemFlag2.ResNexus : 0);
            Flags2.Set(baseItemCategory.ResPois ? ItemFlag2.ResPois : 0);
            Flags2.Set(baseItemCategory.ResShards ? ItemFlag2.ResShards : 0);
            Flags2.Set(baseItemCategory.ResSound ? ItemFlag2.ResSound : 0);
            Flags2.Set(baseItemCategory.SustCha ? ItemFlag2.SustCha : 0);
            Flags2.Set(baseItemCategory.SustCon ? ItemFlag2.SustCon : 0);
            Flags2.Set(baseItemCategory.SustDex ? ItemFlag2.SustDex : 0);
            Flags2.Set(baseItemCategory.SustInt ? ItemFlag2.SustInt : 0);
            Flags2.Set(baseItemCategory.SustStr ? ItemFlag2.SustStr : 0);
            Flags2.Set(baseItemCategory.SustWis ? ItemFlag2.SustWis : 0);
            Flags3.Set(baseItemCategory.AntiTheft ? ItemFlag3.AntiTheft : 0);
            Flags3.Set(baseItemCategory.Activate ? ItemFlag3.Activate : 0);
            Flags3.Set(baseItemCategory.Aggravate ? ItemFlag3.Aggravate : 0);
            Flags3.Set(baseItemCategory.Blessed ? ItemFlag3.Blessed : 0);
            Flags3.Set(baseItemCategory.Cursed ? ItemFlag3.Cursed : 0);
            Flags3.Set(baseItemCategory.DrainExp ? ItemFlag3.DrainExp : 0);
            Flags3.Set(baseItemCategory.DreadCurse ? ItemFlag3.DreadCurse : 0);
            Flags3.Set(baseItemCategory.EasyKnow ? ItemFlag3.EasyKnow : 0);
            Flags3.Set(baseItemCategory.Feather ? ItemFlag3.Feather : 0);
            Flags3.Set(baseItemCategory.HeavyCurse ? ItemFlag3.HeavyCurse : 0);
            Flags3.Set(baseItemCategory.HideType ? ItemFlag3.HideType : 0);
            Flags3.Set(baseItemCategory.IgnoreAcid ? ItemFlag3.IgnoreAcid : 0);
            Flags3.Set(baseItemCategory.IgnoreCold ? ItemFlag3.IgnoreCold : 0);
            Flags3.Set(baseItemCategory.IgnoreElec ? ItemFlag3.IgnoreElec : 0);
            Flags3.Set(baseItemCategory.IgnoreFire ? ItemFlag3.IgnoreFire : 0);
            Flags3.Set(baseItemCategory.InstaArt ? ItemFlag3.InstaArt : 0);
            Flags3.Set(baseItemCategory.Lightsource ? ItemFlag3.Lightsource : 0);
            Flags3.Set(baseItemCategory.NoMagic ? ItemFlag3.NoMagic : 0);
            Flags3.Set(baseItemCategory.NoTele ? ItemFlag3.NoTele : 0);
            Flags3.Set(baseItemCategory.PermaCurse ? ItemFlag3.PermaCurse : 0);
            Flags3.Set(baseItemCategory.Regen ? ItemFlag3.Regen : 0);
            Flags3.Set(baseItemCategory.SeeInvis ? ItemFlag3.SeeInvis : 0);
            Flags3.Set(baseItemCategory.ShElec ? ItemFlag3.ShElec : 0);
            Flags3.Set(baseItemCategory.ShFire ? ItemFlag3.ShFire : 0);
            Flags3.Set(baseItemCategory.ShowMods ? ItemFlag3.ShowMods : 0);
            Flags3.Set(baseItemCategory.SlowDigest ? ItemFlag3.SlowDigest : 0);
            Flags3.Set(baseItemCategory.Telepathy ? ItemFlag3.Telepathy : 0);
            Flags3.Set(baseItemCategory.Teleport ? ItemFlag3.Teleport : 0);
            Flags3.Set(baseItemCategory.Wraith ? ItemFlag3.Wraith : 0);
            Flags3.Set(baseItemCategory.XtraMight ? ItemFlag3.XtraMight : 0);
            Flags3.Set(baseItemCategory.XtraShots ? ItemFlag3.XtraShots : 0);
        }
    }
}