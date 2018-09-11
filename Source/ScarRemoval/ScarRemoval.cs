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
    public class ScarRemoval : Mod
    {
        public static ScarRemovalSettings settings;
        public ScarRemoval(ModContentPack content) : base(content)
        {
            settings = GetSettings<ScarRemovalSettings>();
        }

        public override string SettingsCategory() => "ScarRemovalSettings".Translate();

        public override void DoSettingsWindowContents(Rect inRect)
        {
            checked
            {
                Listing_Standard listing_Standard = new Listing_Standard();
                listing_Standard.Begin(inRect);
                listing_Standard.CheckboxLabeled("ScarRemovalSettingsHardMode".Translate(), ref ScarRemovalSettings.hardMode, ("ScarRemovalSettingsHardModeTooltip".Translate()));
                listing_Standard.End();
                settings.Write();
            }
        }
        public override void WriteSettings()
        {
            base.WriteSettings();
            ScarRemoval_Constructor.ApplySettings();
        }
    }
}
