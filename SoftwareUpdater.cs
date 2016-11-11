using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;

internal class SoftwareUpdater
{
    private AmountDownloadedChangedHandler <backing_store>OnAmountDownloadedChanged;
    private FileDownloadSizeObtainedHandler <backing_store>OnFileDownloadSizeObtained;
    protected string m_LastVersionSetupURI;
    protected string m_LastVersionStr;
    protected string m_name;
    protected string m_VersionInfoURL;

    public event AmountDownloadedChangedHandler OnAmountDownloadedChanged
    {
        [MethodImpl(MethodImplOptions.Synchronized)] add
        {
            this.<backing_store>OnAmountDownloadedChanged = (AmountDownloadedChangedHandler) Delegate.Combine(this.<backing_store>OnAmountDownloadedChanged, value);
        }
        [MethodImpl(MethodImplOptions.Synchronized)] remove
        {
            this.<backing_store>OnAmountDownloadedChanged = (AmountDownloadedChangedHandler) Delegate.Remove(this.<backing_store>OnAmountDownloadedChanged, value);
        }
        raise
        {
            AmountDownloadedChangedHandler handler = this.<backing_store>OnAmountDownloadedChanged;
            if (handler != null)
            {
                handler(value0);
            }
        }
    }

    public event FileDownloadSizeObtainedHandler OnFileDownloadSizeObtained
    {
        [MethodImpl(MethodImplOptions.Synchronized)] add
        {
            this.<backing_store>OnFileDownloadSizeObtained = (FileDownloadSizeObtainedHandler) Delegate.Combine(this.<backing_store>OnFileDownloadSizeObtained, value);
        }
        [MethodImpl(MethodImplOptions.Synchronized)] remove
        {
            this.<backing_store>OnFileDownloadSizeObtained = (FileDownloadSizeObtainedHandler) Delegate.Remove(this.<backing_store>OnFileDownloadSizeObtained, value);
        }
        raise
        {
            FileDownloadSizeObtainedHandler handler = this.<backing_store>OnFileDownloadSizeObtained;
            if (handler != null)
            {
                handler(value0);
            }
        }
    }

    public SoftwareUpdater(string name)
    {
        this.m_name = name;
        this.m_VersionInfoURL = "http://j2534.lt/VEI/VersionInfo.xml";
        this.m_LastVersionStr = null;
        this.m_LastVersionSetupURI = null;
    }

    [return: MarshalAs(UnmanagedType.U1)]
    public bool IsNewVersionAvailable()
    {
        Stream stream = new WebClient().OpenRead(this.m_VersionInfoURL);
        XmlTextReader reader = new XmlTextReader(new StreamReader(stream));
        XmlDocument document = new XmlDocument();
        document.Load(reader);
        stream.Close();
        XmlNodeList list = document.SelectNodes("VersionInfo/Product");
        int index = 0;
        if (0 < list.Count)
        {
            do
            {
                if (list.Item(index).SelectSingleNode("Name").InnerText == this.m_name)
                {
                    this.m_LastVersionStr = list.Item(index).SelectSingleNode("Version").InnerText;
                    this.m_LastVersionSetupURI = list.Item(index).SelectSingleNode("DownloadURL").InnerText;
                    break;
                }
                index++;
            }
            while (index < list.Count);
        }
        return ((!string.IsNullOrEmpty(this.m_LastVersionStr) && !string.IsNullOrEmpty(this.m_LastVersionSetupURI)) && (new Version(this.m_LastVersionStr) > Assembly.GetEntryAssembly().GetName().Version));
    }

    public void Update()
    {
        int num2;
        string tempFileName = Path.GetTempFileName();
        FileStream stream2 = new FileStream(tempFileName, FileMode.Create, FileAccess.Write);
        WebResponse response = WebRequest.Create(this.m_LastVersionSetupURI).GetResponse();
        uint modopt(IsLong) contentLength = (uint modopt(IsLong)) ((int) response.ContentLength);
        FileDownloadSizeObtainedHandler handler3 = this.<backing_store>OnFileDownloadSizeObtained;
        if (handler3 != null)
        {
            handler3(contentLength);
        }
        Stream responseStream = response.GetResponseStream();
        int num = 0;
        byte[] buffer = new byte[0x400];
        do
        {
            num2 = responseStream.Read(buffer, 0, buffer.Length);
            stream2.Write(buffer, 0, num2);
            num = num2 + num;
            if (num > response.ContentLength)
            {
                uint modopt(IsLong) size = (uint modopt(IsLong)) ((int) response.ContentLength);
                AmountDownloadedChangedHandler handler2 = this.<backing_store>OnAmountDownloadedChanged;
                if (handler2 != null)
                {
                    handler2(size);
                }
            }
            else
            {
                AmountDownloadedChangedHandler handler = this.<backing_store>OnAmountDownloadedChanged;
                if (handler != null)
                {
                    handler((uint modopt(IsLong)) num);
                }
            }
        }
        while (num2 != 0);
        responseStream.Close();
        stream2.Close();
        string path = Path.Combine(Path.GetTempPath(), Path.GetFileName(this.m_LastVersionSetupURI)).Replace("%20", " ");
        if (System.IO.File.Exists(path))
        {
            System.IO.File.Delete(path);
        }
        System.IO.File.Move(tempFileName, path);
        new Process { StartInfo = { FileName = path } }.Start();
    }

    public delegate void AmountDownloadedChangedHandler(uint modopt(IsLong) size);

    public delegate void FileDownloadSizeObtainedHandler(uint modopt(IsLong) size);
}

