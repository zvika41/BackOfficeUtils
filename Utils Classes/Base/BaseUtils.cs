using CouchBaseService;

namespace BackOfficeUtils
{
    public class BaseUtils
    {
        #region --- Enums ---

        public enum Environmet
        {
            Dev,
            Yellow,
            Green,
            Blue,
            Red,
            Black,
            Test
        };

        #endregion Enums


        #region --- Members ---

        private static BaseUtils _instance;
        private Service _service;
        private Environmet _environment;

        #endregion Members


        #region --- Properties ---

        public static BaseUtils Instance { get { return _instance; } }

        public Service CouchBaseService { get { return _service; } }

        public Environmet SelectedEnvironmet 
        { 
            get { return _environment; } 
            set { _environment = value; } 
        }

        #endregion Properties


        #region --- Constructor ---

        public BaseUtils()
        {
            _instance = this;

            if (_environment == Environmet.Dev)
            {
                _service = new Service(Env.Dev);
            }
            else if (_environment == Environmet.Test)
            {
                _service = new Service(Env.Stage);
            }
            else if (_environment == Environmet.Black)
            {
                _service = new Service(Env.Black);
            }
            else if (_environment == Environmet.Blue)
            {
                _service = new Service(Env.Blue);
            }
            else if (_environment == Environmet.Green)
            {
                _service = new Service(Env.Green);
            }
            else if (_environment == Environmet.Red)
            {
                _service = new Service(Env.Red);
            }
            else if (_environment == Environmet.Yellow)
            {
                _service = new Service(Env.Yellow);
            }
        }

        #endregion Constructor
    }
}
