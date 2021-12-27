using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace WpfApp1.Function
{
    class SpeedTest
    {
        private string fileUrl = "https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1601624741273&di=47fde5e5923a8d19905f20296fd8f771&imgtype=0&src=http%3A%2F%2Fbenyouhuifile.it168.com%2Fforum%2F201210%2F05%2F081416s8dgs8zgb85ylraz.jpg";
        private string path = @"/vs file/CleanTool/WpfApp1/TempFile/";
        private string fileName = "TempTest1.jpg";
        Stopwatch stopwatch;
        public double DownloadTempFile()
        {
            stopwatch = new Stopwatch();
            stopwatch.Reset();
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(fileUrl);
                WebResponse webResponse = httpWebRequest.GetResponse();
                Stream stream = webResponse.GetResponseStream();
                stopwatch.Start();
                Stream fileStream = new FileStream(path+fileName, FileMode.Create,FileAccess.ReadWrite);
                byte[] buffer = new byte[983040];
                int streamLength = stream.Read(buffer, 0, buffer.Length);
                while ( streamLength > 0)
                {
                    fileStream.Write(buffer, 0, buffer.Length);
                    streamLength = stream.Read(buffer, 0, buffer.Length);
                }
                stopwatch.Stop();
                long timeCount = stopwatch.ElapsedMilliseconds;
                double timeInSecond = timeCount / 1000.0;
                return timeInSecond;
            }
            catch(IOException ioException)
            {
                Console.WriteLine(ioException.Message);
                return -1.0;
            }
            catch(WebException webException)
            {
                Console.WriteLine(webException.Message);
                return -1.0;
            }
            
            
        }
    }
}
