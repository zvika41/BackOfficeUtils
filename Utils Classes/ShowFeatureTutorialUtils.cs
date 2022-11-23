namespace BackOfficeUtils
{
    public class ShowFeatureTutorialUtils : BaseUtils
    {
        #region --- Const ---

        private const string DOCUMENT_FIELD_VALUE_NAME = "feature_";
        private const string DAILY_MISSIONS_DOCUMENT_PATH = "daily_missions_feature.show_tutorial.";
        private const string FORTUNE_FAIRY_DOCUMENT_PATH = "pickem_feature.show_tutorial.";
        private const string TREASURE_HUNT_DOCUMENT_PATH = "treasure_hunt.show_tutorial.";

        #endregion Const


        #region --- Properties ---

        public bool ShouldShowDailyMissionsTutorial { get; set; }

        public bool ShouldShowFortuneFairyTutorial { get; set; }

        public bool ShouldShowTreasureHuntTutorial { get; set; }

        #endregion Properties 


        #region --- Public Methods ---

        public void ShowTutorial(string playerID)
        {
            string documentName = GetDocumentName(playerID);
            string path = HandleDocumentPath();
            object shouldShowTutorial = true;
            CouchBaseService.ReplaceDocumentValue(documentName, path, shouldShowTutorial);
        }

        #endregion Public Methods


        #region --- Private Methods ---

        private string HandleDocumentPath()
        {
            string path = "";

            if (ShouldShowDailyMissionsTutorial)
            {
                path = DAILY_MISSIONS_DOCUMENT_PATH;
            }
            else if (ShouldShowFortuneFairyTutorial)
            {
                path = FORTUNE_FAIRY_DOCUMENT_PATH;
            }
            else if (ShouldShowTreasureHuntTutorial)
            {
                path = TREASURE_HUNT_DOCUMENT_PATH;
            }

            return path;
        }

        private string GetDocumentName(string playerID)
        {
            return DOCUMENT_FIELD_VALUE_NAME + playerID;
        }

        #endregion Private Methods
    }
}
