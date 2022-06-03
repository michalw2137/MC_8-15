using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Data
{
    public class Logger
    {
        private string filePath;
        private IBall ball;
        private readonly JArray fileDataArray = new JArray();

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

        public async void log()
        {

            //fileDataArray.Add(JObject.FromObject(ball));
            string output = JsonConvert.SerializeObject(ball);
            File.AppendAllText(filePath, DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff") + " " + output + "\n");
        }
    }
}
