namespace BackOfficeUtils
{
    public class ReClaimDailyMissionsRewardsUtils : BaseUtils
    {
        #region --- Const ---

        private const string DOCUMENT_NAME = "feature_";
        private const string CLAIM_MISSION_PATH = "daily_missions_feature.active_set.missions.claimed";
        private const string CLAIM_TODAY_REWARD_PATH = "daily_missions_feature.active_daily_reward.claimed";

        #endregion Const


        #region --- Members ---

        private string _documentName;

        #endregion Members


        #region --- Public Methods ---

        public void ReClaimMissionReward(int playerId, int missionId)
        {
            _documentName = GetDocument(playerId);
            string finalPath = CLAIM_MISSION_PATH.Insert(43, missionId.ToString());

            CouchBaseService.ReplaceDocumentValue(_documentName, finalPath, false);
        }

        public void ReClaimTodayReward(int playerId)
        {
            _documentName = GetDocument(playerId);

            CouchBaseService.ReplaceDocumentValue(_documentName, CLAIM_TODAY_REWARD_PATH, false);
        }

        #endregion Public Methods


        #region --- Private Methods ---

        private string GetDocument(int playerId)
        {
            return DOCUMENT_NAME + playerId;
        }

        #endregion Private Methods
    }
}
