using System;
using System.Diagnostics;
using WpfApp1.Entity;
using QRCoder;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Media.Imaging;
using System.Windows.Interop;

namespace WpfApp1.Function
{
    class WifiPasswordFunction
    {
        WifiInfo wifiInfo = new WifiInfo();
        Bitmap bitmap;
        BitmapSource bitmapSource;
        public void GetSSID()
        {
            string order = "netsh wlan show interfaces | findstr SSID";
            Process process = new Process();
            process.StartInfo.FileName = @"powershell.exe";
            process.StartInfo.Arguments = order;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            string tempResult=process.StandardOutput.ReadToEnd();
            string removeResult = tempResult.Replace("\r\n", "").Replace(" ", "");
            int startIndex,endIndex;
            try
            {
                startIndex = removeResult.IndexOf("SSID:");
                if (startIndex == -1)
                {
                    wifiInfo.SSID = string.Empty;
                }
                string tempstr = removeResult.Substring(startIndex + 5);
                endIndex = tempstr.IndexOf("BSSID");
                if (endIndex == -1)
                {
                    wifiInfo.SSID = string.Empty;
                }

                wifiInfo.SSID = tempstr.Remove(endIndex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetWifiType()
        {
            string order = "netsh wlan show interfaces";
            Process process = new Process();
            process.StartInfo.FileName = @"powershell.exe";
            process.StartInfo.Arguments = order;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            string tempResult = process.StandardOutput.ReadToEnd();
            string removeResult = tempResult.Replace("\r\n", "").Replace(" ", "");
            int startIndex, endIndex;
            try
            {
                startIndex = removeResult.IndexOf("身份验证:");
                if (startIndex == -1)
                {
                    wifiInfo.Type = string.Empty;
                }
                string tempstr = removeResult.Substring(startIndex + 5);
                endIndex = tempstr.IndexOf("-");
                if (endIndex == -1)
                {
                    wifiInfo.Type = string.Empty;
                }

                wifiInfo.Type = tempstr.Remove(endIndex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public WifiInfo SetPassword()
        {
            string order = "netsh wlan show profile " + wifiInfo.SSID + " key=clear";
            Process process = new Process();
            process.StartInfo.FileName = @"powershell.exe";
            process.StartInfo.Arguments = order;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            string tempResult = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            string removeResult = tempResult.Replace("\r\n", "").Replace(" ", "");
            int startIndex, endIndex;
            try
            {
                startIndex = removeResult.IndexOf("关键内容:");
                if (startIndex == -1)
                {
                    wifiInfo.Password = string.Empty;
                }
                string tempstr = removeResult.Substring(startIndex + 5);
                endIndex = tempstr.IndexOf("费用");
                if (endIndex == -1)
                {
                    wifiInfo.Password = string.Empty;
                }

                wifiInfo.Password = tempstr.Remove(endIndex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
          
            return wifiInfo;
        }

        public Bitmap MyQRCode()
        {
            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData 
                = qRCodeGenerator.CreateQrCode("WIFI:S:"+wifiInfo.SSID+";P:"+wifiInfo.Password+";T:"+wifiInfo.Type+";", 
                QRCodeGenerator.ECCLevel.H);
            QRCode qRCode = new QRCode(qRCodeData);
            bitmap = qRCode.GetGraphic(20, Color.Black, Color.White,true);
            return bitmap;
        }

        public BitmapSource BitmapToImage(Bitmap bitmap)
        {
            bitmapSource 
                = Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(),IntPtr.Zero,
                System.Windows.Int32Rect.Empty,BitmapSizeOptions.FromEmptyOptions());
            return bitmapSource;
           
        }

        public void ImageRecycle()
        {
            bitmap.Dispose();
            bitmapSource=null;
            GC.Collect();
        }


    }
}
