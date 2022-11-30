namespace Src.Player.Input
{
    public class PlayerInput
    {
        private static PlayerInput _instance;
        
        public PlayerControls Controls { get; private set; }

        private PlayerInput()
        {
            Controls = new PlayerControls();
            Controls.Enable();
        }

        ~PlayerInput()
        {
            Controls.Disable();
        }

        public static PlayerInput GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PlayerInput();
            }
            
            return _instance;
        }
    }
}