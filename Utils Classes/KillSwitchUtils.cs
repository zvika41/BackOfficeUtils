using System.Runtime.InteropServices;

namespace BackOfficeUtils
{
    public class KillSwitchUtils : BaseUtils
    {
        #region --- Const ---

        public const string DAILY_MISSIONS_FEATURE_NAME = "DailyMissions";
        public const string PICKEM_FEATURE_NAME = "Pickem";
        public const string SLOT_EVENT_FEATURE_NAME = "SlotEvent";
        public const string COLLECTIBLES_FEATURE_NAME = "Collectibles";
        public const string DAILY_REWARDS_FEATURE_NAME = "DailyRewards";
        public const string STORE_BONUS_FEATURE_NAME = "StoreBonus";
        public const string LIVE_OPS_V2_FEATURE_NAME = "LiveOpsV2";

        private const string DAILY_MISSIONS_DOCUMENT_NAME = "daily_missions_config_1";
        private const string DAILY_MISSIONS_DOCUMENT_PATH = "canceled_sets.";
        private const string PICKEM_DOCUMENT_NAME = "pickem_info_1";
        private const string PICKEM_DOCUMENT_PATH = "canceled_games";
        private const string SLOT_EVENT_DOCUMENT_NAME = "excluded_feature_ids_slot_event_feature_1";
        private const string COLLECTIBLES_DOCUMENT_NAME = "excluded_feature_ids_collectibles_feature_1";
        private const string DAILY_REWARDS_DOCUMENT_NAME = "excluded_feature_ids_daily_rewards_feature_1";
        private const string STORE_BONUS_DOCUMENT_NAME = "excluded_feature_ids_store_bonus_feature_1";
        private const string LIVE_OPS_V2_DOCUMENT_NAME = "excluded_feature_ids_live_ops_feature_1";
        private const string EXCLUDE_DOCUMENT_PATH = "exclude_ids";

        #endregion Const


        #region --- Members ---

        private string _documentName;
        private string _documentPath;
        private bool _shouldKillSet;
        private readonly int[] _setValue;

        #endregion Members


        #region --- Constructor ---

        public KillSwitchUtils()
        {
            _setValue = new int[0];
        }

        #endregion


        #region --- Public Methods ---

        //if killSet is false we calling the clearSets method
        public void HandleFeature(string docName, bool killSet, [Optional] int setID)
        {
            switch (docName)
            {
                case DAILY_MISSIONS_FEATURE_NAME:
                    _documentName = DAILY_MISSIONS_DOCUMENT_NAME;
                    _documentPath = DAILY_MISSIONS_DOCUMENT_PATH;
                    break;
                case PICKEM_FEATURE_NAME:
                    _documentName = PICKEM_DOCUMENT_NAME;
                    _documentPath = PICKEM_DOCUMENT_PATH;
                    break;
                case SLOT_EVENT_FEATURE_NAME:
                    _documentName = SLOT_EVENT_DOCUMENT_NAME;
                    _documentPath = EXCLUDE_DOCUMENT_PATH;
                    break;
                case COLLECTIBLES_FEATURE_NAME:
                    _documentName = COLLECTIBLES_DOCUMENT_NAME;
                    _documentPath = EXCLUDE_DOCUMENT_PATH;
                    break;
                case DAILY_REWARDS_FEATURE_NAME:
                    _documentName = DAILY_REWARDS_DOCUMENT_NAME;
                    _documentPath = EXCLUDE_DOCUMENT_PATH;
                    break;
                case STORE_BONUS_FEATURE_NAME:
                    _documentName = STORE_BONUS_DOCUMENT_NAME;
                    _documentPath = EXCLUDE_DOCUMENT_PATH;
                    break;
                case LIVE_OPS_V2_FEATURE_NAME:
                    _documentName = LIVE_OPS_V2_DOCUMENT_NAME;
                    _documentPath = EXCLUDE_DOCUMENT_PATH;
                    break;
            }

            _shouldKillSet = killSet;

            if (_shouldKillSet)
            {
                KillFeatureSet(setID);
            }
            else
            {
                ClearSets();
            }
        }

        #endregion Public Methods


        #region --- Private Methods ---

        private void KillFeatureSet(int setID)
        {
            CouchBaseService.AddArrayValue(_documentName, _documentPath, setID);
        }

        private void ClearSets()
        {
            CouchBaseService.ReplaceDocumentValue(_documentName, _documentPath, _setValue);
        }

        #endregion Private Methods
    }
}
