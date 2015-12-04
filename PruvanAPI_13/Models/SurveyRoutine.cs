using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration;
using System.Data.SqlClient;

namespace PruvanAPI_13.Models
{
    public class SurveyRoutine
    {
        public SurveyRoutine() { }
        public int workorderId { get; set; }
        public string isComplete { get; set; }
        public DateTime vendorCompletedOn { get; set; }
        public string inspectorFirstName { get; set; }
        public string inspectorLastName { get; set; }
        public string inspectionType { get; set; }
        public DateTime inspectionOn { get; set; }
        public DateTime lastInspectionOn { get; set; }
        public char hasAnyHazard { get; set; }
        public int score { get; set; }
        public char canValidate { get; set; }
        public char isVacant { get; set; }
        public string externalInspectionNo { get; set; }
        public DateTime externalDueDate { get; set; }
        public char hasRequiredSigns { get; set; }
        public char isGarageSecured { get; set; }
        public char isPoolSecured { get; set; }
        public char hasGoodLockbox { get; set; }
        public string lockboxLoc { get; set; }
        public char isLawnCut { get; set; }
        public string lawnProblemLoc { get; set; }
        public char isProperlyBoarded { get; set; }
        public string boardedLoc { get; set; }
        public char hasBrokenWindows { get; set; }
        public string brokenWindowLoc { get; set; }
        public char hasBrokenDoors { get; set; }
        public string brokenDoorsLoc { get; set; }
        public char hasDoorWindowsSecured { get; set; }
        public string notSecuredLoc { get; set; }
        public char isHazardFree { get; set; }
        public string hazardLoc { get; set; }
        public char hasExtVandalism { get; set; }
        public string extVandalismLoc { get; set; }
        public char isExtStructureOk { get; set; }
        public string extStructureLoc { get; set; }
        public char isExtRoofOk { get; set; }
        public string extRoofLoc { get; set; }
        public char isExtPaintOk { get; set; }
        public string extPaintLoc { get; set; }
        public char hasSignInSheet { get; set; }
        public char isWinterizationOk { get; set; }
        public char isBroomSwept { get; set; }
        public char doesSignInHaveInspection { get; set; }
        public string missingInspComment { get; set; }
        public char needEmergencyRepair { get; set; }
        public string emergencyRepairLoc { get; set; }
        public char isHvacHeatOk { get; set; }
        public char isElecOk { get; set; }
        public char doesPlumbLeak { get; set; }
        public string plumbLeakLoc { get; set; }
        public char hasIntVandalism { get; set; }
        public string intVandalismLoc { get; set; }
        public char isIntPaintOk { get; set; }
        public string intPaintLoc { get; set; }
        public char hasRoofLeak { get; set; }
        public string intRoofLeakLoc { get; set; }
        public char isFloodDamaged { get; set; }
        public string floodDamageLoc { get; set; }
        public char areKitchenBathOk { get; set; }
        public string kitchenBathLoc { get; set; }
        public char isIntStructureOk { get; set; }
        public string intStructureLoc { get; set; }
        public char areAnyUtilitiesOn { get; set; }
        public string utilitiesLoc { get; set; }
        public char hasCondemableDefect { get; set; }
        public string condemableDefectLoc { get; set; }
        public char hasTripHazard { get; set; }
        public string tripHazardLoc { get; set; }
        public char hasExposedWire { get; set; }
        public string exposedWireLoc { get; set; }
        public char hasBadStairRailing { get; set; }
        public string badStairRailingLoc { get; set; }
        public char hasElectricHazard { get; set; }
        public string electricHazardLoc { get; set; }
        public char hasDefectiveSteps { get; set; }
        public string defectiveStepsLoc { get; set; }
        public char hasToxicGasOdor { get; set; }
        public string toxicGasLoc { get; set; }
        public char hasUnsecuredAbovePool { get; set; }
        public string unsecuredAbovePoolLoc { get; set; }
        public char shouldAbovePoolBeRemoved { get; set; }
        public char hasUnsecuredInGroundPool { get; set; }
        public string unsecuredInGroundPoolLoc { get; set; }
        public char hasMissingDeckRailing { get; set; }
        public string deckRailingLoc { get; set; }
        public char hasOtherHazards { get; set; }
        public string otherHazardsLoc { get; set; }
        public string generalComments { get; set; }
        public Guid createdBy { get; set; }
        public DateTime createdOn { get; set; }
        public Guid updatedBy { get; set; }
        public DateTime updatedOn { get; set; }
        public Guid deactivatedBy { get; set; }
        public DateTime deactivatedOn { get; set; }
        public SurveyRoutine getSurveyOject(string text)
        {
            int StartIndex = text.IndexOf('{');
            string test2 = text.Substring(StartIndex);
            int EndIndex = test2.LastIndexOf('}');
            EndIndex++;
            string test3 = test2.Substring(0, EndIndex);
            SurveyRoutine s = JsonConvert.DeserializeObject<SurveyRoutine>(test3);
            return s;
        }
        public void SaveRoutine(SurveyRoutine Rountine, Guid UserID, int WorkorderId)
        {
            DataManager dm = new DataManager(ConfigurationManager.ConnectionStrings["REAMSViewDev"].ConnectionString);
            List<SqlParameter> parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("WorkorderId", WorkorderId));
            parms.Add(new SqlParameter("IsComplete", Rountine.isComplete));
            parms.Add(new SqlParameter("VendorCompletedOn", Rountine.vendorCompletedOn));
            parms.Add(new SqlParameter("InspectorFirstName", Rountine.inspectorFirstName));
            parms.Add(new SqlParameter("InspectorLastName", Rountine.inspectorLastName));
            parms.Add(new SqlParameter("InspectionType", Rountine.inspectionType));
            parms.Add(new SqlParameter("InspectionOn", Rountine.inspectionOn));
            parms.Add(new SqlParameter("LastInspectionOn", Rountine.lastInspectionOn));
            parms.Add(new SqlParameter("HasAnyHazard", Rountine.hasAnyHazard));
            parms.Add(new SqlParameter("Score", Rountine.score));
            parms.Add(new SqlParameter("CanValidate", Rountine.canValidate));
            parms.Add(new SqlParameter("IsVacant", Rountine.isVacant));
            parms.Add(new SqlParameter("ExternalInspectionNo", Rountine.externalInspectionNo));
            parms.Add(new SqlParameter("ExternalDueDate", Rountine.externalDueDate));
            parms.Add(new SqlParameter("HasRequiredSigns", Rountine.hasRequiredSigns));
            parms.Add(new SqlParameter("IsGarageSecured", Rountine.isGarageSecured));
            parms.Add(new SqlParameter("IsPoolSecured", Rountine.isPoolSecured));
            parms.Add(new SqlParameter("HasGoodLockbox", Rountine.hasGoodLockbox));
            parms.Add(new SqlParameter("LockboxLoc", Rountine.lockboxLoc));
            parms.Add(new SqlParameter("IsLawnCut", Rountine.isLawnCut));
            parms.Add(new SqlParameter("LawnProblemLoc", Rountine.lawnProblemLoc));
            parms.Add(new SqlParameter("IsProperlyBoarded", Rountine.isProperlyBoarded));
            parms.Add(new SqlParameter("BoardedLoc", Rountine.boardedLoc));
            parms.Add(new SqlParameter("HasBrokenWindows", Rountine.hasBrokenWindows));
            parms.Add(new SqlParameter("BrokenWindowLoc", Rountine.brokenWindowLoc));
            parms.Add(new SqlParameter("HasBrokenDoors", Rountine.hasBrokenDoors));
            parms.Add(new SqlParameter("BrokenDoorsLoc", Rountine.brokenDoorsLoc));
            parms.Add(new SqlParameter("HasDoorWindowsSecured", Rountine.hasDoorWindowsSecured));
            parms.Add(new SqlParameter("NotSecuredLoc", Rountine.notSecuredLoc));
            parms.Add(new SqlParameter("IsHazardFree", Rountine.isHazardFree));
            parms.Add(new SqlParameter("HazardLoc", Rountine.hazardLoc));
            parms.Add(new SqlParameter("HasExtVandalism", Rountine.hasExtVandalism));
            parms.Add(new SqlParameter("ExtVandalismLoc", Rountine.extVandalismLoc));
            parms.Add(new SqlParameter("IsExtStructureOk", Rountine.isExtStructureOk));
            parms.Add(new SqlParameter("ExtStructureLoc", Rountine.extStructureLoc));
            parms.Add(new SqlParameter("IsExtRoofOk", Rountine.isExtRoofOk));
            parms.Add(new SqlParameter("ExtRoofLoc", Rountine.extRoofLoc));
            parms.Add(new SqlParameter("IsExtPaintOk", Rountine.isExtPaintOk));
            parms.Add(new SqlParameter("ExtPaintLoc", Rountine.extPaintLoc));
            parms.Add(new SqlParameter("HasSignInSheet", Rountine.hasSignInSheet));
            parms.Add(new SqlParameter("IsWinterizationOk", Rountine.isWinterizationOk));
            parms.Add(new SqlParameter("IsBroomSwept", Rountine.isBroomSwept));
            parms.Add(new SqlParameter("DoesSignInHaveInspection", Rountine.doesSignInHaveInspection));
            parms.Add(new SqlParameter("MissingInspComment", Rountine.missingInspComment));
            parms.Add(new SqlParameter("NeedEmergencyRepair", Rountine.needEmergencyRepair));
            parms.Add(new SqlParameter("EmergencyRepairLoc", Rountine.emergencyRepairLoc));
            parms.Add(new SqlParameter("IsHvacHeatOk", Rountine.isHvacHeatOk));
            parms.Add(new SqlParameter("IsElecOk", Rountine.isElecOk));
            parms.Add(new SqlParameter("DoesPlumbLeak", Rountine.doesPlumbLeak));
            parms.Add(new SqlParameter("PlumbLeakLoc", Rountine.plumbLeakLoc));
            parms.Add(new SqlParameter("HasIntVandalism", Rountine.hasIntVandalism));
            parms.Add(new SqlParameter("IntVandalismLoc", Rountine.intVandalismLoc));
            parms.Add(new SqlParameter("IsIntPaintOk", Rountine.isIntPaintOk));
            parms.Add(new SqlParameter("IntPaintLoc", Rountine.intPaintLoc));
            parms.Add(new SqlParameter("HasRoofLeak", Rountine.hasRoofLeak));
            parms.Add(new SqlParameter("IntRoofLeakLoc", Rountine.intRoofLeakLoc));
            parms.Add(new SqlParameter("IsFloodDamaged", Rountine.isFloodDamaged));
            parms.Add(new SqlParameter("FloodDamageLoc", Rountine.floodDamageLoc));
            parms.Add(new SqlParameter("AreKitchenBathOk", Rountine.areKitchenBathOk));
            parms.Add(new SqlParameter("KitchenBathLoc", Rountine.kitchenBathLoc));
            parms.Add(new SqlParameter("IsIntStructureOk", Rountine.isIntStructureOk));
            parms.Add(new SqlParameter("IntStructureLoc", Rountine.intStructureLoc));
            parms.Add(new SqlParameter("AreAnyUtilitiesOn", Rountine.areAnyUtilitiesOn));
            parms.Add(new SqlParameter("UtilitiesLoc", Rountine.utilitiesLoc));
            parms.Add(new SqlParameter("HasCondemableDefect", Rountine.hasCondemableDefect));
            parms.Add(new SqlParameter("CondemableDefectLoc", Rountine.condemableDefectLoc));
            parms.Add(new SqlParameter("HasTripHazard", Rountine.hasTripHazard));
            parms.Add(new SqlParameter("TripHazardLoc", Rountine.tripHazardLoc));
            parms.Add(new SqlParameter("HasExposedWire", Rountine.hasExposedWire));
            parms.Add(new SqlParameter("ExposedWireLoc", Rountine.exposedWireLoc));
            parms.Add(new SqlParameter("HasBadStairRailing", Rountine.hasBadStairRailing));
            parms.Add(new SqlParameter("BadStairRailingLoc", Rountine.badStairRailingLoc));
            parms.Add(new SqlParameter("HasElectricHazard", Rountine.hasElectricHazard));
            parms.Add(new SqlParameter("ElectricHazardLoc", Rountine.electricHazardLoc));
            parms.Add(new SqlParameter("HasDefectiveSteps", Rountine.hasDefectiveSteps));
            parms.Add(new SqlParameter("DefectiveStepsLoc", Rountine.defectiveStepsLoc));
            parms.Add(new SqlParameter("HasToxicGasOdor", Rountine.hasToxicGasOdor));
            parms.Add(new SqlParameter("ToxicGasLoc", Rountine.toxicGasLoc));
            parms.Add(new SqlParameter("HasUnsecuredAbovePool", Rountine.hasUnsecuredAbovePool));
            parms.Add(new SqlParameter("UnsecuredAbovePoolLoc", Rountine.unsecuredAbovePoolLoc));
            parms.Add(new SqlParameter("ShouldAbovePoolBeRemoved", Rountine.shouldAbovePoolBeRemoved));
            parms.Add(new SqlParameter("HasUnsecuredInGroundPool", Rountine.hasUnsecuredInGroundPool));
            parms.Add(new SqlParameter("UnsecuredInGroundPoolLoc", Rountine.unsecuredInGroundPoolLoc));
            parms.Add(new SqlParameter("HasMissingDeckRailing", Rountine.hasMissingDeckRailing));
            parms.Add(new SqlParameter("DeckRailingLoc", Rountine.deckRailingLoc));
            parms.Add(new SqlParameter("HasOtherHazards", Rountine.hasOtherHazards));
            parms.Add(new SqlParameter("OtherHazardsLoc", Rountine.otherHazardsLoc));
            parms.Add(new SqlParameter("GeneralComments", Rountine.generalComments));
            parms.Add(new SqlParameter("CreatedBy", Rountine.createdBy));
            parms.Add(new SqlParameter("CreatedOn", Rountine.createdOn));
            parms.Add(new SqlParameter("UpdatedBy", Rountine.updatedBy));
            parms.Add(new SqlParameter("UpdatedOn", Rountine.updatedOn));
            parms.Add(new SqlParameter("DeactivatedBy", Rountine.deactivatedBy));
            parms.Add(new SqlParameter("DeactivatedOn", Rountine.deactivatedOn));
            dm.ExecuteNonQuery("spCslaInspRoutine_Insert", parms);
        }
    }
}
