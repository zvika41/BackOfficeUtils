using System;

namespace BackOfficeUtils
{
    public class DeleteUserUtils : BaseUtils
    {
        #region --- Const ---

        private const string DOCUMENT_NAME = "system_info_device_id";
        private const string DOCUMENT_FIELD_NAME = "system_info_device_guest_";
        private const string DOCUMENT_FIELD_VALUE = "player_";

        private const string EXCEPTION_MESSAGE = "Document does not exsits";

        #endregion Const


        #region --- Members ---

        private string _documentName;

        #endregion Members


        #region --- Public Methods ---

        public void TryDeleteDocument(string playerInput)
        {
            if (IsDocumentFound(playerInput))
            {
                CouchBaseService.DeleteDocument(_documentName);
            }
        }

        #endregion Public Methods


        #region --- Private Methods ---

        private bool IsDocumentFound(string playerInput)
        {
            bool isDocumentFound;
            string playerID = DOCUMENT_FIELD_VALUE + playerInput;
            string mapperID = CouchBaseService.GetSubDocumentValue(playerID, DOCUMENT_NAME);

            if (string.IsNullOrEmpty(mapperID))
            {
                isDocumentFound = false;
                throw new ArgumentException(EXCEPTION_MESSAGE);
            }
            else
            {
                isDocumentFound = true;
                _documentName = DOCUMENT_FIELD_NAME + mapperID;
            }

            return isDocumentFound;
        }

        #endregion Private Methods
    }
}
