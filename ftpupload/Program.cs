using System;
using System.IO;
using System.Net;
using System.Text;
using FtpLib;
namespace ftpupload
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {              
                string strSource = "D:\\Syed\\" + "Sample.txt";
                string ftpusername = "ftpuser";
                string ftppassword = "ftp123";
                string ip = "172.26.50.199";//provide ur ftp server ip address
                int FtpPort = Convert.ToInt16(21);
                string RemoteFileName = "Notifications\\sample.txt";
                using (FtpConnection _ftp = new FtpConnection(ip, FtpPort, ftpusername, ftppassword))
                {
                    try
                    {
                        string str = Path.GetFullPath("D:\\Syed\\sample.txt");
                        _ftp.Open();
                        _ftp.Login();
                        _ftp.PutFile(strSource, RemoteFileName);
                    }
                    catch (FtpException ex)
                    {
                        throw ex;
                    }
                }
                Program obj = new Program();
                obj.GetFile();
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void GetFile()
        {
           
            string Newlocation = "";           
            string ftpusername = "ftpuser";
            string ftppassword = "ftp123";
            string ip = "172.26.50.199";
            int FtpPort = Convert.ToInt16("21");
            string Actfile = "sample.txt";


            int cnt = Actfile.LastIndexOf('.');
            string Extn = Actfile.Substring(Actfile.LastIndexOf('.'), Actfile.Length - Actfile.LastIndexOf('.'));
            using (FtpConnection _ftp = new FtpConnection(ip, FtpPort, ftpusername, ftppassword))
            {
                try
                {
                    _ftp.Open();
                    _ftp.Login();


                    string Ftpfile = "Notifications\\sample.txt";
                    Newlocation = "D:\\Syed\\Downloaded";
                   
                    _ftp.GetFile(Ftpfile, Newlocation + "\\" + "sample.txt", false);

                }
                catch (FtpException ex)
                {
                    throw ex;
                }
                finally
                {
                    _ftp.Close();

                    string strDURL = "D:\\Syed\\Downloaded\\sample.txt";
                    System.IO.FileInfo toDownload = new System.IO.FileInfo(strDURL);
                }
            }

        }
    }
}
