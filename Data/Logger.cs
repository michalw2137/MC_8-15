using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Data
{
    public class Logger
    {
        private string filePath;
        private IBall ball;

        public Logger(IBall _ball)

        {
            ball = _ball;
            string tempPath = Path.GetTempPath();
            filePath = tempPath + "ballsLogs\\ball" + ball.id + ".json";
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch (IOException e) {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
            //File.Create(filePath);
        }

        public void log()
        {
            string output = JsonConvert.SerializeObject(ball);
            File.AppendAllText(filePath, output + "\n");
        }
    }
}
