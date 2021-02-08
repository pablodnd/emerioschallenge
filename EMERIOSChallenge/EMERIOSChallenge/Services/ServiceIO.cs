using System.IO;

namespace EMERIOSChallenge
{
    public class ServiceIO : IServiceIO
    {
        public ServiceIO()
        { }

        public string ReadFile(string path)
        {
            using (StreamReader stream = File.OpenText(path))
            {
                return stream.ReadToEnd();
            }
        }
    }
}
