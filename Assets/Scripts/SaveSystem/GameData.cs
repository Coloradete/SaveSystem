namespace SaveSystem
{
    [System.Serializable]
    public class GameData
    {
        public static string savePath = "/gameTestData.coloradete";

        //Level section
        private int currentLevel;
    
        public int CurrentLevel => currentLevel;

        public GameData()
        {
            currentLevel = GameManager.CurrentLevel;
        }
    }
}
