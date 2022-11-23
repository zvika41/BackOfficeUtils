namespace BackOfficeUtils
{
    public class PromotionReuserUtils : BaseUtils
    {
        #region --- Const ---

        private const string DOCUMENT_NAME = "player_system_message_x_-";
        private const string MODIFAY_PLAYER_ID_VALUE = "x";
        private const string MODIFAY_MESSAGE_ID_VALUE = "-";

        private const string DOCUMENT_VALUE = "claimed";


        #endregion Const


        #region --- Public Methods ---

        public void ChangeDocumentValue(string playerID, string messageID)
        {
            string documentName = GetDocumentName(playerID, messageID);

            CouchBaseService.ReplaceDocumentValue(documentName, DOCUMENT_VALUE, false);
        }

        #endregion Public Methods


        #region --- Private Methods ---

        private string GetDocumentName(string playerID, string messageID)
        {
            string modifyDocumentName = DOCUMENT_NAME.Replace(MODIFAY_PLAYER_ID_VALUE, playerID);

            return modifyDocumentName.Replace(MODIFAY_MESSAGE_ID_VALUE, messageID);
        }

        #endregion Private Methods
    }
}
