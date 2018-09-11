using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using RimWorld;
using Verse;
using Verse.AI;
using System.Reflection;

namespace SyrScarRemoval
{
    public class ScarRemovalSettings : ModSettings
    {
        public static bool hardMode;
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look<bool>(ref hardMode, "ScarRemoval_hardMode", true, true);
        }
    }
}
