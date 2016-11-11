using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;

public class HttpServer
{
    private bool initialized;
    protected ErrorState m_LastError;
    protected bool m_SessionAlive;
    protected string m_SSID;
    protected const string m_SSIDName = "ssid";
    protected string m_Url;
    protected string m_UserAgent;

    public HttpServer(string useragent)
    {
        this.m_UserAgent = useragent;
        if (!this.initialized)
        {
            this.m_SSID = "";
            this.m_LastError = ErrorState.NoError;
            ServicePointManager.Expect100Continue = false;
            this.initialized = true;
        }
    }

    [return: MarshalAs(UnmanagedType.U1)]
    public unsafe bool CreateSession(string url)
    {
        byte num2;
        bool flag2;
        int num3 = (int) stackalloc byte[___CxxQueryExceptionSize()];
        this.m_Url = url;
        try
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(this.m_Url);
            request.KeepAlive = true;
            if (this.m_UserAgent != null)
            {
                request.UserAgent = this.m_UserAgent;
            }
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                this.m_LastError = ErrorState.HttpStatusCodeNotOK;
                num2 = 0;
                goto Label_01AA;
            }
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
            string str2 = reader.ReadToEnd();
            reader.Close();
            responseStream.Close();
            response.Close();
            if (str2.IndexOf("ssid" + "=") < 0)
            {
                this.m_LastError = ErrorState.SessionIdNotFound;
                num2 = 0;
                goto Label_01AA;
            }
            string str = str2.Substring(str2.IndexOf("ssid" + "="));
            this.m_SSID = str;
            if (str.IndexOf("\n") >= 0)
            {
                this.m_SSID = this.m_SSID.Substring(0, this.m_SSID.IndexOf("\n"));
            }
            this.m_SessionAlive = true;
            goto Label_019E;
        }
        catch (WebException exception1)
        {
            this.m_LastError = ErrorState.HttpCommunicationError;
            if (exception1.InnerException is SocketException)
            {
                this.m_LastError = ErrorState.SocketError;
            }
            flag2 = false;
        }
        catch when (?)
        {
            uint num = 0;
            ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num3);
            try
            {
                try
                {
                    this.m_LastError = ErrorState.Other;
                    return false;
                }
                catch when (?)
                {
                }
                if (num != 0)
                {
                    throw;
                }
            }
            finally
            {
                ___CxxUnregisterExceptionObject((void*) num3, (int) num);
            }
            goto Label_019E;
        }
        return flag2;
    Label_019E:
        this.m_LastError = ErrorState.NoError;
        return true;
    Label_01AA:
        return (bool) num2;
    }

    [return: MarshalAs(UnmanagedType.U1)]
    public unsafe bool DestroySession()
    {
        bool flag2;
        int num2 = (int) stackalloc byte[___CxxQueryExceptionSize()];
        if (!this.m_SessionAlive)
        {
            return true;
        }
        if (this.m_SSID.Trim() == "")
        {
            return false;
        }
        try
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(this.m_Url + "?" + this.m_SSID);
            request.KeepAlive = false;
            if (this.m_UserAgent != null)
            {
                request.UserAgent = this.m_UserAgent;
            }
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                byte num3 = 0;
                return (bool) num3;
            }
            response.Close();
            this.m_SSID = "";
            this.m_SessionAlive = false;
            goto Label_0128;
        }
        catch (WebException exception1)
        {
            this.m_LastError = ErrorState.HttpCommunicationError;
            if (exception1.InnerException is SocketException)
            {
                this.m_LastError = ErrorState.SocketError;
            }
            flag2 = false;
        }
        catch when (?)
        {
            uint num = 0;
            ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
            try
            {
                try
                {
                    this.m_LastError = ErrorState.Other;
                    return false;
                }
                catch when (?)
                {
                }
                if (num != 0)
                {
                    throw;
                }
            }
            finally
            {
                ___CxxUnregisterExceptionObject((void*) num2, (int) num);
            }
            goto Label_0128;
        }
        return flag2;
    Label_0128:
        this.m_LastError = ErrorState.NoError;
        return true;
    }

    public ErrorState GetError() => 
        this.m_LastError;

    private void InitializeInstanceFields()
    {
        if (!this.initialized)
        {
            this.m_SSID = "";
            this.m_LastError = ErrorState.NoError;
            ServicePointManager.Expect100Continue = false;
            this.initialized = true;
        }
    }

    [return: MarshalAs(UnmanagedType.U1)]
    public bool IsSessionAlive() => 
        this.m_SessionAlive;

    [return: MarshalAs(UnmanagedType.U1)]
    public unsafe bool Request(GETparameter[] parameters, ref HttpResponse response)
    {
        byte num6;
        bool flag2;
        int num7 = (int) stackalloc byte[___CxxQueryExceptionSize()];
        if (!this.m_SessionAlive)
        {
            this.m_LastError = ErrorState.SessionNotAlive;
            return false;
        }
        if (this.m_SSID.Trim() == "")
        {
            this.m_LastError = ErrorState.SessionIdNotValid;
            return false;
        }
        try
        {
            string requestUriString = this.m_Url + "?" + this.m_SSID;
            GETparameter[] tparameterArray = parameters;
            int index = 0;
            while (true)
            {
                if (index >= tparameterArray.Length)
                {
                    break;
                }
                GETparameter tparameter = tparameterArray[index];
                string key = tparameter.Key;
                if (key.Trim() != "")
                {
                    requestUriString = (requestUriString + "&" + key.Trim()) + "=" + HttpUtility.UrlEncode(tparameter.Value);
                }
                index++;
            }
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(requestUriString);
            request.KeepAlive = true;
            if (this.m_UserAgent != null)
            {
                request.UserAgent = this.m_UserAgent;
            }
            HttpWebResponse response2 = (HttpWebResponse) request.GetResponse();
            if (response2.StatusCode != HttpStatusCode.OK)
            {
                this.m_LastError = ErrorState.HttpStatusCodeNotOK;
                num6 = 0;
                goto Label_02FC;
            }
            Stream responseStream = response2.GetResponseStream();
            if (response2.ContentEncoding.ToLower().Contains("gzip"))
            {
                responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
            }
            else if (response2.ContentEncoding.ToLower().Contains("deflate"))
            {
                responseStream = new DeflateStream(responseStream, CompressionMode.Decompress);
            }
            if (response2.ContentType == "application/octet-stream")
            {
                response.ContentType = HttpResponseContentType.Bytes;
                int length = 0;
                int num4 = 0;
                byte[] buffer2 = new byte[0x10000];
                response.bytes = new byte[0];
                while (true)
                {
                    length = responseStream.Read(buffer2, 0, buffer2.Length);
                    if (length <= 0)
                    {
                        goto Label_0250;
                    }
                    num4 = length + num4;
                    byte[] bytes = response.bytes;
                    int num5 = bytes.Length;
                    byte[] destinationArray = new byte[num5];
                    Array.Copy(bytes, destinationArray, num5);
                    byte[] buffer3 = new byte[num4];
                    response.bytes = buffer3;
                    Array.Copy(destinationArray, 0, buffer3, 0, destinationArray.Length);
                    Array.Copy(buffer2, 0, response.bytes, destinationArray.Length, length);
                }
            }
            if (response2.ContentType != "text/html")
            {
                goto Label_0261;
            }
            response.ContentType = HttpResponseContentType.Text;
            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
            response.text = reader.ReadToEnd();
            reader.Close();
        Label_0250:
            responseStream.Close();
            response2.Close();
            goto Label_02F0;
        Label_0261:
            response.ContentType = HttpResponseContentType.None;
            this.m_LastError = ErrorState.BadContentType;
            num6 = 0;
            goto Label_02FC;
        }
        catch (WebException exception1)
        {
            this.m_LastError = ErrorState.HttpCommunicationError;
            if (exception1.InnerException is SocketException)
            {
                this.m_LastError = ErrorState.SocketError;
            }
            flag2 = false;
        }
        catch when (?)
        {
            uint num = 0;
            ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num7);
            try
            {
                try
                {
                    this.m_LastError = ErrorState.Other;
                    return false;
                }
                catch when (?)
                {
                }
                if (num != 0)
                {
                    throw;
                }
            }
            finally
            {
                ___CxxUnregisterExceptionObject((void*) num7, (int) num);
            }
            goto Label_02F0;
        }
        return flag2;
    Label_02F0:
        this.m_LastError = ErrorState.NoError;
        return true;
    Label_02FC:
        return (bool) num6;
    }

    [return: MarshalAs(UnmanagedType.U1)]
    public unsafe bool UploadFile(string filename, byte[] filedata, GETparameter[] parameters, ref HttpResponse response)
    {
        byte num5;
        bool flag2;
        int num7 = (int) stackalloc byte[___CxxQueryExceptionSize()];
        if (!this.m_SessionAlive)
        {
            this.m_LastError = ErrorState.SessionNotAlive;
            return false;
        }
        if (this.m_SSID.Trim() == "")
        {
            this.m_LastError = ErrorState.SessionIdNotValid;
            return false;
        }
        string str2 = "---------------------------" + DateTime.Now.Ticks.ToString("x");
        byte[] bytes = Encoding.ASCII.GetBytes("\r\n--" + str2 + "\r\n");
        try
        {
            string requestUriString = this.m_Url + "?" + this.m_SSID;
            GETparameter[] tparameterArray = parameters;
            int index = 0;
            while (true)
            {
                if (index >= tparameterArray.Length)
                {
                    break;
                }
                GETparameter tparameter = tparameterArray[index];
                string key = tparameter.Key;
                if (key.Trim() != "")
                {
                    requestUriString = (requestUriString + "&" + key.Trim()) + "=" + HttpUtility.UrlEncode(tparameter.Value);
                }
                index++;
            }
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(requestUriString);
            request.ContentType = "multipart/form-data; boundary=" + str2;
            request.Method = "POST";
            request.KeepAlive = true;
            if (this.m_UserAgent != null)
            {
                request.UserAgent = this.m_UserAgent;
            }
            request.Credentials = CredentialCache.DefaultCredentials;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            string s = $"Content-Disposition: form-data; name="uploadedfile"; filename="{filename}"
Content-Type: {"application/octet-stream"}

";
            byte[] buffer6 = Encoding.UTF8.GetBytes(s);
            requestStream.Write(buffer6, 0, buffer6.Length);
            requestStream.Write(filedata, 0, filedata.Length);
            byte[] buffer5 = Encoding.ASCII.GetBytes("\r\n--" + str2 + "--\r\n");
            requestStream.Write(buffer5, 0, buffer5.Length);
            requestStream.Close();
            HttpWebResponse response2 = (HttpWebResponse) request.GetResponse();
            if (response2.StatusCode != HttpStatusCode.OK)
            {
                this.m_LastError = ErrorState.HttpStatusCodeNotOK;
                num5 = 0;
                goto Label_03EF;
            }
            Stream responseStream = response2.GetResponseStream();
            if (response2.ContentEncoding.ToLower().Contains("gzip"))
            {
                responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
            }
            else if (response2.ContentEncoding.ToLower().Contains("deflate"))
            {
                responseStream = new DeflateStream(responseStream, CompressionMode.Decompress);
            }
            if (response2.ContentType == "application/octet-stream")
            {
                response.ContentType = HttpResponseContentType.Bytes;
                int length = 0;
                int num4 = 0;
                byte[] buffer2 = new byte[0x10000];
                response.bytes = new byte[0];
                while (true)
                {
                    length = responseStream.Read(buffer2, 0, buffer2.Length);
                    if (length <= 0)
                    {
                        goto Label_0346;
                    }
                    num4 = length + num4;
                    byte[] sourceArray = response.bytes;
                    int num6 = sourceArray.Length;
                    byte[] destinationArray = new byte[num6];
                    Array.Copy(sourceArray, destinationArray, num6);
                    byte[] buffer3 = new byte[num4];
                    response.bytes = buffer3;
                    Array.Copy(destinationArray, 0, buffer3, 0, destinationArray.Length);
                    Array.Copy(buffer2, 0, response.bytes, destinationArray.Length, length);
                }
            }
            if (response2.ContentType != "text/html")
            {
                goto Label_0355;
            }
            response.ContentType = HttpResponseContentType.Text;
            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
            response.text = reader.ReadToEnd();
            reader.Close();
        Label_0346:
            this.m_LastError = ErrorState.NoError;
            num5 = 1;
            goto Label_03EF;
        Label_0355:
            response.ContentType = HttpResponseContentType.None;
            this.m_LastError = ErrorState.BadContentType;
            num5 = 0;
            goto Label_03EF;
        }
        catch (WebException exception1)
        {
            this.m_LastError = ErrorState.HttpCommunicationError;
            if (exception1.InnerException is SocketException)
            {
                this.m_LastError = ErrorState.SocketError;
            }
            flag2 = false;
        }
        catch when (?)
        {
            uint num = 0;
            ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num7);
            try
            {
                try
                {
                    this.m_LastError = ErrorState.Other;
                    return false;
                }
                catch when (?)
                {
                }
                if (num != 0)
                {
                    throw;
                }
            }
            finally
            {
                ___CxxUnregisterExceptionObject((void*) num7, (int) num);
            }
            return false;
        }
        return flag2;
    Label_03EF:
        return (bool) num5;
    }

    public enum ErrorState
    {
        NoError,
        HttpStatusCodeNotOK,
        HttpCommunicationError,
        SocketError,
        SessionIdNotFound,
        SessionNotAlive,
        SessionIdNotValid,
        BadContentType,
        Other
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GETparameter
    {
        public string Key;
        public string Value;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HttpResponse
    {
        public HttpServer.HttpResponseContentType ContentType;
        public byte[] bytes;
        public string text;
    }

    public enum HttpResponseContentType
    {
        None,
        Bytes,
        Text
    }
}

