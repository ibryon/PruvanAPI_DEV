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
    public class SurveyHPIR
    {
        public SurveyHPIR() { }
        public int workorderId { get; set; }
        public int vendorIdPart1 { get; set; }
        public int vendorIdPart2 { get; set; }
        public int vendorIdPart3 { get; set; }
        public int bedrooms { get; set; }
        public int stories { get; set; }
        public DateTime vendorCompletedOn { get; set; }
        public DateTime inspectionOn { get; set; }
        public DateTime part2UploadedOn { get; set; }
        public DateTime part2PdfUploadedon { get; set; }
        public DateTime part3UploadedOn { get; set; }
        public DateTime part3PdfUploadedon { get; set; }
        public DateTime updatedOn { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime deactivatedOn { get; set; }
        public string inspectorFirstName { get; set; }
        public string inspectorLastName { get; set; }
        public string mortgageeActivities { get; set; }
        public string propertyType { get; set; }
        public string foundationType { get; set; }
        public string subdivisionName { get; set; }
        public string lockboxCode { get; set; }
        public string gateCode { get; set; }
        public string lockBoxSerialNo { get; set; }
        public string keyCode { get; set; }
        public string masterHoaName { get; set; }
        public string subHoaName { get; set; }
        public string hoaAddress { get; set; }
        public string hoaContactName { get; set; }
        public string hoaContactPhone { get; set; }
        public string hvacCommentP1 { get; set; }
        public string hvacAcCondP1 { get; set; }
        public string hvacHeatCondP1 { get; set; }
        public string hvacDuctCondP1 { get; set; }
        public string elecCommentP1 { get; set; }
        public string elecWiringCondP1 { get; set; }
        public string elecOtherCondP1 { get; set; }
        public string kitCommentP1 { get; set; }
        public string kitApplCondP1 { get; set; }
        public string kitCabCondP1 { get; set; }
        public string kitOtherCondP1 { get; set; }
        public string plumbCommentP1 { get; set; }
        public string plumbPlumbCondP1 { get; set; }
        public string plumbSinkCondP1 { get; set; }
        public string PlumbOtherCondP1 { get; set; }
        public string roofCommentP1 { get; set; }
        public string roofCondP1 { get; set; }
        public string wHeatCommentP1 { get; set; }
        public string wHeatCondP1 { get; set; }
        public string saniCommentP1 { get; set; }
        public string saniSewerCondP1 { get; set; }
        public string saniToiletCondP1 { get; set; }
        public string saniOtherCondP1 { get; set; }
        public string roofLeakCommentP1 { get; set; }
        public string roofLeakLocP1 { get; set; }
        public string propStructureCommentP1 { get; set; }
        public string hazardCommentP1 { get; set; }
        public string hazardExtCommentP1 { get; set; }
        public string hazardIntCommentP1 { get; set; }
        public string waterDamageComment { get; set; }
        public string mortgageeDamagedComment { get; set; }
        public string damagedComment { get; set; }
        public string howManyLockBoxes { get; set; }
        public string howManyKnobs { get; set; }
        public string howManyBolts { get; set; }
        public string brokenWindowCount { get; set; }
        public string brokenWindowLoc { get; set; }
        public string howManyDoorsBoarded { get; set; }
        public string debrisIntComment { get; set; }
        public string intPersonalItemsComment { get; set; }
        public string debrisExtComment { get; set; }
        public string leftVehicleComment { get; set; }
        public string howManyInchesWaterInCrawl { get; set; }
        public string crawlWaterSource { get; set; }
        public string floodingDamageComments { get; set; }
        public string leadComment { get; set; }
        public string hvacCommentP3 { get; set; }
        public string hvacAcCondP3 { get; set; }
        public string hvacHeatCondP3 { get; set; }
        public string hvacHeatCommentP3 { get; set; }
        public string hvacDuctCondP3 { get; set; }
        public string hvacDuctCommentP3 { get; set; }
        public string elecCommentP3 { get; set; }
        public string elecWiringCondP3 { get; set; }
        public string elecOther1CondP3 { get; set; }
        public string elecOther2CondP3 { get; set; }
        public string applCommentP3 { get; set; }
        public string kitApplCondP3 { get; set; }
        public string kitCabCondP3 { get; set; }
        public string kitOtherCondP3 { get; set; }
        public string kitOtherCommentP3 { get; set; }
        public string plumbCommentP3 { get; set; }
        public string plumbPlumbCondP3 { get; set; }
        public string plumbSinkCondP3 { get; set; }
        public string plumbOtherCondP3 { get; set; }
        public string wHeatCommentP3 { get; set; }
        public string wHeatCondP3 { get; set; }
        public string saniCommentP3 { get; set; }
        public string saniSewerCondP3 { get; set; }
        public string saniToiletCondP3 { get; set; }
        public string saniOtherCondP3 { get; set; }
        public string roofCommentP3 { get; set; }
        public string roofCondP3 { get; set; }
        public string roofOtherCondP3 { get; set; }
        public string hpirComments { get; set; }
        public string downSpoutCond { get; set; }
        public string roofCondP2 { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public float bathrooms { get; set; }
        public float interiorDubris { get; set; }
        public float exteriorDubris { get; set; }
        public double hvacAcEstP1 { get; set; }
        public double hvacHeatEstP1 { get; set; }
        public double hvacDuctEstP1 { get; set; }
        public double elecWiringEstP1 { get; set; }
        public double elecOtherEstP1 { get; set; }
        public double kitApplEstP1 { get; set; }
        public double kitCabEstP1 { get; set; }
        public double kitOtherEstP1 { get; set; }
        public double plumbPlumbEstP1 { get; set; }
        public double plumbSinkEstP1 { get; set; }
        public double plumbOtherEstP1 { get; set; }
        public double wHeatEstP1 { get; set; }
        public double saniSewerEstP1 { get; set; }
        public double saniToiletEstP1 { get; set; }
        public double saniOtherEstP1 { get; set; }
        public double roofEstP1 { get; set; }
        public double roofLeakEstP1 { get; set; }
        public double propStructureEstP1 { get; set; }
        public double hazardExtEstP1 { get; set; }
        public char canValidate { get; set; }
        public char isComplete { get; set; }
        public char hasAttachedGarage { get; set; }
        public char hasCarport { get; set; }
        public char hasDetachedGarage { get; set; }
        public char isPropertyAnHoa { get; set; }
        public char isVacant { get; set; }
        public char isLenderSecurity { get; set; }
        public char didLenderWinterize { get; set; }
        public char isLawnMaintenanceOk { get; set; }
        public char isBroomSwept { get; set; }
        public char isHvacReqP1 { get; set; }
        public char isElecOkP1 { get; set; }
        public char isKitOkP1 { get; set; }
        public char isPlumbOkP1 { get; set; }
        public char isWHeatOkP1 { get; set; }
        public char isSaniOkP1 { get; set; }
        public char isRoofOkP1 { get; set; }
        public char hasRoofLeakDamageP1 { get; set; }
        public char isPropStructureOkP1 { get; set; }
        public char isHazardOkP1 { get; set; }
        public char hasDatedPhotos { get; set; }
        public char isPropDamaged { get; set; }
        public char isFireDamaged { get; set; }
        public char isFloodDamaged { get; set; }
        public char isHurricaneDamaged { get; set; }
        public char isTornadoDamaged { get; set; }
        public char isEarthquakeDamaged { get; set; }
        public char isBoilerDamaged { get; set; }
        public char isMortgageeDamaged { get; set; }
        public char hasWaterDamage { get; set; }
        public char hasNewLocks { get; set; }
        public char hasKeyedLocks { get; set; }
        public char hasGlassOrdered { get; set; }
        public char hasWindowLocksOrdered { get; set; }
        public char hasLawnBeenCut { get; set; }
        public char isExteriorCleaned { get; set; }
        public char isInHotZone { get; set; }
        public char isApprovedBoarding { get; set; }
        public char isNonApprovedBoarding { get; set; }
        public char hasHudLockKey { get; set; }
        public char hasDoorWindowsSecured { get; set; }
        public char isGarageSecured { get; set; }
        public char hasOutbuildingsSecured { get; set; }
        public char hasPool { get; set; }
        public char isPoolSecured { get; set; }
        public char isPoolFenceOk { get; set; }
        public char isPoolGateOk { get; set; }
        public char hasHotTub { get; set; }
        public char isHotTubSecured { get; set; }
        public char isPoolDrained { get; set; }
        public char hasBrokenWindows { get; set; }
        public char hasBoardedWindows { get; set; }
        public char hasBrokenGlassRemoved { get; set; }
        public char isCellarBoarded { get; set; }
        public char hasCrackedWindow { get; set; }
        public char hasUrineStainedFloor { get; set; }
        public char hasTripHazard { get; set; }
        public char hasTripHazardPhotos { get; set; }
        public char isWinterizationOk { get; set; }
        public char isWaterlineDrained { get; set; }
        public char isMeterDisconnected { get; set; }
        public char isWaterOffAtCurb { get; set; }
        public char isWaterMainPlugged { get; set; }
        public char isWellDrained { get; set; }
        public char hasToiletsTaped { get; set; }
        public char hasDatedSigns { get; set; }
        public char hasVisibleProblems { get; set; }
        public char hasRpzValve { get; set; }
        public char hasAntiFreeze { get; set; }
        public char isHeatOn { get; set; }
        public char isWHeatDrained { get; set; }
        public char isRoofSurfaceDamaged { get; set; }
        public char hasRoofBeenCovered { get; set; }
        public char didNeedPrevention { get; set; }
        public char hasRoofLeakDamageP2 { get; set; }
        public char isDeckDamaged { get; set; }
        public char isChimneyDamaged { get; set; }
        public char hasIntDebris { get; set; }
        public char hasIntPersonalItems { get; set; }
        public char hasExtDebris { get; set; }
        public char hasLeftVehicle { get; set; }
        public char isSumpPumpOnSite { get; set; }
        public char isSumpPumpOperational { get; set; }
        public char isPowerOn { get; set; }
        public char isCrawlSpaceFlooded { get; set; }
        public char hasIntWallCoveringDamage { get; set; }
        public char hasGraffiti { get; set; }
        public char hasViolationPosted { get; set; }
        public char isYardOk { get; set; }
        public char isLawnCut { get; set; }
        public char hasClearTreeLimbs { get; set; }
        public char hasDeadTreeRemoved { get; set; }
        public char builtBefore1978Lead { get; set; }
        public char isPaintPealingLead { get; set; }
        public char isHvacOkP3 { get; set; }
        public char isElecOkP3 { get; set; }
        public char isApplOkP3 { get; set; }
        public char isPlumbOkP3 { get; set; }
        public char isWHeatOkP3 { get; set; }
        public char isSaniOkP3 { get; set; }
        public char isRoofOkP3 { get; set; }
        public Guid createdBy { get; set; }
        public Guid deactivatedBy { get; set; }
        public Guid updatedBy { get; set; }
        public SurveyHPIR getSurveyOject(string text)
        {
            int StartIndex = text.IndexOf('{');
            string test2 = text.Substring(StartIndex);
            int EndIndex = test2.LastIndexOf('}');
            EndIndex++;
            string test3 = test2.Substring(0, EndIndex);
            SurveyHPIR s = JsonConvert.DeserializeObject<SurveyHPIR>(test3);
            return s;
        }
        public void SaveHPIR(SurveyHPIR HPIR, Guid UserID, int WorkorderId)
        {
            DataManager dm = new DataManager(ConfigurationManager.ConnectionStrings["REAMSViewDev"].ConnectionString);
            List<SqlParameter> parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("WorkorderId", WorkorderId));
            parms.Add(new SqlParameter("VendorIdPart1", HPIR.vendorIdPart1));
            parms.Add(new SqlParameter("VendorIdPart2", HPIR.vendorIdPart2));
            parms.Add(new SqlParameter("VendorIdPart3", HPIR.vendorIdPart3));
            parms.Add(new SqlParameter("Bedrooms", HPIR.bedrooms));
            parms.Add(new SqlParameter("Stories", HPIR.stories));
            parms.Add(new SqlParameter("VendorCompletedOn", HPIR.vendorCompletedOn));
            parms.Add(new SqlParameter("InspectionOn", HPIR.inspectionOn));
            parms.Add(new SqlParameter("Part2UploadedOn", HPIR.part2UploadedOn));
            parms.Add(new SqlParameter("Part2PdfUploadedon", HPIR.part2PdfUploadedon));
            parms.Add(new SqlParameter("Part3UploadedOn", HPIR.part3UploadedOn));
            parms.Add(new SqlParameter("Part3PdfUploadedon", HPIR.part3PdfUploadedon));
            parms.Add(new SqlParameter("UpdatedOn", HPIR.updatedOn));
            parms.Add(new SqlParameter("CreatedOn", HPIR.createdOn));
            parms.Add(new SqlParameter("DeactivatedOn", HPIR.deactivatedOn));
            parms.Add(new SqlParameter("InspectorFirstName", HPIR.inspectorFirstName));
            parms.Add(new SqlParameter("InspectorLastName", HPIR.inspectorLastName));
            parms.Add(new SqlParameter("MortgageeActivities", HPIR.mortgageeActivities));
            parms.Add(new SqlParameter("PropertyType", HPIR.propertyType));
            parms.Add(new SqlParameter("FoundationType", HPIR.foundationType));
            parms.Add(new SqlParameter("SubdivisionName", HPIR.subdivisionName));
            parms.Add(new SqlParameter("LockboxCode", HPIR.lockboxCode));
            parms.Add(new SqlParameter("GateCode", HPIR.gateCode));
            parms.Add(new SqlParameter("LockBoxSerialNo", HPIR.lockBoxSerialNo));
            parms.Add(new SqlParameter("KeyCode", HPIR.keyCode));
            parms.Add(new SqlParameter("MasterHoaName", HPIR.masterHoaName));
            parms.Add(new SqlParameter("SubHoaName", HPIR.subHoaName));
            parms.Add(new SqlParameter("HoaAddress", HPIR.hoaAddress));
            parms.Add(new SqlParameter("HoaContactName", HPIR.hoaContactName));
            parms.Add(new SqlParameter("HoaContactPhone", HPIR.hoaContactPhone));
            parms.Add(new SqlParameter("HvacCommentP1", HPIR.hvacCommentP1));
            parms.Add(new SqlParameter("HvacAcCondP1", HPIR.hvacAcCondP1));
            parms.Add(new SqlParameter("HvacHeatCondP1", HPIR.hvacHeatCondP1));
            parms.Add(new SqlParameter("HvacDuctCondP1", HPIR.hvacDuctCondP1));
            parms.Add(new SqlParameter("ElecCommentP1", HPIR.elecCommentP1));
            parms.Add(new SqlParameter("ElecWiringCondP1", HPIR.elecWiringCondP1));
            parms.Add(new SqlParameter("ElecOtherCondP1", HPIR.elecOtherCondP1));
            parms.Add(new SqlParameter("KitCommentP1", HPIR.kitCommentP1));
            parms.Add(new SqlParameter("KitApplCondP1", HPIR.kitApplCondP1));
            parms.Add(new SqlParameter("KitCabCondP1", HPIR.kitCabCondP1));
            parms.Add(new SqlParameter("KitOtherCondP1", HPIR.kitOtherCondP1));
            parms.Add(new SqlParameter("PlumbCommentP1", HPIR.plumbCommentP1));
            parms.Add(new SqlParameter("PlumbPlumbCondP1", HPIR.plumbPlumbCondP1));
            parms.Add(new SqlParameter("PlumbSinkCondP1", HPIR.plumbSinkCondP1));
            parms.Add(new SqlParameter("PlumbOtherCondP1", HPIR.PlumbOtherCondP1));
            parms.Add(new SqlParameter("RoofCommentP1", HPIR.roofCommentP1));
            parms.Add(new SqlParameter("RoofCondP1", HPIR.roofCondP1));
            parms.Add(new SqlParameter("WHeatCommentP1", HPIR.wHeatCommentP1));
            parms.Add(new SqlParameter("WHeatCondP1", HPIR.wHeatCondP1));
            parms.Add(new SqlParameter("SaniCommentP1", HPIR.saniCommentP1));
            parms.Add(new SqlParameter("SaniSewerCondP1", HPIR.saniSewerCondP1));
            parms.Add(new SqlParameter("SaniToiletCondP1", HPIR.saniToiletCondP1));
            parms.Add(new SqlParameter("SaniOtherCondP1", HPIR.saniOtherCondP1));
            parms.Add(new SqlParameter("RoofLeakCommentP1", HPIR.roofLeakCommentP1));
            parms.Add(new SqlParameter("RoofLeakLocP1", HPIR.roofLeakLocP1));
            parms.Add(new SqlParameter("PropStructureCommentP1", HPIR.propStructureCommentP1));
            parms.Add(new SqlParameter("HazardCommentP1", HPIR.hazardCommentP1));
            parms.Add(new SqlParameter("HazardExtCommentP1", HPIR.hazardExtCommentP1));
            parms.Add(new SqlParameter("HazardIntCommentP1", HPIR.hazardIntCommentP1));
            parms.Add(new SqlParameter("WaterDamageComment", HPIR.waterDamageComment));
            parms.Add(new SqlParameter("MortgageeDamagedComment", HPIR.mortgageeDamagedComment));
            parms.Add(new SqlParameter("DamagedComment", HPIR.damagedComment));
            parms.Add(new SqlParameter("HowManyLockBoxes", HPIR.howManyLockBoxes));
            parms.Add(new SqlParameter("HowManyKnobs", HPIR.howManyKnobs));
            parms.Add(new SqlParameter("HowManyBolts", HPIR.howManyBolts));
            parms.Add(new SqlParameter("BrokenWindowCount", HPIR.brokenWindowCount));
            parms.Add(new SqlParameter("BrokenWindowLoc", HPIR.brokenWindowLoc));
            parms.Add(new SqlParameter("HowManyDoorsBoarded", HPIR.howManyDoorsBoarded));
            parms.Add(new SqlParameter("DebrisIntComment", HPIR.debrisIntComment));
            parms.Add(new SqlParameter("IntPersonalItemsComment", HPIR.intPersonalItemsComment));
            parms.Add(new SqlParameter("DebrisExtComment", HPIR.debrisExtComment));
            parms.Add(new SqlParameter("LeftVehicleComment", HPIR.leftVehicleComment));
            parms.Add(new SqlParameter("HowManyInchesWaterInCrawl", HPIR.howManyInchesWaterInCrawl));
            parms.Add(new SqlParameter("CrawlWaterSource", HPIR.crawlWaterSource));
            parms.Add(new SqlParameter("FloodingDamageComments", HPIR.floodingDamageComments));
            parms.Add(new SqlParameter("LeadComment", HPIR.leadComment));
            parms.Add(new SqlParameter("HvacCommentP3", HPIR.hvacCommentP3));
            parms.Add(new SqlParameter("HvacAcCondP3", HPIR.hvacAcCondP3));
            parms.Add(new SqlParameter("HvacHeatCondP3", HPIR.hvacHeatCondP3));
            parms.Add(new SqlParameter("HvacHeatCommentP3", HPIR.hvacHeatCommentP3));
            parms.Add(new SqlParameter("HvacDuctCondP3", HPIR.hvacDuctCondP3));
            parms.Add(new SqlParameter("HvacDuctCommentP3", HPIR.hvacDuctCommentP3));
            parms.Add(new SqlParameter("ElecCommentP3", HPIR.elecCommentP3));
            parms.Add(new SqlParameter("ElecWiringCondP3", HPIR.elecWiringCondP3));
            parms.Add(new SqlParameter("ElecOther1CondP3", HPIR.elecOther1CondP3));
            parms.Add(new SqlParameter("ElecOther2CondP3", HPIR.elecOther2CondP3));
            parms.Add(new SqlParameter("ApplCommentP3", HPIR.applCommentP3));
            parms.Add(new SqlParameter("KitApplCondP3", HPIR.kitApplCondP3));
            parms.Add(new SqlParameter("KitCabCondP3", HPIR.kitCabCondP3));
            parms.Add(new SqlParameter("KitOtherCondP3", HPIR.kitOtherCondP3));
            parms.Add(new SqlParameter("KitOtherCommentP3", HPIR.kitOtherCommentP3));
            parms.Add(new SqlParameter("PlumbCommentP3", HPIR.plumbCommentP3));
            parms.Add(new SqlParameter("PlumbPlumbCondP3", HPIR.plumbPlumbCondP3));
            parms.Add(new SqlParameter("PlumbSinkCondP3", HPIR.plumbSinkCondP3));
            parms.Add(new SqlParameter("PlumbOtherCondP3", HPIR.plumbOtherCondP3));
            parms.Add(new SqlParameter("WHeatCommentP3", HPIR.wHeatCommentP3));
            parms.Add(new SqlParameter("WHeatCondP3", HPIR.wHeatCondP3));
            parms.Add(new SqlParameter("SaniCommentP3", HPIR.saniCommentP3));
            parms.Add(new SqlParameter("SaniSewerCondP3", HPIR.saniSewerCondP3));
            parms.Add(new SqlParameter("SaniToiletCondP3", HPIR.saniToiletCondP3));
            parms.Add(new SqlParameter("SaniOtherCondP3", HPIR.saniOtherCondP3));
            parms.Add(new SqlParameter("RoofCommentP3", HPIR.roofCommentP3));
            parms.Add(new SqlParameter("RoofCondP3", HPIR.roofCondP3));
            parms.Add(new SqlParameter("RoofOtherCondP3", HPIR.roofOtherCondP3));
            parms.Add(new SqlParameter("HpirComments", HPIR.hpirComments));
            parms.Add(new SqlParameter("DownSpoutCond", HPIR.downSpoutCond));
            parms.Add(new SqlParameter("RoofCondP2", HPIR.roofCondP2));
            parms.Add(new SqlParameter("Latitude", HPIR.latitude));
            parms.Add(new SqlParameter("Longitude", HPIR.longitude));
            parms.Add(new SqlParameter("Bathrooms", HPIR.bathrooms));
            parms.Add(new SqlParameter("InteriorDubris", HPIR.interiorDubris));
            parms.Add(new SqlParameter("ExteriorDubris", HPIR.exteriorDubris));
            parms.Add(new SqlParameter("HvacAcEstP1", HPIR.hvacAcEstP1));
            parms.Add(new SqlParameter("HvacHeatEstP1", HPIR.hvacHeatEstP1));
            parms.Add(new SqlParameter("HvacDuctEstP1", HPIR.hvacDuctEstP1));
            parms.Add(new SqlParameter("ElecWiringEstP1", HPIR.elecWiringEstP1));
            parms.Add(new SqlParameter("ElecOtherEstP1", HPIR.elecOtherEstP1));
            parms.Add(new SqlParameter("KitApplEstP1", HPIR.kitApplEstP1));
            parms.Add(new SqlParameter("KitCabEstP1", HPIR.kitCabEstP1));
            parms.Add(new SqlParameter("KitOtherEstP1", HPIR.kitOtherEstP1));
            parms.Add(new SqlParameter("PlumbPlumbEstP1", HPIR.plumbPlumbEstP1));
            parms.Add(new SqlParameter("PlumbSinkEstP1", HPIR.plumbSinkEstP1));
            parms.Add(new SqlParameter("PlumbOtherEstP1", HPIR.plumbOtherEstP1));
            parms.Add(new SqlParameter("WHeatEstP1", HPIR.wHeatEstP1));
            parms.Add(new SqlParameter("SaniSewerEstP1", HPIR.saniSewerEstP1));
            parms.Add(new SqlParameter("SaniToiletEstP1", HPIR.saniToiletEstP1));
            parms.Add(new SqlParameter("SaniOtherEstP1", HPIR.saniOtherEstP1));
            parms.Add(new SqlParameter("RoofEstP1", HPIR.roofEstP1));
            parms.Add(new SqlParameter("RoofLeakEstP1", HPIR.roofLeakEstP1));
            parms.Add(new SqlParameter("PropStructureEstP1", HPIR.propStructureEstP1));
            parms.Add(new SqlParameter("HazardExtEstP1", HPIR.hazardExtEstP1));
            parms.Add(new SqlParameter("CanValidate", HPIR.canValidate));
            parms.Add(new SqlParameter("IsComplete", HPIR.isComplete));
            parms.Add(new SqlParameter("HasAttachedGarage", HPIR.hasAttachedGarage));
            parms.Add(new SqlParameter("HasCarport", HPIR.hasCarport));
            parms.Add(new SqlParameter("HasDetachedGarage", HPIR.hasDetachedGarage));
            parms.Add(new SqlParameter("IsPropertyAnHoa", HPIR.isPropertyAnHoa));
            parms.Add(new SqlParameter("IsVacant", HPIR.isVacant));
            parms.Add(new SqlParameter("IsLenderSecurity", HPIR.isLenderSecurity));
            parms.Add(new SqlParameter("DidLenderWinterize", HPIR.didLenderWinterize));
            parms.Add(new SqlParameter("IsLawnMaintenanceOk", HPIR.isLawnMaintenanceOk));
            parms.Add(new SqlParameter("IsBroomSwept", HPIR.isBroomSwept));
            parms.Add(new SqlParameter("IsHvacReqP1", HPIR.isHvacReqP1));
            parms.Add(new SqlParameter("IsElecOkP1", HPIR.isElecOkP1));
            parms.Add(new SqlParameter("IsKitOkP1", HPIR.isKitOkP1));
            parms.Add(new SqlParameter("IsPlumbOkP1", HPIR.isPlumbOkP1));
            parms.Add(new SqlParameter("IsWHeatOkP1", HPIR.isWHeatOkP1));
            parms.Add(new SqlParameter("IsSaniOkP1", HPIR.isSaniOkP1));
            parms.Add(new SqlParameter("IsRoofOkP1", HPIR.isRoofOkP1));
            parms.Add(new SqlParameter("HasRoofLeakDamageP1", HPIR.hasRoofLeakDamageP1));
            parms.Add(new SqlParameter("IsPropStructureOkP1", HPIR.isPropStructureOkP1));
            parms.Add(new SqlParameter("IsHazardOkP1", HPIR.isHazardOkP1));
            parms.Add(new SqlParameter("HasDatedPhotos", HPIR.hasDatedPhotos));
            parms.Add(new SqlParameter("IsPropDamaged", HPIR.isPropDamaged));
            parms.Add(new SqlParameter("IsFireDamaged", HPIR.isFireDamaged));
            parms.Add(new SqlParameter("IsFloodDamaged", HPIR.isFloodDamaged));
            parms.Add(new SqlParameter("IsHurricaneDamaged", HPIR.isHurricaneDamaged));
            parms.Add(new SqlParameter("IsTornadoDamaged", HPIR.isTornadoDamaged));
            parms.Add(new SqlParameter("IsEarthquakeDamaged", HPIR.isEarthquakeDamaged));
            parms.Add(new SqlParameter("IsBoilerDamaged", HPIR.isBoilerDamaged));
            parms.Add(new SqlParameter("IsMortgageeDamaged", HPIR.isMortgageeDamaged));
            parms.Add(new SqlParameter("HasWaterDamage", HPIR.hasWaterDamage));
            parms.Add(new SqlParameter("HasNewLocks", HPIR.hasNewLocks));
            parms.Add(new SqlParameter("HasKeyedLocks", HPIR.hasKeyedLocks));
            parms.Add(new SqlParameter("HasGlassOrdered", HPIR.hasGlassOrdered));
            parms.Add(new SqlParameter("HasWindowLocksOrdered", HPIR.hasWindowLocksOrdered));
            parms.Add(new SqlParameter("HasLawnBeenCut", HPIR.hasLawnBeenCut));
            parms.Add(new SqlParameter("IsExteriorCleaned", HPIR.isExteriorCleaned));
            parms.Add(new SqlParameter("IsInHotZone", HPIR.isInHotZone));
            parms.Add(new SqlParameter("IsApprovedBoarding", HPIR.isApprovedBoarding));
            parms.Add(new SqlParameter("IsNonApprovedBoarding", HPIR.isNonApprovedBoarding));
            parms.Add(new SqlParameter("HasHudLockKey", HPIR.hasHudLockKey));
            parms.Add(new SqlParameter("HasDoorWindowsSecured", HPIR.hasDoorWindowsSecured));
            parms.Add(new SqlParameter("IsGarageSecured", HPIR.isGarageSecured));
            parms.Add(new SqlParameter("HasOutbuildingsSecured", HPIR.hasOutbuildingsSecured));
            parms.Add(new SqlParameter("HasPool", HPIR.hasPool));
            parms.Add(new SqlParameter("IsPoolSecured", HPIR.isPoolSecured));
            parms.Add(new SqlParameter("IsPoolFenceOk", HPIR.isPoolFenceOk));
            parms.Add(new SqlParameter("IsPoolGateOk", HPIR.isPoolGateOk));
            parms.Add(new SqlParameter("HasHotTub", HPIR.hasHotTub));
            parms.Add(new SqlParameter("IsHotTubSecured", HPIR.isHotTubSecured));
            parms.Add(new SqlParameter("IsPoolDrained", HPIR.isPoolDrained));
            parms.Add(new SqlParameter("HasBrokenWindows", HPIR.hasBrokenWindows));
            parms.Add(new SqlParameter("HasBoardedWindows", HPIR.hasBoardedWindows));
            parms.Add(new SqlParameter("HasBrokenGlassRemoved", HPIR.hasBrokenGlassRemoved));
            parms.Add(new SqlParameter("IsCellarBoarded", HPIR.isCellarBoarded));
            parms.Add(new SqlParameter("HasCrackedWindow", HPIR.hasCrackedWindow));
            parms.Add(new SqlParameter("HasUrineStainedFloor", HPIR.hasUrineStainedFloor));
            parms.Add(new SqlParameter("HasTripHazard", HPIR.hasTripHazard));
            parms.Add(new SqlParameter("HasTripHazardPhotos", HPIR.hasTripHazardPhotos));
            parms.Add(new SqlParameter("IsWinterizationOk", HPIR.isWinterizationOk));
            parms.Add(new SqlParameter("IsWaterlineDrained", HPIR.isWaterlineDrained));
            parms.Add(new SqlParameter("IsMeterDisconnected", HPIR.isMeterDisconnected));
            parms.Add(new SqlParameter("IsWaterOffAtCurb", HPIR.isWaterOffAtCurb));
            parms.Add(new SqlParameter("IsWaterMainPlugged", HPIR.isWaterMainPlugged));
            parms.Add(new SqlParameter("IsWellDrained", HPIR.isWellDrained));
            parms.Add(new SqlParameter("HasToiletsTaped", HPIR.hasToiletsTaped));
            parms.Add(new SqlParameter("HasDatedSigns", HPIR.hasDatedSigns));
            parms.Add(new SqlParameter("HasVisibleProblems", HPIR.hasVisibleProblems));
            parms.Add(new SqlParameter("HasRpzValve", HPIR.hasRpzValve));
            parms.Add(new SqlParameter("HasAntiFreeze", HPIR.hasAntiFreeze));
            parms.Add(new SqlParameter("IsHeatOn", HPIR.isHeatOn));
            parms.Add(new SqlParameter("IsWHeatDrained", HPIR.isWHeatDrained));
            parms.Add(new SqlParameter("IsRoofSurfaceDamaged", HPIR.isRoofSurfaceDamaged));
            parms.Add(new SqlParameter("HasRoofBeenCovered", HPIR.hasRoofBeenCovered));
            parms.Add(new SqlParameter("DidNeedPrevention", HPIR.didNeedPrevention));
            parms.Add(new SqlParameter("HasRoofLeakDamageP2", HPIR.hasRoofLeakDamageP2));
            parms.Add(new SqlParameter("IsDeckDamaged", HPIR.isDeckDamaged));
            parms.Add(new SqlParameter("IsChimneyDamaged", HPIR.isChimneyDamaged));
            parms.Add(new SqlParameter("HasIntDebris", HPIR.hasIntDebris));
            parms.Add(new SqlParameter("HasIntPersonalItems", HPIR.hasIntPersonalItems));
            parms.Add(new SqlParameter("HasExtDebris", HPIR.hasExtDebris));
            parms.Add(new SqlParameter("HasLeftVehicle", HPIR.hasLeftVehicle));
            parms.Add(new SqlParameter("IsSumpPumpOnSite", HPIR.isSumpPumpOnSite));
            parms.Add(new SqlParameter("IsSumpPumpOperational", HPIR.isSumpPumpOperational));
            parms.Add(new SqlParameter("IsPowerOn", HPIR.isPowerOn));
            parms.Add(new SqlParameter("IsCrawlSpaceFlooded", HPIR.isCrawlSpaceFlooded));
            parms.Add(new SqlParameter("HasIntWallCoveringDamage", HPIR.hasIntWallCoveringDamage));
            parms.Add(new SqlParameter("HasGraffiti", HPIR.hasGraffiti));
            parms.Add(new SqlParameter("HasViolationPosted", HPIR.hasViolationPosted));
            parms.Add(new SqlParameter("IsYardOk", HPIR.isYardOk));
            parms.Add(new SqlParameter("IsLawnCut", HPIR.isLawnCut));
            parms.Add(new SqlParameter("HasClearTreeLimbs", HPIR.hasClearTreeLimbs));
            parms.Add(new SqlParameter("HasDeadTreeRemoved", HPIR.hasDeadTreeRemoved));
            parms.Add(new SqlParameter("BuiltBefore1978Lead", HPIR.builtBefore1978Lead));
            parms.Add(new SqlParameter("IsPaintPealingLead", HPIR.isPaintPealingLead));
            parms.Add(new SqlParameter("IsHvacOkP3", HPIR.isHvacOkP3));
            parms.Add(new SqlParameter("IsElecOkP3", HPIR.isElecOkP3));
            parms.Add(new SqlParameter("IsApplOkP3", HPIR.isApplOkP3));
            parms.Add(new SqlParameter("IsPlumbOkP3", HPIR.isPlumbOkP3));
            parms.Add(new SqlParameter("IsWHeatOkP3", HPIR.isWHeatOkP3));
            parms.Add(new SqlParameter("IsSaniOkP3", HPIR.isSaniOkP3));
            parms.Add(new SqlParameter("IsRoofOkP3", HPIR.isRoofOkP3));
            parms.Add(new SqlParameter("CreatedBy", UserID));
            //parms.Add(new SqlParameter("DeactivatedBy", HPIR.deactivatedBy));
            //parms.Add(new SqlParameter("UpdatedBy", HPIR.updatedBy));
            dm.ExecuteNonQuery("spCslaInspHpir_Insert", parms);
        }
    }

}
