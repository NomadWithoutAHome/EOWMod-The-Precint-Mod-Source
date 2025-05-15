using HarmonyLib;
using Il2Cpp;
using Il2CppFallenTreeGames.CharacterController;
using UnityEngine;

namespace EOWMod
{
    [HarmonyPatch(typeof(CharacterMotor))]
    [HarmonyPatch("TakeDamage_CheckForUnauthorisedActionsByPlayer")]
    public class CharacterMotorPatch
    {
        public static bool Prefix(Damage damage, bool invincibleToThisDamage)
        {
            // Skip unauthorized action checks for player damage to civilians
            return false;
        }
    }

    [HarmonyPatch(typeof(AuthorisationManager))]
    [HarmonyPatch("IsAllRammingAcceptableForAuthorisationLevel")]
    public class AuthorisationManagerPatch
    {
        public static bool Prefix(AuthorisationManager.AuthorisationLevel authorisationLevel, out float acceptableDamageIfNot)
        {
            // Always return true and set acceptable damage to max
            acceptableDamageIfNot = float.MaxValue;
            return true;
        }
    }

    [HarmonyPatch(typeof(DamageManager))]
    [HarmonyPatch("Awake")]
    public class DamageManagerPatch
    {
        public static void Postfix(DamageManager __instance)
        {
            // Set the civilian damage multiplier field directly
            __instance._playerVehiclehittingCivilianDamageMultiplier = 1.0f;
        }
    }

    [HarmonyPatch(typeof(AuthorisationWarningPanel))]
    [HarmonyPatch("ShowWarning")]
    public class AuthorisationWarningPanelPatch
    {
        public static bool Prefix(AuthorisationWarningPanel.WarningType warningType)
        {
            // Skip showing any authorization warnings
            return false;
        }
    }

    [HarmonyPatch(typeof(UnauthorisedActionTracker))]
    [HarmonyPatch("AddUnauthorisedAction")]
    public class UnauthorisedActionTrackerPatch
    {
        public static bool Prefix(UnauthorisedActionTracker.ActionType actionType)
        {
            // Skip tracking any unauthorized actions
            return false;
        }
    }
} 