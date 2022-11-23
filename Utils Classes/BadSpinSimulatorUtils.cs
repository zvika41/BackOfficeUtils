namespace BackOfficeUtils
{
    public class BadSpinSimulatorUtils : BaseUtils
    {
        #region --- Const ---

        private const string PLAYER_DOCUMENT_NAME = "player_";
        private const string DOCUMENT_FIELD_NAME = "total_lifetime_spins";
        private const string DOCUMENT_PATH = "total_lifetime_spins.";
        private const int DECREMENT_SPIN_VALUE = 1;

        #endregion


        #region --- Members ---

        private string _documentName;

        #endregion Members


        #region --- Public Methods ---

        public void Simulate(string playerID)
        {
            int totalLifetimeSpins = GetSpinDecrementedValue(playerID);
            CouchBaseService.ReplaceDocumentValue(_documentName, DOCUMENT_PATH, totalLifetimeSpins);
        }

        #endregion Public Methods


        #region --- Private Methods ---

        private int GetSpinDecrementedValue(string playerID)
        {
            int spinValue = GetSubDocumentValue(playerID);

            return spinValue - DECREMENT_SPIN_VALUE;
        }

        private int GetSubDocumentValue(string playerID)
        {
            _documentName = GetDocumentName(playerID);

            return int.Parse(CouchBaseService.GetSubDocumentValue(_documentName, DOCUMENT_FIELD_NAME));
        }

        private string GetDocumentName(string playerID)
        {
            return PLAYER_DOCUMENT_NAME.Insert(7, playerID);
        }

        #endregion Private Methods
    }
}
