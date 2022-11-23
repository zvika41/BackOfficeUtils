namespace BackOfficeUtils
{
    public class ResetFeatureDataUtils : BaseUtils
    {
        #region --- Const ---

        private const string DOCUMENT_FEATURE_NAME = "feature_";
        private const string PERSONAL_AREA_DOC_PATH = "personal_area_feature.periodic_stats";
        private const string COLLECTIBLES_DOC_PATH = "collectibles_feature";
        private const string STORE_BONUS_DOC_PATH = "store_bonus_feature";
        private const string DAILY_MISSIONS_DOC_PATH = "daily_missions_feature";
        private const string LIVE_OPS_V2_DOC_PATH = "live_ops_feature";

        #endregion Const


        #region --- Properties ---

        public bool ShouldResetCollectiblesData { get; set; }
        public bool ShouldResetDailyMissionsData { get; set; }
        public bool ShouldResetLiveOpsV2Data { get; set; }
        public bool ShouldResetStoreBonusData { get; set; }

        #endregion Properties


        #region --- Public Methods ---

        public void TryResetFeatureData(int playerId)
        {
            string docName = DOCUMENT_FEATURE_NAME + playerId;

            if (ShouldResetCollectiblesData)
            {
                CouchBaseService.RemoveValueFromDictionary(docName, COLLECTIBLES_DOC_PATH);
            }
            else if (ShouldResetStoreBonusData)
            {
                CouchBaseService.RemoveValueFromDictionary(docName, STORE_BONUS_DOC_PATH);
            }
            else if (ShouldResetDailyMissionsData)
            {
                CouchBaseService.RemoveValueFromDictionary(docName, DAILY_MISSIONS_DOC_PATH);
            }
            else if (ShouldResetLiveOpsV2Data)
            {
                CouchBaseService.RemoveValueFromDictionary(docName, LIVE_OPS_V2_DOC_PATH);
            }
            else
            {
                CouchBaseService.RemoveValueFromDictionary(docName, PERSONAL_AREA_DOC_PATH);
            }
        }

        #endregion Public Methods
    }
}
