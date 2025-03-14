import { SoundEffectsEnum } from "../sound-effects-enum/sound-effects-enum.module";

export class SoundEffectsMap {
  public static getSoundEffectsMap(): string[][] {
    const sounds: string[][] = [];
    sounds[SoundEffectsEnum.ActivateArtifact] = ["plm_aim_wand.wav"];
    sounds[SoundEffectsEnum.Bell] = ["plm_jar_ding.wav"];
    sounds[SoundEffectsEnum.BreathWeapon] = ["mco_attack_breath.wav"];
    sounds[SoundEffectsEnum.BumpWall] = ["plm_wood_thud.wav"];
    sounds[SoundEffectsEnum.CastSpell] = ["plm_spell1.wav", "plm_spell2.wav", "plm_spell3.wav"];
    sounds[SoundEffectsEnum.Cursed] = ["pls_man_oooh.wav"];
    sounds[SoundEffectsEnum.DestroyItem] = ["plm_bang_metal.wav", "plm_break_canister.wav", "plm_break_glass.wav", "plm_break_glass2.wav", "plm_break_plates.wav", "plm_break_shatter.wav", "plm_break_smash.wav", "plm_glass_breaking.wav", "plm_glass_break.wav", "plm_glass_smashing.wav"];
    sounds[SoundEffectsEnum.Dig] = ["plm_metal_clank.wav"];
    sounds[SoundEffectsEnum.DisarmTrap] = ["plm_bang_ceramic.wav", "plm_chest_latch.wav", "plm_click_switch3.wav"];
    sounds[SoundEffectsEnum.Drop] = ["plm_drop_boot.wav"];
    sounds[SoundEffectsEnum.Eat] = ["plm_eat_bite.wav"];
    sounds[SoundEffectsEnum.EnterDungeon1] = ["amb_door_iron.wav", "amb_bell_metal1.wav"];
    sounds[SoundEffectsEnum.EnterDungeon2] = ["amb_bell_tibet1.wav", "amb_bell_metal2.wav", "amb_gong_strike.wav"];
    sounds[SoundEffectsEnum.EnterDungeon3] = ["amb_bell_tibet2.wav", "amb_dungeon_echo.wav", "amb_pulse_low.wav"];
    sounds[SoundEffectsEnum.EnterDungeon4] = ["amb_bell_tibet3.wav", "amb_dungeon_echowet.wav", "amb_gong_undertone.wav"];
    sounds[SoundEffectsEnum.EnterDungeon5] = ["amb_door_doom.wav", "amb_gong_chinese.wav", "amb_gong_low.wav"];
    sounds[SoundEffectsEnum.EnterStore] = ["sto_bell_desk.wav", "sto_bell_ding.wav", "sto_bell_dingaling.wav", "sto_bell_jingles.wav", "sto_bell_ringing.wav", "sto_bell_shop.wav"];
    sounds[SoundEffectsEnum.EnterTownDay] = ["amb_thunder_rain.wav"];
    sounds[SoundEffectsEnum.EnterTownNight] = ["amb_guitar_chord.wav", "amb_thunder_roll.wav"];
    sounds[SoundEffectsEnum.FindSecretDoor] = ["id_bad_hmm.wav"];
    sounds[SoundEffectsEnum.HealthWarning] = ["plc_bell_warn.wav"];
    sounds[SoundEffectsEnum.HitGood] = ["plc_hit_anvil.wav"];
    sounds[SoundEffectsEnum.HitGreat] = ["plc_hit_groan.wav"];
    sounds[SoundEffectsEnum.HitHiGreat] = ["plc_hit_grunt.wav"];
    sounds[SoundEffectsEnum.HitHiSuperb] = ["plc_hit_anvil2.wav"];
    sounds[SoundEffectsEnum.HitSuperb] = ["plc_hit_grunt2.wav"];
    sounds[SoundEffectsEnum.Hungry] = ["id_bad_hmm.wav"];
    sounds[SoundEffectsEnum.IdentifyBad] = ["id_bad_hmm.wav"];
    sounds[SoundEffectsEnum.IdentifyGood] = ["id_bad_hmm.wav"];
    sounds[SoundEffectsEnum.IdentifySpecial] = ["id_bad_hmm.wav"];
    sounds[SoundEffectsEnum.LeaveStore] = ["plm_door_bolt.wav"];
    sounds[SoundEffectsEnum.LevelGain] = ["plm_levelup.wav"];
    sounds[SoundEffectsEnum.LockpickFail] = ["plm_click_dry.wav", "plm_click_switch.wav", "plm_click_wood.wav", "plm_door_echolock.wav", "plm_door_wooden.wav"];
    sounds[SoundEffectsEnum.LockpickSuccess] = ["plm_break_wood.wav", "plm_cabinet_open.wav", "plm_chest_unlatch.wav", "plm_lock_case.wav", "plm_lock_distant.wav", "plm_open_case.wav"];
    sounds[SoundEffectsEnum.MeleeHit] = ["plc_hit_hay.wav", "plc_hit_body.wav"];
    sounds[SoundEffectsEnum.Miss] = ["plc_miss_arrow2.wav"];
    sounds[SoundEffectsEnum.MonsterBashes] = ["mco_squish_snap.wav"];
    sounds[SoundEffectsEnum.MonsterBegs] = ["mco_man_mumble.wav"];
    sounds[SoundEffectsEnum.MonsterBites] = ["mco_snarl_short.wav", "mco_bite_soft.wav", "mco_bite_munch.wav", "mco_bite_long.wav", "mco_bite_short.wav", "mco_bite_gnash.wav", "mco_bite_chomp.wav", "mco_bite_regular.wav", "mco_bite_small.wav", "mco_bite_dainty.wav", "mco_bite_hard.wav", "mco_bite_chew.wav"];
    sounds[SoundEffectsEnum.MonsterBreeds] = ["mco_frog_trill.wav"];
    sounds[SoundEffectsEnum.MonsterButts] = ["mco_cuica_rubbing.wav", "mco_thud_crash.wav"];
    sounds[SoundEffectsEnum.MonsterCausesFear] = ["mco_creature_groan.wav", "mco_dino_slur.wav"];
    sounds[SoundEffectsEnum.MonsterClaws] = ["mco_ceramic_trill.wav", "mco_scurry_dry.wav"];
    sounds[SoundEffectsEnum.MonsterCrawls] = ["mco_card_shuffle.wav", "mco_shake_roll.wav"];
    sounds[SoundEffectsEnum.MonsterCreatesTraps] = ["mco_thoing_deep.wav"];
    sounds[SoundEffectsEnum.MonsterCrushes] = ["mco_dino_low.wav", "mco_squish_hit.wav"];
    sounds[SoundEffectsEnum.MonsterDies] = ["mco_howl_croak.wav", "mco_howl_deep.wav", "mco_howl_distressed.wav", "mco_howl_high.wav", "mco_howl_long.wav"];
    sounds[SoundEffectsEnum.MonsterDrools] = ["mco_creature_choking.wav", "mco_liquid_squirt.wav"];
    sounds[SoundEffectsEnum.MonsterEngulfs] = ["mco_dino_talk.wav", "mco_dino_yawn.wav"];
    sounds[SoundEffectsEnum.MonsterFlees] = ["mco_creature_yelp.wav"];
    sounds[SoundEffectsEnum.MonsterGazes] = ["mco_thoing_backwards.wav"];
    sounds[SoundEffectsEnum.MonsterHits] = ["mco_hit_whip.wav"];
    sounds[SoundEffectsEnum.MonsterInsults] = ["mco_strange_thwoink.wav"];
    sounds[SoundEffectsEnum.MonsterKicks] = ["mco_rubber_thud.wav"];
    sounds[SoundEffectsEnum.MonsterMoans] = ["mco_strange_music.wav"];
    sounds[SoundEffectsEnum.MonsterShrieks] = ["mco_mouse_squeaks.wav"];
    sounds[SoundEffectsEnum.MonsterSpits] = ["mco_attack_spray.wav"];
    sounds[SoundEffectsEnum.MonsterSpores] = ["mco_dub_wobble.wav", "mco_spray_long.wav"];
    sounds[SoundEffectsEnum.MonsterStings] = ["mco_castanet_trill.wav", "mco_tube_hit.wav"];
    sounds[SoundEffectsEnum.MonsterTouches] = ["mco_click_vibra.wav"];
    sounds[SoundEffectsEnum.MonsterWails] = ["mco_dino_low.wav"];
    sounds[SoundEffectsEnum.NothingToOpen] = ["plm_click_switch2.wav", "plm_door_knob.wav"];
    sounds[SoundEffectsEnum.OpenDoor] = ["plm_door_bolt.wav", "plm_door_creak.wav", "plm_door_dungeon.wav", "plm_door_entrance.wav", "plm_door_open.wav", "plm_door_opening.wav", "plm_door_rusty.wav", "plm_door_squeaky.wav"];
    sounds[SoundEffectsEnum.PickUpMoney1] = ["plm_coins_light.wav", "plm_coins_shake.wav"];
    sounds[SoundEffectsEnum.PickUpMoney2] = ["plm_chain_light.wav", "plm_coins_pour.wav"];
    sounds[SoundEffectsEnum.PickUpMoney3] = ["plm_coins_dump.wav"];
    sounds[SoundEffectsEnum.PlayerAfraid] = ["pls_man_yell.wav"];
    sounds[SoundEffectsEnum.PlayerBerserk] = ["pls_man_scream2.wav"];
    sounds[SoundEffectsEnum.PlayerBlessed] = ["sum_angel_song.wav"];
    sounds[SoundEffectsEnum.PlayerBlind] = ["pls_tone_conk.wav"];
    sounds[SoundEffectsEnum.Playerconfused] = ["pls_man_ugh.wav"];
    sounds[SoundEffectsEnum.PlayerCut] = ["pls_man_argoh.wav"];
    sounds[SoundEffectsEnum.PlayerDeath] = ["plc_die_laugh.wav"];
    sounds[SoundEffectsEnum.PlayerDrugged] = ["pls_breathe_in.wav"];
    sounds[SoundEffectsEnum.PlayerHaste] = ["pls_bell_sustain.wav"];
    sounds[SoundEffectsEnum.PlayerHeroism] = ["pls_tone_goblet.wav"];
    sounds[SoundEffectsEnum.PlayerInfravision] = ["pls_tone_clavelo8.wav"];
    sounds[SoundEffectsEnum.PlayerInvulnerable] = ["pls_tone_blurk.wav"];
    sounds[SoundEffectsEnum.PlayerParalysed] = ["pls_man_gulp_new.wav"];
    sounds[SoundEffectsEnum.PlayerPoisoned] = ["pls_tone_guiro.wav"];
    sounds[SoundEffectsEnum.PlayerProtEvil] = ["pls_bell_glass.wav"];
    sounds[SoundEffectsEnum.PlayerRecover] = ["pls_bell_chime_new.wav"];
    sounds[SoundEffectsEnum.PlayerResistAcid] = ["pls_man_sniff.wav"];
    sounds[SoundEffectsEnum.PlayerResistCold] = ["pls_tone_stick.wav"];
    sounds[SoundEffectsEnum.PlayerResistElectric] = ["pls_tone_elec.wav"];
    sounds[SoundEffectsEnum.PlayerResistFire] = ["pls_tone_scrape.wav"];
    sounds[SoundEffectsEnum.PlayerResistPoison] = ["pls_man_spit.wav"];
    sounds[SoundEffectsEnum.PlayerSeeInvisible] = ["pls_tone_clave6.wav"];
    sounds[SoundEffectsEnum.PlayerShield] = ["pls_bell_bowl.wav"];
    sounds[SoundEffectsEnum.PlayerSlow] = ["pls_man_sigh.wav"];
    sounds[SoundEffectsEnum.PlayerStatDrain] = ["pls_tone_headstock.wav"];
    sounds[SoundEffectsEnum.Pray] = ["sum_angel_song.wav"];
    sounds[SoundEffectsEnum.PseudoId] = ["id_good_hmm.wav"];
    sounds[SoundEffectsEnum.Quaff] = ["plm_bottle_clinks.wav", "plm_cork_pop.wav", "plm_cork_squeak.wav"];
    sounds[SoundEffectsEnum.QuestMonsterDies] = ["amb_guitar_chord.wav"];
    sounds[SoundEffectsEnum.RangedHit] = ["plc_hit_arrow.wav"];
    sounds[SoundEffectsEnum.Shoot] = ["plc_miss_swish.wav", "plc_miss_arrow.wav"];
    sounds[SoundEffectsEnum.ShutDoor] = ["plm_bang_dumpster.wav", "plm_cabinet_shut.wav", "plm_close_hatch.wav", "plm_door_creakshut.wav", "plm_door_latch.wav", "plm_door_shut.wav", "plm_door_slam.wav"];
    sounds[SoundEffectsEnum.StairsDown] = ["plm_floor_creak.wav"];
    sounds[SoundEffectsEnum.StairsUp] = ["plm_floor_creak2.wav"];
    sounds[SoundEffectsEnum.StoreSoldBargain] = ["id_bad_dang.wav"];
    sounds[SoundEffectsEnum.StoreSoldCheaply] = ["sto_man_haha.wav"];
    sounds[SoundEffectsEnum.StoreSoldExtraCheaply] = ["sto_man_whoohaha.wav"];
    sounds[SoundEffectsEnum.StoreSoldWorthless] = ["sto_man_hey.wav"];
    sounds[SoundEffectsEnum.StoreTransaction] = ["sto_coins_countertop.wav", "sto_bell_register1.wav", "sto_bell_register2.wav"];
    sounds[SoundEffectsEnum.Study] = ["plm_book_pageturn.wav"];
    sounds[SoundEffectsEnum.SummonAngel] = ["sum_angel_song.wav"];
    sounds[SoundEffectsEnum.SummonAnimals] = ["sum_lion_growl.wav"];
    sounds[SoundEffectsEnum.SummonDemons] = ["sum_ghost_wail.wav", "sum_laugh_evil2.wav"];
    sounds[SoundEffectsEnum.SummonDragons] = ["sum_piano_scrape.wav"];
    sounds[SoundEffectsEnum.SummonGreaterDemons] = ["sum_ghost_moan.wav"];
    sounds[SoundEffectsEnum.SummonGreaterDragons] = ["sum_gong_temple.wav"];
    sounds[SoundEffectsEnum.SummonGreaterUndead] = ["sum_ghost_moan.wav"];
    sounds[SoundEffectsEnum.SummonHounds] = ["sum_lion_growl.wav"];
    sounds[SoundEffectsEnum.SummonHydras] = ["sum_piano_scrape.wav"];
    sounds[SoundEffectsEnum.SummonMonster] = ["sum_chime_jangle.wav"];
    sounds[SoundEffectsEnum.SummonRingwraiths] = ["sum_bell_hand.wav"];
    sounds[SoundEffectsEnum.SummonSpiders] = ["sum_piano_scrape.wav"];
    sounds[SoundEffectsEnum.SummonUndead] = ["sum_ghost_oooo.wav"];
    sounds[SoundEffectsEnum.SummonUniques] = ["sum_bell_tone.wav"];
    sounds[SoundEffectsEnum.Teleport] = ["plm_chimes_jangle.wav"];
    sounds[SoundEffectsEnum.TeleportLevel] = ["sum_bell_crystal.wav"];
    sounds[SoundEffectsEnum.UniqueDies] = ["sum_ghost_wail.wav"];
    sounds[SoundEffectsEnum.UseStaff] = ["plm_use_staff.wav"];
    sounds[SoundEffectsEnum.WieldWeapon] = ["plm_metal_sharpen.wav"];
    sounds[SoundEffectsEnum.ZapRod] = ["plm_zap_rod.wav"];
    return sounds;
  }
}
