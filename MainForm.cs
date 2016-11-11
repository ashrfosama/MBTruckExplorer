namespace TruckExplorer
{
    using <CppImplementationDetails>;
    using cliext;
    using cliext.impl;
    using Microsoft.VisualBasic.PowerPacks;
    using Microsoft.VisualC.StlClr;
    using MigraDoc.DocumentObjectModel;
    using MigraDoc.DocumentObjectModel.Tables;
    using MigraDoc.Rendering;
    using msclr.interop;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Reflection;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Runtime.ExceptionServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;

    public class MainForm : Form
    {
        private Button btnAddKey;
        private Button btnCarLeft;
        private Button btnCarRight;
        private Button btnConnect;
        private Button btnDASPwdCalc;
        private Button btnDetectECUs;
        private Button btnDisconnect;
        private Button btnEraseAddKey;
        private Button btnEraseFaultCodes;
        private Button btnExit;
        private Button btnExtraRunOperation;
        private Button btnFDOKCalculate;
        private Button btnGenerateFullFaultsReport;
        private Button btnGetKeysInfo;
        private Button btnKeysRunOperation;
        private Button btnMemAnalyse;
        private Button btnMemAnalyseAndRead;
        private Button btnMemReadEEPROMA;
        private Button btnMemReadEEPROMB;
        private Button btnMemReadFlash;
        private Button btnMemRunOperation;
        private Button btnMemWriteEEPROMA;
        private Button btnMemWriteEEPROMB;
        private Button btnMemWriteFlash;
        private Button btnReadDeviceInfo;
        private Button btnReadFaultCodes;
        private Button btnUpdateDevice;
        private Button btnUpdateSoftware;
        private Button btnVeDocCalculate;
        private Button btnVeDocPrepare;
        private ComboBox cbxDASPwdType;
        private ComboBox cbxDetectedECUs;
        private ComboBox cbxExtraOperation;
        private ComboBox cbxExtraOperationParameter;
        private ComboBox cbxFDOKCalcType;
        private ComboBox cbxKeysOperation;
        private ComboBox cbxLanguage;
        private ComboBox cbxMemECU;
        private ComboBox cbxMemOperation;
        private ComboBox cbxSystemVoltage;
        private ComboBox cbxVeDocCalcType;
        private DataGridViewTextBoxColumn clmnCode2;
        private DataGridViewTextBoxColumn clmnDescription2;
        private IContainer components;
        private OpenFileDialog dlgOpenFile;
        private SaveFileDialog dlgSaveFile;
        private TextBox edDASPwd;
        private TextBox edExtraOperationParameter;
        private TextBox edFDOKNewResult;
        private TextBox edFDOKOldResult;
        public TextBox edLog;
        private TextBox edVeDocID;
        private TextBox edVeDocNumOfKeys;
        private TextBox edVeDocResult;
        private TextBox edVeDocRnd;
        private TextBox edVeDocTransponderCode;
        private TextBox edVeDocVIN;
        private GroupBox gbxInformation;
        private DataGridView gridFaultCodes;
        private PictureBox imgCar;
        private ImageList imglstTrucks;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label18;
        private Label label19;
        private Label label2;
        private Label label21;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label lblAboutCopyright;
        private Label lblAboutVersion;
        private Label lblCar;
        private ToolStripStatusLabel lblCurrentVEIInfo;
        private Label lblDeviceInfo;
        private Label lblExtraOperation;
        private Label lblExtraOperationParameter;
        private Label lblExtraWarning;
        private Label lblKeysInfo;
        private Label lblKeysOperation;
        private Label lblKeysWarning;
        private Label lblMemInfo;
        private Label lblMemWarning;
        private Label lblOperations;
        private Label lblSystemVoltage;
        private LineShape lineShape1;
        private LineShape lineShape10;
        private LineShape lineShape11;
        private LineShape lineShape12;
        private LineShape lineShape16;
        private LineShape lineShape17;
        private LineShape lineShape18;
        private LineShape lineShape2;
        private LineShape lineShape3;
        private LineShape lineShape4;
        private LineShape lineShape5;
        private LineShape lineShape6;
        private LineShape lineShape7;
        private LineShape lineShape9;
        private LinkLabel lnkAboutHomepage;
        private LinkLabel lnkAboutRegistration;
        private LinkLabel lnkAboutSupport;
        private bool m_AlreadyShowedSupportExpiredMsg;
        private bool m_AlreadyTriedAutomaticDeviceUpdate;
        private bool m_AutomaticDeviceUpdate;
        private bool m_AutomaticSoftwareUpdate;
        private MCUDerivative_t m_BootstrapMCU;
        private bool m_CanAccessFR;
        private bool m_CarChangeBtnPrevState;
        private int modopt(IsConst) m_CheckDeviceUpdatePeriodInDays;
        private int modopt(IsConst) m_CheckSoftwareUpdatePeriodInDays;
        private bool m_ConnectBtnPrevState;
        private ConnectionState_t m_ConnectionState;
        private int m_CurrentECUIdx;
        public string m_CurrentVersionPostfix;
        private string m_CurrentWriteFlashCompletedStr;
        private Command_t m_CurrentWriteFlashFailedCmd;
        private string m_CurrentWriteFlashFailedStr;
        private bool m_CurrentWriteFlashHaveToCheckMainCRC;
        private Command_t m_CurrentWriteFlashOkCmd;
        private string m_CurrentWriteFlashOperationStr;
        private Command_t m_CurrentWriteFlashProgressCmd;
        private byte *() m_CurrentWriteFlashProgressFnc;
        private Command_t m_CurrentWriteFlashStartCmd;
        private DASPasswordType_t m_DASPwdType;
        private readonly map<System::String ^,int> modreq(IsByValue) m_DASPwdTypes;
        private ECUInfo[] m_DetectedECU;
        private bool m_DeviceExpireSoon;
        private uint modopt(IsLong) m_DeviceID;
        private int m_DeviceSN;
        private ushort m_DeviceStatus;
        private ushort m_DeviceTrialDaysLeft;
        private string m_DeviceUpdateURL;
        private uint modopt(IsLong) m_DirectCableSN;
        private bool m_DisconnectBtnPrevState;
        private Dictionary<TruckType_t, ECUInfo[]> m_ECUInfo;
        private bool m_EngineEnabled;
        private readonly ExtraTab modreq(IsByValue) m_ExtraTab = new ExtraTab();
        private ResourceManager m_FaultCodesResource;
        private uint modopt(IsLong) m_FDOKID;
        private bool m_FDOKIDValid;
        private ushort m_FDOKRnd;
        private bool m_FDOKRndValid;
        private string m_FFRPTMControlUnitVer;
        private string m_FFRPTMEngineNumber;
        private string m_FFRPTMItemNumber;
        private string m_FFRPTMManufacturerCode;
        private string m_FFRPTMManufacturerSoft;
        private string m_FFRPTMVehicleNumber;
        private bool m_FRLicenseEnabled;
        private PdfDocumentRenderer m_GeneratedPDFReport;
        public ushort m_HwVersion;
        private bool m_HybridLicenseEnabled;
        private bool m_IsBootstrapMode;
        private bool m_IsDirectConnection;
        private readonly KeysTab modreq(IsByValue) m_KeysTab = new KeysTab();
        private Dictionary<string, string> m_Languages;
        private string m_LastOperationStr;
        public ushort m_LdrVersion;
        private string m_MainCaption;
        private string m_MainCaptionFormat;
        private bool m_MANEnabled;
        private MANMainECU_t m_MANMainECU;
        private bool m_MBEnabled;
        private readonly MemoryTab modreq(IsByValue) m_MemoryTab = new MemoryTab();
        private int modopt(IsConst) m_MinimalDeviceVersion;
        private string m_MRMotorNumber;
        private CustomMsgBox m_msgbox;
        private bool m_OperationRunning;
        private byte m_ProductID;
        private ResourceManager m_Resources;
        private bool m_SelectedTabPrevState;
        private Settings m_Settings;
        private bool m_ShowFRInfo;
        public ushort m_SwVersion;
        private int m_SystemVoltage;
        public static MainForm m_this = null;
        private bool m_TRICORELicenseEnabled;
        private TruckType_t m_TruckType;
        private string m_UpdateAgent;
        private string m_UpdateAgentFormat;
        private readonly map<System::String ^,unsigned char> modreq(IsByValue) m_VeDocCalcTypes;
        private bool m_VeDocCryptoKeySetWasCalled;
        private string m_VIN;
        private bool m_WasIgnitionChanged;
        private bool m_WatchIgnitionChange;
        private MaskedTextBox maskedFDOKID;
        private MaskedTextBox maskedFDOKRnd;
        private ToolStripProgressBar pbarProgress;
        private PictureBox pictureBox1;
        private Panel pnlAbout;
        private Panel pnlFaultCodes;
        private ShapeContainer shapeContainer1;
        private ShapeContainer shapeContainer10;
        private ShapeContainer shapeContainer3;
        private ShapeContainer shapeContainer4;
        private ShapeContainer shapeContainer5;
        private ShapeContainer shapeContainer7;
        private ShapeContainer shapeContainer8;
        private StatusStrip strStatus;
        private TabControl tabctlActions;
        private TabPage tabDASPwdCalc;
        private TabPage tabExtra;
        private TabPage tabFaultCodes;
        private TabPage tabFDOKCalc;
        private TabPage tabLearnKeys;
        private TabPage tabMemory;
        private TabPage tabSettings;
        private TabPage tabVeDocCalc;
        private ToolStripStatusLabel toolStripStatusLabel1;

        public MainForm()
        {
            map<System::String ^,unsigned char> modopt(IsConst) local14 = new map<System::String ^,unsigned char>();
            try
            {
                this.m_VeDocCalcTypes = local14;
                map<System::String ^,int> modopt(IsConst) local13 = new map<System::String ^,int>();
                try
                {
                    this.m_DASPwdTypes = local13;
                    this.m_CheckSoftwareUpdatePeriodInDays = 15;
                    this.m_CheckDeviceUpdatePeriodInDays = 15;
                    this.m_DeviceUpdateURL = "http://j2534.lt/VEI/MBTruckExplorer/update.php";
                    this.m_CurrentVersionPostfix = "";
                    this.m_MainCaptionFormat = "Truck Explorer v{0}";
                    this.m_UpdateAgentFormat = "TruckExplorer v{0}";
                    this.m_AlreadyTriedAutomaticDeviceUpdate = false;
                    this.m_MinimalDeviceVersion = 0x1236;
                    this.m_AlreadyShowedSupportExpiredMsg = false;
                    base..ctor();
                    try
                    {
                        BidirectionalIterator<cliext::impl::tree<cliext::impl::map_traits<System::String ^,int,0,0,0> > > local7;
                        BidirectionalIterator<cliext::impl::tree<cliext::impl::map_traits<System::String ^,unsigned char,0,0,0> > > local11;
                        ECUInfo info49;
                        ECUInfo info50;
                        ECUInfo info51;
                        ECUInfo info52;
                        ECUInfo info53;
                        ECUInfo info54;
                        ECUInfo info55;
                        ECUInfo info56;
                        ECUInfo info57;
                        ECUInfo info58;
                        ECUInfo info59;
                        ECUInfo info60;
                        ECUInfo info61;
                        ECUInfo info62;
                        this.m_Resources = new ResourceManager("TruckExplorer.TruckExplorer", Assembly.GetExecutingAssembly());
                        Dictionary<string, string> modopt(IsConst) dictionary = new Dictionary<string, string>();
                        this.m_Languages = dictionary;
                        dictionary.Add("English", "en");
                        this.m_Languages.Add("Deutsch", "de");
                        this.m_Languages.Add("Fran\x00e7ais", "fr");
                        this.m_Languages.Add("Espa\x00f1ol", "es");
                        this.m_Languages.Add("Portugu\x00eas", "pt");
                        this.m_Languages.Add("Русский", "ru");
                        this.m_Languages.Add("Lietuvių", "lt");
                        this.m_Languages.Add("العربية", "ar");
                        this.m_Languages.Add("فارسی", "fa-IR");
                        Settings modopt(IsConst) settings = new Settings();
                        this.m_Settings = settings;
                        if (settings.SettingsUpgradeRequired)
                        {
                            this.m_Settings.Upgrade();
                            this.m_Settings.SettingsUpgradeRequired = false;
                        }
                        try
                        {
                            Thread.CurrentThread.CurrentUICulture = new CultureInfo(this.m_Languages[this.m_Settings.UserLanguage]);
                            if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                            {
                                this.RightToLeft = RightToLeft.Yes;
                                this.RightToLeftLayout = true;
                            }
                        }
                        catch (KeyNotFoundException)
                        {
                            this.MessageBoxThreadSafe($"Cannot find translation for {this.m_Settings.UserLanguage}! Please reinstall application.", "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        this.InitializeComponent();
                        this.UpdateGridFaultCodesHeight();
                        CommunicationLogInit(true);
                        int num = 0;
                        if (0 < this.tabctlActions.TabPages.Count)
                        {
                            do
                            {
                                if (this.tabctlActions.TabPages[num] != this.tabSettings)
                                {
                                    this.tabctlActions.TabPages[num].Enabled = false;
                                }
                                num++;
                            }
                            while (num < this.tabctlActions.TabPages.Count);
                        }
                        string str = (Assembly.GetEntryAssembly().GetName().Version.ToString(2) + " (build " + Assembly.GetEntryAssembly().GetName().Version.Build) + ")" + this.m_CurrentVersionPostfix;
                        this.m_MainCaption = string.Format(this.m_MainCaptionFormat, str);
                        this.m_UpdateAgent = string.Format(this.m_UpdateAgentFormat, str);
                        if (Thread.CurrentThread.CurrentUICulture.EnglishName != "English")
                        {
                            this.m_UpdateAgent = this.m_UpdateAgent + (" " + Thread.CurrentThread.CurrentUICulture.EnglishName);
                        }
                        this.Text = this.m_MainCaption;
                        this.lblAboutVersion.Text = this.m_MainCaption;
                        Dictionary<string, string>.KeyCollection.Enumerator enumerator = this.m_Languages.Keys.GetEnumerator();
                        if (enumerator.MoveNext())
                        {
                            do
                            {
                                string current = enumerator.Current;
                                this.cbxLanguage.Items.Add(current);
                            }
                            while (enumerator.MoveNext());
                        }
                        this.cbxLanguage.SelectedIndex = this.cbxLanguage.Items.IndexOf(this.m_Settings.UserLanguage);
                        this.lblDeviceInfo.Text = this.GetLocalizedString("strDeviceNotConnected");
                        this.lblCurrentVEIInfo.Text = this.GetLocalizedString("strDeviceNotConnected");
                        int systemVoltage = this.m_Settings.SystemVoltage;
                        this.m_SystemVoltage = systemVoltage;
                        this.cbxSystemVoltage.SelectedIndex = this.cbxSystemVoltage.Items.IndexOf(systemVoltage + " V");
                        this.m_VeDocCalcTypes.clear();
                        this.m_VeDocCalcTypes["X1"] = 1;
                        this.m_VeDocCalcTypes["X2"] = 2;
                        this.m_VeDocCalcTypes["X8"] = 7;
                        this.m_VeDocCalcTypes["XA"] = 7;
                        this.cbxVeDocCalcType.Items.Clear();
                        local11._Mynode = this.m_VeDocCalcTypes._Myhead._Left;
                        BidirectionalIterator<cliext::impl::tree<cliext::impl::map_traits<System::String ^,unsigned char,0,0,0> > > local4 = local11;
                        while (true)
                        {
                            BidirectionalIterator<cliext::impl::tree<cliext::impl::map_traits<System::String ^,unsigned char,0,0,0> > > local9;
                            tree<cliext::impl::map_traits<System::String ^,unsigned char,0,0,0> > modopt(IsConst) veDocCalcTypes = this.m_VeDocCalcTypes;
                            local9._Mynode = veDocCalcTypes._Myhead;
                            BidirectionalIterator<cliext::impl::tree<cliext::impl::map_traits<System::String ^,unsigned char,0,0,0> > > local16 = local9;
                            if (((byte) !local4.equal_to(ref local16)) == 0)
                            {
                                break;
                            }
                            tree_node<System::String ^,Microsoft::VisualC::StlClr::GenericPair<System::String ^,unsigned char> ^> local3 = local4._Mynode;
                            ref GenericPair<string, byte> pairRef2 = local3._Value;
                            this.cbxVeDocCalcType.Items.Add(pairRef2.first);
                            local4._Mynode = local3.next_node();
                            local4 = local4;
                        }
                        this.m_DASPwdTypes.clear();
                        this.m_DASPwdTypes["MR download MR1_90"] = 0;
                        this.m_DASPwdTypes["MR download MR1_96"] = 1;
                        this.m_DASPwdTypes["MR download MR1_97"] = 2;
                        this.cbxDASPwdType.Items.Clear();
                        local7._Mynode = this.m_DASPwdTypes._Myhead._Left;
                        BidirectionalIterator<cliext::impl::tree<cliext::impl::map_traits<System::String ^,int,0,0,0> > > local2 = local7;
                        while (true)
                        {
                            BidirectionalIterator<cliext::impl::tree<cliext::impl::map_traits<System::String ^,int,0,0,0> > > local5;
                            tree<cliext::impl::map_traits<System::String ^,int,0,0,0> > modopt(IsConst) dASPwdTypes = this.m_DASPwdTypes;
                            local5._Mynode = dASPwdTypes._Myhead;
                            BidirectionalIterator<cliext::impl::tree<cliext::impl::map_traits<System::String ^,int,0,0,0> > > local15 = local5;
                            if (((byte) !local2.equal_to(ref local15)) == 0)
                            {
                                break;
                            }
                            tree_node<System::String ^,Microsoft::VisualC::StlClr::GenericPair<System::String ^,int> ^> local = local2._Mynode;
                            ref GenericPair<string, int> pairRef = local._Value;
                            this.cbxDASPwdType.Items.Add(pairRef.first);
                            local2._Mynode = local.next_node();
                            local2 = local2;
                        }
                        this.m_ECUInfo = new Dictionary<TruckType_t, ECUInfo[]>();
                        ECUInfo[] infoArray = new ECUInfo[50];
                        string str29 = "strFR";
                        string str28 = "FR";
                        info62.m_addr = 2;
                        info62.m_shortname = str28;
                        info62.m_longnameid = str29;
                        info62.m_HaveMoreECUsWithSameAddr = false;
                        infoArray[0] = info62;
                        string str27 = "strFLA";
                        string str26 = "FLA";
                        info61.m_addr = 7;
                        info61.m_shortname = str26;
                        info61.m_longnameid = str27;
                        info61.m_HaveMoreECUsWithSameAddr = false;
                        infoArray[1] = info61;
                        string str25 = "strKS";
                        string str24 = "KS";
                        info60.m_addr = 8;
                        info60.m_shortname = str24;
                        info60.m_longnameid = str25;
                        info60.m_HaveMoreECUsWithSameAddr = false;
                        infoArray[2] = info60;
                        string str23 = "strSIR";
                        string str22 = "SIR";
                        info59.m_addr = 11;
                        info59.m_shortname = str22;
                        info59.m_longnameid = str23;
                        info59.m_HaveMoreECUsWithSameAddr = false;
                        infoArray[3] = info59;
                        string str21 = "strWSK";
                        string str20 = "WSK";
                        info58.m_addr = 13;
                        info58.m_shortname = str20;
                        info58.m_longnameid = str21;
                        info58.m_HaveMoreECUsWithSameAddr = false;
                        infoArray[4] = info58;
                        string str19 = "strABS";
                        string str18 = "ABS";
                        info57.m_addr = 14;
                        info57.m_shortname = str18;
                        info57.m_longnameid = str19;
                        info57.m_HaveMoreECUsWithSameAddr = false;
                        infoArray[5] = info57;
                        string str17 = "strTMB";
                        string str16 = "TMB";
                        info56.m_addr = 0x13;
                        info56.m_shortname = str16;
                        info56.m_longnameid = str17;
                        info56.m_HaveMoreECUsWithSameAddr = false;
                        infoArray[6] = info56;
                        string str15 = "strZV";
                        string str14 = "ZV";
                        info55.m_addr = 0x13;
                        info55.m_shortname = str14;
                        info55.m_longnameid = str15;
                        info55.m_HaveMoreECUsWithSameAddr = false;
                        infoArray[7] = info55;
                        string str13 = "strCLS";
                        string str12 = "CLS";
                        info54.m_addr = 0x13;
                        info54.m_shortname = str12;
                        info54.m_longnameid = str13;
                        info54.m_HaveMoreECUsWithSameAddr = false;
                        infoArray[8] = info54;
                        string str11 = "strINS";
                        string str10 = "INS";
                        info53.m_addr = 0x15;
                        info53.m_shortname = str10;
                        info53.m_longnameid = str11;
                        info53.m_HaveMoreECUsWithSameAddr = false;
                        infoArray[9] = info53;
                        string str9 = "strKOM";
                        string str8 = "KOM";
                        info52.m_addr = 0x1a;
                        info52.m_shortname = str8;
                        info52.m_longnameid = str9;
                        info52.m_HaveMoreECUsWithSameAddr = false;
                        infoArray[10] = info52;
                        string str7 = "strHZR";
                        string str6 = "HZR";
                        info51.m_addr = 0x1c;
                        info51.m_shortname = str6;
                        info51.m_longnameid = str7;
                        info51.m_HaveMoreECUsWithSameAddr = false;
                        infoArray[11] = info51;
                        string str5 = "strHPS";
                        string str4 = "HPS";
                        info50.m_addr = 0x1f;
                        info50.m_shortname = str4;
                        info50.m_longnameid = str5;
                        info50.m_HaveMoreECUsWithSameAddr = false;
                        infoArray[12] = info50;
                        string str3 = "strTMF";
                        string str2 = "TMF";
                        info49.m_addr = 0x20;
                        info49.m_shortname = str2;
                        info49.m_longnameid = str3;
                        info49.m_HaveMoreECUsWithSameAddr = false;
                        infoArray[13] = info49;
                        ECUInfo info48 = new ECUInfo(0x23, "ADM", "strADM");
                        infoArray[14] = info48;
                        ECUInfo info47 = new ECUInfo(0x25, "RDK", "strRDK");
                        infoArray[15] = info47;
                        ECUInfo info46 = new ECUInfo(0x26, "AG", "strAG");
                        infoArray[0x10] = info46;
                        ECUInfo info45 = new ECUInfo(0x2a, "SRS", "strSRS");
                        infoArray[0x11] = info45;
                        ECUInfo info44 = new ECUInfo(0x2c, "EDW", "strEDW");
                        infoArray[0x12] = info44;
                        ECUInfo info43 = new ECUInfo(0x31, "ART", "strART");
                        infoArray[0x13] = info43;
                        ECUInfo info42 = new ECUInfo(0x31, "APS", "strAPS");
                        infoArray[20] = info42;
                        ECUInfo info41 = new ECUInfo(50, "ZDS", "strZDS");
                        infoArray[0x15] = info41;
                        ECUInfo info40 = new ECUInfo(0x3d, "FM", "strFM");
                        infoArray[0x16] = info40;
                        ECUInfo info39 = new ECUInfo(0x3e, "CDC", "strCDC");
                        infoArray[0x17] = info39;
                        ECUInfo info38 = new ECUInfo(0x40, "EAPU", "strEAPU");
                        infoArray[0x18] = info38;
                        ECUInfo info37 = new ECUInfo(0x4c, "BNT", "strBNT");
                        infoArray[0x19] = info37;
                        ECUInfo info36 = new ECUInfo(0x7f, "SIN", "strSIN");
                        infoArray[0x1a] = info36;
                        ECUInfo info35 = new ECUInfo(0x85, "SPA", "strSPA");
                        infoArray[0x1b] = info35;
                        ECUInfo info34 = new ECUInfo(0x89, "GS", "strGS");
                        infoArray[0x1c] = info34;
                        ECUInfo info33 = new ECUInfo(140, "SIL", "strSIL");
                        infoArray[0x1d] = info33;
                        ECUInfo info32 = new ECUInfo(0x8f, "RS", "strRS");
                        infoArray[30] = info32;
                        ECUInfo info31 = new ECUInfo(0x91, "HM", "strHM");
                        infoArray[0x1f] = info31;
                        ECUInfo info30 = new ECUInfo(0x91, "NR", "strNR");
                        infoArray[0x20] = info30;
                        ECUInfo info29 = new ECUInfo(0x92, "FFB", "strFFB");
                        infoArray[0x21] = info29;
                        ECUInfo info28 = new ECUInfo(0x94, "EHZ", "strEHZ");
                        infoArray[0x22] = info28;
                        ECUInfo info27 = new ECUInfo(0x97, "MSF", "strMSF");
                        infoArray[0x23] = info27;
                        ECUInfo info26 = new ECUInfo(0x98, "WS", "strWS");
                        infoArray[0x24] = info26;
                        ECUInfo info25 = new ECUInfo(0x9d, "ZHE", "strZHE");
                        infoArray[0x25] = info25;
                        ECUInfo info24 = new ECUInfo(0xa1, "DTCO", "strDTCO");
                        infoArray[0x26] = info24;
                        ECUInfo info23 = new ECUInfo(0xa1, "MTCO", "strMTCO");
                        infoArray[0x27] = info23;
                        ECUInfo info22 = new ECUInfo(0xa1, "FTCO", "strFTCO");
                        infoArray[40] = info22;
                        ECUInfo info21 = new ECUInfo(0xa2, "LWS", "strLWS");
                        infoArray[0x29] = info21;
                        ECUInfo info20 = new ECUInfo(0xa4, "BS", "strBS");
                        infoArray[0x2a] = info20;
                        ECUInfo info19 = new ECUInfo(0xa8, "MR", "strMR");
                        infoArray[0x2b] = info19;
                        ECUInfo info18 = new ECUInfo(0xae, "PSM", "strPSM");
                        infoArray[0x2c] = info18;
                        ECUInfo info17 = new ECUInfo(0xb3, "ABA", "strABA");
                        infoArray[0x2d] = info17;
                        ECUInfo info16 = new ECUInfo(0xba, "GM", "strGM");
                        infoArray[0x2e] = info16;
                        ECUInfo info15 = new ECUInfo(0xbc, "TP", "strTP");
                        infoArray[0x2f] = info15;
                        ECUInfo info14 = new ECUInfo(0xbf, "BTS", "strBTS");
                        infoArray[0x30] = info14;
                        ECUInfo info13 = new ECUInfo(0xc1, "CTEL", "strCTEL");
                        infoArray[0x31] = info13;
                        this.m_ECUInfo.Add(TruckType_t.MercedesBenz, infoArray);
                        ECUInfo[] infoArray2 = new ECUInfo[12];
                        ECUInfo info12 = new ECUInfo(0x20, "FFR", "strFFR");
                        infoArray2[0] = info12;
                        ECUInfo info11 = new ECUInfo(0x10, "EDC", "strEDC");
                        infoArray2[1] = info11;
                        ECUInfo info10 = new ECUInfo(0x2a, "EBS", "strEBS");
                        infoArray2[2] = info10;
                        ECUInfo info9 = new ECUInfo(0x61, "INST", "strINST");
                        infoArray2[3] = info9;
                        ECUInfo info8 = new ECUInfo(0x2d, "INT", "strINT");
                        infoArray2[4] = info8;
                        ECUInfo info7 = new ECUInfo(0xa8, "TUER", "strTUER");
                        infoArray2[5] = info7;
                        ECUInfo info6 = new ECUInfo(0x21, "ZBR", "strZBR");
                        infoArray2[6] = info6;
                        ECUInfo info5 = new ECUInfo(0x38, "ECAS", "strECAS");
                        infoArray2[7] = info5;
                        ECUInfo info4 = new ECUInfo(0x98, "KLIMA", "strKLIMA");
                        infoArray2[8] = info4;
                        ECUInfo info3 = new ECUInfo(0x9c, "EBP", "strEBP");
                        infoArray2[9] = info3;
                        ECUInfo info2 = new ECUInfo(0x27, "PTM", "strPTM");
                        infoArray2[10] = info2;
                        ECUInfo info = new ECUInfo(0x18, "ASTRONIC", "strASTRONIC");
                        infoArray2[11] = info;
                        this.m_ECUInfo.Add(TruckType_t.MAN, infoArray2);
                        this.m_msgbox = new CustomMsgBox();
                        this.m_ConnectionState = ConnectionState_t.NotConnected;
                        this.m_EngineEnabled = true;
                        this.m_MANEnabled = true;
                        this.m_MBEnabled = true;
                        this.m_DeviceID = 0;
                        this.m_OperationRunning = false;
                        this.m_IsDirectConnection = false;
                        this.m_IsBootstrapMode = false;
                        this.m_MRMotorNumber = null;
                        this.m_VIN = null;
                        this.m_MANMainECU = MANMainECU_t.Unknown;
                        this.m_SwVersion = 0;
                        this.m_VeDocCryptoKeySetWasCalled = false;
                        this.m_MemoryTab.m_EEPROMBName = null;
                        this.m_MemoryTab.m_EEPROMAName = null;
                        this.m_MemoryTab.m_FlashName = null;
                        this.m_MemoryTab.m_EEPROMB = null;
                        this.m_MemoryTab.m_EEPROMA = null;
                        this.m_MemoryTab.m_Flash = null;
                        this.m_MemoryTab.m_EEPROMAName = null;
                        this.m_MemoryTab.m_FlashName = null;
                        this.m_MemoryTab.m_EEPROMA = null;
                        this.m_MemoryTab.m_Flash = null;
                        this.m_FDOKIDValid = false;
                        this.m_FDOKRndValid = false;
                        this.m_WatchIgnitionChange = false;
                        m_this = this;
                        System.Enum.TryParse<TruckType_t>(this.m_Settings.TruckType, out this.m_TruckType);
                        this.UpdateCarNavigationImage();
                        this.UpdateCarNavigationButtons();
                    }
                    fault
                    {
                        base.Dispose(true);
                    }
                }
                fault
                {
                    this.m_DASPwdTypes.Dispose();
                }
            }
            fault
            {
                this.m_VeDocCalcTypes.Dispose();
            }
        }

        private void ~MainForm()
        {
            IContainer components = this.components;
            if (components != null)
            {
                components.Dispose();
            }
            IDisposable msgbox = this.m_msgbox;
            if (msgbox != null)
            {
                msgbox.Dispose();
            }
        }

        private void AddKeysFailedThreadSafe(string ErrorString)
        {
            string localizedString = null;
            if (this.InvokeRequired)
            {
                TaskFailedDelegate method = new TaskFailedDelegate(this.AddKeysFailedThreadSafe);
                object[] args = new object[] { ErrorString };
                this.Invoke(method, args);
            }
            else
            {
                this.StopOperation();
                int keysAdded = this.m_KeysTab.m_KeysAdded;
                switch (keysAdded)
                {
                    case 0:
                        this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + ErrorString + ")!\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strLearnKeysFailed") + " (") + ErrorString + ")!", this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;

                    case 1:
                        localizedString = this.GetLocalizedString("str1KeyWasAdded");
                        break;

                    default:
                        if (keysAdded > 1)
                        {
                            localizedString = this.GetParamedLocalizedString("strXKeysWereAdded", keysAdded);
                        }
                        break;
                }
                this.AddToLogThreadSafe(((this.GetLocalizedString("strLastKeyFailed") + " (") + ErrorString + ")! ") + localizedString + "\r\n");
                this.MessageBoxThreadSafe((this.GetLocalizedString("strLastKeyFailed") + " (" + ErrorString) + ")! " + localizedString, this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void AddKeysOkThreadSafe()
        {
            string text = null;
            if (this.InvokeRequired)
            {
                Action method = new Action(this.AddKeysOkThreadSafe);
                base.Invoke(method);
            }
            else
            {
                this.StopOperation();
                int keysAdded = this.m_KeysTab.m_KeysAdded;
                if (keysAdded == 1)
                {
                    text = this.GetLocalizedString("str1KeyWasAdded");
                }
                else if (keysAdded > 1)
                {
                    text = this.GetParamedLocalizedString("strXKeysWereAdded", keysAdded);
                }
                this.AddToLogThreadSafe(text + "\r\n");
                this.MessageBoxThreadSafe(text, this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.btnGetKeysInfo_Click(null, null);
            }
        }

        private unsafe void AddKeysTask()
        {
            uint num;
            int num3 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            this.m_KeysTab.m_KeysAdded = 0;
            try
            {
                byte num2;
                bool flag4;
                VeDocCalcType_t _t3;
                FFRImmoCmd_t _t4;
                uint num7;
                PTMImmoCmd_t _t5;
                uint num10;
                $ArrayType$$$BY0BA@E e$$$byba@e;
                KeysInfo_t _t7;
                bool flag5;
                FFRImmoInfo_t _t8;
                $ArrayType$$$BY0BA@E e$$$byba@e2;
                bool flag6;
                PTMImmoInfo_t _t9;
                TruckType_t truckType = this.m_TruckType;
                if (*(((int*) &truckType)) == 0)
                {
                    goto Label_0465;
                }
                if (*(((int*) &truckType)) != 1)
                {
                    CustomAssert(&??_C@_0BC@DFLNDNFC@KeyLearnTasks?4cpp?$AA@, 510, true, null);
                    return;
                }
            Label_0041:
                flag4 = false;
                if (this.MessageBoxThreadSafe(this.GetLocalizedString("strPutNewKey"), this.m_LastOperationStr, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel)
                {
                    throw new UserAborted();
                }
                this.AskForIgnition(false, this.m_LastOperationStr, true);
                this.AskForIgnition(true, this.m_LastOperationStr, true);
                MANMainECU_t mANMainECU = this.m_MANMainECU;
                if (*(((int*) &mANMainECU)) == 1)
                {
                    goto Label_026A;
                }
                if (*(((int*) &mANMainECU)) != 2)
                {
                    CustomAssert(&??_C@_0BC@DFLNDNFC@KeyLearnTasks?4cpp?$AA@, 0x1e2, true, null);
                    goto Label_03B9;
                }
                if (!RunLongOperation((Command_t) 0xe9, null, 0, (Command_t) 0xea, (Command_t) 0xeb, 0))
                {
                    goto Label_024D;
                }
                CmdLayerGetPTMImmoInfo(&_t9, &flag6);
                int num9 = *((byte*) (&_t9 + 5));
                bool flag3 = false;
                KeysTab keysTab = this.m_KeysTab;
                if (keysTab.m_KeysAdded > 0)
                {
                    flag3 = (*(((int*) (&_t9 + 1))) != 3) ? ((bool) ((byte) 1)) : ((bool) ((byte) 0));
                }
                else
                {
                    KeysTab.AddKeysType addKeysType = keysTab.m_AddKeysType;
                    if (*(((int*) &addKeysType)) == 0)
                    {
                        flag3 = (*(((int*) (&_t9 + 1))) != 3) ? ((bool) ((byte) 1)) : ((bool) ((byte) 0));
                    }
                    else if (*(((int*) &addKeysType)) == 1)
                    {
                        int num8;
                        if ((*(((int*) (&_t9 + 1))) != 3) && (*(((int*) (&_t9 + 1))) != 0))
                        {
                            num8 = 1;
                        }
                        else
                        {
                            num8 = 0;
                        }
                        flag3 = (bool) ((byte) num8);
                    }
                    else
                    {
                        CustomAssert(&??_C@_0BC@DFLNDNFC@KeyLearnTasks?4cpp?$AA@, 0x1ad, true, null);
                        goto Label_019B;
                    }
                }
                if (flag3)
                {
                    this.AddKeysFailedThreadSafe(this.GetLocalizedString("strKeyStatus") + ": " + this.GetPTMKeyStatusString((ushort) *(((int*) (&_t9 + 1)))));
                    return;
                }
            Label_019B:
                keysTab = this.m_KeysTab;
                if ((keysTab.m_AddKeysType == KeysTab.AddKeysType.EraseThenAdd) && (keysTab.m_KeysAdded == 0))
                {
                    _t5 = (PTMImmoCmd_t) 2;
                }
                else
                {
                    _t5 = (PTMImmoCmd_t) 1;
                }
                if (!CmdLayerCreatePTMKeyLearningParameters((byte*) &e$$$byba@e2, 0x10, &num7, _t5))
                {
                    CustomAssert(&??_C@_0BC@DFLNDNFC@KeyLearnTasks?4cpp?$AA@, 0x1c8, true, null);
                }
                if (RunLongOperation((Command_t) 0xec, (byte modopt(IsConst)*) &e$$$byba@e2, num7, (Command_t) 0xed, (Command_t) 0xee, 0))
                {
                    PTMResponseCode_t _t2 = CmdLayerGetPTMKeyLearningAnswer();
                    if ((_t2 == ((PTMResponseCode_t) 1)) || ((_t2 == ((PTMResponseCode_t) 2)) && (this.m_KeysTab.m_AddKeysType == KeysTab.AddKeysType.EraseThenAdd)))
                    {
                        goto Label_03B9;
                    }
                    this.AddKeysFailedThreadSafe(this.GetPTMKeyLearnString((ushort) _t2));
                }
                else
                {
                    num2 = CmdLayerGetErrorData((Command_t) 0xee);
                    this.AddKeysFailedThreadSafe(this.GetErrorExplanation(num2));
                }
                return;
            Label_024D:
                num2 = CmdLayerGetErrorData((Command_t) 0xeb);
                this.AddKeysFailedThreadSafe(this.GetErrorExplanation(num2));
                return;
            Label_026A:
                if (!RunLongOperation((Command_t) 0xf9, null, 0, (Command_t) 250, (Command_t) 0xfb, 0))
                {
                    goto Label_0448;
                }
                CmdLayerGetFFRImmoInfo(&_t8, &flag5);
                num9 = *((byte*) (&_t8 + 5));
                bool flag2 = false;
                keysTab = this.m_KeysTab;
                if (keysTab.m_KeysAdded > 0)
                {
                    flag2 = (*(((int*) (&_t8 + 1))) != 1) ? ((bool) ((byte) 1)) : ((bool) ((byte) 0));
                }
                else
                {
                    KeysTab.AddKeysType type2 = keysTab.m_AddKeysType;
                    if (*(((int*) &type2)) == 0)
                    {
                        flag2 = (*(((int*) (&_t8 + 1))) != 1) ? ((bool) ((byte) 1)) : ((bool) ((byte) 0));
                    }
                    else if (*(((int*) &type2)) == 1)
                    {
                        int num6;
                        if ((*(((int*) (&_t8 + 1))) != 1) && (*(((int*) (&_t8 + 1))) != 3))
                        {
                            num6 = 1;
                        }
                        else
                        {
                            num6 = 0;
                        }
                        flag2 = (bool) ((byte) num6);
                    }
                    else
                    {
                        CustomAssert(&??_C@_0BC@DFLNDNFC@KeyLearnTasks?4cpp?$AA@, 0x16c, true, null);
                        goto Label_0355;
                    }
                }
                if (flag2)
                {
                    this.AddKeysFailedThreadSafe(this.GetLocalizedString("strKeyStatus") + ": " + this.GetFFRKeyStatusString((ushort) *(((int*) (&_t8 + 1)))));
                    return;
                }
            Label_0355:
                keysTab = this.m_KeysTab;
                if ((keysTab.m_AddKeysType == KeysTab.AddKeysType.EraseThenAdd) && (keysTab.m_KeysAdded == 0))
                {
                    _t4 = (FFRImmoCmd_t) 0x87;
                }
                else
                {
                    _t4 = (FFRImmoCmd_t) 0xfd;
                }
                if (!CmdLayerCreateFFRKeyLearningParameters((byte*) &e$$$byba@e2, 0x10, &num7, _t4))
                {
                    CustomAssert(&??_C@_0BC@DFLNDNFC@KeyLearnTasks?4cpp?$AA@, 0x187, true, null);
                }
                if (!RunLongOperation((Command_t) 0xfc, (byte modopt(IsConst)*) &e$$$byba@e2, num7, (Command_t) 0xfd, (Command_t) 0xfe, 0))
                {
                    goto Label_042B;
                }
            Label_03B9:
                this.m_KeysTab.m_KeysAdded++;
                if (((num9 + 1) < this.m_KeysTab.m_MANMaxNumOfKeysAllowed) && (this.MessageBoxThreadSafe(this.GetLocalizedString("strWantToAddMoreKeys"), this.m_LastOperationStr, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    flag4 = true;
                    goto Label_0041;
                }
                this.AskForIgnition(false, this.m_LastOperationStr, true);
                this.AskForIgnition(true, this.m_LastOperationStr, true);
                this.AddKeysOkThreadSafe();
                return;
            Label_042B:
                num2 = CmdLayerGetErrorData((Command_t) 0xfe);
                this.AddKeysFailedThreadSafe(this.GetErrorExplanation(num2));
                return;
            Label_0448:
                num2 = CmdLayerGetErrorData((Command_t) 0xfb);
                this.AddKeysFailedThreadSafe(this.GetErrorExplanation(num2));
                return;
            Label_0465:
                flag4 = false;
                if (this.MessageBoxThreadSafe(this.GetLocalizedString("strPutNewKey"), this.m_LastOperationStr, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel)
                {
                    throw new UserAborted();
                }
                this.WatchIgnitionChange();
                if ((this.m_KeysTab.m_KeysAdded == 0) && !this.VeDocCryptoKeySet(this.m_LastOperationStr, &num2))
                {
                    this.AddKeysFailedThreadSafe(this.GetErrorExplanation(num2));
                    return;
                }
                if (!this.WasIgnitionChanged())
                {
                    this.AskForIgnition(false, this.m_LastOperationStr, true);
                    this.AskForIgnition(true, this.m_LastOperationStr, true);
                }
                if (!RunLongOperation((Command_t) 150, null, 0, (Command_t) 0x97, (Command_t) 0x98, 0))
                {
                    goto Label_06DB;
                }
                CmdLayerGetMRTransponderKeysInfo(&_t7);
                bool flag = false;
                keysTab = this.m_KeysTab;
                if (keysTab.m_KeysAdded > 0)
                {
                    flag = (*(((int*) (&_t7 + 4))) != 0) ? ((bool) ((byte) 1)) : ((bool) ((byte) 0));
                }
                else
                {
                    KeysTab.AddKeysType type = keysTab.m_AddKeysType;
                    if (*(((int*) &type)) == 0)
                    {
                        flag = (*(((int*) (&_t7 + 4))) != 0) ? ((bool) ((byte) 1)) : ((bool) ((byte) 0));
                    }
                    else if (*(((int*) &type)) == 1)
                    {
                        int num5;
                        if ((*(((int*) (&_t7 + 4))) != 0) && (*(((int*) (&_t7 + 4))) != 11))
                        {
                            num5 = 1;
                        }
                        else
                        {
                            num5 = 0;
                        }
                        flag = (bool) ((byte) num5);
                    }
                    else
                    {
                        CustomAssert(&??_C@_0BC@DFLNDNFC@KeyLearnTasks?4cpp?$AA@, 0xef, true, null);
                        goto Label_05B7;
                    }
                }
                if (flag)
                {
                    this.AddKeysFailedThreadSafe(this.GetLocalizedString("strKeyStatus") + ": " + this.GetMRKeyStatusString((ushort) *(((int*) (&_t7 + 4)))));
                    return;
                }
            Label_05B7:
                keysTab = this.m_KeysTab;
                if ((keysTab.m_AddKeysType == KeysTab.AddKeysType.EraseThenAdd) && (keysTab.m_KeysAdded == 0))
                {
                    _t3 = (VeDocCalcType_t) 2;
                }
                else
                {
                    _t3 = (VeDocCalcType_t) 1;
                }
                if (!CmdLayerCreateMRKeyLearningParameters((byte*) &e$$$byba@e, 0x10, &num10, _t3))
                {
                    CustomAssert(&??_C@_0BC@DFLNDNFC@KeyLearnTasks?4cpp?$AA@, 0x10c, true, null);
                }
                if (RunLongOperation((Command_t) 0x99, (byte modopt(IsConst)*) &e$$$byba@e, num10, (Command_t) 0x9a, (Command_t) 0x9b, 0))
                {
                    KeyStatus_t _t = CmdLayerGetMRKeyLearningAnswer();
                    if ((_t != ((KeyStatus_t) 0)) && ((_t != ((KeyStatus_t) 11)) || (this.m_KeysTab.m_AddKeysType != KeysTab.AddKeysType.EraseThenAdd)))
                    {
                        this.AddKeysFailedThreadSafe(this.GetMRKeyStatusString((ushort) _t));
                    }
                    else
                    {
                        this.m_KeysTab.m_KeysAdded++;
                        if (((*(((byte*) (&_t7 + 8))) + 1) < this.m_KeysTab.m_MBMaxNumOfKeysAllowed) && (this.MessageBoxThreadSafe(this.GetLocalizedString("strWantToAddMoreKeys"), this.m_LastOperationStr, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            flag4 = true;
                            goto Label_0465;
                        }
                        this.AskForIgnition(false, this.m_LastOperationStr, true);
                        this.AskForIgnition(true, this.m_LastOperationStr, true);
                        this.AddKeysOkThreadSafe();
                    }
                }
                else
                {
                    num2 = CmdLayerGetErrorData((Command_t) 0x9b);
                    this.AddKeysFailedThreadSafe(this.GetErrorExplanation(num2));
                }
                return;
            Label_06DB:
                num2 = CmdLayerGetErrorData((Command_t) 0x98);
                this.AddKeysFailedThreadSafe(this.GetErrorExplanation(num2));
            }
            catch (UserAborted)
            {
                this.AddKeysFailedThreadSafe(this.GetLocalizedString("strUserAborted"));
            }
            catch (InvalidOBDPower)
            {
                this.AddKeysFailedThreadSafe(this.GetLocalizedString("strInvalidOBDPower"));
            }
            catch (NoOBDPower)
            {
                this.AddKeysFailedThreadSafe(this.GetLocalizedString("strNoOBDPower"));
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num3);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t6;
                        byte errorcode = (byte) _t6;
                        this.AddToLogThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(errorcode) + ")!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(errorcode) + ")!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0BC@DFLNDNFC@KeyLearnTasks?4cpp?$AA@, 0x219, false, null);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num3, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num3);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num3, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num3);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0BC@DFLNDNFC@KeyLearnTasks?4cpp?$AA@, 0x22c, true, null);
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num3, (int) num);
                }
            }
        }

        private void AddToLogThreadSafe(string text)
        {
            if (this.InvokeRequired)
            {
                AddToLogDelegate method = new AddToLogDelegate(this.AddToLogThreadSafe);
                object[] args = new object[] { text };
                this.Invoke(method, args);
            }
            else
            {
                this.edLog.AppendText(text);
            }
        }

        private unsafe void AskForIgnition([MarshalAs(UnmanagedType.U1)] bool WantedIgnState, string MsgCaption, [MarshalAs(UnmanagedType.U1)] bool WaitForPLDStartUpDown)
        {
            CommandType_t _t;
            string localizedString;
            if (WantedIgnState)
            {
                localizedString = this.GetLocalizedString("strIgnitionOn");
            }
            else
            {
                localizedString = this.GetLocalizedString("strIgnitionOff");
            }
            if (!SendRequestWaitForAnswer((Command_t) 5, null, 0, &_t))
            {
                CustomAssert(&??_C@_0BA@NJELOBDB@CommonTasks?4cpp?$AA@, 50, true, null);
            }
            if (_t != ((CommandType_t) 1))
            {
                CustomAssert(&??_C@_0BA@NJELOBDB@CommonTasks?4cpp?$AA@, 0x33, true, null);
            }
            if (CmdLayerGetOBDPowerLevel() < 0x2710)
            {
                throw new NoOBDPower();
            }
            this.CheckSystemVoltage(CmdLayerGetOBDPowerLevel());
            if (WantedIgnState)
            {
                if (CmdLayerGetOBDIgnitionLevel() >= 0x2710)
                {
                    this.CheckSystemVoltage(CmdLayerGetOBDIgnitionLevel());
                    return;
                }
            }
            else if (CmdLayerGetOBDIgnitionLevel() < 0x2710)
            {
                return;
            }
            bool flag = false;
            if (this.m_IsDirectConnection)
            {
                if (!this.m_IsBootstrapMode)
                {
                    uint num;
                    $ArrayType$$$BY0BA@E e$$$byba@e;
                    if (!CmdLayerCreateIgnitionLevelToSetData((byte*) &e$$$byba@e, 0x10, &num, WantedIgnState))
                    {
                        CustomAssert(&??_C@_0BA@NJELOBDB@CommonTasks?4cpp?$AA@, 0x49, true, null);
                    }
                    if (!SendRequestWaitForAnswer((Command_t) 7, (byte modopt(IsConst)*) &e$$$byba@e, num, &_t))
                    {
                        CustomAssert(&??_C@_0BA@NJELOBDB@CommonTasks?4cpp?$AA@, 0x4a, true, null);
                    }
                    if (_t != ((CommandType_t) 1))
                    {
                        CommandUtilsError_t _t2 = (CommandUtilsError_t) 0x21;
                        _CxxThrowException((void*) &_t2, &_TI1?AW4CommandUtilsError_t@@);
                    }
                    flag = true;
                }
                goto Label_01B7;
            }
            this.SetProgressUndefinedThreadSafe();
            this.ShowMessageBoxThreadSafe(localizedString, MsgCaption);
        Label_0102:
            if (this.m_msgbox.DialogResult == DialogResult.Cancel)
            {
                throw new UserAborted();
            }
            if (!SendRequestWaitForAnswer((Command_t) 5, null, 0, &_t))
            {
                CustomAssert(&??_C@_0BA@NJELOBDB@CommonTasks?4cpp?$AA@, 0x73, true, null);
            }
            if (_t != ((CommandType_t) 1))
            {
                CustomAssert(&??_C@_0BA@NJELOBDB@CommonTasks?4cpp?$AA@, 0x74, true, null);
            }
            if (WantedIgnState)
            {
                if (CmdLayerGetOBDIgnitionLevel() >= 0x2710)
                {
                    goto Label_0163;
                }
                goto Label_0102;
            }
            if (CmdLayerGetOBDIgnitionLevel() >= 0x2710)
            {
                goto Label_0102;
            }
        Label_0163:
            this.HideMessageBoxThreadSafe();
            if (WantedIgnState)
            {
                Thread.Sleep(200);
                if (!SendRequestWaitForAnswer((Command_t) 5, null, 0, &_t))
                {
                    CustomAssert(&??_C@_0BA@NJELOBDB@CommonTasks?4cpp?$AA@, 0x80, true, null);
                }
                if (_t != ((CommandType_t) 1))
                {
                    CustomAssert(&??_C@_0BA@NJELOBDB@CommonTasks?4cpp?$AA@, 0x81, true, null);
                }
                this.CheckSystemVoltage(CmdLayerGetOBDIgnitionLevel());
            }
            flag = true;
        Label_01B7:
            if (WaitForPLDStartUpDown && flag)
            {
                if (WantedIgnState)
                {
                    Thread.Sleep(0x1388);
                }
                else
                {
                    Thread.Sleep(0x3a98);
                }
            }
            if (this.m_WatchIgnitionChange)
            {
                this.m_WasIgnitionChanged = true;
            }
        }

        private void AutomaticDeviceUpdate()
        {
            if (!this.m_AlreadyTriedAutomaticDeviceUpdate)
            {
                DateTime time = this.m_Settings.DeviceUpdateLastCheckTime.AddDays((double) this.m_CheckDeviceUpdatePeriodInDays);
                if ((DateTime.Now > time) || this.m_DeviceExpireSoon)
                {
                    this.m_AlreadyTriedAutomaticDeviceUpdate = true;
                    this.m_AutomaticDeviceUpdate = true;
                    this.StartTask(new ThreadStart(this.DeviceUpdateTask), this.GetLocalizedString("strCheckingForDeviceUpdate"), this.GetLocalizedString("strUpdateDevice"));
                }
            }
        }

        private unsafe void btnAddKey_Click(object sender, EventArgs e)
        {
            string logmsg = null;
            if (sender == this.btnAddKey)
            {
                this.m_KeysTab.m_AddKeysType = KeysTab.AddKeysType.Add;
                logmsg = this.GetLocalizedString("strAddKeys");
            }
            else if (sender == this.btnEraseAddKey)
            {
                this.m_KeysTab.m_AddKeysType = KeysTab.AddKeysType.EraseThenAdd;
                logmsg = this.GetLocalizedString("strEraseAndAddKeys");
            }
            else
            {
                CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0xc1a, true, null);
            }
            this.StartTask(new ThreadStart(this.AddKeysTask), logmsg, logmsg);
        }

        private unsafe void btnCarLeft_Click(object sender, EventArgs e)
        {
            do
            {
                TruckType_t truckType = this.m_TruckType;
                if (*(((int*) &truckType)) != 0)
                {
                    if (*(((int*) &truckType)) != 1)
                    {
                        if (*(((int*) &truckType)) != 2)
                        {
                            CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0xfb3, true, null);
                        }
                        else
                        {
                            this.m_TruckType = TruckType_t.MAN;
                        }
                    }
                    else
                    {
                        this.m_TruckType = TruckType_t.MercedesBenz;
                    }
                }
                else
                {
                    this.m_TruckType = TruckType_t.Engine;
                }
            }
            while (!this.IsCurrentTruckTypeValid());
            this.UpdateCarNavigationImage();
        }

        private unsafe void btnCarRight_Click(object sender, EventArgs e)
        {
            do
            {
                TruckType_t truckType = this.m_TruckType;
                if (*(((int*) &truckType)) != 0)
                {
                    if (*(((int*) &truckType)) != 1)
                    {
                        if (*(((int*) &truckType)) != 2)
                        {
                            CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0xf97, true, null);
                        }
                        else
                        {
                            this.m_TruckType = TruckType_t.MercedesBenz;
                        }
                    }
                    else
                    {
                        this.m_TruckType = TruckType_t.Engine;
                    }
                }
                else
                {
                    this.m_TruckType = TruckType_t.MAN;
                }
            }
            while (!this.IsCurrentTruckTypeValid());
            this.UpdateCarNavigationImage();
        }

        private unsafe void btnConnect_Click(object sender, EventArgs e)
        {
            if (this.ConnectToDevice(false))
            {
                this.btnUpdateDevice.Enabled = true;
                switch (this.m_ConnectionState)
                {
                    case ConnectionState_t.GoodDeviceConnected:
                        this.UpdateCarNavigationButtons();
                        if (!this.CorrectCurrentTruckType())
                        {
                            this.StartTask(new ThreadStart(this.ConnectTask), this.GetLocalizedString("strDetectingConnection"), this.GetLocalizedString("strConnect"));
                            break;
                        }
                        this.AddToLogThreadSafe("\r\n");
                        this.AddToLogThreadSafe(this.GetLocalizedString("strTruckTypeNotAvailable") + "\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strTruckTypeNotAvailable"), this.GetLocalizedString("strDeviceError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.UpdateCarNavigationImage();
                        break;

                    case ConnectionState_t.BadDeviceConnected:
                        this.AddToLogThreadSafe("\r\n");
                        this.AddToLogThreadSafe(this.GetLocalizedString("strPleaseUpdate") + $" (code {this.m_DeviceStatus:X}).");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strPleaseUpdate") + $" (code {this.m_DeviceStatus:X}).", this.GetLocalizedString("strDeviceError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.tabctlActions.SelectedTab = this.tabSettings;
                        break;

                    case ConnectionState_t.OldDeviceConnected:
                        this.AddToLogThreadSafe("\r\n");
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceTooOldPleaseUpdate") + "\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceTooOldPleaseUpdate"), this.GetLocalizedString("strDeviceError"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.tabctlActions.SelectedTab = this.tabSettings;
                        break;

                    case ConnectionState_t.GUITooOld:
                        this.AddToLogThreadSafe("\r\n");
                        this.AddToLogThreadSafe(this.GetLocalizedString("strGUITooOldPleaseUpdate") + "\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strGUITooOldPleaseUpdate"), this.GetLocalizedString("strDeviceError"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.tabctlActions.SelectedTab = this.tabSettings;
                        break;

                    default:
                        CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0xa46, true, null);
                        break;
                }
            }
        }

        private unsafe void btnDASPwdCalc_Click(object sender, EventArgs e)
        {
            BidirectionalIterator<cliext::impl::tree<cliext::impl::map_traits<System::String ^,int,0,0,0> > > local;
            BidirectionalIterator<cliext::impl::tree<cliext::impl::map_traits<System::String ^,int,0,0,0> > > local3 = this.m_DASPwdTypes.find(this.cbxDASPwdType.Text);
            local._Mynode = this.m_DASPwdTypes._Myhead;
            BidirectionalIterator<cliext::impl::tree<cliext::impl::map_traits<System::String ^,int,0,0,0> > > local2 = local;
            if (((byte) !local3.equal_to(ref local2)) == 0)
            {
                CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0xdc1, true, null);
            }
            ref GenericPair<string, int> pairRef = local3._Mynode._Value;
            this.m_DASPwdType = pairRef.second;
            this.StartTask(new ThreadStart(this.DASPwdCalculateTask), this.GetLocalizedString("strCalculatingDASPwd"), this.GetLocalizedString("strDASPwdCalculate"));
        }

        private void btnDetectECUs_Click(object sender, EventArgs e)
        {
            this.StartTask(new ThreadStart(this.DetectECUsTask), this.GetLocalizedString("strDetectingECUs"), this.GetLocalizedString("strDetectECUs"));
        }

        private unsafe void btnDisconnect_Click(object sender, EventArgs e)
        {
            uint num;
            int num2 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                if (this.m_IsDirectConnection)
                {
                    this.AddToLogThreadSafe("\r\n");
                    this.AddToLogThreadSafe(this.GetLocalizedString("strDisconnecting") + "... ");
                    this.AskForIgnition(false, this.GetLocalizedString("strDisconnect"), false);
                    this.AddToLogThreadSafe(this.GetLocalizedString("strdone"));
                    this.AddToLogThreadSafe("\r\n");
                }
            }
            catch (UserAborted)
            {
                this.ConnectFailedThreadSafe(this.GetLocalizedString("strUserAborted"));
            }
            catch (InvalidOBDPower)
            {
                this.ConnectFailedThreadSafe(this.GetLocalizedString("strInvalidOBDPower"));
            }
            catch (NoOBDPower)
            {
                this.ConnectFailedThreadSafe(this.GetLocalizedString("strNoOBDPower"));
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t;
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommError") + $" (code {((int) _t):X})!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommError") + $" (code {((int) _t):X})!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0xa78, false, null);
                        goto Label_0259;
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
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        goto Label_0259;
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
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0xa87, true, null);
                        goto Label_0259;
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
            }
        Label_0259:
            this.DisconnectThreadSafe();
        }

        private void btnEraseFaultCodes_Click(object sender, EventArgs e)
        {
            this.m_CurrentECUIdx = this.cbxDetectedECUs.SelectedIndex;
            this.StartTask(new ThreadStart(this.EraseFaultsTask), this.GetParamedLocalizedString("strErasingFaultsFromX", this.m_DetectedECU[this.m_CurrentECUIdx].m_shortname), this.GetLocalizedString("strErasingFaults"));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private unsafe void btnExtraRunOperation_Click(object sender, EventArgs e)
        {
            switch (this.m_ExtraTab.GetActiveOperation())
            {
                case ExtraTab.Operation.GetSpeedLimit:
                    this.edExtraOperationParameter.Clear();
                    this.StartTask(new ThreadStart(this.GetSpeedLimitTask), this.GetLocalizedString("strGettingSpeedLimit"), this.GetLocalizedString("strGetSpeedLimit"));
                    break;

                case ExtraTab.Operation.SetSpeedLimit:
                {
                    string localizedString = this.GetLocalizedString("strSetSpeedLimit");
                    try
                    {
                        this.m_ExtraTab.m_SpeedLimit = (byte) Convert.ToInt32(this.edExtraOperationParameter.Text);
                        ExtraTab extraTab = this.m_ExtraTab;
                        byte speedLimit = extraTab.m_SpeedLimit;
                        if ((speedLimit >= 1) && (speedLimit <= extraTab.m_MaxSpeedLimit))
                        {
                            this.StartTask(new ThreadStart(this.SetSpeedLimitTask), this.GetLocalizedString("strSettingSpeedLimit"), localizedString);
                        }
                        else
                        {
                            this.MessageBoxThreadSafe(string.Format(this.GetLocalizedString("strValueMustBeFromXToX"), 1, (byte) extraTab.m_MaxSpeedLimit), localizedString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                    catch (FormatException)
                    {
                        this.MessageBoxThreadSafe(this.GetParamedLocalizedString("strInputXIsNotInteger", this.edExtraOperationParameter.Text), localizedString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    break;
                }
                case ExtraTab.Operation.GetTorqueLimit:
                    this.edExtraOperationParameter.Clear();
                    this.StartTask(new ThreadStart(this.GetTorqueLimitTask), this.GetLocalizedString("strGettingTorqueLimit"), this.GetLocalizedString("strGetTorqueLimit"));
                    break;

                case ExtraTab.Operation.SetTorqueLimit:
                    this.StartTask(new ThreadStart(this.SetTorqueLimitTask), this.GetLocalizedString("strSettingTorqueLimit"), this.GetLocalizedString("strSetTorqueLimit"));
                    break;

                case ExtraTab.Operation.EraseEmissionFaults:
                    this.StartTask(new ThreadStart(this.EraseEmissionFaultsTask), this.GetLocalizedString("strErasingEmissionFaults"), this.GetLocalizedString("strEraseEmissionFaults"));
                    break;

                default:
                    CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0x109b, true, null);
                    break;
            }
        }

        private unsafe void btnFDOKCalculate_Click(object sender, EventArgs e)
        {
            uint num;
            int num2 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                CommandType_t _t;
                FDOKCalcType_t _t2;
                uint num8;
                MRSerialNumber_t _t4;
                $ArrayType$$$BY0BA@E e$$$byba@e;
                this.AddToLogThreadSafe(("\r\n" + this.GetLocalizedString("strFDOKCalculate") + " (") + this.cbxFDOKCalcType.Text + ")... ");
                if (!this.m_FDOKRndValid || !this.m_FDOKIDValid)
                {
                    CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0xd08, true, null);
                }
                if (this.cbxFDOKCalcType.Text == "XT")
                {
                    _t2 = (FDOKCalcType_t) 1;
                }
                else if (this.cbxFDOKCalcType.Text == "XN")
                {
                    _t2 = (FDOKCalcType_t) 0;
                }
                else
                {
                    CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0xd11, true, null);
                }
                uint num5 = 0;
                while (true)
                {
                    if (num5 >= 4)
                    {
                        break;
                    }
                    *((&_t4 + 3) - num5) = this.m_FDOKID >> (num5 << 3);
                    num5++;
                }
                if (!CmdLayerCreateMRFDOKNumberParameters((byte*) &e$$$byba@e, 0x10, &num8, _t4, _t2, this.m_FDOKRnd))
                {
                    CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0xd1c, true, null);
                }
                if (!SendRequestWaitForAnswer((Command_t) 0x41, (byte modopt(IsConst)*) &e$$$byba@e, num8, &_t))
                {
                    CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0xd1f, true, null);
                }
                if (_t != ((CommandType_t) 1))
                {
                    if (_t != ((CommandType_t) 2))
                    {
                        CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0xd4f, true, null);
                    }
                    else
                    {
                        byte errorcode = CmdLayerGetErrorCode();
                        this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + this.GetErrorExplanation(errorcode) + ")!\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strFDOKCalculateFailed") + " (") + this.GetErrorExplanation(errorcode) + ")!", this.GetLocalizedString("strFDOKCalculate"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else
                {
                    FDOKNumber_t _t5;
                    FDOKNumber_t _t6;
                    this.AddToLogThreadSafe(this.GetLocalizedString("strdone") + "\r\n");
                    CmdLayerGetMRFDOKNumber(&_t6, &_t5);
                    this.edFDOKOldResult.Clear();
                    int num4 = 0;
                    while (true)
                    {
                        if (num4 >= 4)
                        {
                            break;
                        }
                        if (num4 > 0)
                        {
                            this.edFDOKOldResult.Text = this.edFDOKOldResult.Text + " ";
                        }
                        this.edFDOKOldResult.Text = this.edFDOKOldResult.Text + $"{((byte) num4[(int) &_t6]):D3}";
                        num4++;
                    }
                    this.edFDOKOldResult.Enabled = true;
                    this.edFDOKNewResult.Clear();
                    int num3 = 0;
                    while (true)
                    {
                        if (num3 >= 4)
                        {
                            break;
                        }
                        if (num3 > 0)
                        {
                            this.edFDOKNewResult.Text = this.edFDOKNewResult.Text + " ";
                        }
                        this.edFDOKNewResult.Text = this.edFDOKNewResult.Text + $"{((byte) num3[(int) &_t5]):D3}";
                        num3++;
                    }
                    this.edFDOKNewResult.Enabled = true;
                    Clipboard.SetDataObject(this.edFDOKNewResult.Text);
                    this.btnFDOKCalculate.Enabled = false;
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t3;
                        byte num6 = (byte) _t3;
                        this.AddToLogThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(num6) + ")!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(num6) + ")!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0xd5f, false, null);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0xd72, true, null);
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
        }

        private void btnFRMRAnalyseAndRead_Click(object sender, EventArgs e)
        {
            string paramedLocalizedString = this.GetParamedLocalizedString("strECUXAnalyseAndReadMemory", this.m_MemoryTab.GetActiveECUString());
            this.StartTask(new ThreadStart(this.FRMRMemAnalyseAndReadTask), paramedLocalizedString, paramedLocalizedString);
        }

        private void btnFRMRMemAnalyse_Click(object sender, EventArgs e)
        {
            string paramedLocalizedString = this.GetParamedLocalizedString("strECUXAnalyseMemory", this.m_MemoryTab.GetActiveECUString());
            this.StartTask(new ThreadStart(this.FRMRMemAnalyseTask), paramedLocalizedString, paramedLocalizedString);
        }

        private unsafe void btnFRMRReadEEPROM_Click(object sender, EventArgs e)
        {
            string logmsg = null;
            if (sender == this.btnMemReadEEPROMA)
            {
                this.m_MemoryTab.m_WorkingEEPROMIdx = 0;
                logmsg = this.GetParamedLocalizedString("strECUXReadEEPROMA", this.m_MemoryTab.GetActiveECUString());
            }
            else if (sender == this.btnMemReadEEPROMB)
            {
                this.m_MemoryTab.m_WorkingEEPROMIdx = 1;
                logmsg = this.GetParamedLocalizedString("strECUXReadEEPROMB", this.m_MemoryTab.GetActiveECUString());
            }
            else
            {
                CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0xc63, true, null);
            }
            this.StartTask(new ThreadStart(this.FRMRReadEEPROMTask), logmsg, logmsg);
        }

        private void btnFRMRReadFlash_Click(object sender, EventArgs e)
        {
            string paramedLocalizedString = this.GetParamedLocalizedString("strECUXReadFlash", this.m_MemoryTab.GetActiveECUString());
            this.StartTask(new ThreadStart(this.FRMRReadFlashTask), paramedLocalizedString, paramedLocalizedString);
        }

        private unsafe void btnFRMRWriteEEPROM_Click(object sender, EventArgs e)
        {
            string caption = null;
            if (this.dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                Stream stream = this.dlgOpenFile.OpenFile();
                if (stream != null)
                {
                    ref MemoryStream modopt(IsExplicitlyDereferenced) streamRef;
                    if (sender == this.btnMemWriteEEPROMA)
                    {
                        this.m_MemoryTab.m_WorkingEEPROMIdx = 0;
                        MemoryTab memoryTab = this.m_MemoryTab;
                        streamRef = (ref MemoryStream modopt(IsExplicitlyDereferenced)) &memoryTab.m_EEPROMA;
                        caption = this.GetParamedLocalizedString("strECUXWriteEEPROMA", memoryTab.GetActiveECUString());
                    }
                    else if (sender == this.btnMemWriteEEPROMB)
                    {
                        this.m_MemoryTab.m_WorkingEEPROMIdx = 1;
                        MemoryTab tab = this.m_MemoryTab;
                        streamRef = (ref MemoryStream modopt(IsExplicitlyDereferenced)) &tab.m_EEPROMB;
                        caption = this.GetParamedLocalizedString("strECUXWriteEEPROMB", tab.GetActiveECUString());
                    }
                    else
                    {
                        CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0xccb, true, null);
                    }
                    long capacity = streamRef[0].Capacity;
                    if (stream.Length != capacity)
                    {
                        this.MessageBoxThreadSafe(this.GetParamedLocalizedString("strFileLengthMustBeX", streamRef[0].Capacity), caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        streamRef[0].Position = 0L;
                        stream.CopyTo(streamRef[0]);
                        stream.Close();
                        this.StartTask(new ThreadStart(this.FRMRWriteEEPROMTask), caption, caption);
                    }
                }
            }
        }

        private unsafe void btnFRMRWriteFlash_Click(object sender, EventArgs e)
        {
            MemoryTab memoryTab = this.m_MemoryTab;
            ref MemoryStream modopt(IsExplicitlyDereferenced) streamRef = (ref MemoryStream modopt(IsExplicitlyDereferenced)) &memoryTab.m_Flash;
            this.m_CurrentWriteFlashStartCmd = (Command_t) 0x26;
            this.m_CurrentWriteFlashProgressCmd = (Command_t) 0x27;
            this.m_CurrentWriteFlashOkCmd = (Command_t) 40;
            this.m_CurrentWriteFlashFailedCmd = (Command_t) 0x29;
            this.m_CurrentWriteFlashProgressFnc = (byte *()) CmdLayerGetECUFlashWrittenDataRate;
            this.m_CurrentWriteFlashOperationStr = this.GetParamedLocalizedString("strECUXWriteFlash", memoryTab.GetActiveECUString());
            this.m_CurrentWriteFlashCompletedStr = this.GetParamedLocalizedString("strECUXWriteFlashCompleted", this.m_MemoryTab.GetActiveECUString());
            this.m_CurrentWriteFlashFailedStr = this.GetParamedLocalizedString("strECUXWriteFlashFailed", this.m_MemoryTab.GetActiveECUString());
            this.m_CurrentWriteFlashHaveToCheckMainCRC = true;
            if (this.dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                Stream stream = this.dlgOpenFile.OpenFile();
                if (stream != null)
                {
                    long capacity = streamRef[0].Capacity;
                    if (stream.Length != capacity)
                    {
                        this.MessageBoxThreadSafe(this.GetParamedLocalizedString("strFileLengthMustBeX", streamRef[0].Capacity), this.m_CurrentWriteFlashOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        streamRef[0].Position = 0L;
                        stream.CopyTo(streamRef[0]);
                        stream.Close();
                        string currentWriteFlashOperationStr = this.m_CurrentWriteFlashOperationStr;
                        this.StartTask(new ThreadStart(this.FRMRWriteFlashTask), currentWriteFlashOperationStr, currentWriteFlashOperationStr);
                    }
                }
            }
        }

        private void btnGenerateFullFaultCodesReport_Click(object sender, EventArgs e)
        {
            this.StartTask(new ThreadStart(this.GenerateFullFaultsReport), this.GetLocalizedString("strGeneratingFullFaultsReport"), this.GetLocalizedString("strGeneratingFullFaultsReport"));
        }

        private void btnGetKeysInfo_Click(object sender, EventArgs e)
        {
            this.lblKeysInfo.Text = null;
            this.StartTask(new ThreadStart(this.ReadKeysInfoTask), this.GetLocalizedString("strReadingKeysInfo"), this.GetLocalizedString("strReadKeysInfo"));
        }

        private unsafe void btnKeysRunOperation_Click(object sender, EventArgs e)
        {
            switch (this.m_KeysTab.GetActiveOperation())
            {
                case KeysTab.Operation.MRImmoOff:
                    this.StartTask(new ThreadStart(this.MRImmoOffTask), this.GetParamedLocalizedString("strECUXImmoOff", "MR"), this.GetParamedLocalizedString("strECUXImmoOff", "MR"));
                    break;

                case KeysTab.Operation.FRImmoOff:
                    this.m_KeysTab.m_FRImmoStatus2Set = false;
                    this.StartTask(new ThreadStart(this.FRImmoSetTask), this.GetParamedLocalizedString("strECUXImmoOff", "FR"), this.GetParamedLocalizedString("strECUXImmoOff", "FR"));
                    break;

                case KeysTab.Operation.FRImmoOn:
                    this.m_KeysTab.m_FRImmoStatus2Set = true;
                    this.StartTask(new ThreadStart(this.FRImmoSetTask), this.GetParamedLocalizedString("strECUXImmoOn", "FR"), this.GetParamedLocalizedString("strECUXImmoOn", "FR"));
                    break;

                case KeysTab.Operation.EDCFFRPairing:
                case KeysTab.Operation.EDCPTMPairing:
                    this.TaskNotImplementedThreadSafe();
                    break;

                default:
                    CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0x1050, true, null);
                    break;
            }
        }

        private unsafe void btnMemRunOperation_Click(object sender, EventArgs e)
        {
            if (this.m_MemoryTab.GetActiveOperation() != MemoryTab.Operation.WriteFuelMap)
            {
                CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0xf22, true, null);
            }
            else
            {
                this.m_CurrentWriteFlashOperationStr = this.GetLocalizedString("strWriteMAP");
                this.m_CurrentWriteFlashCompletedStr = this.GetLocalizedString("strWriteMAPCompleted");
                this.m_CurrentWriteFlashFailedStr = this.GetLocalizedString("strWriteMAPFailed");
                this.m_CurrentWriteFlashStartCmd = (Command_t) 0x37;
                this.m_CurrentWriteFlashProgressCmd = (Command_t) 0x38;
                this.m_CurrentWriteFlashOkCmd = (Command_t) 0x39;
                this.m_CurrentWriteFlashFailedCmd = (Command_t) 0x3a;
                this.m_CurrentWriteFlashProgressFnc = (byte *()) CmdLayerGetMRPowerMapWrittenDataRate;
                this.m_CurrentWriteFlashHaveToCheckMainCRC = false;
                if (this.dlgOpenFile.ShowDialog() == DialogResult.OK)
                {
                    Stream stream = this.dlgOpenFile.OpenFile();
                    if (stream != null)
                    {
                        long capacity = this.m_MemoryTab.m_Flash.Capacity;
                        if (stream.Length != capacity)
                        {
                            this.MessageBoxThreadSafe(this.GetParamedLocalizedString("strFileLengthMustBeX", this.m_MemoryTab.m_Flash.Capacity), this.m_CurrentWriteFlashOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        else
                        {
                            this.m_MemoryTab.m_Flash.Position = 0L;
                            stream.CopyTo(this.m_MemoryTab.m_Flash);
                            stream.Close();
                            string currentWriteFlashOperationStr = this.m_CurrentWriteFlashOperationStr;
                            this.StartTask(new ThreadStart(this.FRMRWriteFlashTask), currentWriteFlashOperationStr, currentWriteFlashOperationStr);
                        }
                    }
                }
            }
        }

        private unsafe void btnReadDeviceInfo_Click(object sender, EventArgs e)
        {
            ConnectionState_t connectionState = this.m_ConnectionState;
            if (!this.ConnectToDevice(true))
            {
                if (connectionState != this.m_ConnectionState)
                {
                    this.DisconnectThreadSafe();
                }
            }
            else
            {
                switch (this.m_ConnectionState)
                {
                    case ConnectionState_t.GoodDeviceConnected:
                    case ConnectionState_t.GUITooOld:
                        this.UpdateCarNavigationButtons();
                        if (this.CorrectCurrentTruckType())
                        {
                            this.UpdateCarNavigationImage();
                        }
                        break;

                    case ConnectionState_t.BadDeviceConnected:
                        this.AddToLogThreadSafe("\r\n");
                        this.AddToLogThreadSafe(this.GetLocalizedString("strPleaseUpdate") + $" (code {this.m_DeviceStatus:X}).");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strPleaseUpdate") + $" (code {this.m_DeviceStatus:X}).", this.GetLocalizedString("strDeviceError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        break;

                    case ConnectionState_t.OldDeviceConnected:
                        this.AddToLogThreadSafe("\r\n");
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceTooOldPleaseUpdate") + "\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceTooOldPleaseUpdate"), this.GetLocalizedString("strDeviceError"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;

                    default:
                        CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0xbd6, true, null);
                        break;
                }
                this.btnUpdateDevice.Enabled = true;
            }
        }

        private void btnReadFaultCodes_Click(object sender, EventArgs e)
        {
            this.m_CurrentECUIdx = this.cbxDetectedECUs.SelectedIndex;
            this.StartTask(new ThreadStart(this.ReadFaultsTask), this.GetParamedLocalizedString("strReadingFaultsFromX", this.m_DetectedECU[this.m_CurrentECUIdx].m_shortname), this.GetLocalizedString("strReadingFaults"));
        }

        private void btnUpdateDevice_Click(object sender, EventArgs e)
        {
            this.m_AutomaticDeviceUpdate = false;
            this.StartTask(new ThreadStart(this.DeviceUpdateTask), this.GetLocalizedString("strCheckingForDeviceUpdate"), this.GetLocalizedString("strUpdateDevice"));
        }

        private void btnUpdateSoftware_Click(object sender, EventArgs e)
        {
            this.m_AutomaticSoftwareUpdate = false;
            this.StartTask(new ThreadStart(this.SoftwareUpdateTask), this.GetLocalizedString("strCheckingForSoftwareUpdate"), this.GetLocalizedString("strUpdateSoftware"));
        }

        private unsafe void btnVeDocCalculate_Click(object sender, EventArgs e)
        {
            uint num;
            int num2 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                CommandType_t _t;
                uint num6;
                $ArrayType$$$BY0BA@E e$$$byba@e;
                this.AddToLogThreadSafe(("\r\n" + this.GetLocalizedString("strVeDocCalculate") + " (") + this.cbxVeDocCalcType.Text + ")... ");
                BidirectionalIterator<cliext::impl::tree<cliext::impl::map_traits<System::String ^,unsigned char,0,0,0> > > local = this.m_VeDocCalcTypes.find(this.cbxVeDocCalcType.Text);
                BidirectionalIterator<cliext::impl::tree<cliext::impl::map_traits<System::String ^,unsigned char,0,0,0> > > local4 = local;
                BidirectionalIterator<cliext::impl::tree<cliext::impl::map_traits<System::String ^,unsigned char,0,0,0> > > local3 = local;
                BidirectionalIterator<cliext::impl::tree<cliext::impl::map_traits<System::String ^,unsigned char,0,0,0> > > local2 = this.m_VeDocCalcTypes.end();
                if (&local3 == &local2)
                {
                    CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0xb46, true, null);
                }
                VeDocCalcType_t second = BidirectionalIterator<cliext::impl::tree<cliext::impl::map_traits<System::String ^,unsigned char,0,0,0> > >.op_MemberSelection(ref local3).second;
                if (!CmdLayerCreateMRVeDocNumberParameters((byte*) &e$$$byba@e, 0x10, &num6, second))
                {
                    CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0xb4b, true, null);
                }
                if (!SendRequestWaitForAnswer((Command_t) 0x40, (byte modopt(IsConst)*) &e$$$byba@e, num6, &_t))
                {
                    CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0xb4e, true, null);
                }
                if (_t != ((CommandType_t) 1))
                {
                    if (_t != ((CommandType_t) 2))
                    {
                        CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0xb73, true, null);
                    }
                    else
                    {
                        byte errorcode = CmdLayerGetErrorCode();
                        this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + this.GetErrorExplanation(errorcode) + ")!\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strVeDocCalculateFailed") + " (") + this.GetErrorExplanation(errorcode) + ")!", this.GetLocalizedString("strVeDocCalculate"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else
                {
                    VeDocNumber_t _t4;
                    this.AddToLogThreadSafe(this.GetLocalizedString("strdone") + "\r\n");
                    CmdLayerGetMRVeDocNumber(&_t4);
                    this.edVeDocResult.Clear();
                    int num3 = 0;
                    while (true)
                    {
                        if (num3 >= 4)
                        {
                            break;
                        }
                        if (num3 > 0)
                        {
                            this.edVeDocResult.Text = this.edVeDocResult.Text + " ";
                        }
                        this.edVeDocResult.Text = this.edVeDocResult.Text + $"{((byte) num3[(int) &_t4]):D3}";
                        num3++;
                    }
                    this.edVeDocResult.Enabled = true;
                    Clipboard.SetDataObject(this.edVeDocResult.Text);
                    this.btnVeDocCalculate.Enabled = false;
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t2;
                        byte num4 = (byte) _t2;
                        this.AddToLogThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(num4) + ")!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(num4) + ")!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0xb83, false, null);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0xb96, true, null);
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
        }

        private void btnVeDocPrepare_Click(object sender, EventArgs e)
        {
            this.StartTask(new ThreadStart(this.VeDocPrepareTask), this.GetLocalizedString("strVeDocCalcPrepare"), this.GetLocalizedString("strVeDocCalcPrepare"));
        }

        private void cbxDASPwdType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.edDASPwd.Clear();
            this.edDASPwd.Enabled = false;
            this.btnDASPwdCalc.Enabled = true;
        }

        private void cbxDetectedECUs_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.gridFaultCodes.Rows.Clear();
            this.UpdateGridFaultCodesHeight();
            this.pnlFaultCodes.Enabled = false;
        }

        private void cbxExtraOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.m_ExtraTab.m_ActiveOperationIdx = this.cbxExtraOperation.SelectedIndex;
            this.ExtraUpdateOperationParameter();
        }

        private unsafe void cbxExtraOperationParameter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_ExtraTab.GetActiveOperation() != ExtraTab.Operation.SetTorqueLimit)
            {
                CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0x10b8, true, null);
            }
            else
            {
                switch (this.cbxExtraOperationParameter.SelectedIndex)
                {
                    case 0:
                        this.m_ExtraTab.m_TorqueLimit = 60;
                        return;

                    case 1:
                        this.m_ExtraTab.m_TorqueLimit = 0x4b;
                        return;

                    case 2:
                        this.m_ExtraTab.m_TorqueLimit = 100;
                        return;

                    case 3:
                        this.m_ExtraTab.m_TorqueLimit = 50;
                        return;
                }
                CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0x10b3, true, null);
            }
        }

        private void cbxFDOKCalcType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.edFDOKOldResult.Clear();
            this.edFDOKOldResult.Enabled = false;
            this.edFDOKNewResult.Clear();
            this.edFDOKNewResult.Enabled = false;
            if (this.m_FDOKRndValid && this.m_FDOKIDValid)
            {
                this.btnFDOKCalculate.Enabled = true;
            }
        }

        private void cbxKeysOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.m_KeysTab.m_ActiveOperationIdx = this.cbxKeysOperation.SelectedIndex;
        }

        private void cbxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_Settings.UserLanguage != this.cbxLanguage.Text)
            {
                this.m_Settings.UserLanguage = this.cbxLanguage.Text;
                Application.Restart();
                base.Close();
            }
        }

        private void cbxMemECU_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_MemoryTab.m_ActiveECUIdx != this.cbxMemECU.SelectedIndex)
            {
                this.m_MemoryTab.m_ActiveECUIdx = this.cbxMemECU.SelectedIndex;
                this.m_MemoryTab.m_WasAnalysed = false;
                this.MemUpdateECUInfo();
            }
        }

        private void cbxMemOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.m_MemoryTab.m_ActiveOperationIdx = this.cbxMemOperation.SelectedIndex;
        }

        private unsafe void cbxSystemVoltage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = this.cbxSystemVoltage.SelectedIndex;
            if (selectedIndex != 0)
            {
                if (selectedIndex != 1)
                {
                    CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0x10d5, true, null);
                }
                else
                {
                    this.m_SystemVoltage = 12;
                }
            }
            else
            {
                this.m_SystemVoltage = 0x18;
            }
            this.m_Settings.SystemVoltage = this.m_SystemVoltage;
        }

        private void cbxVeDocCalcType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnVeDocCalculate.Enabled = true;
            this.edVeDocResult.Clear();
            this.edVeDocResult.Enabled = false;
        }

        private unsafe void CheckSystemVoltage(int voltage)
        {
            int systemVoltage = this.m_SystemVoltage;
            if (systemVoltage == 12)
            {
                if (voltage >= 0x4650)
                {
                    throw new InvalidOBDPower();
                }
            }
            else if (systemVoltage == 0x18)
            {
                if (voltage < 0x4650)
                {
                    throw new InvalidOBDPower();
                }
            }
            else
            {
                CustomAssert(&??_C@_0BA@NJELOBDB@CommonTasks?4cpp?$AA@, 0x18, true, null);
            }
        }

        private void ConnectFailedThreadSafe(string ErrorString)
        {
            if (this.InvokeRequired)
            {
                TaskFailedDelegate method = new TaskFailedDelegate(this.ConnectFailedThreadSafe);
                object[] args = new object[] { ErrorString };
                this.Invoke(method, args);
            }
            else
            {
                this.StopOperation();
                if (this.m_IsDirectConnection)
                {
                    this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + ErrorString + ")!\r\n");
                    this.MessageBoxThreadSafe((this.GetLocalizedString("strDirectConnectCommError") + " (") + ErrorString + ")!", this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + ErrorString + ")!\r\n");
                    this.MessageBoxThreadSafe((this.GetLocalizedString("strTruckCommError") + " (") + ErrorString + ")!", this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                this.AutomaticDeviceUpdate();
            }
        }

        private unsafe void ConnectMANOkThreadSafe()
        {
            string param = null;
            if (this.InvokeRequired)
            {
                Action method = new Action(this.ConnectMANOkThreadSafe);
                base.Invoke(method);
            }
            else
            {
                this.StopOperation();
                this.AddToLogThreadSafe("\r\n");
                this.AddToLogThreadSafe("  " + this.GetLocalizedString("strVIN") + $": {this.m_VIN}
");
                MANMainECU_t mANMainECU = this.m_MANMainECU;
                MANMainECU_t _t2 = mANMainECU;
                if ((*(((int*) &_t2)) - 1) <= 1)
                {
                    MANMainECU_t _t = mANMainECU;
                    if (*(((int*) &_t)) != 1)
                    {
                        if (*(((int*) &_t)) != 2)
                        {
                            CustomAssert(&??_C@_0BA@NJELOBDB@CommonTasks?4cpp?$AA@, 0x339, true, null);
                        }
                        else
                        {
                            param = "PTM";
                        }
                    }
                    else
                    {
                        param = "FFR";
                    }
                    this.AddToLogThreadSafe("  " + this.GetLocalizedString("strVehicleNumber") + $": {this.m_FFRPTMVehicleNumber}
");
                    this.AddToLogThreadSafe("  " + this.GetLocalizedString("strEngineNumber") + $": {this.m_FFRPTMEngineNumber}
");
                    this.AddToLogThreadSafe("  " + this.GetParamedLocalizedString("strECUXItemNumber", param) + $": {this.m_FFRPTMItemNumber}
");
                    this.AddToLogThreadSafe("  " + this.GetParamedLocalizedString("strECUXManufacturerCode", param) + $": {this.m_FFRPTMManufacturerCode}
");
                    this.AddToLogThreadSafe("  " + this.GetParamedLocalizedString("strECUXHWVersion", param) + $": {this.m_FFRPTMControlUnitVer}
");
                    this.AddToLogThreadSafe("  " + this.GetParamedLocalizedString("strECUXFWVersion", param) + $": {this.m_FFRPTMManufacturerSoft}
");
                }
                else
                {
                    CustomAssert(&??_C@_0BA@NJELOBDB@CommonTasks?4cpp?$AA@, 860, true, null);
                }
                this.tabctlActions.TabPages.Remove(this.tabMemory);
                this.tabctlActions.TabPages.Remove(this.tabVeDocCalc);
                this.tabctlActions.TabPages.Remove(this.tabFDOKCalc);
                this.tabctlActions.TabPages.Remove(this.tabDASPwdCalc);
                this.tabctlActions.TabPages.Remove(this.tabExtra);
                this.tabctlActions.TabPages.Remove(this.tabFaultCodes);
                this.tabLearnKeys.Enabled = true;
                this.KeysUpdateOperationList();
                this.btnConnect.Enabled = false;
                this.btnDisconnect.Enabled = true;
                this.m_ConnectionState = ConnectionState_t.TruckConnected;
                this.UpdateCarNavigationButtons();
                this.UpdateCarNavigationImage();
                this.AutomaticDeviceUpdate();
            }
        }

        private unsafe void ConnectMBOkThreadSafe(string MRSerialNumber, string MRCertificationNumber, string MRDatasetNumber, string MRFWVersion, string FRFWVersion, string FRDiagVersion, string FRDatasetNumber)
        {
            if (this.InvokeRequired)
            {
                ConnectMBOkDelegate method = new ConnectMBOkDelegate(this.ConnectMBOkThreadSafe);
                object[] args = new object[] { MRSerialNumber, MRCertificationNumber, MRDatasetNumber, MRFWVersion, FRFWVersion, FRDiagVersion, FRDatasetNumber };
                this.Invoke(method, args);
                return;
            }
            this.StopOperation();
            this.AddToLogThreadSafe("\r\n");
            if (!this.m_IsDirectConnection)
            {
                if (string.IsNullOrEmpty(this.m_VIN))
                {
                    this.AddToLogThreadSafe("  " + this.GetLocalizedString("strVIN") + ": ???\r\n");
                }
                else
                {
                    this.AddToLogThreadSafe("  " + this.GetLocalizedString("strVIN") + $": {this.m_VIN}
");
                }
            }
            else if (this.m_IsBootstrapMode)
            {
                this.AddToLogThreadSafe("  " + this.GetLocalizedString("strMCUType") + ": ");
                switch (this.m_BootstrapMCU)
                {
                    case ((MCUDerivative_t) 0):
                    case ((MCUDerivative_t) 1):
                        this.AddToLogThreadSafe("C167Cx\r\n");
                        goto Label_0174;

                    case ((MCUDerivative_t) 4):
                        this.AddToLogThreadSafe("XC2287\r\n");
                        goto Label_0174;

                    case ((MCUDerivative_t) 5):
                        this.AddToLogThreadSafe("TC1796\r\n");
                        this.m_MemoryTab.m_ECUList.Add(MemoryTab.ECU.MCM);
                        goto Label_0174;
                }
                CustomAssert(&??_C@_0BA@NJELOBDB@CommonTasks?4cpp?$AA@, 0x288, true, null);
            }
        Label_0174:
            if (this.m_MemoryTab.m_ECUList.Count == 0)
            {
                this.m_MemoryTab.m_ECUList.Add(MemoryTab.ECU.MR);
            }
            this.m_KeysTab.m_OperationList.Add(KeysTab.Operation.MRImmoOff);
            this.edVeDocVIN.Text = this.m_VIN;
            if (!this.m_IsBootstrapMode)
            {
                this.AddToLogThreadSafe("  " + this.GetLocalizedString("strEngineNumber") + $": {this.m_MRMotorNumber}
");
                this.AddToLogThreadSafe("  " + this.GetLocalizedString("strMRSerialNumber") + $": {MRSerialNumber}
");
                this.AddToLogThreadSafe("  " + this.GetLocalizedString("strMRCertificationNumber") + $": {MRCertificationNumber}
");
                this.AddToLogThreadSafe("  " + this.GetLocalizedString("strMRDatasetNumber") + $": {MRDatasetNumber}
");
                this.AddToLogThreadSafe("  " + this.GetParamedLocalizedString("strECUXFWVersion", "MR") + $": {MRFWVersion}
");
            }
            if (this.m_CanAccessFR && this.m_ShowFRInfo)
            {
                this.AddToLogThreadSafe("  " + this.GetParamedLocalizedString("strECUXFWVersion", "FR") + $": {FRFWVersion}
");
                this.AddToLogThreadSafe("  " + this.GetLocalizedString("strFRDiagVersion") + $": {FRDiagVersion}
");
                this.AddToLogThreadSafe("  " + this.GetLocalizedString("strFRDatasetNumber") + $": {FRDatasetNumber}
");
                this.m_MemoryTab.m_ECUList.Add(MemoryTab.ECU.FR);
                this.m_KeysTab.m_OperationList.Add(KeysTab.Operation.FRImmoOn);
                this.m_KeysTab.m_OperationList.Add(KeysTab.Operation.FRImmoOff);
            }
            int num = 0;
            if (0 < this.m_MemoryTab.m_ECUList.Count)
            {
                do
                {
                    List<MemoryTab.Operation> list = new List<MemoryTab.Operation>();
                    MemoryTab.ECU ecu = this.m_MemoryTab.m_ECUList[num];
                    if (*(((int*) &ecu)) != 0)
                    {
                        if ((*(((int*) &ecu)) <= 0) || (*(((int*) &ecu)) > 2))
                        {
                            CustomAssert(&??_C@_0BA@NJELOBDB@CommonTasks?4cpp?$AA@, 0x2ca, true, null);
                        }
                    }
                    else
                    {
                        list.Add(MemoryTab.Operation.WriteFuelMap);
                    }
                    this.m_MemoryTab.m_OperationList.Add(this.m_MemoryTab.m_ECUList[num], list);
                    num++;
                }
                while (num < this.m_MemoryTab.m_ECUList.Count);
            }
            if (!this.m_IsDirectConnection)
            {
                this.tabMemory.Enabled = true;
                this.tabLearnKeys.Enabled = true;
                this.tabVeDocCalc.Enabled = true;
                this.tabDASPwdCalc.Enabled = true;
                this.tabExtra.Enabled = true;
                this.tabFaultCodes.Enabled = true;
                this.m_ExtraTab.m_OperationList.Add(ExtraTab.Operation.GetSpeedLimit);
                this.m_ExtraTab.m_OperationList.Add(ExtraTab.Operation.SetSpeedLimit);
                this.m_ExtraTab.m_OperationList.Add(ExtraTab.Operation.GetTorqueLimit);
                this.m_ExtraTab.m_OperationList.Add(ExtraTab.Operation.SetTorqueLimit);
                this.m_ExtraTab.m_OperationList.Add(ExtraTab.Operation.EraseEmissionFaults);
            }
            else
            {
                this.tabMemory.Enabled = true;
                if (!this.m_IsBootstrapMode)
                {
                    this.tabLearnKeys.Enabled = true;
                    this.tabVeDocCalc.Enabled = true;
                    this.tabExtra.Enabled = true;
                    this.m_ExtraTab.m_OperationList.Add(ExtraTab.Operation.EraseEmissionFaults);
                    this.tabFaultCodes.Enabled = true;
                }
            }
            this.MemUpdateECUList();
            this.MemUpdateECUInfo();
            this.KeysUpdateOperationList();
            this.maskedFDOKRnd.Clear();
            this.maskedFDOKID.Text = MRSerialNumber;
            this.cbxFDOKCalcType.SelectedIndex = -1;
            this.btnFDOKCalculate.Enabled = false;
            this.edFDOKOldResult.Clear();
            this.edFDOKOldResult.Enabled = false;
            this.edFDOKNewResult.Clear();
            this.edFDOKNewResult.Enabled = false;
            this.ExtraUpdateOperationList();
            this.btnDetectECUs.Enabled = true;
            this.cbxSystemVoltage.Enabled = false;
            this.btnConnect.Enabled = false;
            this.btnDisconnect.Enabled = true;
            this.m_ConnectionState = ConnectionState_t.TruckConnected;
            this.UpdateCarNavigationButtons();
            this.UpdateCarNavigationImage();
            this.AutomaticDeviceUpdate();
        }

        private unsafe void ConnectTask()
        {
            uint num;
            string fRDatasetNumber = null;
            string fRDiagVersion = null;
            string fRFWVersion = null;
            string mRFWVersion = null;
            string mRDatasetNumber = null;
            string mRCertificationNumber = null;
            string mRSerialNumber = null;
            int num3 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                byte num2;
                int num6;
                CommandType_t _t3;
                uint num9;
                $ArrayType$$$BY0BA@E e$$$byba@e;
                if (!SendRequestWaitForAnswer((Command_t) 5, null, 0, &_t3))
                {
                    CustomAssert(&??_C@_0BA@NJELOBDB@CommonTasks?4cpp?$AA@, 0x13d, true, null);
                }
                if (_t3 != ((CommandType_t) 1))
                {
                    CustomAssert(&??_C@_0BA@NJELOBDB@CommonTasks?4cpp?$AA@, 0x13e, true, null);
                }
                if (CmdLayerGetOBDPowerLevel() < 0x2710)
                {
                    throw new NoOBDPower();
                }
                this.CheckSystemVoltage(CmdLayerGetOBDPowerLevel());
                if (!SendRequestWaitForAnswer((Command_t) 6, null, 0, &_t3))
                {
                    CustomAssert(&??_C@_0BA@NJELOBDB@CommonTasks?4cpp?$AA@, 0x149, true, null);
                }
                if (_t3 != ((CommandType_t) 1))
                {
                    CustomAssert(&??_C@_0BA@NJELOBDB@CommonTasks?4cpp?$AA@, 330, true, null);
                }
                this.m_DirectCableSN = CmdLayerGetDirectCableSerial();
                if ((CmdLayerGetDirectCableId() != 0x21) && (CmdLayerGetDirectCableId() != 0x22))
                {
                    num6 = 0;
                }
                else
                {
                    num6 = 1;
                }
                byte num5 = (byte) num6;
                this.m_IsDirectConnection = (bool) num5;
                int num10 = (int) (num5 == 0);
                this.m_CanAccessFR = (bool) num10;
                this.AddToLogThreadSafe("\r\n");
                this.AddToLogThreadSafe("  " + this.GetLocalizedString("strConnectionType") + ": ");
                if (this.m_IsDirectConnection)
                {
                    this.AddToLogThreadSafe($"DIRECT (cable s/n {(uint) this.m_DirectCableSN:D5})
");
                }
                else
                {
                    this.AddToLogThreadSafe("OBD\r\n");
                }
                this.AddToLogThreadSafe("  " + this.GetLocalizedString("strTruckManufacturer") + ": ");
                TruckType_t truckType = this.m_TruckType;
                if (*(((int*) &truckType)) != 0)
                {
                    if (*(((int*) &truckType)) != 1)
                    {
                        CustomAssert(&??_C@_0BA@NJELOBDB@CommonTasks?4cpp?$AA@, 0x163, true, null);
                    }
                    else
                    {
                        this.AddToLogThreadSafe("MAN\r\n");
                    }
                }
                else
                {
                    this.AddToLogThreadSafe("Mercedes Benz\r\n");
                }
                if (!this.m_IsDirectConnection)
                {
                    this.AddToLogThreadSafe("\r\n" + this.GetLocalizedString("strReadingTruckInfo") + "... ");
                }
                else
                {
                    this.AddToLogThreadSafe("\r\n" + this.GetLocalizedString("strReadingECUInfo") + "... ");
                }
                TruckType_t _t12 = this.m_TruckType;
                if (*(((int*) &_t12)) != 0)
                {
                    if (*(((int*) &_t12)) != 1)
                    {
                        CustomAssert(&??_C@_0BA@NJELOBDB@CommonTasks?4cpp?$AA@, 0x22f, true, null);
                    }
                    else
                    {
                        this.AskForIgnition(true, this.m_LastOperationStr, true);
                        if (RunLongOperation((Command_t) 0xf6, null, 0, (Command_t) 0xf7, (Command_t) 0xf8, 0))
                        {
                            FFRInfo_t _t11;
                            CmdLayerGetFFRInfo(&_t11);
                            this.m_MANMainECU = MANMainECU_t.FFR;
                            this.m_VIN = new string((sbyte*) &_t11);
                            this.m_FFRPTMItemNumber = new string((sbyte*) (&_t11 + 0x12));
                            this.m_FFRPTMManufacturerCode = new string((sbyte*) (&_t11 + 0x20));
                            this.m_FFRPTMManufacturerSoft = new string((sbyte*) (&_t11 + 0x30));
                            this.m_FFRPTMControlUnitVer = new string((sbyte*) (&_t11 + 0x40));
                            this.m_FFRPTMEngineNumber = new string((sbyte*) (&_t11 + 80));
                            this.m_FFRPTMVehicleNumber = new string((sbyte*) (&_t11 + 0x58));
                            this.ConnectMANOkThreadSafe();
                        }
                        else if (RunLongOperation((Command_t) 0x83, null, 0, (Command_t) 0x84, (Command_t) 0x85, 0))
                        {
                            FFRInfo_t _t10;
                            CmdLayerGetPTMInfo(&_t10);
                            this.m_MANMainECU = MANMainECU_t.PTM;
                            this.m_VIN = new string((sbyte*) &_t10);
                            this.m_FFRPTMItemNumber = new string((sbyte*) (&_t10 + 0x12));
                            this.m_FFRPTMManufacturerCode = new string((sbyte*) (&_t10 + 0x20));
                            this.m_FFRPTMManufacturerSoft = new string((sbyte*) (&_t10 + 0x30));
                            this.m_FFRPTMControlUnitVer = new string((sbyte*) (&_t10 + 0x40));
                            this.m_FFRPTMEngineNumber = new string((sbyte*) (&_t10 + 80));
                            this.m_FFRPTMVehicleNumber = new string((sbyte*) (&_t10 + 0x58));
                            this.ConnectMANOkThreadSafe();
                        }
                        else
                        {
                            num2 = CmdLayerGetErrorData((Command_t) 0x85);
                            this.ConnectFailedThreadSafe(this.GetErrorExplanation(num2));
                        }
                    }
                    return;
                }
                this.AskForIgnition(true, this.m_LastOperationStr, true);
                if (!this.m_IsDirectConnection)
                {
                    if (RunLongOperation((Command_t) 0xb0, null, 0, (Command_t) 0xb1, (Command_t) 0xb2, 0))
                    {
                        this.m_VIN = new string(CmdLayerGetVIN());
                    }
                    else
                    {
                        num2 = CmdLayerGetErrorData((Command_t) 0xb2);
                        this.ConnectFailedThreadSafe(this.GetErrorExplanation(num2));
                        return;
                    }
                }
                if (RunLongOperation((Command_t) 0x9f, null, 0, (Command_t) 160, (Command_t) 0xa1, 0))
                {
                    MRFWVersion_t _t5;
                    DatasetNumber_t _t6;
                    CertificationNumber_t _t7;
                    EngineNumber_t _t8;
                    MRSerialNumber_t _t9;
                    CmdLayerGetMRInfo(&_t9, &_t8, &_t7, &_t6, &_t5);
                    mRSerialNumber = $"{*((byte*) (&_t9 + 3)):X2} {*((byte*) (&_t9 + 2)):X2} {*((byte*) (&_t9 + 1)):X2} {*((byte*) &_t9):X2}";
                    this.m_MRMotorNumber = $"{(uint) *(((int*) &_t8)):D6} {*((byte*) (&_t8 + 4)):D2} {(uint) *(((int*) (&_t8 + 5))):D6}";
                    mRCertificationNumber = new string((sbyte*) &_t7);
                    mRDatasetNumber = new string((sbyte*) &_t6);
                    mRFWVersion = new string((sbyte*) &_t5);
                    goto Label_05AF;
                }
                if (!this.m_IsDirectConnection)
                {
                    goto Label_0656;
                }
                this.m_IsBootstrapMode = false;
                MCUDerivative_t[] _tArray = new MCUDerivative_t[3];
                *((int*) &(_tArray[0])) = 1;
                *((int*) &(_tArray[1])) = 4;
                *((int*) &(_tArray[2])) = 5;
                MCUDerivative_t[] _tArray2 = _tArray;
                int index = 0;
            Label_04F6:
                if ((index >= _tArray2.Length) || this.m_IsBootstrapMode)
                {
                    goto Label_057A;
                }
                MCUDerivative_t mcuderivative = _tArray2[index];
                if (mcuderivative == ((MCUDerivative_t) 4))
                {
                    if (this.m_HybridLicenseEnabled)
                    {
                        goto Label_052D;
                    }
                    goto Label_056F;
                }
                if ((mcuderivative == ((MCUDerivative_t) 5)) && !this.m_TRICORELicenseEnabled)
                {
                    goto Label_056F;
                }
            Label_052D:
                if (!CmdLayerCreateECUBootstrapParameters((byte*) &e$$$byba@e, 0x10, &num9, mcuderivative))
                {
                    CustomAssert(&??_C@_0BA@NJELOBDB@CommonTasks?4cpp?$AA@, 0x1b5, true, null);
                }
                if (RunLongOperation((Command_t) 0x19, (byte modopt(IsConst)*) &e$$$byba@e, num9, (Command_t) 0x1a, (Command_t) 0x1b, 0))
                {
                    this.m_BootstrapMCU = mcuderivative;
                    this.m_IsBootstrapMode = true;
                }
            Label_056F:
                index++;
                goto Label_04F6;
            Label_057A:
                if (!this.m_IsBootstrapMode)
                {
                    goto Label_063C;
                }
                if (!RunLongOperation((Command_t) 0x1c, null, 0, (Command_t) 0x1d, (Command_t) 30, 0))
                {
                    num2 = CmdLayerGetErrorData((Command_t) 30);
                    this.ConnectFailedThreadSafe(this.GetErrorExplanation(num2));
                    return;
                }
            Label_05AF:
                if (this.m_CanAccessFR && this.m_ShowFRInfo)
                {
                    if (!RunLongOperation((Command_t) 0xe0, null, 0, (Command_t) 0xe1, (Command_t) 0xe2, 0))
                    {
                        fRDatasetNumber = "???";
                        fRDiagVersion = fRDatasetNumber;
                        fRFWVersion = fRDatasetNumber;
                    }
                    else
                    {
                        byte num7;
                        byte num8;
                        DatasetNumber_t _t4;
                        CmdLayerGetFRInfo(&num8, &num7, &_t4);
                        fRFWVersion = $"{num8:X2}";
                        fRDiagVersion = $"{num7}";
                        fRDatasetNumber = new string((sbyte*) &_t4);
                    }
                }
                this.ConnectMBOkThreadSafe(mRSerialNumber, mRCertificationNumber, mRDatasetNumber, mRFWVersion, fRFWVersion, fRDiagVersion, fRDatasetNumber);
                return;
            Label_063C:
                num2 = CmdLayerGetErrorData((Command_t) 0x1b);
                this.ConnectFailedThreadSafe(this.GetErrorExplanation(num2));
                return;
            Label_0656:
                num2 = CmdLayerGetErrorData((Command_t) 0xa1);
                this.ConnectFailedThreadSafe(this.GetErrorExplanation(num2));
            }
            catch (UserAborted)
            {
                this.ConnectFailedThreadSafe(this.GetLocalizedString("strUserAborted"));
            }
            catch (InvalidOBDPower)
            {
                this.ConnectFailedThreadSafe(this.GetLocalizedString("strInvalidOBDPower"));
            }
            catch (NoOBDPower)
            {
                this.ConnectFailedThreadSafe(this.GetLocalizedString("strNoOBDPower"));
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num3);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t2;
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommError") + $" (code {((int) _t2):X})!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommError") + $" (code {((int) _t2):X})!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0BA@NJELOBDB@CommonTasks?4cpp?$AA@, 0x24b, false, null);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num3, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num3);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num3, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num3);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0BA@NJELOBDB@CommonTasks?4cpp?$AA@, 0x25e, true, null);
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num3, (int) num);
                }
            }
        }

        [return: MarshalAs(UnmanagedType.U1)]
        private unsafe bool ConnectToDevice([MarshalAs(UnmanagedType.U1)] bool RefreshInfo)
        {
            string str = null;
            uint num;
            byte num2;
            string str2 = null;
            bool flag2;
            int num3 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                ConnectionState_t connectionState = this.m_ConnectionState;
                if (((*(((int*) &connectionState)) != 0) && (*(((int*) &connectionState)) != 5)) || RefreshInfo)
                {
                    CommandType_t _t;
                    ModulesMask_t _t3;
                    $ArrayType$$$BY0BA@D e$$$byba@d;
                    this.AddToLogThreadSafe("\r\n");
                    this.AddToLogThreadSafe(this.GetLocalizedString("strConnectingToDevice"));
                    if (this.m_ConnectionState == ConnectionState_t.NotConnected)
                    {
                        uint num7 = RS232GetDeviceCount((DKDeviceType_t) 0);
                        if (num7 > 1)
                        {
                            this.AddToLogThreadSafe(this.GetLocalizedString("strfailed"));
                            this.AddToLogThreadSafe("!\r\n");
                            this.MessageBoxThreadSafe(this.GetLocalizedString("strTooManyDevices"), this.GetLocalizedString("strDeviceError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            num2 = 0;
                            goto Label_0C04;
                        }
                        if ((num7 == 0) || !RS232OpenDevice((DKDeviceType_t) 0))
                        {
                            this.AddToLogThreadSafe(this.GetLocalizedString("strfailed"));
                            this.AddToLogThreadSafe("!\r\n");
                            this.MessageBoxThreadSafe(this.GetLocalizedString("strCannotFindDevice"), this.GetLocalizedString("strDeviceError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            num2 = 0;
                            goto Label_0C04;
                        }
                    }
                    if (!SendRequestWaitForAnswer((Command_t) 0, null, 0, &_t))
                    {
                        CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0x7c1, true, null);
                    }
                    if (_t != ((CommandType_t) 1))
                    {
                        CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0x7c2, true, null);
                    }
                    this.m_ProductID = CmdLayerGetProductId();
                    this.m_DeviceStatus = CmdLayerGetDeviceStatus();
                    this.m_DeviceID = CmdLayerGetDeviceSN();
                    this.m_HwVersion = CmdLayerGetDeviceHwVer();
                    this.m_LdrVersion = CmdLayerGetDeviceLoaderVer();
                    this.m_SwVersion = CmdLayerGetDeviceSwVer();
                    if (this.m_ProductID != 1)
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strUnknownDevice"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strUnknownDevice"), this.GetLocalizedString("strDeviceError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        RS232CloseDevice();
                        this.m_ConnectionState = ConnectionState_t.NotConnected;
                        this.m_DeviceID = 0;
                        num2 = 0;
                        goto Label_0C04;
                    }
                    this.AddToLogThreadSafe("\r\n");
                    this.AddToLogThreadSafe("  " + this.GetLocalizedString("strDeviceType") + ": Vehicle Explorer Interface\r\n");
                    this.lblDeviceInfo.Text = this.GetLocalizedString("strDeviceType") + ": Vehicle Explorer Interface\r\n";
                    if ((RS232ReadDeviceSN((sbyte modopt(IsSignUnspecifiedByte)*) &e$$$byba@d) && (atoi((sbyte modopt(IsSignUnspecifiedByte) modopt(IsConst)*) &e$$$byba@d) > 0x2710)) && (atoi((sbyte modopt(IsSignUnspecifiedByte) modopt(IsConst)*) &e$$$byba@d) < 0x4e1f))
                    {
                        this.m_DeviceSN = atoi((sbyte modopt(IsSignUnspecifiedByte) modopt(IsConst)*) &e$$$byba@d);
                        this.AddToLogThreadSafe(("  " + this.GetLocalizedString("strDeviceSN") + ": ") + new string((sbyte*) &e$$$byba@d) + "\r\n");
                        this.lblDeviceInfo.Text = this.lblDeviceInfo.Text + ((this.GetLocalizedString("strDeviceSN") + ": ") + new string((sbyte*) &e$$$byba@d) + "\r\n");
                        this.lblCurrentVEIInfo.Text = "VEI: " + new string((sbyte*) &e$$$byba@d);
                    }
                    else
                    {
                        this.AddToLogThreadSafe("  " + this.GetLocalizedString("strDeviceID") + $": {((uint) this.m_DeviceID):X8}
");
                        this.lblDeviceInfo.Text = this.lblDeviceInfo.Text + (this.GetLocalizedString("strDeviceID") + $": {((uint) this.m_DeviceID):X8}
");
                        this.lblCurrentVEIInfo.Text = "VEI: ???";
                    }
                    this.AddToLogThreadSafe("  " + this.GetLocalizedString("strFirmwareVersion"));
                    this.lblDeviceInfo.Text = this.lblDeviceInfo.Text + this.GetLocalizedString("strFirmwareVersion");
                    ushort swVersion = this.m_SwVersion;
                    if (swVersion == 0)
                    {
                        this.AddToLogThreadSafe($": {this.m_HwVersion}.???
");
                        this.lblDeviceInfo.Text = this.lblDeviceInfo.Text + $": {this.m_HwVersion}.???";
                    }
                    else
                    {
                        this.AddToLogThreadSafe($": {this.m_HwVersion}.{swVersion}
");
                        this.lblDeviceInfo.Text = this.lblDeviceInfo.Text + $": {this.m_HwVersion}.{this.m_SwVersion}";
                    }
                    if (this.m_DeviceStatus != 0)
                    {
                        this.m_ConnectionState = ConnectionState_t.BadDeviceConnected;
                        num2 = 1;
                        goto Label_0C04;
                    }
                    if (!SendRequestWaitForAnswer((Command_t) 1, null, 0, &_t))
                    {
                        CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0x816, true, null);
                    }
                    if (_t != ((CommandType_t) 1))
                    {
                        CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0x817, true, null);
                    }
                    CmdLayerGetLicensedModulesMask(&_t3);
                    this.m_DeviceTrialDaysLeft = CmdLayerGetTrialExpirationDaysLeft();
                    this.m_EngineEnabled = false;
                    this.m_MANEnabled = false;
                    this.m_MBEnabled = false;
                    if (((byte) (*(((byte*) &_t3)) & 2)) != 0)
                    {
                        str = str + "MEMO ";
                    }
                    if (((byte) (*(((byte*) &_t3)) & 4)) != 0)
                    {
                        str = str + "KEYS ";
                    }
                    if (((byte) (*(((byte*) &_t3)) & 8)) != 0)
                    {
                        str = str + "CALC ";
                    }
                    if (((byte) (*(((byte*) (&_t3 + 1))) & 1)) != 0)
                    {
                        str = str + "EXTRA ";
                    }
                    if (((byte) (*(((byte*) (&_t3 + 1))) & 2)) != 0)
                    {
                        str = str + "DIAG ";
                    }
                    if (((byte) (*(((byte*) &_t3)) & 0x10)) != 0)
                    {
                        str = str + "2011+ ";
                    }
                    if (((byte) (*(((byte*) &_t3)) & 0x20)) != 0)
                    {
                        str = str + "DC ";
                    }
                    if (((byte) (*(((byte*) &_t3)) & 0x40)) != 0)
                    {
                        str = str + "3CORE ";
                    }
                    if (((byte) (*(((byte*) &_t3)) & 0x80)) != 0)
                    {
                        str = str + "FR ";
                    }
                    if (!string.IsNullOrEmpty(str))
                    {
                        this.m_MBEnabled = true;
                        this.AddToLogThreadSafe(("  " + this.GetParamedLocalizedString("strLicensesForX", "ME")) + ": " + str);
                        this.AddToLogThreadSafe("\r\n");
                        this.lblDeviceInfo.Text = this.lblDeviceInfo.Text + (("\r\n" + this.GetParamedLocalizedString("strLicensesForX", "ME")) + ": " + str);
                    }
                    if (((byte) (*(((byte*) (&_t3 + 1))) & 4)) != 0)
                    {
                        str2 = str2 + "KEYS ";
                    }
                    if (!string.IsNullOrEmpty(str2))
                    {
                        this.m_MANEnabled = true;
                        this.AddToLogThreadSafe(("  " + this.GetParamedLocalizedString("strLicensesForX", "MN")) + ": " + str2);
                        this.AddToLogThreadSafe("\r\n");
                        this.lblDeviceInfo.Text = this.lblDeviceInfo.Text + (("\r\n" + this.GetParamedLocalizedString("strLicensesForX", "MN")) + ": " + str2);
                    }
                    if (((byte) (*(((byte*) &_t3)) & 1)) != 0)
                    {
                        this.AddToLogThreadSafe("  " + this.GetLocalizedString("strTrialDaysLeft") + $": {this.m_DeviceTrialDaysLeft}
");
                        this.lblDeviceInfo.Text = this.lblDeviceInfo.Text + ("\r\n" + this.GetLocalizedString("strTrialDaysLeft") + $": {this.m_DeviceTrialDaysLeft}");
                        if (this.m_DeviceTrialDaysLeft < 1)
                        {
                            this.MessageBoxThreadSafe(this.GetLocalizedString("strLicenseExpired"), this.GetLocalizedString("strDeviceError"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            meminit(&_t3, 0, 2);
                            *((sbyte*) &_t3) = *(((byte*) &_t3)) | 1;
                        }
                    }
                    if (((byte) (*(((byte*) &_t3)) & 2)) == 0)
                    {
                        this.tabctlActions.TabPages.Remove(this.tabMemory);
                    }
                    byte num5 = (byte) (*(((byte*) &_t3)) >> 7);
                    this.m_ShowFRInfo = (bool) num5;
                    this.m_FRLicenseEnabled = (bool) num5;
                    this.m_TRICORELicenseEnabled = (bool) (((byte) (*(((byte*) &_t3)) & 0x40)) >> 6);
                    this.m_HybridLicenseEnabled = (bool) (((byte) (*(((byte*) &_t3)) & 0x10)) >> 4);
                    if ((((byte) (*(((byte*) &_t3)) & 4)) == 0) && (((byte) (*(((byte*) (&_t3 + 1))) & 4)) == 0))
                    {
                        this.tabctlActions.TabPages.Remove(this.tabLearnKeys);
                    }
                    if (((byte) (*(((byte*) &_t3)) & 8)) == 0)
                    {
                        this.tabctlActions.TabPages.Remove(this.tabVeDocCalc);
                        this.tabctlActions.TabPages.Remove(this.tabFDOKCalc);
                        this.tabctlActions.TabPages.Remove(this.tabDASPwdCalc);
                    }
                    if (((byte) (*(((byte*) (&_t3 + 1))) & 1)) == 0)
                    {
                        this.tabctlActions.TabPages.Remove(this.tabExtra);
                    }
                    if (((byte) (*(((byte*) (&_t3 + 1))) & 2)) == 0)
                    {
                        this.tabctlActions.TabPages.Remove(this.tabFaultCodes);
                    }
                    if (this.m_SwVersion < this.m_MinimalDeviceVersion)
                    {
                        this.m_ConnectionState = ConnectionState_t.OldDeviceConnected;
                        num2 = 1;
                        goto Label_0C04;
                    }
                    if (!SendRequestWaitForAnswer((Command_t) 3, null, 0, &_t))
                    {
                        CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0x88c, true, null);
                    }
                    if (_t != ((CommandType_t) 1))
                    {
                        CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0x88d, true, null);
                    }
                    Version version = new Version(new string(CmdLayerGetGUIMinVersion()));
                    if (Assembly.GetEntryAssembly().GetName().Version < version)
                    {
                        this.m_ConnectionState = ConnectionState_t.GUITooOld;
                        num2 = 1;
                        goto Label_0C04;
                    }
                    if (!SendRequestWaitForAnswer((Command_t) 4, null, 0, &_t))
                    {
                        CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0x89b, true, null);
                    }
                    if (_t != ((CommandType_t) 1))
                    {
                        CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0x89c, true, null);
                    }
                    this.m_DeviceExpireSoon = CmdLayerGetExpireSoon();
                    ushort num4 = CmdLayerGetSupportExpirationDaysLeft();
                    this.AddToLogThreadSafe("  " + this.GetLocalizedString("strSupportDaysLeft") + $": {num4}
");
                    this.lblDeviceInfo.Text = this.lblDeviceInfo.Text + ("\r\n" + this.GetLocalizedString("strSupportDaysLeft") + $": {num4}");
                    if ((num4 == 0) && !this.m_AlreadyShowedSupportExpiredMsg)
                    {
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strSupportExpired"), this.GetLocalizedString("strDeviceError"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.m_AlreadyShowedSupportExpiredMsg = true;
                    }
                    this.m_ConnectionState = ConnectionState_t.GoodDeviceConnected;
                    this.tabFDOKCalc.Enabled = true;
                }
                num2 = 1;
                goto Label_0C04;
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num3);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t2;
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommError") + $" (code {((int) _t2):X})!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommError") + $" (code {((int) _t2):X})!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0x8c1, false, null);
                        this.DisconnectThreadSafe();
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
                goto Label_0C02;
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num3);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.DisconnectThreadSafe();
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
                goto Label_0C02;
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num3);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0x8d6, true, null);
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
                goto Label_0C02;
            }
            return flag2;
        Label_0C02:
            return false;
        Label_0C04:
            return (bool) num2;
        }

        [return: MarshalAs(UnmanagedType.U1)]
        private unsafe bool CorrectCurrentTruckType()
        {
            int num2;
            int num = 0;
            if (!this.IsCurrentTruckTypeValid())
            {
                do
                {
                    TruckType_t truckType = this.m_TruckType;
                    if (*(((int*) &truckType)) != 0)
                    {
                        if (*(((int*) &truckType)) != 1)
                        {
                            if (*(((int*) &truckType)) != 2)
                            {
                                CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0x1007, true, null);
                            }
                            else
                            {
                                this.m_TruckType = TruckType_t.MercedesBenz;
                            }
                        }
                        else
                        {
                            this.m_TruckType = TruckType_t.Engine;
                        }
                    }
                    else
                    {
                        this.m_TruckType = TruckType_t.MAN;
                    }
                    num++;
                    if (num >= 3)
                    {
                        CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0x100b, true, null);
                    }
                }
                while (!this.IsCurrentTruckTypeValid());
                if (num > 0)
                {
                    num2 = 1;
                    goto Label_007B;
                }
            }
            num2 = 0;
        Label_007B:
            return (bool) ((byte) num2);
        }

        private void DASPwdCalculateFailedThreadSafe(string ErrorString)
        {
            if (this.InvokeRequired)
            {
                TaskFailedDelegate method = new TaskFailedDelegate(this.DASPwdCalculateFailedThreadSafe);
                object[] args = new object[] { ErrorString };
                this.Invoke(method, args);
            }
            else
            {
                this.edDASPwd.Clear();
                this.edDASPwd.Enabled = false;
                this.StopOperation();
                this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + ErrorString + ")!\r\n");
                this.MessageBoxThreadSafe((this.GetLocalizedString("strDASPwdCalcFailed") + " (") + ErrorString + ")!", this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void DASPwdCalculateOkThreadSafe(uint modopt(IsLong) Password)
        {
            if (this.InvokeRequired)
            {
                DASPwdCalculateOkDelegate method = new DASPwdCalculateOkDelegate(this.DASPwdCalculateOkThreadSafe);
                object[] args = new object[] { (uint) Password };
                this.Invoke(method, args);
            }
            else
            {
                this.edDASPwd.Text = $"{(uint) Password}";
                this.edDASPwd.Enabled = true;
                Clipboard.SetDataObject(this.edDASPwd.Text);
                this.btnDASPwdCalc.Enabled = false;
                this.StopOperation();
                this.AddToLogThreadSafe(this.GetLocalizedString("strdone") + "\r\n");
            }
        }

        private unsafe void DASPwdCalculateTask()
        {
            uint num;
            int num2 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                uint num5;
                $ArrayType$$$BY0BA@E e$$$byba@e;
                this.AskForIgnition(true, this.m_LastOperationStr, true);
                if (!CmdLayerCreateDASPasswordType((byte*) &e$$$byba@e, 0x10, &num5, (byte) this.m_DASPwdType))
                {
                    CustomAssert(&??_C@_0BA@IJKHGAEM@DASPwdTasks?4cpp?$AA@, 0x17, true, null);
                }
                if (RunLongOperation((Command_t) 0xb3, (byte modopt(IsConst)*) &e$$$byba@e, num5, (Command_t) 180, (Command_t) 0xb5, 0))
                {
                    this.DASPwdCalculateOkThreadSafe(CmdLayerGetDASPassword());
                }
                else
                {
                    byte errorcode = CmdLayerGetErrorData((Command_t) 0xb5);
                    this.DASPwdCalculateFailedThreadSafe(this.GetErrorExplanation(errorcode));
                }
            }
            catch (UserAborted)
            {
                this.DASPwdCalculateFailedThreadSafe(this.GetLocalizedString("strUserAborted"));
            }
            catch (InvalidOBDPower)
            {
                this.DASPwdCalculateFailedThreadSafe(this.GetLocalizedString("strInvalidOBDPower"));
            }
            catch (NoOBDPower)
            {
                this.DASPwdCalculateFailedThreadSafe(this.GetLocalizedString("strNoOBDPower"));
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t;
                        byte num3 = (byte) _t;
                        this.AddToLogThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(num3) + ")!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(num3) + ")!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0BA@IJKHGAEM@DASPwdTasks?4cpp?$AA@, 60, false, null);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0BA@IJKHGAEM@DASPwdTasks?4cpp?$AA@, 0x4f, true, null);
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
        }

        private void DetectECUsFailedThreadSafe(string ErrorString)
        {
            if (this.InvokeRequired)
            {
                TaskFailedDelegate method = new TaskFailedDelegate(this.DetectECUsFailedThreadSafe);
                object[] args = new object[] { ErrorString };
                this.Invoke(method, args);
            }
            else
            {
                this.cbxDetectedECUs.Items.Clear();
                this.cbxDetectedECUs.Enabled = false;
                this.btnGenerateFullFaultsReport.Enabled = false;
                this.btnReadFaultCodes.Enabled = false;
                this.btnEraseFaultCodes.Enabled = false;
                this.gridFaultCodes.Rows.Clear();
                this.UpdateGridFaultCodesHeight();
                this.pnlFaultCodes.Enabled = false;
                this.StopOperation();
                this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + ErrorString + ")!\r\n");
                this.MessageBoxThreadSafe((this.GetLocalizedString("strDetectECUsFailed") + " (") + ErrorString + ")!", this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void DetectECUsOkThreadSafe()
        {
            if (this.InvokeRequired)
            {
                Action method = new Action(this.DetectECUsOkThreadSafe);
                base.Invoke(method);
            }
            else
            {
                this.FaultCodesFillECUList(this.m_DetectedECU);
                this.StopOperation();
                this.AddToLogThreadSafe(this.GetLocalizedString("strdone") + "\r\n");
            }
        }

        private unsafe void DetectECUsTask()
        {
            uint num;
            int num3 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                byte modopt(IsConst)* numPtr;
                byte num9;
                uint num10;
                this.AskForIgnition(true, this.m_LastOperationStr, true);
                if (!RunLongOperation((Command_t) 0xb6, null, 0, (Command_t) 0xb7, (Command_t) 0xb8, 0))
                {
                    goto Label_01E5;
                }
                CmdLayerGetECUListData(&numPtr, &num10);
                Array.Resize<ECUInfo>(ref this.m_DetectedECU, 0);
                uint num2 = 0;
            Label_0049:
                if (num2 >= num10)
                {
                    goto Label_01C3;
                }
                uint num7 = 0;
                int index = 0;
                while (true)
                {
                    if (index >= this.m_ECUInfo[this.m_TruckType].Length)
                    {
                        break;
                    }
                    if (this.m_ECUInfo[this.m_TruckType][index].m_addr == num2[numPtr])
                    {
                        num7++;
                    }
                    index++;
                }
                switch (num7)
                {
                    case 0:
                        goto Label_01BA;

                    case 1:
                        break;

                    default:
                        for (int i = 0; i < this.m_ECUInfo[this.m_TruckType].Length; i++)
                        {
                            if (this.m_ECUInfo[this.m_TruckType][i].m_addr == num2[numPtr])
                            {
                                Array.Resize<ECUInfo>(ref this.m_DetectedECU, this.m_DetectedECU.Length + 1);
                                this.m_DetectedECU[this.m_DetectedECU.Length - 1] = this.m_ECUInfo[this.m_TruckType][i];
                            }
                        }
                        goto Label_01BA;
                }
                int num4 = 0;
                while (true)
                {
                    if (num4 >= this.m_ECUInfo[this.m_TruckType].Length)
                    {
                        break;
                    }
                    if (this.m_ECUInfo[this.m_TruckType][num4].m_addr == num2[numPtr])
                    {
                        Array.Resize<ECUInfo>(ref this.m_DetectedECU, this.m_DetectedECU.Length + 1);
                        this.m_DetectedECU[this.m_DetectedECU.Length - 1] = this.m_ECUInfo[this.m_TruckType][num4];
                        break;
                    }
                    num4++;
                }
            Label_01BA:
                num2++;
                goto Label_0049;
            Label_01C3:
                Array.Sort<ECUInfo>(this.m_DetectedECU, new Comparison<ECUInfo>(<Module>.ECUInfoCompare));
                this.DetectECUsOkThreadSafe();
                return;
            Label_01E5:
                num9 = CmdLayerGetErrorData((Command_t) 0xb8);
                this.DetectECUsFailedThreadSafe(this.GetErrorExplanation(num9));
            }
            catch (UserAborted)
            {
                this.DetectECUsFailedThreadSafe(this.GetLocalizedString("strUserAborted"));
            }
            catch (InvalidOBDPower)
            {
                this.DetectECUsFailedThreadSafe(this.GetLocalizedString("strInvalidOBDPower"));
            }
            catch (NoOBDPower)
            {
                this.DetectECUsFailedThreadSafe(this.GetLocalizedString("strNoOBDPower"));
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num3);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t;
                        byte errorcode = (byte) _t;
                        this.AddToLogThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(errorcode) + ")!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(errorcode) + ")!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0BE@NEIAFJLK@FaultCodesTasks?4cpp?$AA@, 0x77, false, null);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num3, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num3);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num3, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num3);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0BE@NEIAFJLK@FaultCodesTasks?4cpp?$AA@, 0x8a, true, null);
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num3, (int) num);
                }
            }
        }

        private unsafe void DeviceUpdateTask()
        {
            HttpServer.GETparameter[] parameters = null;
            uint num2;
            int num8;
            uint num25 = (uint) ___CxxQueryExceptionSize();
            int num6 = (int) stackalloc byte[(num25 << 1)];
            HttpServer server = new HttpServer(this.m_UpdateAgent);
            try
            {
                uint num3;
                ValueType modopt(HttpServer.HttpResponse) modopt(IsBoxed) type;
                CommandType_t _t;
                uint num4;
                uint num16;
                bool flag;
                bool flag2;
                byte num27;
                byte num28;
                uint modopt(IsLong) num29;
                ushort num30;
                marshal_context _context2;
                $ArrayType$$$BY0EBC@E e$$$byebc@e;
                num8 = ((int) num25) + num6;
                if (!server.IsSessionAlive() && !server.CreateSession(this.m_DeviceUpdateURL))
                {
                    this.StopDeviceUpdateThreadSafe(DeviceUpdateResult_t.CantConnectServer, 0, null);
                }
                else
                {
                    parameters = new HttpServer.GETparameter[6];
                    parameters[0].Key = "pid";
                    parameters[0].Value = this.m_ProductID.ToString();
                    parameters[1].Key = "stat";
                    parameters[1].Value = this.m_DeviceStatus.ToString();
                    parameters[2].Key = "id";
                    parameters[2].Value = $"{(uint) this.m_DeviceID:X8}";
                    parameters[3].Key = "hwv";
                    parameters[3].Value = this.m_HwVersion.ToString();
                    parameters[4].Key = "ldrv";
                    parameters[4].Value = this.m_LdrVersion.ToString();
                    parameters[5].Key = "swv";
                    parameters[5].Value = this.m_SwVersion.ToString();
                    ValueType modopt(HttpServer.HttpResponse) modopt(IsBoxed) type2 = new HttpServer.HttpResponse();
                    type = type2;
                    if (!server.Request(parameters, ref (HttpServer.HttpResponse) type2))
                    {
                        server.DestroySession();
                        this.StopDeviceUpdateThreadSafe(DeviceUpdateResult_t.CantConnectServer, 0, null);
                    }
                    else if (((HttpServer.HttpResponse) type2).ContentType != HttpServer.HttpResponseContentType.Text)
                    {
                        server.DestroySession();
                        this.StopDeviceUpdateThreadSafe(DeviceUpdateResult_t.BadServerData, 0, null);
                    }
                    else
                    {
                        char[] chArray3 = new char[] { '\n' };
                        string[] strArray3 = ((HttpServer.HttpResponse) type2).text.Split(chArray3);
                        try
                        {
                            int num19 = Convert.ToInt32(strArray3[0]);
                            if (num19 == 0)
                            {
                                goto Label_0237;
                            }
                            server.DestroySession();
                            if (strArray3.Length == 2)
                            {
                                this.StopDeviceUpdateThreadSafe(DeviceUpdateResult_t.BadServerResponse, (byte) num19, strArray3[1]);
                            }
                            else
                            {
                                this.StopDeviceUpdateThreadSafe(DeviceUpdateResult_t.BadServerResponse, (byte) num19, null);
                            }
                        }
                        catch (FormatException)
                        {
                            server.DestroySession();
                            this.StopDeviceUpdateThreadSafe(DeviceUpdateResult_t.BadServerData, 0, null);
                        }
                    }
                }
                return;
            Label_0237:
                flag2 = false;
                int num18 = 0;
            Label_023D:
                Array.Resize<HttpServer.GETparameter>(ref parameters, 1);
                parameters[0].Key = "cmd";
                parameters[0].Value = "GETNEXTCMD";
                if (!server.Request(parameters, ref (HttpServer.HttpResponse) type))
                {
                    server.DestroySession();
                    this.StopDeviceUpdateThreadSafe(DeviceUpdateResult_t.CantConnectServer, 0, null);
                    return;
                }
                if (((HttpServer.HttpResponse) type).ContentType != HttpServer.HttpResponseContentType.Text)
                {
                    server.DestroySession();
                    this.StopDeviceUpdateThreadSafe(DeviceUpdateResult_t.BadServerData, 0, null);
                    return;
                }
                char[] separator = new char[] { '\n' };
                string[] strArray = ((HttpServer.HttpResponse) type).text.Split(separator);
                if ((strArray[0] == "FINISH") && (strArray.Length == 1))
                {
                    DateTime now = DateTime.Now;
                    this.m_Settings.DeviceUpdateLastCheckTime = now;
                    goto Label_0F65;
                }
                if ((strArray[0] != "UPLOADFILE") || (strArray.Length != 2))
                {
                    goto Label_061E;
                }
                if (strArray[1] != "PC:GUIErrors.log")
                {
                    goto Label_03F6;
                }
                byte[] filedata = null;
                try
                {
                    filedata = System.IO.File.ReadAllBytes(new string(GetAssertLogFilename()));
                }
                catch when (?)
                {
                    num3 = 0;
                    ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num6);
                    try
                    {
                        try
                        {
                            goto Label_0398;
                        }
                        catch when (?)
                        {
                        }
                        if (num3 != 0)
                        {
                            throw;
                        }
                    }
                    finally
                    {
                        ___CxxUnregisterExceptionObject((void*) num6, (int) num3);
                    }
                }
            Label_0398:
                if (filedata == null)
                {
                    goto Label_0F65;
                }
                Array.Resize<HttpServer.GETparameter>(ref parameters, 1);
                parameters[0].Key = "cmd";
                parameters[0].Value = strArray[0];
                if (server.UploadFile("GUIErrors.log", filedata, parameters, ref (HttpServer.HttpResponse) type))
                {
                    goto Label_0F65;
                }
                server.DestroySession();
                this.StopDeviceUpdateThreadSafe(DeviceUpdateResult_t.CantConnectServer, 0, null);
                return;
            Label_03F6:
                _context2 = new marshal_context();
                if (!CmdLayerCreateStartFileReadData((byte*) &e$$$byebc@e, 0x412, &num4, _context2.marshal_as<char const *,System::String>(strArray[1])))
                {
                    CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0xb2, true, null);
                }
                if (!SendRequestWaitForAnswer((Command_t) 0x60, (byte modopt(IsConst)*) &e$$$byebc@e, num4, &_t))
                {
                    CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 180, true, null);
                }
                if (_t != ((CommandType_t) 1))
                {
                    CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0xb5, true, null);
                }
                uint modopt(IsLong) num17 = CmdLayerGetFileLengthToRead();
                if (num17 <= 0)
                {
                    goto Label_0F65;
                }
                byte[] buffer2 = new byte[num17];
                uint modopt(IsLong) offset = 0;
                do
                {
                    byte modopt(IsConst)* numPtr3;
                    if (this.m_SwVersion >= 0xcad)
                    {
                        if (!CmdLayerCreateFileReadNewData((byte*) &e$$$byebc@e, 0x412, &num4, offset, 0x400))
                        {
                            CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0xc9, true, null);
                        }
                        if (!SendRequestWaitForAnswer((Command_t) 0x67, (byte modopt(IsConst)*) &e$$$byebc@e, num4, &_t))
                        {
                            CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0xca, true, null);
                        }
                        if (_t != ((CommandType_t) 1))
                        {
                            CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0xcb, true, null);
                        }
                        CmdLayerGetFileReadNewAnswer(&numPtr3, &num16);
                    }
                    else
                    {
                        uint modopt(IsLong) num31;
                        if (!SendRequestWaitForAnswer((Command_t) 0x61, null, 0, &_t))
                        {
                            CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0xd1, true, null);
                        }
                        if (_t != ((CommandType_t) 1))
                        {
                            CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 210, true, null);
                        }
                        CmdLayerGetFileReadAnswer(&num31, &numPtr3, &num16);
                        if (offset != num31)
                        {
                            CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0xd4, true, null);
                        }
                    }
                    uint num13 = 0;
                    while (true)
                    {
                        if (num13 >= num16)
                        {
                            break;
                        }
                        buffer2[num13 + offset] = *((byte*) (num13 + numPtr3));
                        num13++;
                    }
                    offset = num16 + offset;
                }
                while (num16 != 0);
                if (offset != num17)
                {
                    CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0xdf, true, null);
                }
                if (!SendRequestWaitForAnswer((Command_t) 0x62, null, 0, &_t))
                {
                    CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0xe3, true, null);
                }
                if (_t != ((CommandType_t) 1))
                {
                    CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0xe4, true, null);
                }
                Array.Resize<HttpServer.GETparameter>(ref parameters, 1);
                parameters[0].Key = "cmd";
                parameters[0].Value = strArray[0];
                if (server.UploadFile(strArray[1], buffer2, parameters, ref (HttpServer.HttpResponse) type))
                {
                    goto Label_0F65;
                }
                server.DestroySession();
                this.StopDeviceUpdateThreadSafe(DeviceUpdateResult_t.CantConnectServer, 0, null);
                return;
            Label_061E:
                if ((strArray[0] == "ERASEFILE") && (strArray.Length == 2))
                {
                    if (strArray[1] == "PC:GUIErrors.log")
                    {
                        try
                        {
                            System.IO.File.Delete(new string(GetAssertLogFilename()));
                            goto Label_0F65;
                        }
                        catch when (?)
                        {
                            num3 = 0;
                            ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num6);
                            try
                            {
                                try
                                {
                                    goto Label_0F65;
                                }
                                catch when (?)
                                {
                                }
                                if (num3 != 0)
                                {
                                    throw;
                                }
                            }
                            finally
                            {
                                ___CxxUnregisterExceptionObject((void*) num6, (int) num3);
                            }
                            goto Label_0F65;
                        }
                    }
                    marshal_context _context = new marshal_context();
                    if (!CmdLayerCreateDeleteFileData((byte*) &e$$$byebc@e, 0x412, &num4, _context.marshal_as<char const *,System::String>(strArray[1])))
                    {
                        CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x112, true, null);
                    }
                    if (!SendRequestWaitForAnswer((Command_t) 0x63, (byte modopt(IsConst)*) &e$$$byebc@e, num4, &_t))
                    {
                        CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x114, true, null);
                    }
                    if (_t != ((CommandType_t) 1))
                    {
                        CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x115, true, null);
                    }
                    goto Label_0F65;
                }
                if ((strArray[0] != "GETUPDATE") || (strArray.Length != 1))
                {
                    goto Label_0F3F;
                }
                this.AddToLogThreadSafe(this.GetLocalizedString("strdone"));
                if ((this.m_AutomaticDeviceUpdate && (num18 <= 0)) && (this.MessageBoxThreadSafe(this.GetLocalizedString("strWantToUpdateDevice"), this.GetLocalizedString("strUpdateDevice"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes))
                {
                    goto Label_0F65;
                }
                this.AddToLogThreadSafe("\r\n");
                this.AddToLogThreadSafe(this.GetLocalizedString("strUpdatingDevice"));
                uint modopt(IsLong) cb = 0;
                byte* numPtr = null;
                bool flag3 = false;
                Array.Resize<HttpServer.GETparameter>(ref parameters, 1);
                parameters[0].Key = "cmd";
                parameters[0].Value = strArray[0];
                if (!server.Request(parameters, ref (HttpServer.HttpResponse) type))
                {
                    server.DestroySession();
                    this.StopDeviceUpdateThreadSafe(DeviceUpdateResult_t.CantConnectServer, 0, null);
                    return;
                }
                if (((HttpServer.HttpResponse) type).ContentType != HttpServer.HttpResponseContentType.Bytes)
                {
                    goto Label_0F2A;
                }
                cb = (uint modopt(IsLong)) ((HttpServer.HttpResponse) type).bytes.Length;
                byte* numPtr2 = (byte*) new[](cb);
                numPtr = numPtr2;
                if (numPtr2 == null)
                {
                    CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x16e, true, null);
                }
                uint modopt(IsLong) index = 0;
                while (true)
                {
                    if (index >= cb)
                    {
                        break;
                    }
                    index[(int) numPtr] = ((HttpServer.HttpResponse) type).bytes[index];
                    index++;
                }
                if (cb != 0x6f56a)
                {
                    byte* numPtr9 = numPtr;
                    delete[]((void*) numPtr);
                    server.DestroySession();
                    this.StopDeviceUpdateThreadSafe(DeviceUpdateResult_t.BadServerData, 0, null);
                    return;
                }
                memcpy(&num30, (numPtr + 0x6f568), 2);
                if (CRC16Calc((byte modopt(IsConst)*) numPtr, 0x6f568) != num30)
                {
                    byte* numPtr8 = numPtr;
                    delete[]((void*) numPtr);
                    server.DestroySession();
                    this.StopDeviceUpdateThreadSafe(DeviceUpdateResult_t.BadServerData, 0, null);
                    return;
                }
                memcpy(&num29, numPtr, 4);
                if (this.m_DeviceID != num29)
                {
                    byte* numPtr7 = numPtr;
                    delete[]((void*) numPtr);
                    server.DestroySession();
                    this.StopDeviceUpdateThreadSafe(DeviceUpdateResult_t.BadServerData, 0, null);
                    return;
                }
                if (!SendRequestWaitForAnswer((Command_t) 80, null, 0, &_t))
                {
                    CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x1a2, true, null);
                }
                if (_t != ((CommandType_t) 1))
                {
                    CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x1a3, true, null);
                }
                delayMs(0x7d0);
                if (!SendRequestWaitForAnswer((Command_t) 0x54, null, 0, &_t))
                {
                    CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x1a9, true, null);
                }
                if (_t != ((CommandType_t) 1))
                {
                    CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x1aa, true, null);
                }
                delayMs(0x7d0);
                this.SetProgressBoundsThreadSafe(0, 0x6f56a);
                memcpy(&num28, (numPtr + 6), 1);
                if (!CmdLayerCreateInitUpdateData((byte*) &e$$$byebc@e, 0x412, &num4, num28))
                {
                    CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x1ba, true, null);
                }
                if (!SendRequestWaitForAnswer((Command_t) 0x51, (byte modopt(IsConst)*) &e$$$byebc@e, num4, &_t))
                {
                    CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x1bb, true, null);
                }
                if (_t != ((CommandType_t) 1))
                {
                    CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x1bc, true, null);
                }
                ushort blockidx = 1;
                uint modopt(IsLong) num24 = 0x6edc7;
                uint num14 = 0x408;
                uint modopt(IsLong) val = 7;
                while (val < num24)
                {
                    uint num10;
                    CommandType_t _t3;
                    uint modopt(IsLong) num23 = num24 - val;
                    if (num14 < num23)
                    {
                        num10 = num14;
                    }
                    else
                    {
                        num10 = num23;
                    }
                    uint num37 = num10;
                    if (this.m_LdrVersion >= 0xcad)
                    {
                        if (!CmdLayerCreateUpdateFlashDataNew((byte*) &e$$$byebc@e, 0x412, &num4, blockidx, val + numPtr, num10))
                        {
                            CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x1d1, true, null);
                        }
                    }
                    else if (!CmdLayerCreateUpdateFlashData((byte*) &e$$$byebc@e, 0x412, &num4, val + numPtr, num10))
                    {
                        CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x1d3, true, null);
                    }
                    val = num10 + val;
                    blockidx = (ushort) (blockidx + 1);
                    if (this.m_LdrVersion >= 0xcad)
                    {
                        if (!SendRequestWaitForAnswer((Command_t) 0x59, (byte modopt(IsConst)*) &e$$$byebc@e, num4, &_t3))
                        {
                            CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x1da, true, null);
                        }
                    }
                    else if (!SendRequestWaitForAnswer((Command_t) 0x52, (byte modopt(IsConst)*) &e$$$byebc@e, num4, &_t3))
                    {
                        CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x1dc, true, null);
                    }
                    if (_t3 != ((CommandType_t) 1))
                    {
                        if (_t3 == ((CommandType_t) 2))
                        {
                            byte* numPtr6 = numPtr;
                            delete[]((void*) numPtr);
                            server.DestroySession();
                            this.StopDeviceUpdateThreadSafe(DeviceUpdateResult_t.Failed, CmdLayerGetErrorCode(), null);
                            return;
                        }
                        CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x1ed, true, null);
                    }
                    else
                    {
                        this.SetProgressValueThreadSafe(val);
                    }
                }
                memcpy(&num27, (val + numPtr), 1);
                val++;
                if (!CmdLayerCreateInitUpdateData((byte*) &e$$$byebc@e, 0x412, &num4, num27))
                {
                    CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x1fb, true, null);
                }
                if (!SendRequestWaitForAnswer((Command_t) 0x51, (byte modopt(IsConst)*) &e$$$byebc@e, num4, &_t))
                {
                    CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x1fc, true, null);
                }
                if (_t != ((CommandType_t) 1))
                {
                    CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x1fd, true, null);
                }
                blockidx = 1;
                uint modopt(IsLong) num22 = cb - 2;
                while (val < num22)
                {
                    uint num9;
                    CommandType_t _t2;
                    uint modopt(IsLong) num21 = num22 - val;
                    if (num14 < num21)
                    {
                        num9 = num14;
                    }
                    else
                    {
                        num9 = num21;
                    }
                    uint num36 = num9;
                    if (this.m_LdrVersion >= 0xcad)
                    {
                        if (!CmdLayerCreateUpdateSRAMDataNew((byte*) &e$$$byebc@e, 0x412, &num4, blockidx, val + numPtr, num9))
                        {
                            CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x209, true, null);
                        }
                    }
                    else if (!CmdLayerCreateUpdateSRAMData((byte*) &e$$$byebc@e, 0x412, &num4, val + numPtr, num9))
                    {
                        CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x20b, true, null);
                    }
                    val = num9 + val;
                    blockidx = (ushort) (blockidx + 1);
                    if (this.m_LdrVersion >= 0xcad)
                    {
                        if (!SendRequestWaitForAnswer((Command_t) 90, (byte modopt(IsConst)*) &e$$$byebc@e, num4, &_t2))
                        {
                            CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 530, true, null);
                        }
                    }
                    else if (!SendRequestWaitForAnswer((Command_t) 0x53, (byte modopt(IsConst)*) &e$$$byebc@e, num4, &_t2))
                    {
                        CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x214, true, null);
                    }
                    if (_t2 != ((CommandType_t) 1))
                    {
                        if (_t2 == ((CommandType_t) 2))
                        {
                            byte* numPtr5 = numPtr;
                            delete[]((void*) numPtr);
                            server.DestroySession();
                            this.StopDeviceUpdateThreadSafe(DeviceUpdateResult_t.Failed, CmdLayerGetErrorCode(), null);
                            return;
                        }
                        CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x225, true, null);
                    }
                    else
                    {
                        this.SetProgressValueThreadSafe(val);
                    }
                }
                this.SetProgressUndefinedThreadSafe();
                byte* numPtr4 = numPtr;
                delete[]((void*) numPtr);
                if (!SendRequestWaitForAnswer((Command_t) 0x54, null, 0, &_t))
                {
                    CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x22f, true, null);
                }
                if (_t != ((CommandType_t) 1))
                {
                    CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 560, true, null);
                }
                uint modopt(IsLong) timeInMs = GetTimeInMs();
            Label_0D21:
                flag = false;
                delayMs(0xbb8);
                try
                {
                    if (!SendRequestWaitForAnswer((Command_t) 0, null, 0, &_t))
                    {
                        CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x240, true, null);
                    }
                    goto Label_0DC9;
                }
                catch when (?)
                {
                    num3 = 0;
                    ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num6);
                    try
                    {
                        try
                        {
                            CommandUtilsError_t _t5;
                            if ((_t5 == ((CommandUtilsError_t) 0x20)) && ((GetTimeInMs() - timeInMs) < 0x7530))
                            {
                                flag = true;
                            }
                            else
                            {
                                _CxxThrowException(null, null);
                            }
                            goto Label_0DC2;
                        }
                        catch when (?)
                        {
                        }
                        if (num3 != 0)
                        {
                            throw;
                        }
                    }
                    finally
                    {
                        ___CxxUnregisterExceptionObject((void*) num6, (int) num3);
                    }
                }
            Label_0DC2:
                if (flag)
                {
                    goto Label_0D21;
                }
            Label_0DC9:
                if (_t != ((CommandType_t) 1))
                {
                    CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x251, true, null);
                }
                if (CmdLayerGetDeviceStatus() != 0)
                {
                    server.DestroySession();
                    this.StopDeviceUpdateThreadSafe(DeviceUpdateResult_t.FinalCheckFailed, 0, null);
                    return;
                }
                if (!flag3)
                {
                    Array.Resize<HttpServer.GETparameter>(ref parameters, 2);
                    parameters[0].Key = "cmd";
                    parameters[0].Value = "UPDATEDONE";
                    parameters[1].Key = "arg0";
                    parameters[1].Value = CmdLayerGetDeviceSwVer().ToString();
                    if (!server.Request(parameters, ref (HttpServer.HttpResponse) type))
                    {
                        server.DestroySession();
                        this.StopDeviceUpdateThreadSafe(DeviceUpdateResult_t.CantConnectServer, 0, null);
                    }
                    else if (((HttpServer.HttpResponse) type).ContentType != HttpServer.HttpResponseContentType.Text)
                    {
                        server.DestroySession();
                        this.StopDeviceUpdateThreadSafe(DeviceUpdateResult_t.BadServerData, 0, null);
                    }
                    else
                    {
                        char[] chArray = new char[] { '\n' };
                        string[] strArray2 = ((HttpServer.HttpResponse) type).text.Split(chArray);
                        try
                        {
                            int num15 = Convert.ToInt32(strArray2[0]);
                            if (num15 == 0)
                            {
                                goto Label_0F1F;
                            }
                            server.DestroySession();
                            if (strArray2.Length == 2)
                            {
                                this.StopDeviceUpdateThreadSafe(DeviceUpdateResult_t.BadServerResponse, (byte) num15, strArray2[1]);
                            }
                            else
                            {
                                this.StopDeviceUpdateThreadSafe(DeviceUpdateResult_t.BadServerResponse, (byte) num15, null);
                            }
                        }
                        catch (FormatException)
                        {
                            server.DestroySession();
                            this.StopDeviceUpdateThreadSafe(DeviceUpdateResult_t.BadServerData, 0, null);
                        }
                    }
                    return;
                }
            Label_0F1F:
                flag2 = true;
                num18++;
                goto Label_0F65;
            Label_0F2A:
                server.DestroySession();
                this.StopDeviceUpdateThreadSafe(DeviceUpdateResult_t.BadServerData, 0, null);
                return;
            Label_0F3F:
                if ((strArray[0] != "SHOWMSG") || (strArray.Length != 2))
                {
                    goto Label_0F9B;
                }
                this.MessageBoxThreadSafe(strArray[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Label_0F65:
                if (strArray[0] != "FINISH")
                {
                    goto Label_023D;
                }
                server.DestroySession();
                if (flag2)
                {
                    this.StopDeviceUpdateThreadSafe(DeviceUpdateResult_t.SuccessUpdated, 0, null);
                }
                else
                {
                    this.StopDeviceUpdateThreadSafe(DeviceUpdateResult_t.SuccessNoUpdates, 0, null);
                }
                return;
            Label_0F9B:
                server.DestroySession();
                this.StopDeviceUpdateThreadSafe(DeviceUpdateResult_t.BadServerData, 0, null);
            }
            catch when (?)
            {
                num2 = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num8);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t4;
                        server.DestroySession();
                        byte errorcode = (byte) _t4;
                        this.AddToLogThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(errorcode) + ")!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(errorcode) + ")!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x2ca, false, null);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num2 != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num8, (int) num2);
                }
            }
            catch when (?)
            {
                num2 = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num8);
                try
                {
                    try
                    {
                        server.DestroySession();
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num2 != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num8, (int) num2);
                }
            }
            catch (FileNotFoundException)
            {
                this.AddToLogThreadSafe("NET Framework 4.0 Full not found!");
                this.AddToLogThreadSafe("\r\n");
                this.MessageBoxThreadSafe("Microsoft Framework 4.0 Full was not found. Please install it before using this application.", "Library missed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.DisconnectThreadSafe();
            }
            catch when (?)
            {
                num2 = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num8);
                try
                {
                    try
                    {
                        server.DestroySession();
                        CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x2ef, true, null);
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num2 != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num8, (int) num2);
                }
            }
        }

        private void DisconnectThreadSafe()
        {
            if (this.InvokeRequired)
            {
                Action method = new Action(this.DisconnectThreadSafe);
                base.Invoke(method);
            }
            else
            {
                if (RS232IsDeviceOpened())
                {
                    RS232CloseDevice();
                    this.m_ConnectionState = ConnectionState_t.NotConnected;
                    this.m_DeviceID = 0;
                }
                this.tabctlActions.Enabled = true;
                int num = 0;
                if (0 < this.tabctlActions.TabPages.Count)
                {
                    do
                    {
                        if (this.tabctlActions.TabPages[num] != this.tabSettings)
                        {
                            this.tabctlActions.TabPages[num].Enabled = false;
                        }
                        num++;
                    }
                    while (num < this.tabctlActions.TabPages.Count);
                }
                base.UseWaitCursor = false;
                this.pbarProgress.Visible = false;
                this.pbarProgress.Style = ProgressBarStyle.Marquee;
                this.UpdateCarNavigationImage();
                this.m_IsDirectConnection = false;
                this.m_IsBootstrapMode = false;
                this.m_MRMotorNumber = null;
                this.m_VIN = null;
                this.m_MANMainECU = MANMainECU_t.Unknown;
                this.m_MemoryTab.Clear();
                this.m_KeysTab.Clear();
                this.m_ExtraTab.Clear();
                this.m_SwVersion = 0;
                this.m_VeDocCryptoKeySetWasCalled = false;
                this.m_FDOKIDValid = false;
                this.m_FDOKRndValid = false;
                this.m_EngineEnabled = true;
                this.m_MANEnabled = true;
                this.m_MBEnabled = true;
                this.MemUpdateECUList();
                this.MemUpdateECUInfo();
                this.lblKeysInfo.Text = null;
                this.KeysUpdateOperationList();
                this.edVeDocVIN.Clear();
                this.edVeDocRnd.Enabled = false;
                this.edVeDocRnd.Clear();
                this.edVeDocID.Enabled = false;
                this.edVeDocID.Clear();
                this.edVeDocNumOfKeys.Enabled = false;
                this.edVeDocNumOfKeys.Clear();
                this.edVeDocTransponderCode.Enabled = false;
                this.edVeDocTransponderCode.Clear();
                this.cbxVeDocCalcType.Enabled = false;
                this.cbxVeDocCalcType.SelectedIndex = -1;
                this.btnVeDocCalculate.Enabled = false;
                this.edVeDocResult.Clear();
                this.edVeDocResult.Enabled = false;
                this.maskedFDOKRnd.Clear();
                this.maskedFDOKID.Clear();
                this.cbxFDOKCalcType.SelectedIndex = -1;
                this.btnFDOKCalculate.Enabled = false;
                this.edFDOKOldResult.Clear();
                this.edFDOKOldResult.Enabled = false;
                this.edFDOKNewResult.Clear();
                this.edFDOKNewResult.Enabled = false;
                this.cbxDASPwdType.SelectedIndex = -1;
                this.edDASPwd.Clear();
                this.edDASPwd.Enabled = false;
                this.btnDASPwdCalc.Enabled = false;
                this.ExtraUpdateOperationList();
                this.btnGenerateFullFaultsReport.Enabled = false;
                this.btnReadFaultCodes.Enabled = false;
                this.btnEraseFaultCodes.Enabled = false;
                this.cbxDetectedECUs.Items.Clear();
                this.cbxDetectedECUs.Enabled = false;
                this.gridFaultCodes.Rows.Clear();
                this.UpdateGridFaultCodesHeight();
                this.pnlFaultCodes.Enabled = false;
                this.lblDeviceInfo.Text = this.GetLocalizedString("strDeviceNotConnected");
                this.lblCurrentVEIInfo.Text = this.GetLocalizedString("strDeviceNotConnected");
                this.btnUpdateDevice.Enabled = false;
                this.cbxSystemVoltage.Enabled = true;
                if (!this.tabctlActions.TabPages.Contains(this.tabMemory))
                {
                    this.tabctlActions.TabPages.Insert(0, this.tabMemory);
                }
                if (!this.tabctlActions.TabPages.Contains(this.tabLearnKeys))
                {
                    this.tabctlActions.TabPages.Insert(1, this.tabLearnKeys);
                }
                if (!this.tabctlActions.TabPages.Contains(this.tabVeDocCalc))
                {
                    this.tabctlActions.TabPages.Insert(2, this.tabVeDocCalc);
                }
                if (!this.tabctlActions.TabPages.Contains(this.tabFDOKCalc))
                {
                    this.tabctlActions.TabPages.Insert(3, this.tabFDOKCalc);
                }
                if (!this.tabctlActions.TabPages.Contains(this.tabDASPwdCalc))
                {
                    this.tabctlActions.TabPages.Insert(4, this.tabDASPwdCalc);
                }
                if (!this.tabctlActions.TabPages.Contains(this.tabExtra))
                {
                    this.tabctlActions.TabPages.Insert(5, this.tabExtra);
                }
                if (!this.tabctlActions.TabPages.Contains(this.tabFaultCodes))
                {
                    this.tabctlActions.TabPages.Insert(6, this.tabFaultCodes);
                }
                this.UpdateCarNavigationButtons();
                this.btnConnect.Enabled = true;
                this.btnDisconnect.Enabled = false;
                this.m_OperationRunning = false;
            }
        }

        [HandleProcessCorruptedStateExceptions]
        protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool flag1)
        {
            if (flag1)
            {
                try
                {
                    this.~MainForm();
                    return;
                }
                finally
                {
                    try
                    {
                        base.Dispose(true);
                    }
                    finally
                    {
                        try
                        {
                            this.m_DASPwdTypes.Dispose();
                        }
                        finally
                        {
                            try
                            {
                                this.m_VeDocCalcTypes.Dispose();
                            }
                            finally
                            {
                            }
                        }
                    }
                }
            }
            base.Dispose(false);
        }

        private void EraseEmissionFaultsFailedThreadSafe(string ErrorString)
        {
            if (this.InvokeRequired)
            {
                TaskFailedDelegate method = new TaskFailedDelegate(this.EraseEmissionFaultsFailedThreadSafe);
                object[] args = new object[] { ErrorString };
                this.Invoke(method, args);
            }
            else
            {
                this.StopOperation();
                this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + ErrorString + ")!\r\n");
                this.MessageBoxThreadSafe((this.GetLocalizedString("strEraseEmissionFaultsFailed") + " (") + ErrorString + ")!", this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void EraseEmissionFaultsOkThreadSafe()
        {
            if (this.InvokeRequired)
            {
                Action method = new Action(this.EraseEmissionFaultsOkThreadSafe);
                base.Invoke(method);
            }
            else
            {
                this.StopOperation();
                this.AddToLogThreadSafe(this.GetLocalizedString("strdone") + "\r\n");
            }
        }

        private unsafe void EraseEmissionFaultsTask()
        {
            uint num;
            int num2 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                this.AskForIgnition(true, this.m_LastOperationStr, true);
                if (RunLongOperation((Command_t) 0xa2, null, 0, (Command_t) 0xa3, (Command_t) 0xa4, 0))
                {
                    this.EraseEmissionFaultsOkThreadSafe();
                }
                else
                {
                    byte errorcode = CmdLayerGetErrorData((Command_t) 0xa4);
                    this.EraseEmissionFaultsFailedThreadSafe(this.GetErrorExplanation(errorcode));
                }
            }
            catch (UserAborted)
            {
                this.EraseEmissionFaultsFailedThreadSafe(this.GetLocalizedString("strUserAborted"));
            }
            catch (InvalidOBDPower)
            {
                this.EraseEmissionFaultsFailedThreadSafe(this.GetLocalizedString("strInvalidOBDPower"));
            }
            catch (NoOBDPower)
            {
                this.EraseEmissionFaultsFailedThreadSafe(this.GetLocalizedString("strNoOBDPower"));
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t;
                        byte num3 = (byte) _t;
                        this.AddToLogThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(num3) + ")!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(num3) + ")!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0P@NKJDEOOE@ExtraTasks?4cpp?$AA@, 0x297, false, null);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0P@NKJDEOOE@ExtraTasks?4cpp?$AA@, 0x2aa, true, null);
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
        }

        private void EraseFaultsFailedThreadSafe(string ErrorString)
        {
            if (this.InvokeRequired)
            {
                TaskFailedDelegate method = new TaskFailedDelegate(this.EraseFaultsFailedThreadSafe);
                object[] args = new object[] { ErrorString };
                this.Invoke(method, args);
            }
            else
            {
                this.StopOperation();
                this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + ErrorString + ")!\r\n");
            }
        }

        private void EraseFaultsOkThreadSafe()
        {
            if (this.InvokeRequired)
            {
                Action method = new Action(this.EraseFaultsOkThreadSafe);
                base.Invoke(method);
            }
            else
            {
                this.StopOperation();
                this.AddToLogThreadSafe(this.GetLocalizedString("strdone") + "\r\n");
            }
        }

        private unsafe void EraseFaultsTask()
        {
            uint num;
            int num2 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                TruckType_t truckType = this.m_TruckType;
                if (*(((int*) &truckType)) != 0)
                {
                    if (*(((int*) &truckType)) != 1)
                    {
                        CustomAssert(&??_C@_0BE@NEIAFJLK@FaultCodesTasks?4cpp?$AA@, 0x1e7, true, null);
                    }
                    else
                    {
                        this.TaskNotImplementedThreadSafe();
                    }
                }
                else
                {
                    uint num5;
                    $ArrayType$$$BY0BA@E e$$$byba@e;
                    this.AskForIgnition(true, this.m_LastOperationStr, true);
                    if (!CmdLayerCreateDTCClearParams((byte*) &e$$$byba@e, 0x10, &num5, this.m_DetectedECU[this.m_CurrentECUIdx].m_addr))
                    {
                        CustomAssert(&??_C@_0BE@NEIAFJLK@FaultCodesTasks?4cpp?$AA@, 0x1d4, true, null);
                    }
                    if (RunLongOperation((Command_t) 0xbc, (byte modopt(IsConst)*) &e$$$byba@e, num5, (Command_t) 0xbd, (Command_t) 190, 0))
                    {
                        this.EraseFaultsOkThreadSafe();
                    }
                    else
                    {
                        byte errorcode = CmdLayerGetErrorData((Command_t) 190);
                        this.ReadFaultsFailedThreadSafe(this.GetErrorExplanation(errorcode));
                    }
                }
            }
            catch (UserAborted)
            {
                this.EraseFaultsFailedThreadSafe(this.GetLocalizedString("strUserAborted"));
            }
            catch (InvalidOBDPower)
            {
                this.EraseFaultsFailedThreadSafe(this.GetLocalizedString("strInvalidOBDPower"));
            }
            catch (NoOBDPower)
            {
                this.EraseFaultsFailedThreadSafe(this.GetLocalizedString("strNoOBDPower"));
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t;
                        byte num3 = (byte) _t;
                        this.AddToLogThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(num3) + ")!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(num3) + ")!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0BE@NEIAFJLK@FaultCodesTasks?4cpp?$AA@, 0x203, false, null);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0BE@NEIAFJLK@FaultCodesTasks?4cpp?$AA@, 0x216, true, null);
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
        }

        private unsafe void ExtraUpdateOperationList()
        {
            this.cbxExtraOperation.Items.Clear();
            int num = 0;
            if (0 < this.m_ExtraTab.m_OperationList.Count)
            {
                do
                {
                    switch (this.m_ExtraTab.m_OperationList[num])
                    {
                        case ExtraTab.Operation.GetSpeedLimit:
                            this.cbxExtraOperation.Items.Add(this.GetLocalizedString("strGetSpeedLimit"));
                            break;

                        case ExtraTab.Operation.SetSpeedLimit:
                            this.cbxExtraOperation.Items.Add(this.GetLocalizedString("strSetSpeedLimit"));
                            break;

                        case ExtraTab.Operation.GetTorqueLimit:
                            this.cbxExtraOperation.Items.Add(this.GetLocalizedString("strGetTorqueLimit"));
                            break;

                        case ExtraTab.Operation.SetTorqueLimit:
                            this.cbxExtraOperation.Items.Add(this.GetLocalizedString("strSetTorqueLimit"));
                            break;

                        case ExtraTab.Operation.EraseEmissionFaults:
                            this.cbxExtraOperation.Items.Add(this.GetLocalizedString("strEraseEmissionFaults"));
                            break;

                        default:
                            CustomAssert(&??_C@_0P@NKJDEOOE@ExtraTasks?4cpp?$AA@, 0x20, true, null);
                            break;
                    }
                    num++;
                }
                while (num < this.m_ExtraTab.m_OperationList.Count);
            }
            this.m_ExtraTab.m_ActiveOperationIdx = 0;
            if (this.cbxExtraOperation.Items.Count == 0)
            {
                this.cbxExtraOperation.Enabled = false;
                this.cbxExtraOperationParameter.Visible = false;
                this.edExtraOperationParameter.Visible = false;
                this.lblExtraOperationParameter.Visible = false;
                this.btnExtraRunOperation.Enabled = false;
            }
            else
            {
                this.cbxExtraOperation.Enabled = true;
                this.cbxExtraOperation.SelectedIndex = this.m_MemoryTab.m_ActiveOperationIdx;
                this.btnExtraRunOperation.Enabled = true;
                this.ExtraUpdateOperationParameter();
            }
        }

        private unsafe void ExtraUpdateOperationParameter()
        {
            Point point2 = new Point(0xba, 0x81);
            Point modopt(IsConst) point = point2;
            switch (this.m_ExtraTab.GetActiveOperation())
            {
                case ExtraTab.Operation.GetSpeedLimit:
                    this.lblExtraOperationParameter.Text = this.GetLocalizedString("strSpeedLimit");
                    this.lblExtraOperationParameter.Visible = true;
                    this.cbxExtraOperationParameter.Visible = false;
                    this.edExtraOperationParameter.Visible = true;
                    this.edExtraOperationParameter.Enabled = true;
                    this.edExtraOperationParameter.Location = point;
                    this.edExtraOperationParameter.ReadOnly = true;
                    this.edExtraOperationParameter.Clear();
                    break;

                case ExtraTab.Operation.SetSpeedLimit:
                {
                    this.lblExtraOperationParameter.Text = this.GetLocalizedString("strSpeedLimit");
                    this.lblExtraOperationParameter.Visible = true;
                    this.cbxExtraOperationParameter.Visible = false;
                    this.edExtraOperationParameter.Visible = true;
                    this.edExtraOperationParameter.Enabled = true;
                    this.edExtraOperationParameter.Location = point;
                    this.edExtraOperationParameter.ReadOnly = false;
                    ExtraTab extraTab = this.m_ExtraTab;
                    if (!extraTab.m_HaveTorqueLimit)
                    {
                        this.edExtraOperationParameter.Clear();
                        break;
                    }
                    this.edExtraOperationParameter.Text = extraTab.m_SpeedLimit.ToString();
                    break;
                }
                case ExtraTab.Operation.GetTorqueLimit:
                    this.lblExtraOperationParameter.Text = this.GetLocalizedString("strTorqueLimit");
                    this.lblExtraOperationParameter.Visible = true;
                    this.cbxExtraOperationParameter.Visible = false;
                    this.edExtraOperationParameter.Visible = true;
                    this.edExtraOperationParameter.Enabled = true;
                    this.edExtraOperationParameter.Location = point;
                    this.edExtraOperationParameter.ReadOnly = true;
                    this.edExtraOperationParameter.Clear();
                    break;

                case ExtraTab.Operation.SetTorqueLimit:
                    this.lblExtraOperationParameter.Text = this.GetLocalizedString("strTorqueLimit");
                    this.lblExtraOperationParameter.Visible = true;
                    this.edExtraOperationParameter.Visible = false;
                    this.cbxExtraOperationParameter.Visible = true;
                    this.cbxExtraOperationParameter.Location = point;
                    this.cbxExtraOperationParameter.Items.Clear();
                    this.cbxExtraOperationParameter.Items.Add("60 %");
                    this.cbxExtraOperationParameter.Items.Add("75 %");
                    this.cbxExtraOperationParameter.Items.Add("100 %");
                    this.cbxExtraOperationParameter.Items.Add("Not present");
                    this.cbxExtraOperationParameter.SelectedIndex = 0;
                    break;

                case ExtraTab.Operation.EraseEmissionFaults:
                    this.lblExtraOperationParameter.Visible = false;
                    this.cbxExtraOperationParameter.Visible = false;
                    this.edExtraOperationParameter.Visible = true;
                    this.edExtraOperationParameter.Enabled = false;
                    this.edExtraOperationParameter.Location = point;
                    break;

                default:
                    CustomAssert(&??_C@_0P@NKJDEOOE@ExtraTasks?4cpp?$AA@, 0x89, true, null);
                    break;
            }
        }

        private void FaultCodesFillECUList(ECUInfo[] eculist)
        {
            this.cbxDetectedECUs.Items.Clear();
            int index = 0;
            if (0 < eculist.Length)
            {
                do
                {
                    string str;
                    int num2 = 0;
                    if (!eculist[index].m_HaveMoreECUsWithSameAddr)
                    {
                        do
                        {
                            if (num2 >= eculist.Length)
                            {
                                break;
                            }
                            if ((index != num2) && (eculist[index].m_addr == eculist[num2].m_addr))
                            {
                                eculist[num2].m_HaveMoreECUsWithSameAddr = true;
                                eculist[index].m_HaveMoreECUsWithSameAddr = true;
                            }
                            num2++;
                        }
                        while (!eculist[index].m_HaveMoreECUsWithSameAddr);
                    }
                    if (eculist[index].m_HaveMoreECUsWithSameAddr)
                    {
                        str = "? ";
                    }
                    else
                    {
                        str = "";
                    }
                    this.cbxDetectedECUs.Items.Add((str + eculist[index].m_shortname) + " " + this.GetLocalizedString(eculist[index].m_longnameid));
                    index++;
                }
                while (index < eculist.Length);
            }
            this.cbxDetectedECUs.SelectedIndex = 0;
            this.cbxDetectedECUs.Enabled = true;
            this.btnGenerateFullFaultsReport.Enabled = true;
            this.btnReadFaultCodes.Enabled = true;
            this.btnEraseFaultCodes.Enabled = true;
            this.gridFaultCodes.Rows.Clear();
            this.UpdateGridFaultCodesHeight();
            this.pnlFaultCodes.Enabled = false;
        }

        private void FRImmoSetFailedThreadSafe(string ErrorString)
        {
            if (this.InvokeRequired)
            {
                TaskFailedDelegate method = new TaskFailedDelegate(this.FRImmoSetFailedThreadSafe);
                object[] args = new object[] { ErrorString };
                this.Invoke(method, args);
            }
            else
            {
                this.StopOperation();
                this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + ErrorString + ")!\r\n");
                if (this.m_KeysTab.m_FRImmoStatus2Set)
                {
                    this.MessageBoxThreadSafe((this.GetParamedLocalizedString("strECUXImmoOnFailed", "FR") + " (") + ErrorString + ")!", this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    this.MessageBoxThreadSafe((this.GetParamedLocalizedString("strECUXImmoOffFailed", "FR") + " (") + ErrorString + ")!", this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void FRImmoSetOkThreadSafe()
        {
            if (this.InvokeRequired)
            {
                Action method = new Action(this.FRImmoSetOkThreadSafe);
                base.Invoke(method);
            }
            else
            {
                this.StopOperation();
                this.AddToLogThreadSafe(this.GetLocalizedString("strdone") + "\r\n");
                if (this.m_KeysTab.m_FRImmoStatus2Set)
                {
                    this.MessageBoxThreadSafe(this.GetParamedLocalizedString("strECUXImmoOnCompleted", "FR"), this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    this.MessageBoxThreadSafe(this.GetParamedLocalizedString("strECUXImmoOffCompleted", "FR"), this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                this.btnGetKeysInfo_Click(null, null);
            }
        }

        private unsafe void FRImmoSetTask()
        {
            uint num;
            int num2 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                uint num5;
                $ArrayType$$$BY0BA@E e$$$byba@e;
                this.AskForIgnition(true, this.m_LastOperationStr, true);
                if (!CmdLayerCreateFRImmoSetParams((byte*) &e$$$byba@e, 0x10, &num5, (byte) this.m_KeysTab.m_FRImmoStatus2Set))
                {
                    CustomAssert(&??_C@_0BC@DFLNDNFC@KeyLearnTasks?4cpp?$AA@, 0x456, true, null);
                }
                if (RunLongOperation((Command_t) 230, (byte modopt(IsConst)*) &e$$$byba@e, num5, (Command_t) 0xe7, (Command_t) 0xe8, 0))
                {
                    this.AskForIgnition(false, this.m_LastOperationStr, true);
                    this.AskForIgnition(true, this.m_LastOperationStr, true);
                    this.FRImmoSetOkThreadSafe();
                }
                else
                {
                    byte errorcode = CmdLayerGetErrorData((Command_t) 0xe8);
                    this.FRImmoSetFailedThreadSafe(this.GetErrorExplanation(errorcode));
                }
            }
            catch (UserAborted)
            {
                this.MRImmoOffFailedThreadSafe(this.GetLocalizedString("strUserAborted"));
            }
            catch (InvalidOBDPower)
            {
                this.MRImmoOffFailedThreadSafe(this.GetLocalizedString("strInvalidOBDPower"));
            }
            catch (NoOBDPower)
            {
                this.MRImmoOffFailedThreadSafe(this.GetLocalizedString("strNoOBDPower"));
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t;
                        byte num3 = (byte) _t;
                        this.AddToLogThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(num3) + ")!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(num3) + ")!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0BC@DFLNDNFC@KeyLearnTasks?4cpp?$AA@, 0x481, false, null);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0BC@DFLNDNFC@KeyLearnTasks?4cpp?$AA@, 0x494, true, null);
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
        }

        [return: MarshalAs(UnmanagedType.U1)]
        private unsafe bool FRMRAnalyseMemory(byte* modopt(IsImplicitlyDereferenced) ErrorCode)
        {
            sbyte modopt(IsSignUnspecifiedByte) modopt(IsConst)* numPtr;
            ushort num3;
            sbyte modopt(IsSignUnspecifiedByte) modopt(IsConst)* numPtr2;
            ushort num4;
            sbyte modopt(IsSignUnspecifiedByte) modopt(IsConst)* numPtr3;
            uint modopt(IsLong) num5;
            ushort num6;
            if (!RunLongOperation((Command_t) 0x20, null, 0, (Command_t) 0x21, (Command_t) 0x22, 0))
            {
                ErrorCode[0] = (byte* modopt(IsImplicitlyDereferenced)) CmdLayerGetErrorData((Command_t) 0x22);
                return false;
            }
            CmdLayerGetECUFlashInfo(&num6, &num5, &numPtr3);
            this.m_MemoryTab.m_FlashSize = num5;
            this.m_MemoryTab.m_FlashName = new string(numPtr3);
            this.m_MemoryTab.m_Flash = new MemoryStream(this.m_MemoryTab.m_FlashSize);
            if (!RunLongOperation((Command_t) 0x2a, null, 0, (Command_t) 0x2b, (Command_t) 0x2c, 0))
            {
                ErrorCode[0] = (byte* modopt(IsImplicitlyDereferenced)) CmdLayerGetErrorData((Command_t) 0x2c);
                return false;
            }
            CmdLayerGetECUEepromInfo(&num4, &numPtr2, &num3, &numPtr);
            this.m_MemoryTab.m_EEPROMASize = num4;
            this.m_MemoryTab.m_EEPROMBSize = num3;
            this.m_MemoryTab.m_EEPROMAName = new string(numPtr2);
            MemoryTab memoryTab = this.m_MemoryTab;
            uint modopt(IsLong) eEPROMASize = memoryTab.m_EEPROMASize;
            if (eEPROMASize > 0)
            {
                this.m_MemoryTab.m_EEPROMA = new MemoryStream(eEPROMASize);
            }
            else
            {
                memoryTab.m_EEPROMA = null;
            }
            this.m_MemoryTab.m_EEPROMBName = new string(numPtr);
            memoryTab = this.m_MemoryTab;
            uint modopt(IsLong) eEPROMBSize = memoryTab.m_EEPROMBSize;
            if (eEPROMBSize > 0)
            {
                this.m_MemoryTab.m_EEPROMB = new MemoryStream(eEPROMBSize);
            }
            else
            {
                memoryTab.m_EEPROMB = null;
            }
            return true;
        }

        private unsafe void FRMRFileBuffering(ref MemoryStream modopt(IsExplicitlyDereferenced) databuf)
        {
            CommandType_t _t;
            long capacity;
            uint num6;
            $ArrayType$$$BY0BO@E e$$$bybo@e;
            databuf[0].Position = 0L;
            this.SetProgressBoundsThreadSafe(0, databuf[0].Capacity);
            this.SetProgressCommentThreadSafe(this.GetLocalizedString("strBuffering"));
            if (!CmdLayerCreateStartFileWriteData((byte*) &e$$$bybo@e, 30, &num6, (uint modopt(IsLong)) databuf[0].Capacity, &??_C@_04FGEHGIFJ@temp?$AA@))
            {
                CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x98, true, null);
            }
            if (!SendRequestWaitForAnswer((Command_t) 100, (byte modopt(IsConst)*) &e$$$bybo@e, num6, &_t))
            {
                CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x9b, true, null);
            }
            if (_t != ((CommandType_t) 1))
            {
                CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x9c, true, null);
            }
            do
            {
                uint num3;
                $ArrayType$$$BY0EAK@E e$$$byeak@e;
                $ArrayType$$$BY0EAA@E e$$$byeaa@e;
                uint modopt(IsLong) position = (uint modopt(IsLong)) ((int) databuf[0].Position);
                uint datalen = 0;
                do
                {
                    long num4 = databuf[0].Capacity;
                    if (databuf[0].Position >= num4)
                    {
                        break;
                    }
                    datalen[(int) &e$$$byeaa@e] = (uint) databuf[0].ReadByte();
                    datalen++;
                }
                while (datalen < 0x400);
                if (!CmdLayerCreateFileWriteData((byte*) &e$$$byeak@e, 0x40a, &num3, position, (byte modopt(IsConst)*) &e$$$byeaa@e, datalen))
                {
                    CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0xa8, true, null);
                }
                if (!SendRequestWaitForAnswer((Command_t) 0x65, (byte modopt(IsConst)*) &e$$$byeak@e, num3, &_t))
                {
                    CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0xa9, true, null);
                }
                if (_t != ((CommandType_t) 1))
                {
                    CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 170, true, null);
                }
                this.SetProgressValueThreadSafe((int) databuf[0].Position);
                capacity = databuf[0].Capacity;
            }
            while (databuf[0].Position < capacity);
            if (!SendRequestWaitForAnswer((Command_t) 0x66, null, 0, &_t))
            {
                CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0xb1, true, null);
            }
            if (_t != ((CommandType_t) 1))
            {
                CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0xb2, true, null);
            }
            this.SetProgressCommentThreadSafe(null);
            this.SetProgressUndefinedThreadSafe();
        }

        private void FRMRMemAnalyseAndReadFailedThreadSafe(string ErrorString)
        {
            if (this.InvokeRequired)
            {
                TaskFailedDelegate method = new TaskFailedDelegate(this.FRMRMemAnalyseAndReadFailedThreadSafe);
                object[] args = new object[] { ErrorString };
                this.Invoke(method, args);
            }
            else
            {
                this.StopOperation();
                this.m_MemoryTab.m_WasAnalysed = false;
                this.MemUpdateECUInfo();
                this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + ErrorString + ")!\r\n");
                this.MessageBoxThreadSafe((this.GetParamedLocalizedString("strECUXAnalyseAndReadMemoryFailed", this.m_MemoryTab.GetActiveECUString()) + " (") + ErrorString + ")!", this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void FRMRMemAnalyseAndReadOkThreadSafe()
        {
            if (this.InvokeRequired)
            {
                Action method = new Action(this.FRMRMemAnalyseAndReadOkThreadSafe);
                base.Invoke(method);
            }
            else
            {
                this.StopOperation();
                this.m_MemoryTab.m_WasAnalysed = true;
                this.MemUpdateECUInfo();
                try
                {
                    this.FRMRSaveFlashFile();
                }
                catch (IOException exception2)
                {
                    this.FRMRMemAnalyseAndReadFailedThreadSafe(this.GetLocalizedString("strFileWriteError") + ": " + exception2.Message);
                    return;
                }
                this.m_MemoryTab.m_WorkingEEPROMIdx = 0;
                while (true)
                {
                    MemoryTab memoryTab = this.m_MemoryTab;
                    int workingEEPROMIdx = memoryTab.m_WorkingEEPROMIdx;
                    if (workingEEPROMIdx >= 2)
                    {
                        break;
                    }
                    if (((workingEEPROMIdx != 0) || (memoryTab.m_EEPROMASize != null)) && ((workingEEPROMIdx != 1) || (memoryTab.m_EEPROMBSize != null)))
                    {
                        try
                        {
                            this.FRMRSaveEEPROMFile();
                        }
                        catch (IOException exception)
                        {
                            this.FRMRMemAnalyseAndReadFailedThreadSafe(this.GetLocalizedString("strFileWriteError") + ": " + exception.Message);
                            return;
                        }
                    }
                    this.m_MemoryTab.m_WorkingEEPROMIdx++;
                }
                this.AddToLogThreadSafe(this.GetLocalizedString("strdone") + "\r\n");
            }
        }

        private unsafe void FRMRMemAnalyseAndReadTask()
        {
            uint num;
            int num2 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                byte num3;
                bool flag;
                MemoryTab.ECU activeECU = this.m_MemoryTab.GetActiveECU();
                if (*(((int*) &activeECU)) >= 0)
                {
                    if (*(((int*) &activeECU)) > 1)
                    {
                        if (*(((int*) &activeECU)) != 2)
                        {
                            goto Label_004B;
                        }
                        flag = this.FRStart(this.m_LastOperationStr, &num3);
                    }
                    else
                    {
                        flag = this.MRStart(this.m_LastOperationStr, &num3);
                    }
                    goto Label_005D;
                }
            Label_004B:
                CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x5b7, true, null);
            Label_005D:
                if (!flag)
                {
                    this.FRMRMemAnalyseAndReadFailedThreadSafe(this.GetErrorExplanation(num3));
                }
                else if (!this.FRMRAnalyseMemory(&num3))
                {
                    this.FRMRMemAnalyseAndReadFailedThreadSafe(this.GetErrorExplanation(num3));
                }
                else
                {
                    MemoryTab memoryTab = this.m_MemoryTab;
                    this.SetProgressBoundsThreadSafe(0, (memoryTab.m_EEPROMBSize + memoryTab.m_EEPROMASize) + memoryTab.m_FlashSize);
                    if (!this.FRMRReadFlash(&num3))
                    {
                        this.FRMRMemAnalyseAndReadFailedThreadSafe(this.GetErrorExplanation(num3));
                    }
                    else
                    {
                        MemoryTab tab2 = this.m_MemoryTab;
                        int flashSize = tab2.m_FlashSize;
                        tab2.m_WorkingEEPROMIdx = 0;
                        while (true)
                        {
                            MemoryTab tab = this.m_MemoryTab;
                            int workingEEPROMIdx = tab.m_WorkingEEPROMIdx;
                            if (workingEEPROMIdx >= 2)
                            {
                                break;
                            }
                            if (((workingEEPROMIdx != 0) || (tab.m_EEPROMASize != null)) && ((workingEEPROMIdx != 1) || (tab.m_EEPROMBSize != null)))
                            {
                                if (!this.FRMRReadEEPROM(flashSize, &num3))
                                {
                                    this.FRMRMemAnalyseAndReadFailedThreadSafe(this.GetErrorExplanation(num3));
                                    return;
                                }
                                tab = this.m_MemoryTab;
                                flashSize = *(((tab.m_WorkingEEPROMIdx != 0) ? &tab.m_EEPROMB : &tab.m_EEPROMA)).Capacity + flashSize;
                            }
                            this.m_MemoryTab.m_WorkingEEPROMIdx++;
                        }
                        this.SetProgressUndefinedThreadSafe();
                        if (!this.FRMRStop(&num3))
                        {
                            this.FRMRMemAnalyseAndReadFailedThreadSafe(this.GetErrorExplanation(num3));
                        }
                        else
                        {
                            this.FRMRMemAnalyseAndReadOkThreadSafe();
                        }
                    }
                }
            }
            catch (UserAborted)
            {
                this.FRMRMemAnalyseAndReadFailedThreadSafe(this.GetLocalizedString("strUserAborted"));
            }
            catch (InvalidOBDPower)
            {
                this.FRMRMemAnalyseAndReadFailedThreadSafe(this.GetLocalizedString("strInvalidOBDPower"));
            }
            catch (NoOBDPower)
            {
                this.FRMRMemAnalyseAndReadFailedThreadSafe(this.GetLocalizedString("strNoOBDPower"));
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t;
                        byte errorcode = (byte) _t;
                        this.AddToLogThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(errorcode) + ")!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(errorcode) + ")!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x615, false, null);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x628, true, null);
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
        }

        private void FRMRMemAnalyseFailedThreadSafe(string ErrorString)
        {
            if (this.InvokeRequired)
            {
                TaskFailedDelegate method = new TaskFailedDelegate(this.FRMRMemAnalyseFailedThreadSafe);
                object[] args = new object[] { ErrorString };
                this.Invoke(method, args);
            }
            else
            {
                this.StopOperation();
                this.m_MemoryTab.m_WasAnalysed = false;
                this.MemUpdateECUInfo();
                this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + ErrorString + ")!\r\n");
                this.MessageBoxThreadSafe((this.GetParamedLocalizedString("strECUXAnalyseMemoryFailed", this.m_MemoryTab.GetActiveECUString()) + " (") + ErrorString + ")!", this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void FRMRMemAnalyseOkThreadSafe()
        {
            if (this.InvokeRequired)
            {
                Action method = new Action(this.FRMRMemAnalyseOkThreadSafe);
                base.Invoke(method);
            }
            else
            {
                this.StopOperation();
                this.m_MemoryTab.m_WasAnalysed = true;
                this.MemUpdateECUInfo();
                this.AddToLogThreadSafe(this.GetLocalizedString("strdone") + "\r\n");
            }
        }

        private unsafe void FRMRMemAnalyseTask()
        {
            uint num;
            int num2 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                byte num3;
                bool flag;
                switch (this.m_MemoryTab.GetActiveECU())
                {
                    case MemoryTab.ECU.MR:
                    case MemoryTab.ECU.MCM:
                        flag = this.MRStart(this.m_LastOperationStr, &num3);
                        break;

                    case MemoryTab.ECU.FR:
                        flag = this.FRStart(this.m_LastOperationStr, &num3);
                        break;

                    case MemoryTab.ECU.FFR:
                    case MemoryTab.ECU.PTM:
                        this.TaskNotImplementedThreadSafe();
                        return;

                    default:
                        CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0xd4, true, null);
                        break;
                }
                if (!flag)
                {
                    this.FRMRMemAnalyseFailedThreadSafe(this.GetErrorExplanation(num3));
                }
                else if (!this.FRMRAnalyseMemory(&num3))
                {
                    this.FRMRMemAnalyseFailedThreadSafe(this.GetErrorExplanation(num3));
                }
                else if (!this.FRMRStop(&num3))
                {
                    this.FRMRMemAnalyseFailedThreadSafe(this.GetErrorExplanation(num3));
                }
                else
                {
                    this.FRMRMemAnalyseOkThreadSafe();
                }
            }
            catch (UserAborted)
            {
                this.FRMRMemAnalyseFailedThreadSafe(this.GetLocalizedString("strUserAborted"));
            }
            catch (InvalidOBDPower)
            {
                this.FRMRMemAnalyseFailedThreadSafe(this.GetLocalizedString("strInvalidOBDPower"));
            }
            catch (NoOBDPower)
            {
                this.FRMRMemAnalyseFailedThreadSafe(this.GetLocalizedString("strNoOBDPower"));
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t;
                        byte errorcode = (byte) _t;
                        this.AddToLogThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(errorcode) + ")!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(errorcode) + ")!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x106, false, null);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x119, true, null);
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
        }

        [return: MarshalAs(UnmanagedType.U1)]
        private unsafe bool FRMRReadEEPROM(int StartProgressValue, byte* modopt(IsImplicitlyDereferenced) ErrorCode)
        {
            ref MemoryStream modopt(IsExplicitlyDereferenced) streamRef;
            Command_t _t;
            CommandType_t _t3;
            uint num5;
            $ArrayType$$$BY0BA@E e$$$byba@e;
            MemoryTab memoryTab = this.m_MemoryTab;
            if (memoryTab.m_WorkingEEPROMIdx == 0)
            {
                streamRef = (ref MemoryStream modopt(IsExplicitlyDereferenced)) &memoryTab.m_EEPROMA;
            }
            else
            {
                streamRef = (ref MemoryStream modopt(IsExplicitlyDereferenced)) &memoryTab.m_EEPROMB;
            }
            streamRef[0].Position = 0L;
            if (!CmdLayerCreateECUEepromReadParameters((byte*) &e$$$byba@e, 0x10, &num5, (byte) this.m_MemoryTab.m_WorkingEEPROMIdx))
            {
                CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x337, true, null);
            }
            if (!SendRequestWaitForAnswer((Command_t) 0x2d, (byte modopt(IsConst)*) &e$$$byba@e, num5, &_t3))
            {
                CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x339, true, null);
            }
            if (_t3 != ((CommandType_t) 1))
            {
                CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x33a, true, null);
            }
            while (true)
            {
                CommandType_t _t2;
                WaitForNewCmdWithRetry(&_t2, &_t, 0);
                if (_t2 != ((CommandType_t) 0))
                {
                    CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x342, true, null);
                }
                if (_t != ((Command_t) 0x2e))
                {
                    if (_t == ((Command_t) 0x2f))
                    {
                        break;
                    }
                    if (_t != ((Command_t) 0x80))
                    {
                        CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x369, true, null);
                    }
                    else
                    {
                        if (CmdLayerGetCmdInProgress() != ((Command_t) 0x2d))
                        {
                            CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x35d, true, null);
                        }
                        SendCmd((CommandType_t) 1, _t, null, 0);
                    }
                }
                else
                {
                    uint num2;
                    byte modopt(IsConst)* numPtr;
                    uint modopt(IsLong) num4;
                    SendCmd((CommandType_t) 1, (Command_t) 0x2e, null, 0);
                    CmdLayerGetECUEepromReadData(&num4, &numPtr, &num2);
                    if (num4 == streamRef[0].Position)
                    {
                        uint num = 0;
                        if (0 < num2)
                        {
                            do
                            {
                                streamRef[0].WriteByte(*((byte*) (num + numPtr)));
                                num++;
                            }
                            while (num < num2);
                        }
                    }
                }
                this.SetProgressValueThreadSafe(((int) streamRef[0].Position) + StartProgressValue);
                long capacity = streamRef[0].Capacity;
                if ((streamRef[0].Position >= capacity) || (_t == ((Command_t) 0x2f)))
                {
                    return true;
                }
            }
            SendCmd((CommandType_t) 1, (Command_t) 0x2f, null, 0);
            ErrorCode[0] = (byte* modopt(IsImplicitlyDereferenced)) CmdLayerGetErrorData(_t);
            return false;
        }

        private void FRMRReadEEPROMFailedThreadSafe(string ErrorString)
        {
            if (this.InvokeRequired)
            {
                TaskFailedDelegate method = new TaskFailedDelegate(this.FRMRReadEEPROMFailedThreadSafe);
                object[] args = new object[] { ErrorString };
                this.Invoke(method, args);
            }
            else
            {
                string paramedLocalizedString;
                this.StopOperation();
                MemoryTab memoryTab = this.m_MemoryTab;
                if (memoryTab.m_WorkingEEPROMIdx == 0)
                {
                    paramedLocalizedString = this.GetParamedLocalizedString("strECUXReadEEPROMAFailed", memoryTab.GetActiveECUString());
                }
                else
                {
                    paramedLocalizedString = this.GetParamedLocalizedString("strECUXReadEEPROMBFailed", memoryTab.GetActiveECUString());
                }
                this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + ErrorString + ")!\r\n");
                this.MessageBoxThreadSafe((paramedLocalizedString + " (") + ErrorString + ")!", this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void FRMRReadEEPROMOkThreadSafe()
        {
            if (this.InvokeRequired)
            {
                Action method = new Action(this.FRMRReadEEPROMOkThreadSafe);
                base.Invoke(method);
            }
            else
            {
                try
                {
                    this.FRMRSaveEEPROMFile();
                }
                catch (IOException exception)
                {
                    this.FRMRReadEEPROMFailedThreadSafe(this.GetLocalizedString("strFileWriteError") + ": " + exception.Message);
                    return;
                }
                this.StopOperation();
                this.AddToLogThreadSafe(this.GetLocalizedString("strdone") + "\r\n");
            }
        }

        private unsafe void FRMRReadEEPROMTask()
        {
            uint num;
            int num2 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                byte num3;
                bool flag;
                MemoryTab.ECU activeECU = this.m_MemoryTab.GetActiveECU();
                if (*(((int*) &activeECU)) >= 0)
                {
                    if (*(((int*) &activeECU)) > 1)
                    {
                        if (*(((int*) &activeECU)) != 2)
                        {
                            goto Label_004B;
                        }
                        flag = this.FRStart(this.m_LastOperationStr, &num3);
                    }
                    else
                    {
                        flag = this.MRStart(this.m_LastOperationStr, &num3);
                    }
                    goto Label_005D;
                }
            Label_004B:
                CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x29a, true, null);
            Label_005D:
                if (!flag)
                {
                    this.FRMRReadEEPROMFailedThreadSafe(this.GetErrorExplanation(num3));
                }
                else
                {
                    ref MemoryStream modopt(IsExplicitlyDereferenced) streamRef;
                    MemoryTab memoryTab = this.m_MemoryTab;
                    if (memoryTab.m_WorkingEEPROMIdx == 0)
                    {
                        streamRef = (ref MemoryStream modopt(IsExplicitlyDereferenced)) &memoryTab.m_EEPROMA;
                    }
                    else
                    {
                        streamRef = (ref MemoryStream modopt(IsExplicitlyDereferenced)) &memoryTab.m_EEPROMB;
                    }
                    this.SetProgressBoundsThreadSafe(0, streamRef[0].Capacity);
                    if (!this.FRMRReadEEPROM(0, &num3))
                    {
                        this.FRMRReadEEPROMFailedThreadSafe(this.GetErrorExplanation(num3));
                    }
                    else
                    {
                        this.SetProgressUndefinedThreadSafe();
                        if (!this.FRMRStop(&num3))
                        {
                            this.FRMRReadEEPROMFailedThreadSafe(this.GetErrorExplanation(num3));
                        }
                        else
                        {
                            this.FRMRReadEEPROMOkThreadSafe();
                        }
                    }
                }
            }
            catch (UserAborted)
            {
                this.FRMRReadEEPROMFailedThreadSafe(this.GetLocalizedString("strUserAborted"));
            }
            catch (InvalidOBDPower)
            {
                this.FRMRReadEEPROMFailedThreadSafe(this.GetLocalizedString("strInvalidOBDPower"));
            }
            catch (NoOBDPower)
            {
                this.FRMRReadEEPROMFailedThreadSafe(this.GetLocalizedString("strNoOBDPower"));
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t;
                        byte errorcode = (byte) _t;
                        this.AddToLogThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(errorcode) + ")!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(errorcode) + ")!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x2d9, false, null);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x2ec, true, null);
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
        }

        [return: MarshalAs(UnmanagedType.U1)]
        private unsafe bool FRMRReadFlash(byte* modopt(IsImplicitlyDereferenced) ErrorCode)
        {
            Command_t _t;
            CommandType_t _t3;
            ref MemoryStream modopt(IsExplicitlyDereferenced) streamRef = (ref MemoryStream modopt(IsExplicitlyDereferenced)) &this.m_MemoryTab.m_Flash;
            streamRef[0].Position = 0L;
            if (!SendRequestWaitForAnswer((Command_t) 0x23, null, 0, &_t3))
            {
                CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x217, true, null);
            }
            if (_t3 != ((CommandType_t) 1))
            {
                CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x218, true, null);
            }
            while (true)
            {
                CommandType_t _t2;
                WaitForNewCmdWithRetry(&_t2, &_t, 0);
                if (_t2 != ((CommandType_t) 0))
                {
                    CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x220, true, null);
                }
                if (_t != ((Command_t) 0x24))
                {
                    if (_t == ((Command_t) 0x25))
                    {
                        break;
                    }
                    if (_t != ((Command_t) 0x80))
                    {
                        CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x247, true, null);
                    }
                    else
                    {
                        if (CmdLayerGetCmdInProgress() != ((Command_t) 0x23))
                        {
                            CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x23b, true, null);
                        }
                        SendCmd((CommandType_t) 1, _t, null, 0);
                    }
                }
                else
                {
                    uint num2;
                    byte modopt(IsConst)* numPtr;
                    uint modopt(IsLong) num4;
                    SendCmd((CommandType_t) 1, (Command_t) 0x24, null, 0);
                    CmdLayerGetECUFlashReadData(&num4, &numPtr, &num2);
                    if (num4 == streamRef[0].Position)
                    {
                        uint num = 0;
                        if (0 < num2)
                        {
                            do
                            {
                                streamRef[0].WriteByte(*((byte*) (num + numPtr)));
                                num++;
                            }
                            while (num < num2);
                        }
                    }
                }
                this.SetProgressValueThreadSafe((int) streamRef[0].Position);
                long capacity = streamRef[0].Capacity;
                if ((streamRef[0].Position >= capacity) || (_t == ((Command_t) 0x25)))
                {
                    return true;
                }
            }
            SendCmd((CommandType_t) 1, (Command_t) 0x25, null, 0);
            ErrorCode[0] = (byte* modopt(IsImplicitlyDereferenced)) CmdLayerGetErrorData(_t);
            return false;
        }

        private void FRMRReadFlashFailedThreadSafe(string ErrorString)
        {
            if (this.InvokeRequired)
            {
                TaskFailedDelegate method = new TaskFailedDelegate(this.FRMRReadFlashFailedThreadSafe);
                object[] args = new object[] { ErrorString };
                this.Invoke(method, args);
            }
            else
            {
                this.StopOperation();
                this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + ErrorString + ")!\r\n");
                this.MessageBoxThreadSafe((this.GetParamedLocalizedString("strECUXReadFlashFailed", this.m_MemoryTab.GetActiveECUString()) + " (") + ErrorString + ")!", this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void FRMRReadFlashOkThreadSafe()
        {
            if (this.InvokeRequired)
            {
                Action method = new Action(this.FRMRReadFlashOkThreadSafe);
                base.Invoke(method);
            }
            else
            {
                try
                {
                    this.FRMRSaveFlashFile();
                }
                catch (IOException exception)
                {
                    this.FRMRReadFlashFailedThreadSafe(this.GetLocalizedString("strFileWriteError") + ": " + exception.Message);
                    return;
                }
                this.StopOperation();
                this.AddToLogThreadSafe(this.GetLocalizedString("strdone") + "\r\n");
            }
        }

        private unsafe void FRMRReadFlashTask()
        {
            uint num;
            int num2 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                byte num3;
                bool flag;
                MemoryTab.ECU activeECU = this.m_MemoryTab.GetActiveECU();
                if (*(((int*) &activeECU)) >= 0)
                {
                    if (*(((int*) &activeECU)) > 1)
                    {
                        if (*(((int*) &activeECU)) != 2)
                        {
                            goto Label_004B;
                        }
                        flag = this.FRStart(this.m_LastOperationStr, &num3);
                    }
                    else
                    {
                        flag = this.MRStart(this.m_LastOperationStr, &num3);
                    }
                    goto Label_005D;
                }
            Label_004B:
                CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x18c, true, null);
            Label_005D:
                if (!flag)
                {
                    this.FRMRReadFlashFailedThreadSafe(this.GetErrorExplanation(num3));
                }
                else
                {
                    ref MemoryStream modopt(IsExplicitlyDereferenced) streamRef = (ref MemoryStream modopt(IsExplicitlyDereferenced)) &this.m_MemoryTab.m_Flash;
                    this.SetProgressBoundsThreadSafe(0, streamRef[0].Capacity);
                    if (!this.FRMRReadFlash(&num3))
                    {
                        this.FRMRReadFlashFailedThreadSafe(this.GetErrorExplanation(num3));
                    }
                    else
                    {
                        this.SetProgressUndefinedThreadSafe();
                        if (!this.FRMRStop(&num3))
                        {
                            this.FRMRReadFlashFailedThreadSafe(this.GetErrorExplanation(num3));
                        }
                        else
                        {
                            this.FRMRReadFlashOkThreadSafe();
                        }
                    }
                }
            }
            catch (UserAborted)
            {
                this.FRMRReadFlashFailedThreadSafe(this.GetLocalizedString("strUserAborted"));
            }
            catch (InvalidOBDPower)
            {
                this.FRMRReadFlashFailedThreadSafe(this.GetLocalizedString("strInvalidOBDPower"));
            }
            catch (NoOBDPower)
            {
                this.FRMRReadFlashFailedThreadSafe(this.GetLocalizedString("strNoOBDPower"));
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t;
                        byte errorcode = (byte) _t;
                        this.AddToLogThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(errorcode) + ")!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(errorcode) + ")!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x1c6, false, null);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x1d9, true, null);
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
        }

        private unsafe void FRMRSaveEEPROMFile()
        {
            ref MemoryStream modopt(IsExplicitlyDereferenced) streamRef;
            string str2;
            ref string modopt(IsExplicitlyDereferenced) strRef;
            $ArrayType$$$BY09D e$$$byd;
            int num3 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            MemoryTab memoryTab = this.m_MemoryTab;
            if (memoryTab.m_WorkingEEPROMIdx == 0)
            {
                strRef = (ref string modopt(IsExplicitlyDereferenced)) &memoryTab.m_EEPROMAName;
                streamRef = (ref MemoryStream modopt(IsExplicitlyDereferenced)) &memoryTab.m_EEPROMA;
            }
            else
            {
                strRef = (ref string modopt(IsExplicitlyDereferenced)) &memoryTab.m_EEPROMBName;
                streamRef = (ref MemoryStream modopt(IsExplicitlyDereferenced)) &memoryTab.m_EEPROMB;
            }
            CRC32Init();
            byte[] buffer = streamRef[0].ToArray();
            int index = 0;
            if (0 < buffer.Length)
            {
                do
                {
                    CRC32AddByte(buffer[index]);
                    index++;
                }
                while (index < buffer.Length);
            }
            uint modopt(IsLong) num4 = CRC32GetValue();
            sprintf_s<10>(&e$$$byd, &??_C@_02HAOIJKIC@?$CFc?$AA@, this.m_MemoryTab.m_WorkingEEPROMIdx + 0x41);
            object[] args = new object[5];
            if (string.IsNullOrEmpty(this.m_VIN))
            {
                str2 = "";
            }
            else
            {
                str2 = this.m_VIN + "_";
            }
            args[0] = str2;
            args[1] = strRef[0];
            args[2] = new string((sbyte*) &e$$$byd);
            args[3] = num4;
            args[4] = this.m_MemoryTab.GetActiveECUString();
            string str = string.Format("{0}{4}_{1}_{2}_{3:X8}.bin", args);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\TruckExplorer\dumps\" + str;
            try
            {
                FileStream stream2 = System.IO.File.Create(path);
                streamRef[0].WriteTo(stream2);
                stream2.Close();
            }
            catch when (?)
            {
                uint num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num3);
                try
                {
                    try
                    {
                        goto Label_0172;
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
            }
        Label_0172:
            this.dlgSaveFile.FileName = str;
            this.dlgSaveFile.Title = this.GetParamedLocalizedString("strSaveEEPROMXas", new string((sbyte*) &e$$$byd));
            if (this.dlgSaveFile.ShowDialog() == DialogResult.OK)
            {
                Stream stream = this.dlgSaveFile.OpenFile();
                if (stream != null)
                {
                    streamRef[0].WriteTo(stream);
                    stream.Close();
                }
            }
        }

        private unsafe void FRMRSaveFlashFile()
        {
            string str2;
            int num3 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            ref MemoryStream modopt(IsExplicitlyDereferenced) streamRef = (ref MemoryStream modopt(IsExplicitlyDereferenced)) &this.m_MemoryTab.m_Flash;
            CRC32Init();
            byte[] buffer = streamRef[0].ToArray();
            int index = 0;
            if (0 < buffer.Length)
            {
                do
                {
                    CRC32AddByte(buffer[index]);
                    index++;
                }
                while (index < buffer.Length);
            }
            uint modopt(IsLong) num4 = CRC32GetValue();
            object[] args = new object[4];
            if (string.IsNullOrEmpty(this.m_VIN))
            {
                str2 = "";
            }
            else
            {
                str2 = this.m_VIN + "_";
            }
            args[0] = str2;
            args[1] = this.m_MemoryTab.m_FlashName;
            args[2] = num4;
            args[3] = this.m_MemoryTab.GetActiveECUString();
            string str = string.Format("{0}{3}_{1}_{2:X8}.bin", args);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\TruckExplorer\dumps\" + str;
            try
            {
                FileStream stream2 = System.IO.File.Create(path);
                streamRef[0].WriteTo(stream2);
                stream2.Close();
            }
            catch when (?)
            {
                uint num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num3);
                try
                {
                    try
                    {
                        goto Label_0131;
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
            }
        Label_0131:
            this.dlgSaveFile.FileName = str;
            this.dlgSaveFile.Title = this.GetLocalizedString("strSaveFlashas");
            if (this.dlgSaveFile.ShowDialog() == DialogResult.OK)
            {
                Stream stream = this.dlgSaveFile.OpenFile();
                if (stream != null)
                {
                    streamRef[0].WriteTo(stream);
                    stream.Close();
                }
            }
        }

        [return: MarshalAs(UnmanagedType.U1)]
        private unsafe bool FRMRStop(byte* modopt(IsImplicitlyDereferenced) ErrorCode)
        {
            if (!this.m_IsBootstrapMode)
            {
                if (!RunLongOperation((Command_t) 0x16, null, 0, (Command_t) 0x17, (Command_t) 0x18, 0))
                {
                    ErrorCode[0] = (byte* modopt(IsImplicitlyDereferenced)) CmdLayerGetErrorData((Command_t) 0x18);
                    return false;
                }
            }
            else if (!RunLongOperation((Command_t) 0x1c, null, 0, (Command_t) 0x1d, (Command_t) 30, 0))
            {
                ErrorCode[0] = (byte* modopt(IsImplicitlyDereferenced)) CmdLayerGetErrorData((Command_t) 30);
                return false;
            }
            return true;
        }

        private void FRMRWriteEEPROMFailedThreadSafe(string ErrorString)
        {
            if (this.InvokeRequired)
            {
                TaskFailedDelegate method = new TaskFailedDelegate(this.FRMRWriteEEPROMFailedThreadSafe);
                object[] args = new object[] { ErrorString };
                this.Invoke(method, args);
            }
            else
            {
                string paramedLocalizedString;
                this.StopOperation();
                MemoryTab memoryTab = this.m_MemoryTab;
                if (memoryTab.m_WorkingEEPROMIdx == 0)
                {
                    paramedLocalizedString = this.GetParamedLocalizedString("strECUXWriteEEPROMAFailed", memoryTab.GetActiveECUString());
                }
                else
                {
                    paramedLocalizedString = this.GetParamedLocalizedString("strECUXWriteEEPROMBFailed", memoryTab.GetActiveECUString());
                }
                this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + ErrorString + ")!\r\n");
                this.MessageBoxThreadSafe((paramedLocalizedString + " (") + ErrorString + ")!", this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void FRMRWriteEEPROMOkThreadSafe()
        {
            if (this.InvokeRequired)
            {
                Action method = new Action(this.FRMRWriteEEPROMOkThreadSafe);
                base.Invoke(method);
            }
            else
            {
                string paramedLocalizedString;
                this.StopOperation();
                MemoryTab memoryTab = this.m_MemoryTab;
                if (memoryTab.m_WorkingEEPROMIdx == 0)
                {
                    paramedLocalizedString = this.GetParamedLocalizedString("strECUXWriteEEPROMACompleted", memoryTab.GetActiveECUString());
                }
                else
                {
                    paramedLocalizedString = this.GetParamedLocalizedString("strECUXWriteEEPROMBCompleted", memoryTab.GetActiveECUString());
                }
                this.AddToLogThreadSafe(this.GetLocalizedString("strdone") + "\r\n");
                this.MessageBoxThreadSafe(paramedLocalizedString, this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private unsafe void FRMRWriteEEPROMTask()
        {
            uint num;
            int num2 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                byte num3;
                bool flag;
                ref MemoryStream modopt(IsExplicitlyDereferenced) streamRef;
                MemoryTab memoryTab = this.m_MemoryTab;
                if (memoryTab.m_WorkingEEPROMIdx == 0)
                {
                    streamRef = (ref MemoryStream modopt(IsExplicitlyDereferenced)) &memoryTab.m_EEPROMA;
                }
                else
                {
                    streamRef = (ref MemoryStream modopt(IsExplicitlyDereferenced)) &memoryTab.m_EEPROMB;
                }
                this.FRMRFileBuffering(streamRef);
                MemoryTab.ECU activeECU = this.m_MemoryTab.GetActiveECU();
                if (*(((int*) &activeECU)) >= 0)
                {
                    if (*(((int*) &activeECU)) > 1)
                    {
                        if (*(((int*) &activeECU)) != 2)
                        {
                            goto Label_0078;
                        }
                        flag = this.FRStart(this.m_LastOperationStr, &num3);
                    }
                    else
                    {
                        flag = this.MRStart(this.m_LastOperationStr, &num3);
                    }
                    goto Label_008A;
                }
            Label_0078:
                CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x4f1, true, null);
            Label_008A:
                if (!flag)
                {
                    this.FRMRWriteEEPROMFailedThreadSafe(this.GetErrorExplanation(num3));
                }
                else
                {
                    Command_t _t;
                    CommandType_t _t4;
                    uint num5;
                    $ArrayType$$$BY0BO@E e$$$bybo@e;
                    this.SetProgressBoundsThreadSafe(0, 0x100);
                    if (!CmdLayerCreateECUEepromWriteParameters((byte*) &e$$$bybo@e, 30, &num5, (byte) this.m_MemoryTab.m_WorkingEEPROMIdx))
                    {
                        CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x503, true, null);
                    }
                    if (!SendRequestWaitForAnswer((Command_t) 0x30, (byte modopt(IsConst)*) &e$$$bybo@e, num5, &_t4))
                    {
                        CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x506, true, null);
                    }
                    if (_t4 != ((CommandType_t) 1))
                    {
                        CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x507, true, null);
                    }
                    do
                    {
                        CommandType_t _t3;
                        WaitForNewCmdWithRetry(&_t3, &_t, 0);
                        if (_t3 != ((CommandType_t) 0))
                        {
                            CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x510, true, null);
                        }
                        switch (_t)
                        {
                            case ((Command_t) 0x31):
                                SendCmd((CommandType_t) 1, _t, null, 0);
                                this.SetProgressValueThreadSafe(CmdLayerGetECUEepromWrittenDataRate());
                                break;

                            case ((Command_t) 50):
                                SendCmd((CommandType_t) 1, _t, null, 0);
                                break;

                            case ((Command_t) 0x33):
                                SendCmd((CommandType_t) 1, _t, null, 0);
                                num3 = CmdLayerGetErrorData(_t);
                                this.FRMRWriteEEPROMFailedThreadSafe(this.GetErrorExplanation(num3));
                                return;

                            case ((Command_t) 0x80):
                                if (CmdLayerGetCmdInProgress() != ((Command_t) 0x30))
                                {
                                    CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x522, true, null);
                                }
                                SendCmd((CommandType_t) 1, _t, null, 0);
                                break;

                            default:
                                CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x52f, true, null);
                                break;
                        }
                    }
                    while (_t != ((Command_t) 50));
                    this.SetProgressUndefinedThreadSafe();
                    if (!this.FRMRStop(&num3))
                    {
                        this.FRMRWriteEEPROMFailedThreadSafe(this.GetErrorExplanation(num3));
                    }
                    else
                    {
                        this.FRMRWriteEEPROMOkThreadSafe();
                    }
                }
            }
            catch (UserAborted)
            {
                this.FRMRWriteEEPROMFailedThreadSafe(this.GetLocalizedString("strUserAborted"));
            }
            catch (InvalidOBDPower)
            {
                this.FRMRWriteEEPROMFailedThreadSafe(this.GetLocalizedString("strInvalidOBDPower"));
            }
            catch (NoOBDPower)
            {
                this.FRMRWriteEEPROMFailedThreadSafe(this.GetLocalizedString("strNoOBDPower"));
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t2;
                        byte errorcode = (byte) _t2;
                        this.AddToLogThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(errorcode) + ")!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(errorcode) + ")!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x55a, false, null);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x56d, true, null);
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
        }

        private void FRMRWriteFlashFailedThreadSafe(string ErrorString)
        {
            if (this.InvokeRequired)
            {
                TaskFailedDelegate method = new TaskFailedDelegate(this.FRMRWriteFlashFailedThreadSafe);
                object[] args = new object[] { ErrorString };
                this.Invoke(method, args);
            }
            else
            {
                this.StopOperation();
                if (this.m_MemoryTab.GetActiveECU() == MemoryTab.ECU.MR)
                {
                    this.m_VeDocCryptoKeySetWasCalled = false;
                }
                this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + ErrorString + ")!\r\n");
                this.MessageBoxThreadSafe((this.m_CurrentWriteFlashFailedStr + " (") + ErrorString + ")!", this.m_CurrentWriteFlashOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void FRMRWriteFlashOkThreadSafe()
        {
            if (this.InvokeRequired)
            {
                Action method = new Action(this.FRMRWriteFlashOkThreadSafe);
                base.Invoke(method);
            }
            else
            {
                this.StopOperation();
                if (this.m_MemoryTab.GetActiveECU() == MemoryTab.ECU.MR)
                {
                    this.m_VeDocCryptoKeySetWasCalled = false;
                }
                this.AddToLogThreadSafe(this.GetLocalizedString("strdone") + "\r\n");
                this.MessageBoxThreadSafe(this.m_CurrentWriteFlashCompletedStr, this.m_CurrentWriteFlashOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private unsafe void FRMRWriteFlashTask()
        {
            uint num;
            int num3 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                byte num2;
                bool flag;
                ref MemoryStream modopt(IsExplicitlyDereferenced) databuf = (ref MemoryStream modopt(IsExplicitlyDereferenced)) &this.m_MemoryTab.m_Flash;
                this.FRMRFileBuffering(databuf);
                MemoryTab.ECU activeECU = this.m_MemoryTab.GetActiveECU();
                if (*(((int*) &activeECU)) != 0)
                {
                    if (*(((int*) &activeECU)) != 1)
                    {
                        if (*(((int*) &activeECU)) == 2)
                        {
                            if (!RunLongOperation((Command_t) 0xd9, null, 0, (Command_t) 0xda, (Command_t) 0xdb, 0))
                            {
                                num2 = CmdLayerGetErrorData((Command_t) 0xdb);
                                this.FRMRWriteFlashFailedThreadSafe(this.GetErrorExplanation(num2));
                                return;
                            }
                        }
                        else
                        {
                            CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x409, true, null);
                        }
                    }
                }
                else
                {
                    FlashDumpChecksumResult_t _t5;
                    if (!RunLongOperation((Command_t) 0x42, null, 0, (Command_t) 0x43, (Command_t) 0x44, 0))
                    {
                        goto Label_0313;
                    }
                    CmdLayerGetMRFlashDataCheckAnswer(&_t5);
                    if ((*(((byte*) &_t5)) == 0) || (this.m_CurrentWriteFlashHaveToCheckMainCRC && (*(((byte*) (&_t5 + 1))) == 0)))
                    {
                        DialogResult result = this.MessageBoxThreadSafe(this.GetLocalizedString("strFlashCRCInvalidAskCorrect"), this.m_CurrentWriteFlashOperationStr, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                        if (*(((int*) &result)) == 2)
                        {
                            throw new UserAborted();
                        }
                        if (*(((int*) &result)) != 6)
                        {
                            if (*(((int*) &result)) == 7)
                            {
                                this.AddToLogThreadSafe(this.GetLocalizedString("strcontinueWithBadCRC") + "...");
                            }
                        }
                        else
                        {
                            this.AddToLogThreadSafe(this.GetLocalizedString("strcorrectingFlashCRC") + "...");
                            if (!RunLongOperation((Command_t) 0x45, null, 0, (Command_t) 70, (Command_t) 0x47, 0))
                            {
                                num2 = CmdLayerGetErrorData((Command_t) 0x47);
                                this.FRMRWriteFlashFailedThreadSafe(this.GetErrorExplanation(num2));
                                return;
                            }
                        }
                    }
                }
                MemoryTab.ECU ecu = this.m_MemoryTab.GetActiveECU();
                if (*(((int*) &ecu)) >= 0)
                {
                    if (*(((int*) &ecu)) > 1)
                    {
                        if (*(((int*) &ecu)) != 2)
                        {
                            goto Label_0198;
                        }
                        flag = this.FRStart(this.m_CurrentWriteFlashOperationStr, &num2);
                    }
                    else
                    {
                        flag = this.MRStart(this.m_CurrentWriteFlashOperationStr, &num2);
                    }
                    goto Label_01AA;
                }
            Label_0198:
                CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x41f, true, null);
            Label_01AA:
                if (!flag)
                {
                    this.FRMRWriteFlashFailedThreadSafe(this.GetErrorExplanation(num2));
                }
                else
                {
                    Command_t _t;
                    CommandType_t _t4;
                    this.SetProgressBoundsThreadSafe(0, 0x100);
                    if (!SendRequestWaitForAnswer(this.m_CurrentWriteFlashStartCmd, null, 0, &_t4))
                    {
                        CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x430, true, null);
                    }
                    if (_t4 != ((CommandType_t) 1))
                    {
                        CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x431, true, null);
                    }
                    do
                    {
                        CommandType_t _t3;
                        WaitForNewCmdWithRetry(&_t3, &_t, 0);
                        if (_t3 != ((CommandType_t) 0))
                        {
                            CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x43a, true, null);
                        }
                        if (_t == this.m_CurrentWriteFlashProgressCmd)
                        {
                            SendCmd((CommandType_t) 1, _t, null, 0);
                            this.SetProgressValueThreadSafe(*this.m_CurrentWriteFlashProgressFnc());
                        }
                        else if (_t == this.m_CurrentWriteFlashOkCmd)
                        {
                            SendCmd((CommandType_t) 1, _t, null, 0);
                        }
                        else if (_t == ((Command_t) 0x80))
                        {
                            if (CmdLayerGetCmdInProgress() != this.m_CurrentWriteFlashStartCmd)
                            {
                                CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x44d, true, null);
                            }
                            SendCmd((CommandType_t) 1, _t, null, 0);
                        }
                        else
                        {
                            if (_t == this.m_CurrentWriteFlashFailedCmd)
                            {
                                SendCmd((CommandType_t) 1, _t, null, 0);
                                num2 = CmdLayerGetErrorData(_t);
                                this.FRMRWriteFlashFailedThreadSafe(this.GetErrorExplanation(num2));
                                return;
                            }
                            CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x45c, true, null);
                        }
                    }
                    while (_t != this.m_CurrentWriteFlashOkCmd);
                    this.SetProgressUndefinedThreadSafe();
                    if (!this.FRMRStop(&num2))
                    {
                        this.FRMRWriteFlashFailedThreadSafe(this.GetErrorExplanation(num2));
                    }
                    else
                    {
                        this.FRMRWriteFlashOkThreadSafe();
                    }
                }
                return;
            Label_0313:
                num2 = CmdLayerGetErrorData((Command_t) 0x44);
                this.FRMRWriteFlashFailedThreadSafe(this.GetErrorExplanation(num2));
            }
            catch (UserAborted)
            {
                this.FRMRWriteFlashFailedThreadSafe(this.GetLocalizedString("strUserAborted"));
            }
            catch (InvalidOBDPower)
            {
                this.FRMRWriteFlashFailedThreadSafe(this.GetLocalizedString("strInvalidOBDPower"));
            }
            catch (NoOBDPower)
            {
                this.FRMRWriteFlashFailedThreadSafe(this.GetLocalizedString("strNoOBDPower"));
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num3);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t2;
                        byte errorcode = (byte) _t2;
                        this.AddToLogThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(errorcode) + ")!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(errorcode) + ")!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x486, false, null);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num3, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num3);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num3, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num3);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x499, true, null);
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num3, (int) num);
                }
            }
        }

        [return: MarshalAs(UnmanagedType.U1)]
        private unsafe bool FRStart(string MsgCaption, byte* modopt(IsImplicitlyDereferenced) ErrorCode)
        {
            this.AskForIgnition(true, MsgCaption, true);
            if (!RunLongOperation((Command_t) 0xd6, null, 0, (Command_t) 0xd7, (Command_t) 0xd8, 0))
            {
                ErrorCode[0] = (byte* modopt(IsImplicitlyDereferenced)) CmdLayerGetErrorData((Command_t) 0xd8);
                return false;
            }
            return true;
        }

        private unsafe void GenerateFullFaultsReport()
        {
            Paragraph paragraph = null;
            uint num;
            DTCInfo_t[] _tArray = null;
            Row row2 = null;
            int num5 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                DTC_t modopt(IsConst)* _tPtr;
                string vIN;
                uint num10;
                PdfDocumentRenderer modopt(IsConst) renderer;
                int num15;
                string str3;
                string str4;
                uint num21;
                $ArrayType$$$BY0BA@E e$$$byba@e;
                TruckType_t truckType = this.m_TruckType;
                if (*(((int*) &truckType)) != 0)
                {
                    if (*(((int*) &truckType)) != 1)
                    {
                        CustomAssert(&??_C@_0BE@NEIAFJLK@FaultCodesTasks?4cpp?$AA@, 0x3d7, true, null);
                    }
                    else
                    {
                        this.TaskNotImplementedThreadSafe();
                    }
                    return;
                }
                this.AskForIgnition(true, this.m_LastOperationStr, true);
                Document document = new Document {
                    DefaultPageSetup = { PageFormat = PageFormat.A4 }
                };
                Unit pageWidth = document.DefaultPageSetup.PageWidth;
                Unit leftMargin = document.DefaultPageSetup.LeftMargin;
                Unit rightMargin = document.DefaultPageSetup.RightMargin;
                double num22 = pageWidth.Centimeter - leftMargin.Centimeter;
                double num12 = num22 - rightMargin.Centimeter;
                document.Info.Title = "Full fault codes report";
                document.Info.Author = this.m_MainCaption + " Dielektrik UAB \x00a9 2014";
                if (string.IsNullOrEmpty(this.m_VIN))
                {
                    vIN = "???";
                }
                else
                {
                    vIN = this.m_VIN;
                }
                string str5 = vIN;
                document.Info.Subject = vIN;
                Section section = document.AddSection();
                string str = "Arial";
                Table table = section.Headers.Primary.AddTable();
                double num11 = num12 * 0.3;
                Unit width = Unit.FromCentimeter(num11);
                table.AddColumn(width).Format.Alignment = ParagraphAlignment.Left;
                double num19 = num12 * 0.4;
                Unit unit41 = Unit.FromCentimeter(num19);
                table.AddColumn(unit41).Format.Alignment = ParagraphAlignment.Center;
                Unit unit40 = Unit.FromCentimeter(num11);
                table.AddColumn(unit40).Format.Alignment = ParagraphAlignment.Right;
                Row row = table.AddRow();
                row.Format.Font.Name = str;
                row.Format.Font.Size = 10;
                row.Format.Font.Color = Colors.DimGray;
                row.VerticalAlignment = VerticalAlignment.Center;
                row.Cells[0].AddImage(AppDomain.CurrentDomain.BaseDirectory + @"\Logo1.png");
                row.Cells[1].AddParagraph(this.m_MainCaption);
                row.Cells[2].AddParagraph().AddImage(AppDomain.CurrentDomain.BaseDirectory + @"\Logo2.png");
                table = section.Footers.Primary.AddTable();
                Unit unit38 = Unit.FromCentimeter(num11);
                table.AddColumn(unit38).Format.Alignment = ParagraphAlignment.Left;
                Unit unit37 = Unit.FromCentimeter(num19);
                table.AddColumn(unit37).Format.Alignment = ParagraphAlignment.Center;
                Unit unit36 = Unit.FromCentimeter(num11);
                table.AddColumn(unit36).Format.Alignment = ParagraphAlignment.Right;
                row = table.AddRow();
                row.Format.Font.Name = str;
                row.Format.Font.Size = 10;
                row.Format.Font.Color = Colors.DimGray;
                row.Cells[0].AddParagraph().AddDateField();
                row.Cells[1].AddParagraph(vIN);
                paragraph = row.Cells[2].AddParagraph(this.GetLocalizedString("strPage") + " ");
                paragraph.AddPageField();
                paragraph.AddText("/");
                paragraph.AddNumPagesField();
                paragraph = section.AddParagraph();
                paragraph.Format.SpaceBefore = "4pt";
                paragraph.Format.SpaceAfter = "4pt";
                paragraph.Format.Alignment = ParagraphAlignment.Center;
                paragraph.Format.Font.Name = str;
                paragraph.Format.Font.Size = 0x12;
                paragraph.Format.Font.Bold = true;
                paragraph.AddText(this.GetLocalizedString("strFullFaultsReport").ToUpper());
                section.AddParagraph("");
                section.AddParagraph("");
                table = section.AddTable();
                table.LeftPadding = "0.2cm";
                table.RightPadding = "0.2cm";
                table.TopPadding = "0.2cm";
                table.BottomPadding = "0.2cm";
                table.Borders.Bottom.Width = 0.5;
                table.Borders.Bottom.Color = Colors.DarkGray;
                double num18 = num12 * 0.5;
                Unit unit26 = Unit.FromCentimeter(num18);
                Column column = table.AddColumn(unit26);
                column.Format.Font.Name = str;
                column.Format.Font.Size = 10;
                column.Format.Font.Bold = true;
                Unit unit24 = Unit.FromCentimeter(num18);
                column = table.AddColumn(unit24);
                column.Format.Font.Name = str;
                column.Format.Font.Size = 10;
                row = table.AddRow();
                row.Cells[0].AddParagraph(this.GetLocalizedString("strTruckManufacturer"));
                TruckType_t _t3 = this.m_TruckType;
                if (*(((int*) &_t3)) != 0)
                {
                    if (*(((int*) &_t3)) != 1)
                    {
                        CustomAssert(&??_C@_0BE@NEIAFJLK@FaultCodesTasks?4cpp?$AA@, 0x2ca, true, null);
                    }
                    else
                    {
                        row.Cells[1].AddParagraph(this.GetLocalizedString("strMAN"));
                    }
                }
                else
                {
                    row.Cells[1].AddParagraph(this.GetLocalizedString("strMB"));
                }
                row = table.AddRow();
                row.Cells[0].AddParagraph(this.GetLocalizedString("strVIN"));
                row.Cells[1].AddParagraph(vIN);
                if (this.m_MRMotorNumber != null)
                {
                    row = table.AddRow();
                    row.Cells[0].AddParagraph(this.GetLocalizedString("strEngineNumber"));
                    row.Cells[1].AddParagraph(this.m_MRMotorNumber);
                }
                row = table.AddRow();
                row.Cells[0].AddParagraph(this.GetLocalizedString("strDeviceType"));
                row.Cells[1].AddParagraph("Vehicle Explorer Interface");
                row = table.AddRow();
                row.Cells[0].AddParagraph(this.GetLocalizedString("strDeviceSN"));
                row.Cells[1].AddParagraph($"{this.m_DeviceSN:D5}");
                row = table.AddRow();
                row.Cells[0].AddParagraph(this.GetLocalizedString("strConnectionType"));
                if (this.m_IsDirectConnection)
                {
                    str4 = $"DIRECT (cable s/n {(uint) this.m_DirectCableSN:D5})";
                }
                else
                {
                    str4 = "OBD";
                }
                row.Cells[1].AddParagraph(str4);
                section.AddParagraph("");
                this.SetProgressBoundsThreadSafe(0, this.m_DetectedECU.Length);
                int index = 0;
            Label_076A:
                if (index >= this.m_DetectedECU.Length)
                {
                    goto Label_10F8;
                }
                section.AddParagraph("");
                table = section.AddTable();
                table.LeftPadding = "0.2cm";
                table.RightPadding = "0.2cm";
                table.TopPadding = "0.2cm";
                table.BottomPadding = "0.2cm";
                table.Borders.Top.Width = 0.5;
                table.Borders.Top.Color = Colors.DarkGray;
                table.Borders.Bottom.Width = 0.5;
                table.Borders.Bottom.Color = Colors.DarkGray;
                Unit unit16 = "2cm";
                column = table.AddColumn(unit16);
                column.Format.Alignment = ParagraphAlignment.Center;
                column.Format.Font.Name = str;
                column.Format.Font.Size = 12;
                Unit unit14 = Unit.FromCentimeter((num12 - 2.0) - 3.0);
                column = table.AddColumn(unit14);
                column.Format.Font.Name = str;
                column.Format.Font.Size = 12;
                Unit unit12 = "3cm";
                column = table.AddColumn(unit12);
                column.Format.Alignment = ParagraphAlignment.Center;
                column.Format.Font.Name = str;
                column.Format.Font.Size = 12;
                row2 = table.AddRow();
                row2.KeepWith = 1;
                row2.Cells[0].MergeRight = 2;
                row2.Format.Font.Bold = true;
                row2.Format.Alignment = ParagraphAlignment.Left;
                ECUInfo[] detectedECU = this.m_DetectedECU;
                if (detectedECU[index].m_HaveMoreECUsWithSameAddr)
                {
                    str3 = "? ";
                }
                else
                {
                    str3 = "";
                }
                row2.Cells[0].AddParagraph((str3 + this.m_DetectedECU[index].m_shortname) + " " + this.GetLocalizedString(detectedECU[index].m_longnameid));
                this.AddToLogThreadSafe("\r\n  " + this.GetParamedLocalizedString("strReadingFaultsFromX", this.m_DetectedECU[index].m_shortname) + ": ");
                if (!CmdLayerCreateDTCReadParams((byte*) &e$$$byba@e, 0x10, &num21, this.m_DetectedECU[index].m_addr))
                {
                    CustomAssert(&??_C@_0BE@NEIAFJLK@FaultCodesTasks?4cpp?$AA@, 0x318, true, null);
                }
                if (!RunLongOperation((Command_t) 0xb9, (byte modopt(IsConst)*) &e$$$byba@e, num21, (Command_t) 0xba, (Command_t) 0xbb, 0))
                {
                    goto Label_0FE8;
                }
                CmdLayerGetDTCReadData(&_tPtr, &num10);
                uint num13 = 0;
                uint num7 = 0;
            Label_0A88:
                if (num7 >= num10)
                {
                    goto Label_0AE0;
                }
                bool flag2 = true;
                uint num9 = num7 + 1;
                while (true)
                {
                    if (num9 >= num10)
                    {
                        break;
                    }
                    DTC_t modopt(IsConst)* _tPtr5 = ((DTC_t modopt(IsConst)*) (num9 * 8)) + _tPtr;
                    DTC_t modopt(IsConst)* _tPtr4 = ((DTC_t modopt(IsConst)*) (num7 * 8)) + _tPtr;
                    if ((_tPtr4 == _tPtr5) && (*(((byte*) (_tPtr4 + 6))) == *(((byte*) (_tPtr5 + 6)))))
                    {
                        flag2 = false;
                        goto Label_0AD8;
                    }
                    num9++;
                }
                if (flag2)
                {
                    num13++;
                }
            Label_0AD8:
                num7++;
                goto Label_0A88;
            Label_0AE0:
                _tArray = new DTCInfo_t[num13];
                uint num6 = 0;
                uint num4 = 0;
            Label_0AEF:
                if (num4 >= num10)
                {
                    goto Label_0BB5;
                }
                bool flag = true;
                uint num8 = num4 + 1;
                while (true)
                {
                    if (num8 >= num10)
                    {
                        break;
                    }
                    DTC_t modopt(IsConst)* _tPtr3 = ((DTC_t modopt(IsConst)*) (num4 * 8)) + _tPtr;
                    DTC_t modopt(IsConst)* _tPtr2 = ((DTC_t modopt(IsConst)*) (num8 * 8)) + _tPtr;
                    if ((_tPtr3 == _tPtr2) && (*(((byte*) (_tPtr3 + 6))) == *(((byte*) (_tPtr2 + 6)))))
                    {
                        flag = false;
                        goto Label_0BAA;
                    }
                    num8++;
                }
                if (flag)
                {
                    uint num17 = num4 * 8;
                    _tArray[num6].code = new string((sbyte*) (_tPtr + num17));
                    int num16 = *((int*) ((num17 + _tPtr) + 6));
                    if (num16 != 0)
                    {
                        if (num16 != 1)
                        {
                            CustomAssert(&??_C@_0BE@NEIAFJLK@FaultCodesTasks?4cpp?$AA@, 0x34c, true, null);
                        }
                        else
                        {
                            _tArray[num6].status = DTCStatus_t.Current;
                        }
                    }
                    else
                    {
                        _tArray[num6].status = DTCStatus_t.Stored;
                    }
                    num6++;
                }
            Label_0BAA:
                num4++;
                goto Label_0AEF;
            Label_0BB5:
                num15 = _tArray.Length;
                if (num15 == 1)
                {
                    this.AddToLogThreadSafe(this.GetLocalizedString("str1faultfound"));
                }
                else
                {
                    this.AddToLogThreadSafe(this.GetParamedLocalizedString("strXfaultsfound", num15));
                }
                this.SetProgressValueThreadSafe(index + 1);
                if (_tArray.Length != 0)
                {
                    row2.Shading.Color = Colors.LightPink;
                    row2.KeepWith = 2;
                    row = table.AddRow();
                    row.Format.Alignment = ParagraphAlignment.Center;
                    row.Format.Font.Color = Colors.DimGray;
                    row.TopPadding = "0cm";
                    row.BottomPadding = "0cm";
                    row.Cells[0].AddParagraph(this.GetLocalizedString("strFaultCode"));
                    row.Cells[0].Borders.Right.Width = 0.5;
                    row.Cells[0].Borders.Right.Color = Colors.DarkGray;
                    row.Cells[1].AddParagraph(this.GetLocalizedString("strFaultDescription"));
                    row.Cells[1].Borders.Right.Width = 0.5;
                    row.Cells[1].Borders.Right.Color = Colors.DarkGray;
                    row.Cells[2].AddParagraph(this.GetLocalizedString("strFaultStatus"));
                    for (int i = 0; i < _tArray.Length; i++)
                    {
                        row = table.AddRow();
                        row.Cells[0].AddParagraph(_tArray[i].code);
                        row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
                        row.Cells[0].Borders.Right.Width = 0.5;
                        row.Cells[0].Borders.Right.Color = Colors.DarkGray;
                        row.Cells[1].AddParagraph(this.GetDTCDescription(this.m_DetectedECU[index].m_shortname, _tArray[i].code));
                        row.Cells[1].Borders.Right.Width = 0.5;
                        row.Cells[1].Borders.Right.Color = Colors.DarkGray;
                        DTCStatus_t status = _tArray[i].status;
                        if (*(((int*) &status)) != 0)
                        {
                            if (*(((int*) &status)) != 1)
                            {
                                CustomAssert(&??_C@_0BE@NEIAFJLK@FaultCodesTasks?4cpp?$AA@, 0x388, true, null);
                            }
                            else
                            {
                                row.Format.Font.Italic = true;
                                row.Cells[2].AddParagraph(this.GetLocalizedString("strStoredFault"));
                            }
                        }
                        else
                        {
                            row.Cells[2].AddParagraph(this.GetLocalizedString("strCurrentFault"));
                        }
                        row.Cells[2].VerticalAlignment = VerticalAlignment.Center;
                    }
                }
                else
                {
                    row2.Shading.Color = Colors.LightGreen;
                    row = table.AddRow();
                    row.Cells[0].Borders.Right.Width = 0.5;
                    row.Cells[0].Borders.Right.Color = Colors.DarkGray;
                    row.Cells[1].MergeRight = 1;
                    row.Cells[1].AddParagraph(this.GetLocalizedString("strNoFaultsFound"));
                    row.Cells[1].Borders.Right.Width = 0.5;
                    row.Cells[1].Borders.Right.Color = Colors.DarkGray;
                }
                goto Label_10ED;
            Label_0FE8:
                this.AddToLogThreadSafe(this.GetLocalizedString("strfailed"));
                this.SetProgressValueThreadSafe(index + 1);
                row2.Shading.Color = Colors.LightGoldenrodYellow;
                row = table.AddRow();
                row.Cells[0].Borders.Right.Width = 0.5;
                row.Cells[0].Borders.Right.Color = Colors.DarkGray;
                row.Cells[1].MergeRight = 1;
                byte errorcode = CmdLayerGetErrorData((Command_t) 0xbb);
                row.Cells[1].AddParagraph(this.GetErrorExplanation(errorcode));
                row.Cells[1].Borders.Right.Width = 0.5;
                row.Cells[1].Borders.Right.Color = Colors.DarkGray;
            Label_10ED:
                index++;
                goto Label_076A;
            Label_10F8:
                renderer = new PdfDocumentRenderer(true);
                this.m_GeneratedPDFReport = renderer;
                renderer.Document = document;
                this.m_GeneratedPDFReport.RenderDocument();
                this.GenerateFullFaultsReportOkThreadSafe();
            }
            catch (UserAborted)
            {
                this.ReadFaultsFailedThreadSafe(this.GetLocalizedString("strUserAborted"));
            }
            catch (InvalidOBDPower)
            {
                this.ReadFaultsFailedThreadSafe(this.GetLocalizedString("strInvalidOBDPower"));
            }
            catch (NoOBDPower)
            {
                this.ReadFaultsFailedThreadSafe(this.GetLocalizedString("strNoOBDPower"));
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num5);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t;
                        byte num14 = (byte) _t;
                        this.AddToLogThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(num14) + ")!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(num14) + ")!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0BE@NEIAFJLK@FaultCodesTasks?4cpp?$AA@, 0x3f3, false, null);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num5, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num5);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num5, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num5);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0BE@NEIAFJLK@FaultCodesTasks?4cpp?$AA@, 0x406, true, null);
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num5, (int) num);
                }
            }
        }

        private void GenerateFullFaultsReportFailedThreadSafe(string ErrorString)
        {
            if (this.InvokeRequired)
            {
                TaskFailedDelegate method = new TaskFailedDelegate(this.GenerateFullFaultsReportFailedThreadSafe);
                object[] args = new object[] { ErrorString };
                this.Invoke(method, args);
            }
            else
            {
                this.StopOperation();
                this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + ErrorString + ")!\r\n");
            }
        }

        private unsafe void GenerateFullFaultsReportOkThreadSafe()
        {
            uint num;
            string str2;
            int num2 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            if (this.InvokeRequired)
            {
                Action method = new Action(this.GenerateFullFaultsReportOkThreadSafe);
                base.Invoke(method);
                return;
            }
            this.StopOperation();
            this.AddToLogThreadSafe("\r\n");
            MemoryStream stream = new MemoryStream();
            this.m_GeneratedPDFReport.PdfDocument.Save(stream, false);
            DateTime now = DateTime.Now;
            if (string.IsNullOrEmpty(this.m_VIN))
            {
                str2 = !string.IsNullOrEmpty(this.m_MRMotorNumber) ? (this.m_MRMotorNumber + " ") : "";
            }
            else
            {
                str2 = this.m_VIN + " ";
            }
            string str = $"{str2}{now:yyyy-MM-dd HHmmss}.pdf";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\TruckExplorer\reports\" + str;
            try
            {
                FileStream stream3 = System.IO.File.Create(path);
                stream.WriteTo(stream3);
                stream3.Close();
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        goto Label_0137;
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
            }
        Label_0137:
            this.dlgSaveFile.FileName = str;
            this.dlgSaveFile.Title = this.GetLocalizedString("strSaveReportas");
            string filter = this.dlgSaveFile.Filter;
            string defaultExt = this.dlgSaveFile.DefaultExt;
            this.dlgSaveFile.Filter = "PDF files|*.pdf";
            this.dlgSaveFile.DefaultExt = "pdf";
            if (this.dlgSaveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream stream2 = System.IO.File.Create(this.dlgSaveFile.FileName);
                    stream.WriteTo(stream2);
                    stream2.Close();
                    Process.Start(this.dlgSaveFile.FileName);
                }
                catch when (?)
                {
                    num = 0;
                    ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                    try
                    {
                        try
                        {
                            goto Label_0221;
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
                }
            }
        Label_0221:
            this.dlgSaveFile.Filter = filter;
            this.dlgSaveFile.DefaultExt = defaultExt;
            stream.Close();
        }

        private string GetDTCDescription(string ECUShortName, string FullFaultCode)
        {
            string str = "";
            try
            {
                string baseName = "TruckExplorer.FaultCodes." + ECUShortName + "FaultCodes";
                ResourceManager faultCodesResource = this.m_FaultCodesResource;
                if ((faultCodesResource == null) || (faultCodesResource.BaseName != baseName))
                {
                    this.m_FaultCodesResource = new ResourceManager(baseName, Assembly.GetExecutingAssembly());
                }
                string str4 = FullFaultCode.Substring(1);
                int num = 0;
                while (true)
                {
                    string str2 = this.m_FaultCodesResource.GetString(str4 + "_" + num);
                    if (str2 == null)
                    {
                        goto Label_00A9;
                    }
                    if (!string.IsNullOrEmpty(str))
                    {
                        str = str + "\n---\n";
                    }
                    str = str + str2;
                    num++;
                }
            }
            catch (MissingManifestResourceException)
            {
            }
            catch (MissingSatelliteAssemblyException)
            {
            }
        Label_00A9:
            if (string.IsNullOrEmpty(str))
            {
                return this.GetLocalizedString("strUnknownFaultCode");
            }
            return str;
        }

        private string GetErrorExplanation(byte errorcode)
        {
            string localizedString = null;
            if (errorcode < 0x20)
            {
                localizedString = this.GetLocalizedString("strCANError");
            }
            else if (errorcode < 0x30)
            {
                localizedString = this.GetLocalizedString("strDeviceCommError");
            }
            else if (errorcode < 0x40)
            {
                localizedString = this.GetLocalizedString("strKWPError");
            }
            else if (errorcode < 0x60)
            {
                localizedString = this.GetLocalizedString("strECUError");
            }
            else if (errorcode < 0x70)
            {
                localizedString = this.GetLocalizedString("strECUError");
            }
            else if (errorcode < 0x90)
            {
                localizedString = this.GetLocalizedString("strMRCommError");
            }
            else
            {
                switch (errorcode)
                {
                    case 0x97:
                    case 0x98:
                    case 0x99:
                        localizedString = this.GetLocalizedString("strLicenseError");
                        break;

                    case 0x9a:
                    case 0x9b:
                    case 0xaf:
                        localizedString = this.GetLocalizedString("strUnsupportedECU");
                        break;

                    case 0x9f:
                        localizedString = this.GetLocalizedString("strECUError");
                        break;

                    case 0xb1:
                        localizedString = this.GetLocalizedString("strUnsupportedDTCRead");
                        break;

                    case 0xb2:
                    case 0xb8:
                        localizedString = this.GetLocalizedString("strBadFlashStructure");
                        break;
                }
            }
            if (string.IsNullOrEmpty(localizedString))
            {
                return $"code {errorcode:X}";
            }
            return (localizedString + $", code {errorcode:X}");
        }

        private string GetFFRKeyStatusString(ushort FFRKeyStatusCode)
        {
            int num = FFRKeyStatusCode;
            switch (num)
            {
                case 0:
                    return this.GetLocalizedString("strKeyStatusNoKeyFound");

                case 1:
                    return this.GetLocalizedString("strKeyStatusNewKey");
            }
            if (num != 3)
            {
                return $"code {FFRKeyStatusCode:X}";
            }
            return this.GetLocalizedString("strKeyStatusOldKey");
        }

        private string GetFRImmoStatusString([MarshalAs(UnmanagedType.U1)] bool FRImmoStatus)
        {
            if (FRImmoStatus)
            {
                return this.GetLocalizedString("strOn");
            }
            return this.GetLocalizedString("strOff");
        }

        private string GetFRKeyDetectedString([MarshalAs(UnmanagedType.U1)] bool FRKeyDetected)
        {
            if (FRKeyDetected)
            {
                return this.GetLocalizedString("strYes");
            }
            return this.GetLocalizedString("strNo");
        }

        private string GetHumanSize(uint modopt(IsLong) size)
        {
            if (size >= 0x400)
            {
                return $"{((uint) (size >> 10))} KB";
            }
            return $"{((uint) size)} bytes";
        }

        private string GetImmoStatusString([MarshalAs(UnmanagedType.U1)] bool FFRImmoStatus)
        {
            if (FFRImmoStatus)
            {
                return this.GetLocalizedString("strOn");
            }
            return this.GetLocalizedString("strOff");
        }

        private string GetLocalizedString(string stringid)
        {
            string str = this.m_Resources.GetString(stringid);
            if (str == null)
            {
                this.MessageBoxThreadSafe($"Translation for {stringid} not found!", "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return "???";
            }
            return str;
        }

        private string GetMRImmoStatusString(ushort ImmoStatusCode)
        {
            int num = ImmoStatusCode;
            switch (num)
            {
                case 1:
                    return this.GetLocalizedString("strFreeze");

                case 2:
                    return this.GetLocalizedString("strOff");
            }
            if (num != 3)
            {
                return $"code {ImmoStatusCode:X}";
            }
            return this.GetLocalizedString("strOn");
        }

        private string GetMRKeyStatusString(ushort KeyStatusCode)
        {
            switch (KeyStatusCode)
            {
                case 0:
                    return this.GetLocalizedString("strKeyStatusNewKey");

                case 3:
                    return this.GetLocalizedString("strKeyStatusNoKeyFound");

                case 10:
                    return this.GetLocalizedString("strKeyStatusMemoryFault");

                case 11:
                    return this.GetLocalizedString("strKeyStatusOldKey");
            }
            return $"code {KeyStatusCode:X}";
        }

        private string GetParamedLocalizedString(string stringid, int param) => 
            string.Format(this.GetLocalizedString(stringid), param);

        private string GetParamedLocalizedString(string stringid, string param) => 
            string.Format(this.GetLocalizedString(stringid), param);

        private string GetPTMKeyLearnString(ushort PTMKeyLearnCode)
        {
            int num = PTMKeyLearnCode;
            if (num == 2)
            {
                return this.GetLocalizedString("strKeyStatusOldKey");
            }
            if (num != 3)
            {
                return $"code {PTMKeyLearnCode:X}";
            }
            return this.GetLocalizedString("strKeyStatusNoKeyFound");
        }

        private string GetPTMKeyStatusString(ushort PTMKeyStatusCode)
        {
            int num = PTMKeyStatusCode;
            switch (num)
            {
                case 0:
                    return this.GetLocalizedString("strKeyStatusOldKey");

                case 3:
                    return this.GetLocalizedString("strKeyStatusNewKey");
            }
            if (num != 30)
            {
                return $"code {PTMKeyStatusCode:X}";
            }
            return this.GetLocalizedString("strKeyStatusNoKeyFound");
        }

        private void GetSpeedLimitFailedThreadSafe(string ErrorString)
        {
            if (this.InvokeRequired)
            {
                TaskFailedDelegate method = new TaskFailedDelegate(this.GetSpeedLimitFailedThreadSafe);
                object[] args = new object[] { ErrorString };
                this.Invoke(method, args);
            }
            else
            {
                this.edExtraOperationParameter.Clear();
                this.StopOperation();
                this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + ErrorString + ")!\r\n");
                this.MessageBoxThreadSafe((this.GetLocalizedString("strGetSpeedLimitFailed") + " (") + ErrorString + ")!", this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void GetSpeedLimitOkThreadSafe()
        {
            if (this.InvokeRequired)
            {
                Action method = new Action(this.GetSpeedLimitOkThreadSafe);
                base.Invoke(method);
            }
            else
            {
                this.edExtraOperationParameter.Text = $"{(uint) this.m_ExtraTab.m_SpeedLimit}";
                this.StopOperation();
                this.AddToLogThreadSafe(this.GetLocalizedString("strdone") + "\r\n");
            }
        }

        private unsafe void GetSpeedLimitTask()
        {
            uint num;
            int num2 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                this.AskForIgnition(true, this.m_LastOperationStr, true);
                if (RunLongOperation((Command_t) 0xbf, null, 0, (Command_t) 0xc0, (Command_t) 0xc1, 0))
                {
                    this.m_ExtraTab.m_SpeedLimit = CmdLayerGetSpeedLimitGetInfo();
                    this.GetSpeedLimitOkThreadSafe();
                }
                else
                {
                    byte errorcode = CmdLayerGetErrorData((Command_t) 0xc1);
                    this.GetSpeedLimitFailedThreadSafe(this.GetErrorExplanation(errorcode));
                }
            }
            catch (UserAborted)
            {
                this.GetSpeedLimitFailedThreadSafe(this.GetLocalizedString("strUserAborted"));
            }
            catch (InvalidOBDPower)
            {
                this.GetSpeedLimitFailedThreadSafe(this.GetLocalizedString("strInvalidOBDPower"));
            }
            catch (NoOBDPower)
            {
                this.GetSpeedLimitFailedThreadSafe(this.GetLocalizedString("strNoOBDPower"));
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t;
                        byte num3 = (byte) _t;
                        this.AddToLogThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(num3) + ")!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(num3) + ")!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0P@NKJDEOOE@ExtraTasks?4cpp?$AA@, 0xc2, false, null);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0P@NKJDEOOE@ExtraTasks?4cpp?$AA@, 0xd5, true, null);
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
        }

        private void GetTorqueLimitFailedThreadSafe(string ErrorString)
        {
            if (this.InvokeRequired)
            {
                TaskFailedDelegate method = new TaskFailedDelegate(this.GetTorqueLimitFailedThreadSafe);
                object[] args = new object[] { ErrorString };
                this.Invoke(method, args);
            }
            else
            {
                this.edExtraOperationParameter.Clear();
                this.StopOperation();
                this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + ErrorString + ")!\r\n");
                this.MessageBoxThreadSafe((this.GetLocalizedString("strGetTorqueLimitFailed") + " (") + ErrorString + ")!", this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void GetTorqueLimitOkThreadSafe()
        {
            if (this.InvokeRequired)
            {
                Action method = new Action(this.GetTorqueLimitOkThreadSafe);
                base.Invoke(method);
            }
            else
            {
                switch (this.m_ExtraTab.m_TorqueLimit)
                {
                    case 50:
                        this.edExtraOperationParameter.Text = "Not present";
                        break;

                    case 60:
                        this.edExtraOperationParameter.Text = "60 %";
                        break;

                    case 0x4b:
                        this.edExtraOperationParameter.Text = "75 %";
                        break;

                    case 100:
                        this.edExtraOperationParameter.Text = "100 %";
                        break;

                    default:
                        this.edExtraOperationParameter.Text = "Unknown";
                        break;
                }
                this.StopOperation();
                this.AddToLogThreadSafe(this.GetLocalizedString("strdone") + "\r\n");
            }
        }

        private unsafe void GetTorqueLimitTask()
        {
            uint num;
            int num2 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                this.AskForIgnition(true, this.m_LastOperationStr, true);
                if (RunLongOperation((Command_t) 200, null, 0, (Command_t) 0xc9, (Command_t) 0xca, 0))
                {
                    this.m_ExtraTab.m_TorqueLimit = CmdLayerGetNOxTorqueLimitGetInfo();
                    this.GetTorqueLimitOkThreadSafe();
                }
                else
                {
                    byte errorcode = CmdLayerGetErrorData((Command_t) 0xca);
                    this.GetTorqueLimitFailedThreadSafe(this.GetErrorExplanation(errorcode));
                }
            }
            catch (UserAborted)
            {
                this.GetTorqueLimitFailedThreadSafe(this.GetLocalizedString("strUserAborted"));
            }
            catch (InvalidOBDPower)
            {
                this.GetTorqueLimitFailedThreadSafe(this.GetLocalizedString("strInvalidOBDPower"));
            }
            catch (NoOBDPower)
            {
                this.GetTorqueLimitFailedThreadSafe(this.GetLocalizedString("strNoOBDPower"));
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t;
                        byte num3 = (byte) _t;
                        this.AddToLogThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(num3) + ")!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(num3) + ")!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0P@NKJDEOOE@ExtraTasks?4cpp?$AA@, 0x1a5, false, null);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0P@NKJDEOOE@ExtraTasks?4cpp?$AA@, 440, true, null);
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
        }

        private void gridFaultCodes_SelectionChanged(object sender, EventArgs e)
        {
            this.gridFaultCodes.ClearSelection();
        }

        private void HideMessageBoxThreadSafe()
        {
            if (this.InvokeRequired)
            {
                Action method = new Action(this.HideMessageBoxThreadSafe);
                base.Invoke(method);
            }
            else
            {
                this.m_msgbox.Hide();
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(MainForm));
            DataGridViewCellStyle style3 = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style4 = new DataGridViewCellStyle();
            this.gbxInformation = new GroupBox();
            this.lblCar = new Label();
            this.btnCarRight = new Button();
            this.btnCarLeft = new Button();
            this.imgCar = new PictureBox();
            this.edLog = new TextBox();
            this.shapeContainer1 = new ShapeContainer();
            this.lineShape1 = new LineShape();
            this.tabctlActions = new TabControl();
            this.tabMemory = new TabPage();
            this.lblOperations = new Label();
            this.cbxMemOperation = new ComboBox();
            this.btnMemRunOperation = new Button();
            this.cbxMemECU = new ComboBox();
            this.btnMemAnalyseAndRead = new Button();
            this.btnMemWriteEEPROMB = new Button();
            this.btnMemReadEEPROMB = new Button();
            this.btnMemWriteEEPROMA = new Button();
            this.btnMemReadEEPROMA = new Button();
            this.btnMemWriteFlash = new Button();
            this.btnMemReadFlash = new Button();
            this.lblMemInfo = new Label();
            this.lblMemWarning = new Label();
            this.btnMemAnalyse = new Button();
            this.shapeContainer10 = new ShapeContainer();
            this.lineShape18 = new LineShape();
            this.lineShape17 = new LineShape();
            this.lineShape16 = new LineShape();
            this.tabLearnKeys = new TabPage();
            this.lblKeysOperation = new Label();
            this.cbxKeysOperation = new ComboBox();
            this.btnKeysRunOperation = new Button();
            this.btnGetKeysInfo = new Button();
            this.lblKeysInfo = new Label();
            this.btnEraseAddKey = new Button();
            this.btnAddKey = new Button();
            this.lblKeysWarning = new Label();
            this.shapeContainer7 = new ShapeContainer();
            this.lineShape12 = new LineShape();
            this.lineShape9 = new LineShape();
            this.tabVeDocCalc = new TabPage();
            this.pictureBox1 = new PictureBox();
            this.edVeDocResult = new TextBox();
            this.edVeDocNumOfKeys = new TextBox();
            this.label11 = new Label();
            this.edVeDocVIN = new TextBox();
            this.label10 = new Label();
            this.label9 = new Label();
            this.edVeDocTransponderCode = new TextBox();
            this.label6 = new Label();
            this.edVeDocID = new TextBox();
            this.label5 = new Label();
            this.label12 = new Label();
            this.cbxVeDocCalcType = new ComboBox();
            this.edVeDocRnd = new TextBox();
            this.btnVeDocCalculate = new Button();
            this.btnVeDocPrepare = new Button();
            this.label3 = new Label();
            this.shapeContainer3 = new ShapeContainer();
            this.lineShape5 = new LineShape();
            this.lineShape4 = new LineShape();
            this.tabFDOKCalc = new TabPage();
            this.label21 = new Label();
            this.label19 = new Label();
            this.edFDOKNewResult = new TextBox();
            this.maskedFDOKID = new MaskedTextBox();
            this.label13 = new Label();
            this.maskedFDOKRnd = new MaskedTextBox();
            this.edFDOKOldResult = new TextBox();
            this.label2 = new Label();
            this.label7 = new Label();
            this.label8 = new Label();
            this.cbxFDOKCalcType = new ComboBox();
            this.btnFDOKCalculate = new Button();
            this.shapeContainer4 = new ShapeContainer();
            this.lineShape6 = new LineShape();
            this.tabDASPwdCalc = new TabPage();
            this.label14 = new Label();
            this.edDASPwd = new TextBox();
            this.label15 = new Label();
            this.cbxDASPwdType = new ComboBox();
            this.btnDASPwdCalc = new Button();
            this.shapeContainer5 = new ShapeContainer();
            this.lineShape7 = new LineShape();
            this.tabExtra = new TabPage();
            this.cbxExtraOperationParameter = new ComboBox();
            this.edExtraOperationParameter = new TextBox();
            this.lblExtraOperationParameter = new Label();
            this.lblExtraOperation = new Label();
            this.cbxExtraOperation = new ComboBox();
            this.btnExtraRunOperation = new Button();
            this.lblExtraWarning = new Label();
            this.tabFaultCodes = new TabPage();
            this.btnGenerateFullFaultsReport = new Button();
            this.pnlFaultCodes = new Panel();
            this.gridFaultCodes = new DataGridView();
            this.clmnCode2 = new DataGridViewTextBoxColumn();
            this.clmnDescription2 = new DataGridViewTextBoxColumn();
            this.btnEraseFaultCodes = new Button();
            this.btnReadFaultCodes = new Button();
            this.cbxDetectedECUs = new ComboBox();
            this.btnDetectECUs = new Button();
            this.tabSettings = new TabPage();
            this.cbxSystemVoltage = new ComboBox();
            this.lblSystemVoltage = new Label();
            this.pnlAbout = new Panel();
            this.lnkAboutRegistration = new LinkLabel();
            this.lnkAboutSupport = new LinkLabel();
            this.lnkAboutHomepage = new LinkLabel();
            this.lblAboutCopyright = new Label();
            this.lblAboutVersion = new Label();
            this.cbxLanguage = new ComboBox();
            this.label18 = new Label();
            this.btnUpdateSoftware = new Button();
            this.btnReadDeviceInfo = new Button();
            this.lblDeviceInfo = new Label();
            this.btnUpdateDevice = new Button();
            this.shapeContainer8 = new ShapeContainer();
            this.lineShape10 = new LineShape();
            this.lineShape3 = new LineShape();
            this.lineShape2 = new LineShape();
            this.lineShape11 = new LineShape();
            this.btnDisconnect = new Button();
            this.btnExit = new Button();
            this.btnConnect = new Button();
            this.strStatus = new StatusStrip();
            this.lblCurrentVEIInfo = new ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new ToolStripStatusLabel();
            this.pbarProgress = new ToolStripProgressBar();
            this.dlgSaveFile = new SaveFileDialog();
            this.dlgOpenFile = new OpenFileDialog();
            this.imglstTrucks = new ImageList(this.components);
            this.gbxInformation.SuspendLayout();
            ((ISupportInitialize) this.imgCar).BeginInit();
            this.tabctlActions.SuspendLayout();
            this.tabMemory.SuspendLayout();
            this.tabLearnKeys.SuspendLayout();
            this.tabVeDocCalc.SuspendLayout();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            this.tabFDOKCalc.SuspendLayout();
            this.tabDASPwdCalc.SuspendLayout();
            this.tabExtra.SuspendLayout();
            this.tabFaultCodes.SuspendLayout();
            this.pnlFaultCodes.SuspendLayout();
            ((ISupportInitialize) this.gridFaultCodes).BeginInit();
            this.tabSettings.SuspendLayout();
            this.pnlAbout.SuspendLayout();
            this.strStatus.SuspendLayout();
            base.SuspendLayout();
            this.gbxInformation.Controls.Add(this.lblCar);
            this.gbxInformation.Controls.Add(this.btnCarRight);
            this.gbxInformation.Controls.Add(this.btnCarLeft);
            this.gbxInformation.Controls.Add(this.imgCar);
            this.gbxInformation.Controls.Add(this.edLog);
            this.gbxInformation.Controls.Add(this.shapeContainer1);
            manager.ApplyResources(this.gbxInformation, "gbxInformation");
            this.gbxInformation.Name = "gbxInformation";
            this.gbxInformation.TabStop = false;
            manager.ApplyResources(this.lblCar, "lblCar");
            this.lblCar.Name = "lblCar";
            manager.ApplyResources(this.btnCarRight, "btnCarRight");
            this.btnCarRight.Name = "btnCarRight";
            this.btnCarRight.UseVisualStyleBackColor = true;
            this.btnCarRight.Click += new EventHandler(this.btnCarRight_Click);
            manager.ApplyResources(this.btnCarLeft, "btnCarLeft");
            this.btnCarLeft.Name = "btnCarLeft";
            this.btnCarLeft.UseVisualStyleBackColor = true;
            this.btnCarLeft.Click += new EventHandler(this.btnCarLeft_Click);
            manager.ApplyResources(this.imgCar, "imgCar");
            this.imgCar.Name = "imgCar";
            this.imgCar.TabStop = false;
            this.edLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            manager.ApplyResources(this.edLog, "edLog");
            this.edLog.Name = "edLog";
            this.edLog.ReadOnly = true;
            this.edLog.TabStop = false;
            manager.ApplyResources(this.shapeContainer1, "shapeContainer1");
            this.shapeContainer1.Name = "shapeContainer1";
            Shape[] shapes = new Shape[] { this.lineShape1 };
            this.shapeContainer1.Shapes.AddRange(shapes);
            this.shapeContainer1.TabStop = false;
            manager.ApplyResources(this.lineShape1, "lineShape1");
            this.lineShape1.Name = "lineShape1";
            this.tabctlActions.Controls.Add(this.tabMemory);
            this.tabctlActions.Controls.Add(this.tabLearnKeys);
            this.tabctlActions.Controls.Add(this.tabVeDocCalc);
            this.tabctlActions.Controls.Add(this.tabFDOKCalc);
            this.tabctlActions.Controls.Add(this.tabDASPwdCalc);
            this.tabctlActions.Controls.Add(this.tabExtra);
            this.tabctlActions.Controls.Add(this.tabFaultCodes);
            this.tabctlActions.Controls.Add(this.tabSettings);
            manager.ApplyResources(this.tabctlActions, "tabctlActions");
            this.tabctlActions.Multiline = true;
            this.tabctlActions.Name = "tabctlActions";
            this.tabctlActions.SelectedIndex = 0;
            this.tabctlActions.SizeMode = TabSizeMode.FillToRight;
            this.tabMemory.Controls.Add(this.lblOperations);
            this.tabMemory.Controls.Add(this.cbxMemOperation);
            this.tabMemory.Controls.Add(this.btnMemRunOperation);
            this.tabMemory.Controls.Add(this.cbxMemECU);
            this.tabMemory.Controls.Add(this.btnMemAnalyseAndRead);
            this.tabMemory.Controls.Add(this.btnMemWriteEEPROMB);
            this.tabMemory.Controls.Add(this.btnMemReadEEPROMB);
            this.tabMemory.Controls.Add(this.btnMemWriteEEPROMA);
            this.tabMemory.Controls.Add(this.btnMemReadEEPROMA);
            this.tabMemory.Controls.Add(this.btnMemWriteFlash);
            this.tabMemory.Controls.Add(this.btnMemReadFlash);
            this.tabMemory.Controls.Add(this.lblMemInfo);
            this.tabMemory.Controls.Add(this.lblMemWarning);
            this.tabMemory.Controls.Add(this.btnMemAnalyse);
            this.tabMemory.Controls.Add(this.shapeContainer10);
            manager.ApplyResources(this.tabMemory, "tabMemory");
            this.tabMemory.Name = "tabMemory";
            this.tabMemory.UseVisualStyleBackColor = true;
            manager.ApplyResources(this.lblOperations, "lblOperations");
            this.lblOperations.Name = "lblOperations";
            this.cbxMemOperation.DropDownStyle = ComboBoxStyle.DropDownList;
            manager.ApplyResources(this.cbxMemOperation, "cbxMemOperation");
            this.cbxMemOperation.FormattingEnabled = true;
            this.cbxMemOperation.Name = "cbxMemOperation";
            this.cbxMemOperation.SelectedIndexChanged += new EventHandler(this.cbxMemOperation_SelectedIndexChanged);
            manager.ApplyResources(this.btnMemRunOperation, "btnMemRunOperation");
            this.btnMemRunOperation.Name = "btnMemRunOperation";
            this.btnMemRunOperation.UseVisualStyleBackColor = true;
            this.btnMemRunOperation.Click += new EventHandler(this.btnMemRunOperation_Click);
            this.cbxMemECU.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbxMemECU.FormattingEnabled = true;
            manager.ApplyResources(this.cbxMemECU, "cbxMemECU");
            this.cbxMemECU.Name = "cbxMemECU";
            this.cbxMemECU.SelectedIndexChanged += new EventHandler(this.cbxMemECU_SelectedIndexChanged);
            manager.ApplyResources(this.btnMemAnalyseAndRead, "btnMemAnalyseAndRead");
            this.btnMemAnalyseAndRead.Name = "btnMemAnalyseAndRead";
            this.btnMemAnalyseAndRead.UseVisualStyleBackColor = true;
            this.btnMemAnalyseAndRead.Click += new EventHandler(this.btnFRMRAnalyseAndRead_Click);
            manager.ApplyResources(this.btnMemWriteEEPROMB, "btnMemWriteEEPROMB");
            this.btnMemWriteEEPROMB.Name = "btnMemWriteEEPROMB";
            this.btnMemWriteEEPROMB.UseVisualStyleBackColor = true;
            this.btnMemWriteEEPROMB.Click += new EventHandler(this.btnFRMRWriteEEPROM_Click);
            manager.ApplyResources(this.btnMemReadEEPROMB, "btnMemReadEEPROMB");
            this.btnMemReadEEPROMB.Name = "btnMemReadEEPROMB";
            this.btnMemReadEEPROMB.UseVisualStyleBackColor = true;
            this.btnMemReadEEPROMB.Click += new EventHandler(this.btnFRMRReadEEPROM_Click);
            manager.ApplyResources(this.btnMemWriteEEPROMA, "btnMemWriteEEPROMA");
            this.btnMemWriteEEPROMA.Name = "btnMemWriteEEPROMA";
            this.btnMemWriteEEPROMA.UseVisualStyleBackColor = true;
            this.btnMemWriteEEPROMA.Click += new EventHandler(this.btnFRMRWriteEEPROM_Click);
            manager.ApplyResources(this.btnMemReadEEPROMA, "btnMemReadEEPROMA");
            this.btnMemReadEEPROMA.Name = "btnMemReadEEPROMA";
            this.btnMemReadEEPROMA.UseVisualStyleBackColor = true;
            this.btnMemReadEEPROMA.Click += new EventHandler(this.btnFRMRReadEEPROM_Click);
            manager.ApplyResources(this.btnMemWriteFlash, "btnMemWriteFlash");
            this.btnMemWriteFlash.Name = "btnMemWriteFlash";
            this.btnMemWriteFlash.UseVisualStyleBackColor = true;
            this.btnMemWriteFlash.Click += new EventHandler(this.btnFRMRWriteFlash_Click);
            manager.ApplyResources(this.btnMemReadFlash, "btnMemReadFlash");
            this.btnMemReadFlash.Name = "btnMemReadFlash";
            this.btnMemReadFlash.UseVisualStyleBackColor = true;
            this.btnMemReadFlash.Click += new EventHandler(this.btnFRMRReadFlash_Click);
            manager.ApplyResources(this.lblMemInfo, "lblMemInfo");
            this.lblMemInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMemInfo.Name = "lblMemInfo";
            manager.ApplyResources(this.lblMemWarning, "lblMemWarning");
            System.Drawing.Color red = System.Drawing.Color.Red;
            this.lblMemWarning.ForeColor = red;
            this.lblMemWarning.Name = "lblMemWarning";
            manager.ApplyResources(this.btnMemAnalyse, "btnMemAnalyse");
            this.btnMemAnalyse.Name = "btnMemAnalyse";
            this.btnMemAnalyse.UseVisualStyleBackColor = true;
            this.btnMemAnalyse.Click += new EventHandler(this.btnFRMRMemAnalyse_Click);
            manager.ApplyResources(this.shapeContainer10, "shapeContainer10");
            this.shapeContainer10.Name = "shapeContainer10";
            Shape[] shapeArray = new Shape[] { this.lineShape18, this.lineShape17, this.lineShape16 };
            this.shapeContainer10.Shapes.AddRange(shapeArray);
            this.shapeContainer10.TabStop = false;
            manager.ApplyResources(this.lineShape18, "lineShape18");
            this.lineShape18.Name = "lineShape18";
            manager.ApplyResources(this.lineShape17, "lineShape17");
            this.lineShape17.Name = "lineShape17";
            manager.ApplyResources(this.lineShape16, "lineShape16");
            this.lineShape16.Name = "lineShape16";
            this.tabLearnKeys.Controls.Add(this.lblKeysOperation);
            this.tabLearnKeys.Controls.Add(this.cbxKeysOperation);
            this.tabLearnKeys.Controls.Add(this.btnKeysRunOperation);
            this.tabLearnKeys.Controls.Add(this.btnGetKeysInfo);
            this.tabLearnKeys.Controls.Add(this.lblKeysInfo);
            this.tabLearnKeys.Controls.Add(this.btnEraseAddKey);
            this.tabLearnKeys.Controls.Add(this.btnAddKey);
            this.tabLearnKeys.Controls.Add(this.lblKeysWarning);
            this.tabLearnKeys.Controls.Add(this.shapeContainer7);
            manager.ApplyResources(this.tabLearnKeys, "tabLearnKeys");
            this.tabLearnKeys.Name = "tabLearnKeys";
            this.tabLearnKeys.UseVisualStyleBackColor = true;
            manager.ApplyResources(this.lblKeysOperation, "lblKeysOperation");
            this.lblKeysOperation.Name = "lblKeysOperation";
            this.cbxKeysOperation.DropDownStyle = ComboBoxStyle.DropDownList;
            manager.ApplyResources(this.cbxKeysOperation, "cbxKeysOperation");
            this.cbxKeysOperation.FormattingEnabled = true;
            this.cbxKeysOperation.Name = "cbxKeysOperation";
            this.cbxKeysOperation.SelectedIndexChanged += new EventHandler(this.cbxKeysOperation_SelectedIndexChanged);
            manager.ApplyResources(this.btnKeysRunOperation, "btnKeysRunOperation");
            this.btnKeysRunOperation.Name = "btnKeysRunOperation";
            this.btnKeysRunOperation.UseVisualStyleBackColor = true;
            this.btnKeysRunOperation.Click += new EventHandler(this.btnKeysRunOperation_Click);
            manager.ApplyResources(this.btnGetKeysInfo, "btnGetKeysInfo");
            this.btnGetKeysInfo.Name = "btnGetKeysInfo";
            this.btnGetKeysInfo.UseVisualStyleBackColor = true;
            this.btnGetKeysInfo.Click += new EventHandler(this.btnGetKeysInfo_Click);
            manager.ApplyResources(this.lblKeysInfo, "lblKeysInfo");
            this.lblKeysInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeysInfo.Name = "lblKeysInfo";
            manager.ApplyResources(this.btnEraseAddKey, "btnEraseAddKey");
            this.btnEraseAddKey.Name = "btnEraseAddKey";
            this.btnEraseAddKey.UseVisualStyleBackColor = true;
            this.btnEraseAddKey.Click += new EventHandler(this.btnAddKey_Click);
            manager.ApplyResources(this.btnAddKey, "btnAddKey");
            this.btnAddKey.Name = "btnAddKey";
            this.btnAddKey.UseVisualStyleBackColor = true;
            this.btnAddKey.Click += new EventHandler(this.btnAddKey_Click);
            manager.ApplyResources(this.lblKeysWarning, "lblKeysWarning");
            this.lblKeysWarning.Name = "lblKeysWarning";
            manager.ApplyResources(this.shapeContainer7, "shapeContainer7");
            this.shapeContainer7.Name = "shapeContainer7";
            Shape[] shapeArray3 = new Shape[] { this.lineShape12, this.lineShape9 };
            this.shapeContainer7.Shapes.AddRange(shapeArray3);
            this.shapeContainer7.TabStop = false;
            manager.ApplyResources(this.lineShape12, "lineShape12");
            this.lineShape12.Name = "lineShape12";
            manager.ApplyResources(this.lineShape9, "lineShape9");
            this.lineShape9.Name = "lineShape9";
            this.tabVeDocCalc.Controls.Add(this.pictureBox1);
            this.tabVeDocCalc.Controls.Add(this.edVeDocResult);
            this.tabVeDocCalc.Controls.Add(this.edVeDocNumOfKeys);
            this.tabVeDocCalc.Controls.Add(this.label11);
            this.tabVeDocCalc.Controls.Add(this.edVeDocVIN);
            this.tabVeDocCalc.Controls.Add(this.label10);
            this.tabVeDocCalc.Controls.Add(this.label9);
            this.tabVeDocCalc.Controls.Add(this.edVeDocTransponderCode);
            this.tabVeDocCalc.Controls.Add(this.label6);
            this.tabVeDocCalc.Controls.Add(this.edVeDocID);
            this.tabVeDocCalc.Controls.Add(this.label5);
            this.tabVeDocCalc.Controls.Add(this.label12);
            this.tabVeDocCalc.Controls.Add(this.cbxVeDocCalcType);
            this.tabVeDocCalc.Controls.Add(this.edVeDocRnd);
            this.tabVeDocCalc.Controls.Add(this.btnVeDocCalculate);
            this.tabVeDocCalc.Controls.Add(this.btnVeDocPrepare);
            this.tabVeDocCalc.Controls.Add(this.label3);
            this.tabVeDocCalc.Controls.Add(this.shapeContainer3);
            manager.ApplyResources(this.tabVeDocCalc, "tabVeDocCalc");
            this.tabVeDocCalc.Name = "tabVeDocCalc";
            this.tabVeDocCalc.UseVisualStyleBackColor = true;
            manager.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            System.Drawing.Color control = SystemColors.Control;
            this.edVeDocResult.BackColor = control;
            manager.ApplyResources(this.edVeDocResult, "edVeDocResult");
            this.edVeDocResult.Name = "edVeDocResult";
            this.edVeDocResult.ReadOnly = true;
            System.Drawing.Color color24 = SystemColors.Control;
            this.edVeDocNumOfKeys.BackColor = color24;
            manager.ApplyResources(this.edVeDocNumOfKeys, "edVeDocNumOfKeys");
            this.edVeDocNumOfKeys.Name = "edVeDocNumOfKeys";
            this.edVeDocNumOfKeys.ReadOnly = true;
            manager.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            System.Drawing.Color color23 = SystemColors.Control;
            this.edVeDocVIN.BackColor = color23;
            manager.ApplyResources(this.edVeDocVIN, "edVeDocVIN");
            this.edVeDocVIN.Name = "edVeDocVIN";
            this.edVeDocVIN.ReadOnly = true;
            manager.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            manager.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            System.Drawing.Color color22 = SystemColors.Control;
            this.edVeDocTransponderCode.BackColor = color22;
            manager.ApplyResources(this.edVeDocTransponderCode, "edVeDocTransponderCode");
            this.edVeDocTransponderCode.Name = "edVeDocTransponderCode";
            this.edVeDocTransponderCode.ReadOnly = true;
            manager.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            System.Drawing.Color color21 = SystemColors.Control;
            this.edVeDocID.BackColor = color21;
            manager.ApplyResources(this.edVeDocID, "edVeDocID");
            this.edVeDocID.Name = "edVeDocID";
            this.edVeDocID.ReadOnly = true;
            manager.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            manager.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            this.cbxVeDocCalcType.DropDownStyle = ComboBoxStyle.DropDownList;
            manager.ApplyResources(this.cbxVeDocCalcType, "cbxVeDocCalcType");
            this.cbxVeDocCalcType.FormattingEnabled = true;
            this.cbxVeDocCalcType.Name = "cbxVeDocCalcType";
            this.cbxVeDocCalcType.SelectedIndexChanged += new EventHandler(this.cbxVeDocCalcType_SelectedIndexChanged);
            System.Drawing.Color color20 = SystemColors.Control;
            this.edVeDocRnd.BackColor = color20;
            manager.ApplyResources(this.edVeDocRnd, "edVeDocRnd");
            this.edVeDocRnd.Name = "edVeDocRnd";
            this.edVeDocRnd.ReadOnly = true;
            manager.ApplyResources(this.btnVeDocCalculate, "btnVeDocCalculate");
            this.btnVeDocCalculate.Name = "btnVeDocCalculate";
            this.btnVeDocCalculate.UseVisualStyleBackColor = true;
            this.btnVeDocCalculate.Click += new EventHandler(this.btnVeDocCalculate_Click);
            manager.ApplyResources(this.btnVeDocPrepare, "btnVeDocPrepare");
            this.btnVeDocPrepare.Name = "btnVeDocPrepare";
            this.btnVeDocPrepare.UseVisualStyleBackColor = true;
            this.btnVeDocPrepare.Click += new EventHandler(this.btnVeDocPrepare_Click);
            manager.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            manager.ApplyResources(this.shapeContainer3, "shapeContainer3");
            this.shapeContainer3.Name = "shapeContainer3";
            Shape[] shapeArray2 = new Shape[] { this.lineShape5, this.lineShape4 };
            this.shapeContainer3.Shapes.AddRange(shapeArray2);
            this.shapeContainer3.TabStop = false;
            manager.ApplyResources(this.lineShape5, "lineShape5");
            this.lineShape5.Name = "lineShape5";
            manager.ApplyResources(this.lineShape4, "lineShape4");
            this.lineShape4.Name = "lineShape4";
            this.tabFDOKCalc.Controls.Add(this.label21);
            this.tabFDOKCalc.Controls.Add(this.label19);
            this.tabFDOKCalc.Controls.Add(this.edFDOKNewResult);
            this.tabFDOKCalc.Controls.Add(this.maskedFDOKID);
            this.tabFDOKCalc.Controls.Add(this.label13);
            this.tabFDOKCalc.Controls.Add(this.maskedFDOKRnd);
            this.tabFDOKCalc.Controls.Add(this.edFDOKOldResult);
            this.tabFDOKCalc.Controls.Add(this.label2);
            this.tabFDOKCalc.Controls.Add(this.label7);
            this.tabFDOKCalc.Controls.Add(this.label8);
            this.tabFDOKCalc.Controls.Add(this.cbxFDOKCalcType);
            this.tabFDOKCalc.Controls.Add(this.btnFDOKCalculate);
            this.tabFDOKCalc.Controls.Add(this.shapeContainer4);
            manager.ApplyResources(this.tabFDOKCalc, "tabFDOKCalc");
            this.tabFDOKCalc.Name = "tabFDOKCalc";
            this.tabFDOKCalc.UseVisualStyleBackColor = true;
            manager.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            manager.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            System.Drawing.Color color19 = SystemColors.Control;
            this.edFDOKNewResult.BackColor = color19;
            manager.ApplyResources(this.edFDOKNewResult, "edFDOKNewResult");
            this.edFDOKNewResult.Name = "edFDOKNewResult";
            this.edFDOKNewResult.ReadOnly = true;
            this.maskedFDOKID.Culture = new CultureInfo("");
            this.maskedFDOKID.HidePromptOnLeave = true;
            manager.ApplyResources(this.maskedFDOKID, "maskedFDOKID");
            this.maskedFDOKID.Name = "maskedFDOKID";
            this.maskedFDOKID.TextChanged += new EventHandler(this.maskedFDOKID_TextChanged);
            manager.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            this.maskedFDOKRnd.Culture = new CultureInfo("");
            this.maskedFDOKRnd.HidePromptOnLeave = true;
            manager.ApplyResources(this.maskedFDOKRnd, "maskedFDOKRnd");
            this.maskedFDOKRnd.Name = "maskedFDOKRnd";
            this.maskedFDOKRnd.TextChanged += new EventHandler(this.maskedFDOKRnd_TextChanged);
            System.Drawing.Color color18 = SystemColors.Control;
            this.edFDOKOldResult.BackColor = color18;
            manager.ApplyResources(this.edFDOKOldResult, "edFDOKOldResult");
            this.edFDOKOldResult.Name = "edFDOKOldResult";
            this.edFDOKOldResult.ReadOnly = true;
            manager.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            manager.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            manager.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            this.cbxFDOKCalcType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbxFDOKCalcType.FormattingEnabled = true;
            object[] items = new object[] { manager.GetString("cbxFDOKCalcType.Items"), manager.GetString("cbxFDOKCalcType.Items1") };
            this.cbxFDOKCalcType.Items.AddRange(items);
            manager.ApplyResources(this.cbxFDOKCalcType, "cbxFDOKCalcType");
            this.cbxFDOKCalcType.Name = "cbxFDOKCalcType";
            this.cbxFDOKCalcType.SelectedIndexChanged += new EventHandler(this.cbxFDOKCalcType_SelectedIndexChanged);
            manager.ApplyResources(this.btnFDOKCalculate, "btnFDOKCalculate");
            this.btnFDOKCalculate.Name = "btnFDOKCalculate";
            this.btnFDOKCalculate.UseVisualStyleBackColor = true;
            this.btnFDOKCalculate.Click += new EventHandler(this.btnFDOKCalculate_Click);
            manager.ApplyResources(this.shapeContainer4, "shapeContainer4");
            this.shapeContainer4.Name = "shapeContainer4";
            Shape[] shapeArray6 = new Shape[] { this.lineShape6 };
            this.shapeContainer4.Shapes.AddRange(shapeArray6);
            this.shapeContainer4.TabStop = false;
            manager.ApplyResources(this.lineShape6, "lineShape6");
            this.lineShape6.Name = "lineShape6";
            this.tabDASPwdCalc.Controls.Add(this.label14);
            this.tabDASPwdCalc.Controls.Add(this.edDASPwd);
            this.tabDASPwdCalc.Controls.Add(this.label15);
            this.tabDASPwdCalc.Controls.Add(this.cbxDASPwdType);
            this.tabDASPwdCalc.Controls.Add(this.btnDASPwdCalc);
            this.tabDASPwdCalc.Controls.Add(this.shapeContainer5);
            manager.ApplyResources(this.tabDASPwdCalc, "tabDASPwdCalc");
            this.tabDASPwdCalc.Name = "tabDASPwdCalc";
            this.tabDASPwdCalc.UseVisualStyleBackColor = true;
            manager.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            System.Drawing.Color color17 = SystemColors.Control;
            this.edDASPwd.BackColor = color17;
            manager.ApplyResources(this.edDASPwd, "edDASPwd");
            this.edDASPwd.Name = "edDASPwd";
            this.edDASPwd.ReadOnly = true;
            manager.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            this.cbxDASPwdType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbxDASPwdType.FormattingEnabled = true;
            manager.ApplyResources(this.cbxDASPwdType, "cbxDASPwdType");
            this.cbxDASPwdType.Name = "cbxDASPwdType";
            this.cbxDASPwdType.SelectedIndexChanged += new EventHandler(this.cbxDASPwdType_SelectedIndexChanged);
            manager.ApplyResources(this.btnDASPwdCalc, "btnDASPwdCalc");
            this.btnDASPwdCalc.Name = "btnDASPwdCalc";
            this.btnDASPwdCalc.UseVisualStyleBackColor = true;
            this.btnDASPwdCalc.Click += new EventHandler(this.btnDASPwdCalc_Click);
            manager.ApplyResources(this.shapeContainer5, "shapeContainer5");
            this.shapeContainer5.Name = "shapeContainer5";
            Shape[] shapeArray5 = new Shape[] { this.lineShape7 };
            this.shapeContainer5.Shapes.AddRange(shapeArray5);
            this.shapeContainer5.TabStop = false;
            manager.ApplyResources(this.lineShape7, "lineShape7");
            this.lineShape7.Name = "lineShape7";
            this.tabExtra.Controls.Add(this.cbxExtraOperationParameter);
            this.tabExtra.Controls.Add(this.edExtraOperationParameter);
            this.tabExtra.Controls.Add(this.lblExtraOperationParameter);
            this.tabExtra.Controls.Add(this.lblExtraOperation);
            this.tabExtra.Controls.Add(this.cbxExtraOperation);
            this.tabExtra.Controls.Add(this.btnExtraRunOperation);
            this.tabExtra.Controls.Add(this.lblExtraWarning);
            manager.ApplyResources(this.tabExtra, "tabExtra");
            this.tabExtra.Name = "tabExtra";
            this.tabExtra.UseVisualStyleBackColor = true;
            this.cbxExtraOperationParameter.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbxExtraOperationParameter.FormattingEnabled = true;
            manager.ApplyResources(this.cbxExtraOperationParameter, "cbxExtraOperationParameter");
            this.cbxExtraOperationParameter.Name = "cbxExtraOperationParameter";
            this.cbxExtraOperationParameter.SelectedIndexChanged += new EventHandler(this.cbxExtraOperationParameter_SelectedIndexChanged);
            System.Drawing.Color window = SystemColors.Window;
            this.edExtraOperationParameter.BackColor = window;
            manager.ApplyResources(this.edExtraOperationParameter, "edExtraOperationParameter");
            this.edExtraOperationParameter.Name = "edExtraOperationParameter";
            manager.ApplyResources(this.lblExtraOperationParameter, "lblExtraOperationParameter");
            this.lblExtraOperationParameter.Name = "lblExtraOperationParameter";
            manager.ApplyResources(this.lblExtraOperation, "lblExtraOperation");
            this.lblExtraOperation.Name = "lblExtraOperation";
            this.cbxExtraOperation.DropDownStyle = ComboBoxStyle.DropDownList;
            manager.ApplyResources(this.cbxExtraOperation, "cbxExtraOperation");
            this.cbxExtraOperation.FormattingEnabled = true;
            this.cbxExtraOperation.Name = "cbxExtraOperation";
            this.cbxExtraOperation.SelectedIndexChanged += new EventHandler(this.cbxExtraOperation_SelectedIndexChanged);
            manager.ApplyResources(this.btnExtraRunOperation, "btnExtraRunOperation");
            this.btnExtraRunOperation.Name = "btnExtraRunOperation";
            this.btnExtraRunOperation.UseVisualStyleBackColor = true;
            this.btnExtraRunOperation.Click += new EventHandler(this.btnExtraRunOperation_Click);
            manager.ApplyResources(this.lblExtraWarning, "lblExtraWarning");
            System.Drawing.Color color15 = System.Drawing.Color.Red;
            this.lblExtraWarning.ForeColor = color15;
            this.lblExtraWarning.Name = "lblExtraWarning";
            this.tabFaultCodes.Controls.Add(this.btnGenerateFullFaultsReport);
            this.tabFaultCodes.Controls.Add(this.pnlFaultCodes);
            this.tabFaultCodes.Controls.Add(this.btnEraseFaultCodes);
            this.tabFaultCodes.Controls.Add(this.btnReadFaultCodes);
            this.tabFaultCodes.Controls.Add(this.cbxDetectedECUs);
            this.tabFaultCodes.Controls.Add(this.btnDetectECUs);
            manager.ApplyResources(this.tabFaultCodes, "tabFaultCodes");
            this.tabFaultCodes.Name = "tabFaultCodes";
            this.tabFaultCodes.UseVisualStyleBackColor = true;
            manager.ApplyResources(this.btnGenerateFullFaultsReport, "btnGenerateFullFaultsReport");
            this.btnGenerateFullFaultsReport.Name = "btnGenerateFullFaultsReport";
            this.btnGenerateFullFaultsReport.UseVisualStyleBackColor = true;
            this.btnGenerateFullFaultsReport.Click += new EventHandler(this.btnGenerateFullFaultCodesReport_Click);
            manager.ApplyResources(this.pnlFaultCodes, "pnlFaultCodes");
            this.pnlFaultCodes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFaultCodes.Controls.Add(this.gridFaultCodes);
            this.pnlFaultCodes.Name = "pnlFaultCodes";
            this.gridFaultCodes.AllowUserToAddRows = false;
            this.gridFaultCodes.AllowUserToDeleteRows = false;
            this.gridFaultCodes.AllowUserToResizeColumns = false;
            this.gridFaultCodes.AllowUserToResizeRows = false;
            this.gridFaultCodes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.gridFaultCodes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            System.Drawing.Color color14 = SystemColors.Control;
            this.gridFaultCodes.BackgroundColor = color14;
            style3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            System.Drawing.Color color13 = SystemColors.Control;
            style3.BackColor = color13;
            style3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xcc);
            System.Drawing.Color windowText = SystemColors.WindowText;
            style3.ForeColor = windowText;
            System.Drawing.Color color11 = SystemColors.Control;
            style3.SelectionBackColor = color11;
            System.Drawing.Color color10 = SystemColors.WindowText;
            style3.SelectionForeColor = color10;
            style3.WrapMode = DataGridViewTriState.True;
            this.gridFaultCodes.ColumnHeadersDefaultCellStyle = style3;
            this.gridFaultCodes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[] { this.clmnCode2, this.clmnDescription2 };
            this.gridFaultCodes.Columns.AddRange(dataGridViewColumns);
            style2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            System.Drawing.Color color9 = SystemColors.Window;
            style2.BackColor = color9;
            style2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xcc);
            System.Drawing.Color controlText = SystemColors.ControlText;
            style2.ForeColor = controlText;
            System.Drawing.Color color7 = SystemColors.Window;
            style2.SelectionBackColor = color7;
            System.Drawing.Color color6 = SystemColors.ControlText;
            style2.SelectionForeColor = color6;
            style2.WrapMode = DataGridViewTriState.True;
            this.gridFaultCodes.DefaultCellStyle = style2;
            manager.ApplyResources(this.gridFaultCodes, "gridFaultCodes");
            this.gridFaultCodes.MultiSelect = false;
            this.gridFaultCodes.Name = "gridFaultCodes";
            this.gridFaultCodes.ReadOnly = true;
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            System.Drawing.Color color5 = SystemColors.Control;
            style.BackColor = color5;
            style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xcc);
            System.Drawing.Color color4 = SystemColors.WindowText;
            style.ForeColor = color4;
            System.Drawing.Color color3 = SystemColors.Control;
            style.SelectionBackColor = color3;
            System.Drawing.Color color2 = SystemColors.WindowText;
            style.SelectionForeColor = color2;
            style.WrapMode = DataGridViewTriState.True;
            this.gridFaultCodes.RowHeadersDefaultCellStyle = style;
            this.gridFaultCodes.RowHeadersVisible = false;
            this.gridFaultCodes.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.clmnCode2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            manager.ApplyResources(this.clmnCode2, "clmnCode2");
            this.clmnCode2.Name = "clmnCode2";
            this.clmnCode2.ReadOnly = true;
            this.clmnCode2.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.clmnDescription2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            style4.WrapMode = DataGridViewTriState.True;
            this.clmnDescription2.DefaultCellStyle = style4;
            manager.ApplyResources(this.clmnDescription2, "clmnDescription2");
            this.clmnDescription2.Name = "clmnDescription2";
            this.clmnDescription2.ReadOnly = true;
            this.clmnDescription2.SortMode = DataGridViewColumnSortMode.NotSortable;
            manager.ApplyResources(this.btnEraseFaultCodes, "btnEraseFaultCodes");
            this.btnEraseFaultCodes.Name = "btnEraseFaultCodes";
            this.btnEraseFaultCodes.UseVisualStyleBackColor = true;
            this.btnEraseFaultCodes.Click += new EventHandler(this.btnEraseFaultCodes_Click);
            manager.ApplyResources(this.btnReadFaultCodes, "btnReadFaultCodes");
            this.btnReadFaultCodes.Name = "btnReadFaultCodes";
            this.btnReadFaultCodes.UseVisualStyleBackColor = true;
            this.btnReadFaultCodes.Click += new EventHandler(this.btnReadFaultCodes_Click);
            this.cbxDetectedECUs.DropDownStyle = ComboBoxStyle.DropDownList;
            manager.ApplyResources(this.cbxDetectedECUs, "cbxDetectedECUs");
            this.cbxDetectedECUs.FormattingEnabled = true;
            this.cbxDetectedECUs.Name = "cbxDetectedECUs";
            this.cbxDetectedECUs.SelectedIndexChanged += new EventHandler(this.cbxDetectedECUs_SelectedIndexChanged);
            manager.ApplyResources(this.btnDetectECUs, "btnDetectECUs");
            this.btnDetectECUs.Name = "btnDetectECUs";
            this.btnDetectECUs.UseVisualStyleBackColor = true;
            this.btnDetectECUs.Click += new EventHandler(this.btnDetectECUs_Click);
            this.tabSettings.Controls.Add(this.cbxSystemVoltage);
            this.tabSettings.Controls.Add(this.lblSystemVoltage);
            this.tabSettings.Controls.Add(this.pnlAbout);
            this.tabSettings.Controls.Add(this.cbxLanguage);
            this.tabSettings.Controls.Add(this.label18);
            this.tabSettings.Controls.Add(this.btnUpdateSoftware);
            this.tabSettings.Controls.Add(this.btnReadDeviceInfo);
            this.tabSettings.Controls.Add(this.lblDeviceInfo);
            this.tabSettings.Controls.Add(this.btnUpdateDevice);
            this.tabSettings.Controls.Add(this.shapeContainer8);
            manager.ApplyResources(this.tabSettings, "tabSettings");
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.UseVisualStyleBackColor = true;
            this.cbxSystemVoltage.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbxSystemVoltage.FormattingEnabled = true;
            object[] objArray = new object[] { manager.GetString("cbxSystemVoltage.Items"), manager.GetString("cbxSystemVoltage.Items1") };
            this.cbxSystemVoltage.Items.AddRange(objArray);
            manager.ApplyResources(this.cbxSystemVoltage, "cbxSystemVoltage");
            this.cbxSystemVoltage.Name = "cbxSystemVoltage";
            this.cbxSystemVoltage.SelectedIndexChanged += new EventHandler(this.cbxSystemVoltage_SelectedIndexChanged);
            manager.ApplyResources(this.lblSystemVoltage, "lblSystemVoltage");
            this.lblSystemVoltage.Name = "lblSystemVoltage";
            manager.ApplyResources(this.pnlAbout, "pnlAbout");
            this.pnlAbout.Controls.Add(this.lnkAboutRegistration);
            this.pnlAbout.Controls.Add(this.lnkAboutSupport);
            this.pnlAbout.Controls.Add(this.lnkAboutHomepage);
            this.pnlAbout.Controls.Add(this.lblAboutCopyright);
            this.pnlAbout.Controls.Add(this.lblAboutVersion);
            this.pnlAbout.Name = "pnlAbout";
            manager.ApplyResources(this.lnkAboutRegistration, "lnkAboutRegistration");
            this.lnkAboutRegistration.Name = "lnkAboutRegistration";
            this.lnkAboutRegistration.TabStop = true;
            this.lnkAboutRegistration.UseCompatibleTextRendering = true;
            this.lnkAboutRegistration.LinkClicked += new LinkLabelLinkClickedEventHandler(this.lnkAboutRegistration_LinkClicked);
            manager.ApplyResources(this.lnkAboutSupport, "lnkAboutSupport");
            this.lnkAboutSupport.Name = "lnkAboutSupport";
            this.lnkAboutSupport.TabStop = true;
            this.lnkAboutSupport.UseCompatibleTextRendering = true;
            this.lnkAboutSupport.LinkClicked += new LinkLabelLinkClickedEventHandler(this.lnkAboutSupport_LinkClicked);
            manager.ApplyResources(this.lnkAboutHomepage, "lnkAboutHomepage");
            this.lnkAboutHomepage.Name = "lnkAboutHomepage";
            this.lnkAboutHomepage.TabStop = true;
            this.lnkAboutHomepage.UseCompatibleTextRendering = true;
            this.lnkAboutHomepage.LinkClicked += new LinkLabelLinkClickedEventHandler(this.lnkAboutHomepage_LinkClicked);
            manager.ApplyResources(this.lblAboutCopyright, "lblAboutCopyright");
            this.lblAboutCopyright.Name = "lblAboutCopyright";
            manager.ApplyResources(this.lblAboutVersion, "lblAboutVersion");
            this.lblAboutVersion.Name = "lblAboutVersion";
            this.cbxLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbxLanguage.FormattingEnabled = true;
            manager.ApplyResources(this.cbxLanguage, "cbxLanguage");
            this.cbxLanguage.Name = "cbxLanguage";
            this.cbxLanguage.SelectedIndexChanged += new EventHandler(this.cbxLanguage_SelectedIndexChanged);
            manager.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            manager.ApplyResources(this.btnUpdateSoftware, "btnUpdateSoftware");
            this.btnUpdateSoftware.Name = "btnUpdateSoftware";
            this.btnUpdateSoftware.UseVisualStyleBackColor = true;
            this.btnUpdateSoftware.Click += new EventHandler(this.btnUpdateSoftware_Click);
            manager.ApplyResources(this.btnReadDeviceInfo, "btnReadDeviceInfo");
            this.btnReadDeviceInfo.Name = "btnReadDeviceInfo";
            this.btnReadDeviceInfo.UseVisualStyleBackColor = true;
            this.btnReadDeviceInfo.Click += new EventHandler(this.btnReadDeviceInfo_Click);
            this.lblDeviceInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            manager.ApplyResources(this.lblDeviceInfo, "lblDeviceInfo");
            this.lblDeviceInfo.Name = "lblDeviceInfo";
            manager.ApplyResources(this.btnUpdateDevice, "btnUpdateDevice");
            this.btnUpdateDevice.Name = "btnUpdateDevice";
            this.btnUpdateDevice.UseVisualStyleBackColor = true;
            this.btnUpdateDevice.Click += new EventHandler(this.btnUpdateDevice_Click);
            manager.ApplyResources(this.shapeContainer8, "shapeContainer8");
            this.shapeContainer8.Name = "shapeContainer8";
            Shape[] shapeArray4 = new Shape[] { this.lineShape10 };
            this.shapeContainer8.Shapes.AddRange(shapeArray4);
            this.shapeContainer8.TabStop = false;
            manager.ApplyResources(this.lineShape10, "lineShape10");
            this.lineShape10.Name = "lineShape10";
            manager.ApplyResources(this.lineShape3, "lineShape3");
            this.lineShape3.Name = "lineShape3";
            manager.ApplyResources(this.lineShape2, "lineShape2");
            this.lineShape2.Name = "lineShape2";
            manager.ApplyResources(this.lineShape11, "lineShape11");
            this.lineShape11.Name = "lineShape11";
            manager.ApplyResources(this.btnDisconnect, "btnDisconnect");
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new EventHandler(this.btnDisconnect_Click);
            manager.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.Name = "btnExit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            manager.ApplyResources(this.btnConnect, "btnConnect");
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new EventHandler(this.btnConnect_Click);
            ToolStripItem[] toolStripItems = new ToolStripItem[] { this.lblCurrentVEIInfo, this.toolStripStatusLabel1, this.pbarProgress };
            this.strStatus.Items.AddRange(toolStripItems);
            manager.ApplyResources(this.strStatus, "strStatus");
            this.strStatus.Name = "strStatus";
            this.strStatus.SizingGrip = false;
            manager.ApplyResources(this.lblCurrentVEIInfo, "lblCurrentVEIInfo");
            Padding padding = new Padding(10, 3, 0, 2);
            this.lblCurrentVEIInfo.Margin = padding;
            this.lblCurrentVEIInfo.Name = "lblCurrentVEIInfo";
            manager.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.pbarProgress.Name = "pbarProgress";
            manager.ApplyResources(this.pbarProgress, "pbarProgress");
            this.pbarProgress.Style = ProgressBarStyle.Marquee;
            this.dlgSaveFile.DefaultExt = "bin";
            manager.ApplyResources(this.dlgSaveFile, "dlgSaveFile");
            this.dlgOpenFile.DefaultExt = "bin";
            manager.ApplyResources(this.dlgOpenFile, "dlgOpenFile");
            this.imglstTrucks.ImageStream = (ImageListStreamer) manager.GetObject("imglstTrucks.ImageStream");
            System.Drawing.Color transparent = System.Drawing.Color.Transparent;
            this.imglstTrucks.TransparentColor = transparent;
            this.imglstTrucks.Images.SetKeyName(0, "MB_toy_gray.png");
            this.imglstTrucks.Images.SetKeyName(1, "MB_toy.png");
            this.imglstTrucks.Images.SetKeyName(2, "MAN_toy_gray.png");
            this.imglstTrucks.Images.SetKeyName(3, "MAN_toy.png");
            this.imglstTrucks.Images.SetKeyName(4, "checkengine_gray.png");
            this.imglstTrucks.Images.SetKeyName(5, "checkengine.png");
            manager.ApplyResources(this, "$this");
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.strStatus);
            base.Controls.Add(this.btnDisconnect);
            base.Controls.Add(this.btnExit);
            base.Controls.Add(this.btnConnect);
            base.Controls.Add(this.tabctlActions);
            base.Controls.Add(this.gbxInformation);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.Name = "MainForm";
            base.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
            base.Shown += new EventHandler(this.MainForm_Shown);
            this.gbxInformation.ResumeLayout(false);
            this.gbxInformation.PerformLayout();
            ((ISupportInitialize) this.imgCar).EndInit();
            this.tabctlActions.ResumeLayout(false);
            this.tabMemory.ResumeLayout(false);
            this.tabLearnKeys.ResumeLayout(false);
            this.tabVeDocCalc.ResumeLayout(false);
            this.tabVeDocCalc.PerformLayout();
            ((ISupportInitialize) this.pictureBox1).EndInit();
            this.tabFDOKCalc.ResumeLayout(false);
            this.tabFDOKCalc.PerformLayout();
            this.tabDASPwdCalc.ResumeLayout(false);
            this.tabDASPwdCalc.PerformLayout();
            this.tabExtra.ResumeLayout(false);
            this.tabExtra.PerformLayout();
            this.tabFaultCodes.ResumeLayout(false);
            this.pnlFaultCodes.ResumeLayout(false);
            ((ISupportInitialize) this.gridFaultCodes).EndInit();
            this.tabSettings.ResumeLayout(false);
            this.pnlAbout.ResumeLayout(false);
            this.strStatus.ResumeLayout(false);
            this.strStatus.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        [return: MarshalAs(UnmanagedType.U1)]
        private unsafe bool IsCurrentTruckTypeValid()
        {
            TruckType_t truckType = this.m_TruckType;
            if (*(((int*) &truckType)) == 0)
            {
                return this.m_MBEnabled;
            }
            if (*(((int*) &truckType)) == 1)
            {
                return this.m_MANEnabled;
            }
            if (*(((int*) &truckType)) != 2)
            {
                CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0x101d, true, null);
                return false;
            }
            return this.m_EngineEnabled;
        }

        private unsafe void KeysUpdateOperationList()
        {
            this.cbxKeysOperation.Items.Clear();
            int num = 0;
            if (0 < this.m_KeysTab.m_OperationList.Count)
            {
                do
                {
                    switch (this.m_KeysTab.m_OperationList[num])
                    {
                        case KeysTab.Operation.MRImmoOff:
                            this.cbxKeysOperation.Items.Add(this.GetParamedLocalizedString("strECUXImmoOff", "MR"));
                            break;

                        case KeysTab.Operation.FRImmoOff:
                            this.cbxKeysOperation.Items.Add(this.GetParamedLocalizedString("strECUXImmoOff", "FR"));
                            break;

                        case KeysTab.Operation.FRImmoOn:
                            this.cbxKeysOperation.Items.Add(this.GetParamedLocalizedString("strECUXImmoOn", "FR"));
                            break;

                        case KeysTab.Operation.EDCFFRPairing:
                            this.cbxKeysOperation.Items.Add(string.Format(this.GetLocalizedString("strECUXYPairing"), "EDC", "FFR"));
                            break;

                        case KeysTab.Operation.EDCPTMPairing:
                            this.cbxKeysOperation.Items.Add(string.Format(this.GetLocalizedString("strECUXYPairing"), "EDC", "PTM"));
                            break;

                        default:
                            CustomAssert(&??_C@_0BC@DFLNDNFC@KeyLearnTasks?4cpp?$AA@, 0x20, true, null);
                            break;
                    }
                    num++;
                }
                while (num < this.m_KeysTab.m_OperationList.Count);
            }
            this.m_KeysTab.m_ActiveOperationIdx = 0;
            if (this.cbxKeysOperation.Items.Count == 0)
            {
                this.cbxKeysOperation.Enabled = false;
                this.btnKeysRunOperation.Enabled = false;
            }
            else
            {
                this.cbxKeysOperation.Enabled = true;
                this.cbxKeysOperation.SelectedIndex = this.m_MemoryTab.m_ActiveOperationIdx;
                this.btnKeysRunOperation.Enabled = true;
            }
        }

        private unsafe void lnkAboutHomepage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int num2 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            this.lnkAboutHomepage.LinkVisited = true;
            try
            {
                Process.Start("http://www.dielektrik.lt/mbex");
            }
            catch when (?)
            {
                uint num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
        }

        private unsafe void lnkAboutRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int num2 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                Process.Start("mailto:registration@dielektrik.com");
            }
            catch when (?)
            {
                uint num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
        }

        private unsafe void lnkAboutSupport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int num2 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                Process.Start("mailto:support@dielektrik.com");
            }
            catch when (?)
            {
                uint num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
        }

        private unsafe void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            uint num;
            int num2 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            e.Cancel = this.m_OperationRunning;
            if (e.Cancel)
            {
                return;
            }
            try
            {
                this.m_Settings.TruckType = this.m_TruckType.ToString();
                this.m_Settings.Save();
                if (this.m_IsDirectConnection)
                {
                    this.AddToLogThreadSafe("\r\n");
                    this.AddToLogThreadSafe(this.GetLocalizedString("strDisconnecting") + "... ");
                    this.AskForIgnition(false, this.GetLocalizedString("strDisconnect"), false);
                    this.AddToLogThreadSafe(this.GetLocalizedString("strdone"));
                    this.AddToLogThreadSafe("\r\n");
                }
            }
            catch (UserAborted)
            {
                this.ConnectFailedThreadSafe(this.GetLocalizedString("strUserAborted"));
            }
            catch (InvalidOBDPower)
            {
                this.ConnectFailedThreadSafe(this.GetLocalizedString("strInvalidOBDPower"));
            }
            catch (NoOBDPower)
            {
                this.ConnectFailedThreadSafe(this.GetLocalizedString("strNoOBDPower"));
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t;
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommError") + $" (code {((int) _t):X})!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommError") + $" (code {((int) _t):X})!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0x9b3, false, null);
                        goto Label_02A1;
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
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        goto Label_02A1;
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
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0x9c2, true, null);
                        goto Label_02A1;
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
            }
        Label_02A1:
            this.DisconnectThreadSafe();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            DateTime time = this.m_Settings.SoftwareUpdateLastCheckTime.AddDays((double) this.m_CheckSoftwareUpdatePeriodInDays);
            if (DateTime.Now > time)
            {
                this.m_AutomaticSoftwareUpdate = true;
                this.StartTask(new ThreadStart(this.SoftwareUpdateTask), this.GetLocalizedString("strCheckingForSoftwareUpdate"), this.GetLocalizedString("strUpdateSoftware"));
            }
        }

        private unsafe void MANReadKeysInfoOkThreadSafe()
        {
            if (this.InvokeRequired)
            {
                Action method = new Action(this.MANReadKeysInfoOkThreadSafe);
                base.Invoke(method);
            }
            else
            {
                this.StopOperation();
                this.AddToLogThreadSafe("\r\n");
                MANMainECU_t mANMainECU = this.m_MANMainECU;
                if (*(((int*) &mANMainECU)) != 1)
                {
                    if (*(((int*) &mANMainECU)) != 2)
                    {
                        CustomAssert(&??_C@_0BC@DFLNDNFC@KeyLearnTasks?4cpp?$AA@, 0x39d, true, null);
                    }
                    else
                    {
                        this.AddToLogThreadSafe(("  " + this.GetParamedLocalizedString("strECUXImmoStatus", "PTM") + ": ") + this.GetImmoStatusString(this.m_KeysTab.m_MANPTMImmoStatus) + "\r\n");
                        this.AddToLogThreadSafe("  " + this.GetLocalizedString("strNumberOfKeysProgrammed") + $": {this.m_KeysTab.m_NumberOfKeys}
");
                        this.AddToLogThreadSafe(("  " + this.GetLocalizedString("strKeyStatus") + ": ") + this.GetPTMKeyStatusString(this.m_KeysTab.m_MANPTMKeyStatus) + "\r\n");
                        this.lblKeysInfo.Text = (this.GetParamedLocalizedString("strECUXImmoStatus", "PTM") + ": ") + this.GetImmoStatusString(this.m_KeysTab.m_MANPTMImmoStatus) + "\r\n";
                        this.lblKeysInfo.Text = this.lblKeysInfo.Text + (this.GetLocalizedString("strNumberOfKeysProgrammed") + $": {this.m_KeysTab.m_NumberOfKeys}
");
                        this.lblKeysInfo.Text = this.lblKeysInfo.Text + (this.GetLocalizedString("strKeyStatus") + ": " + this.GetPTMKeyStatusString(this.m_KeysTab.m_MANPTMKeyStatus));
                    }
                }
                else
                {
                    this.AddToLogThreadSafe(("  " + this.GetParamedLocalizedString("strECUXImmoStatus", "FFR") + ": ") + this.GetImmoStatusString(this.m_KeysTab.m_MANFFRImmoStatus) + "\r\n");
                    this.AddToLogThreadSafe("  " + this.GetLocalizedString("strNumberOfKeysProgrammed") + $": {this.m_KeysTab.m_NumberOfKeys}
");
                    this.AddToLogThreadSafe(("  " + this.GetLocalizedString("strKeyStatus") + ": ") + this.GetFFRKeyStatusString(this.m_KeysTab.m_MANFFRKeyStatus) + "\r\n");
                    this.lblKeysInfo.Text = (this.GetParamedLocalizedString("strECUXImmoStatus", "FFR") + ": ") + this.GetImmoStatusString(this.m_KeysTab.m_MANFFRImmoStatus) + "\r\n";
                    this.lblKeysInfo.Text = this.lblKeysInfo.Text + (this.GetLocalizedString("strNumberOfKeysProgrammed") + $": {this.m_KeysTab.m_NumberOfKeys}
");
                    this.lblKeysInfo.Text = this.lblKeysInfo.Text + (this.GetLocalizedString("strKeyStatus") + ": " + this.GetFFRKeyStatusString(this.m_KeysTab.m_MANFFRKeyStatus));
                }
            }
        }

        private void maskedFDOKID_TextChanged(object sender, EventArgs e)
        {
            if (!this.maskedFDOKID.MaskFull)
            {
                this.m_FDOKIDValid = false;
            }
            else
            {
                this.m_FDOKID = 0;
                this.m_FDOKIDValid = true;
                char[] separator = new char[] { ' ' };
                string[] strArray = this.maskedFDOKID.Text.Split(separator);
                for (int i = strArray.Length - 1; i >= 0; i--)
                {
                    int num2;
                    if (!int.TryParse(strArray[i], NumberStyles.AllowHexSpecifier, null, out num2))
                    {
                        this.m_FDOKIDValid = false;
                        break;
                    }
                    this.m_FDOKID = (this.m_FDOKID << 8) | ((uint modopt(IsLong)) (num2 & 0xff));
                }
            }
            this.edFDOKOldResult.Clear();
            this.edFDOKOldResult.Enabled = false;
            this.edFDOKNewResult.Clear();
            this.edFDOKNewResult.Enabled = false;
            if ((this.m_FDOKRndValid && this.m_FDOKIDValid) && !string.IsNullOrEmpty(this.cbxFDOKCalcType.Text))
            {
                this.btnFDOKCalculate.Enabled = true;
            }
            else
            {
                this.btnFDOKCalculate.Enabled = false;
            }
        }

        private void maskedFDOKRnd_TextChanged(object sender, EventArgs e)
        {
            if (!this.maskedFDOKRnd.MaskFull)
            {
                this.m_FDOKRndValid = false;
            }
            else
            {
                this.m_FDOKRnd = 0;
                this.m_FDOKRndValid = true;
                char[] separator = new char[] { ' ' };
                string[] strArray = this.maskedFDOKRnd.Text.Split(separator);
                for (int i = strArray.Length - 1; i >= 0; i--)
                {
                    int num2;
                    if (!int.TryParse(strArray[i], NumberStyles.AllowHexSpecifier, null, out num2))
                    {
                        this.m_FDOKRndValid = false;
                        break;
                    }
                    this.m_FDOKRnd = (ushort) ((this.m_FDOKRnd << 8) | (num2 & 0xff));
                }
            }
            this.edFDOKOldResult.Clear();
            this.edFDOKOldResult.Enabled = false;
            this.edFDOKNewResult.Clear();
            this.edFDOKNewResult.Enabled = false;
            if ((this.m_FDOKRndValid && this.m_FDOKIDValid) && !string.IsNullOrEmpty(this.cbxFDOKCalcType.Text))
            {
                this.btnFDOKCalculate.Enabled = true;
            }
            else
            {
                this.btnFDOKCalculate.Enabled = false;
            }
        }

        private void MBReadKeysInfoOkThreadSafe()
        {
            if (this.InvokeRequired)
            {
                Action method = new Action(this.MBReadKeysInfoOkThreadSafe);
                base.Invoke(method);
            }
            else
            {
                this.StopOperation();
                this.AddToLogThreadSafe("\r\n");
                KeysTab keysTab = this.m_KeysTab;
                if (keysTab.m_MRInfoValid)
                {
                    this.AddToLogThreadSafe(("  " + this.GetParamedLocalizedString("strECUXImmoStatus", "MR") + ": ") + this.GetMRImmoStatusString(keysTab.m_MRImmoStatusCode) + "\r\n");
                    this.AddToLogThreadSafe("  " + this.GetLocalizedString("strNumberOfKeysProgrammed") + $": {this.m_KeysTab.m_NumberOfKeys}
");
                    this.AddToLogThreadSafe(("  " + this.GetLocalizedString("strKeyStatus") + ": ") + this.GetMRKeyStatusString(this.m_KeysTab.m_MRKeyStatusCode) + "\r\n");
                    this.lblKeysInfo.Text = (this.GetParamedLocalizedString("strECUXImmoStatus", "MR") + ": ") + this.GetMRImmoStatusString(this.m_KeysTab.m_MRImmoStatusCode) + "\r\n";
                    this.lblKeysInfo.Text = this.lblKeysInfo.Text + (this.GetLocalizedString("strNumberOfKeysProgrammed") + $": {this.m_KeysTab.m_NumberOfKeys}
");
                    this.lblKeysInfo.Text = this.lblKeysInfo.Text + (this.GetLocalizedString("strKeyStatus") + ": " + this.GetMRKeyStatusString(this.m_KeysTab.m_MRKeyStatusCode));
                    keysTab = this.m_KeysTab;
                    switch (keysTab.m_MRKeyStatusCode)
                    {
                        case 0:
                        case 11:
                            this.AddToLogThreadSafe("  " + this.GetLocalizedString("strTransponderCode") + $": {keysTab.m_MRTransponderCode[0]:X2} {this.m_KeysTab.m_MRTransponderCode[1]:X2} {this.m_KeysTab.m_MRTransponderCode[2]:X2} {this.m_KeysTab.m_MRTransponderCode[3]:X2} {this.m_KeysTab.m_MRTransponderCode[4]:X2}
");
                            this.lblKeysInfo.Text = this.lblKeysInfo.Text + "\r\n";
                            this.lblKeysInfo.Text = this.lblKeysInfo.Text + (this.GetLocalizedString("strTransponderCode") + $": {this.m_KeysTab.m_MRTransponderCode[0]:X2} {this.m_KeysTab.m_MRTransponderCode[1]:X2} {this.m_KeysTab.m_MRTransponderCode[2]:X2} {this.m_KeysTab.m_MRTransponderCode[3]:X2} {this.m_KeysTab.m_MRTransponderCode[4]:X2}");
                            break;
                    }
                }
                keysTab = this.m_KeysTab;
                if (keysTab.m_FRInfoValid)
                {
                    this.AddToLogThreadSafe(("  " + this.GetParamedLocalizedString("strECUXImmoStatus", "FR") + ": ") + this.GetFRImmoStatusString(keysTab.m_FRImmoStatus) + "\r\n");
                    this.AddToLogThreadSafe(("  " + this.GetLocalizedString("strFRKeyDetected") + ": ") + this.GetFRKeyDetectedString(this.m_KeysTab.m_FRKeyDetected) + "\r\n");
                    if (this.m_KeysTab.m_MRInfoValid)
                    {
                        this.lblKeysInfo.Text = this.lblKeysInfo.Text + "\r\n";
                    }
                    this.lblKeysInfo.Text = this.lblKeysInfo.Text + ((this.GetParamedLocalizedString("strECUXImmoStatus", "FR") + ": ") + this.GetFRImmoStatusString(this.m_KeysTab.m_FRImmoStatus) + "\r\n");
                    this.lblKeysInfo.Text = this.lblKeysInfo.Text + (this.GetLocalizedString("strFRKeyDetected") + ": " + this.GetFRKeyDetectedString(this.m_KeysTab.m_FRKeyDetected));
                }
            }
        }

        private unsafe void MemUpdateECUInfo()
        {
            MemoryTab memoryTab = this.m_MemoryTab;
            if (memoryTab.m_WasAnalysed)
            {
                this.lblMemInfo.Text = $"FLASH: {this.m_MemoryTab.m_FlashName}, {this.GetHumanSize(memoryTab.m_FlashSize)}
";
                this.btnMemReadFlash.Enabled = true;
                this.btnMemWriteFlash.Enabled = true;
                uint modopt(IsLong) eEPROMASize = this.m_MemoryTab.m_EEPROMASize;
                if (eEPROMASize > 0)
                {
                    this.lblMemInfo.Text = this.lblMemInfo.Text + $"
EEPROM A: {this.m_MemoryTab.m_EEPROMAName}, {this.GetHumanSize(eEPROMASize)}";
                    this.btnMemReadEEPROMA.Enabled = true;
                    this.btnMemWriteEEPROMA.Enabled = true;
                }
                else
                {
                    this.btnMemReadEEPROMA.Enabled = false;
                    this.btnMemWriteEEPROMA.Enabled = false;
                }
                uint modopt(IsLong) eEPROMBSize = this.m_MemoryTab.m_EEPROMBSize;
                if (eEPROMBSize > 0)
                {
                    this.lblMemInfo.Text = this.lblMemInfo.Text + $"
EEPROM B: {this.m_MemoryTab.m_EEPROMBName}, {this.GetHumanSize(eEPROMBSize)}";
                    this.btnMemReadEEPROMB.Enabled = true;
                    this.btnMemWriteEEPROMB.Enabled = true;
                }
                else
                {
                    this.btnMemReadEEPROMB.Enabled = false;
                    this.btnMemWriteEEPROMB.Enabled = false;
                }
                MemoryTab.ECU activeECU = this.m_MemoryTab.GetActiveECU();
                this.cbxMemOperation.Items.Clear();
                int num = 0;
                if (0 < this.m_MemoryTab.m_OperationList[activeECU].Count)
                {
                    do
                    {
                        if (((MemoryTab.Operation) this.m_MemoryTab.m_OperationList[activeECU][num]) != MemoryTab.Operation.WriteFuelMap)
                        {
                            CustomAssert(&??_C@_0BE@EEKGANJA@FRMRMemoryTasks?4cpp?$AA@, 0x58, true, null);
                        }
                        else
                        {
                            this.cbxMemOperation.Items.Add(this.GetLocalizedString("strWriteMAP"));
                        }
                        num++;
                    }
                    while (num < this.m_MemoryTab.m_OperationList[activeECU].Count);
                }
                this.m_MemoryTab.m_ActiveOperationIdx = 0;
                if (this.cbxMemOperation.Items.Count == 0)
                {
                    this.cbxMemOperation.Enabled = false;
                    this.btnMemRunOperation.Enabled = false;
                }
                else
                {
                    this.cbxMemOperation.Enabled = true;
                    this.cbxMemOperation.SelectedIndex = this.m_MemoryTab.m_ActiveOperationIdx;
                    this.btnMemRunOperation.Enabled = true;
                }
            }
            else
            {
                this.btnMemReadFlash.Enabled = false;
                this.btnMemWriteFlash.Enabled = false;
                this.btnMemReadEEPROMA.Enabled = false;
                this.btnMemWriteEEPROMA.Enabled = false;
                this.btnMemReadEEPROMB.Enabled = false;
                this.btnMemWriteEEPROMB.Enabled = false;
                this.cbxMemOperation.Items.Clear();
                this.cbxMemOperation.Enabled = false;
                this.btnMemRunOperation.Enabled = false;
                this.lblMemInfo.Text = null;
            }
        }

        private void MemUpdateECUList()
        {
            this.cbxMemECU.Items.Clear();
            int num2 = 0;
            if (0 < this.m_MemoryTab.m_ECUList.Count)
            {
                do
                {
                    string eCUString = this.m_MemoryTab.GetECUString(this.m_MemoryTab.m_ECUList[num2]);
                    int index = 0;
                    if (0 < this.m_ECUInfo[this.m_TruckType].Length)
                    {
                        do
                        {
                            if (this.m_ECUInfo[this.m_TruckType][index].m_shortname == eCUString)
                            {
                                this.cbxMemECU.Items.Add(eCUString + " " + this.GetLocalizedString(this.m_ECUInfo[this.m_TruckType][index].m_longnameid));
                            }
                            index++;
                        }
                        while (index < this.m_ECUInfo[this.m_TruckType].Length);
                    }
                    num2++;
                }
                while (num2 < this.m_MemoryTab.m_ECUList.Count);
            }
            if (this.cbxMemECU.Items.Count != 0)
            {
                this.cbxMemECU.Enabled = true;
                this.m_MemoryTab.m_ActiveECUIdx = 0;
                this.cbxMemECU.SelectedIndex = this.m_MemoryTab.m_ActiveECUIdx;
            }
            else
            {
                this.cbxMemECU.Enabled = false;
            }
        }

        private DialogResult MessageBoxThreadSafe(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            if (this.InvokeRequired)
            {
                MessageBoxDelegate method = new MessageBoxDelegate(this.MessageBoxThreadSafe);
                object[] args = new object[] { text, caption, buttons, icon };
                return (DialogResult) this.Invoke(method, args);
            }
            return MessageBox.Show(text, caption, buttons, icon);
        }

        private void MRImmoOffFailedThreadSafe(string ErrorString)
        {
            if (this.InvokeRequired)
            {
                TaskFailedDelegate method = new TaskFailedDelegate(this.MRImmoOffFailedThreadSafe);
                object[] args = new object[] { ErrorString };
                this.Invoke(method, args);
            }
            else
            {
                this.StopOperation();
                this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + ErrorString + ")!\r\n");
                this.MessageBoxThreadSafe((this.GetParamedLocalizedString("strECUXImmoOffFailed", "MR") + " (") + ErrorString + ")!", this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void MRImmoOffOkThreadSafe()
        {
            if (this.InvokeRequired)
            {
                Action method = new Action(this.MRImmoOffOkThreadSafe);
                base.Invoke(method);
            }
            else
            {
                this.StopOperation();
                this.AddToLogThreadSafe(this.GetLocalizedString("strdone") + "\r\n");
                this.MessageBoxThreadSafe(this.GetParamedLocalizedString("strECUXImmoOffCompleted", "MR"), this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.btnGetKeysInfo_Click(null, null);
            }
        }

        private unsafe void MRImmoOffTask()
        {
            uint num;
            int num2 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                byte num3;
                VeDocCalcType_t _t3 = (VeDocCalcType_t) 3;
                if (!this.VeDocCryptoKeySet(this.m_LastOperationStr, &num3))
                {
                    this.MRImmoOffFailedThreadSafe(this.GetErrorExplanation(num3));
                }
                else
                {
                    uint num5;
                    $ArrayType$$$BY0BA@E e$$$byba@e;
                    if (!CmdLayerCreateMRKeyLearningParameters((byte*) &e$$$byba@e, 0x10, &num5, (VeDocCalcType_t) 3))
                    {
                        CustomAssert(&??_C@_0BC@DFLNDNFC@KeyLearnTasks?4cpp?$AA@, 0x3d5, true, null);
                    }
                    if (RunLongOperation((Command_t) 0x99, (byte modopt(IsConst)*) &e$$$byba@e, num5, (Command_t) 0x9a, (Command_t) 0x9b, 0))
                    {
                        KeyStatus_t _t = CmdLayerGetMRKeyLearningAnswer();
                        if (_t == ((KeyStatus_t) 0))
                        {
                            this.AskForIgnition(false, this.m_LastOperationStr, true);
                            this.AskForIgnition(true, this.m_LastOperationStr, true);
                            this.MRImmoOffOkThreadSafe();
                        }
                        else
                        {
                            this.MRImmoOffFailedThreadSafe(this.GetMRKeyStatusString((ushort) _t));
                        }
                    }
                    else
                    {
                        num3 = CmdLayerGetErrorData((Command_t) 0x9b);
                        this.MRImmoOffFailedThreadSafe(this.GetErrorExplanation(num3));
                    }
                }
            }
            catch (UserAborted)
            {
                this.MRImmoOffFailedThreadSafe(this.GetLocalizedString("strUserAborted"));
            }
            catch (InvalidOBDPower)
            {
                this.MRImmoOffFailedThreadSafe(this.GetLocalizedString("strInvalidOBDPower"));
            }
            catch (NoOBDPower)
            {
                this.MRImmoOffFailedThreadSafe(this.GetLocalizedString("strNoOBDPower"));
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t2;
                        byte errorcode = (byte) _t2;
                        this.AddToLogThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(errorcode) + ")!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(errorcode) + ")!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0BC@DFLNDNFC@KeyLearnTasks?4cpp?$AA@, 0x407, false, null);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0BC@DFLNDNFC@KeyLearnTasks?4cpp?$AA@, 0x41a, true, null);
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
        }

        [return: MarshalAs(UnmanagedType.U1)]
        private unsafe bool MRStart(string MsgCaption, byte* modopt(IsImplicitlyDereferenced) ErrorCode)
        {
            this.AskForIgnition(true, MsgCaption, true);
            if (!this.m_IsBootstrapMode)
            {
                if (!RunLongOperation((Command_t) 0x10, null, 0, (Command_t) 0x11, (Command_t) 0x12, 0))
                {
                    ErrorCode[0] = (byte* modopt(IsImplicitlyDereferenced)) CmdLayerGetErrorData((Command_t) 0x12);
                    return false;
                }
                if (!CmdLayerGetRequiredPositionOfIgnition())
                {
                    this.AskForIgnition(false, MsgCaption, false);
                }
                if (!RunLongOperation((Command_t) 0x13, null, 0, (Command_t) 20, (Command_t) 0x15, 0))
                {
                    ErrorCode[0] = (byte* modopt(IsImplicitlyDereferenced)) CmdLayerGetErrorData((Command_t) 0x15);
                    return false;
                }
            }
            else
            {
                uint num;
                $ArrayType$$$BY0BA@E e$$$byba@e;
                if (!CmdLayerCreateECUBootstrapParameters((byte*) &e$$$byba@e, 0x10, &num, this.m_BootstrapMCU))
                {
                    CustomAssert(&??_C@_0BA@NJELOBDB@CommonTasks?4cpp?$AA@, 0xca, true, null);
                }
                if (!RunLongOperation((Command_t) 0x19, (byte modopt(IsConst)*) &e$$$byba@e, num, (Command_t) 0x1a, (Command_t) 0x1b, 0))
                {
                    ErrorCode[0] = (byte* modopt(IsImplicitlyDereferenced)) CmdLayerGetErrorData((Command_t) 0x1b);
                    return false;
                }
            }
            return true;
        }

        private void ReadFaultsFailedThreadSafe(string ErrorString)
        {
            if (this.InvokeRequired)
            {
                TaskFailedDelegate method = new TaskFailedDelegate(this.ReadFaultsFailedThreadSafe);
                object[] args = new object[] { ErrorString };
                this.Invoke(method, args);
            }
            else
            {
                this.gridFaultCodes.Rows.Clear();
                this.UpdateGridFaultCodesHeight();
                this.pnlFaultCodes.Enabled = false;
                this.StopOperation();
                this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + ErrorString + ")!\r\n");
            }
        }

        private unsafe void ReadFaultsOkThreadSafe(DTCInfo_t[] DTCs)
        {
            if (this.InvokeRequired)
            {
                ReadFaultsOkDelegate method = new ReadFaultsOkDelegate(this.ReadFaultsOkThreadSafe);
                object[] args = new object[] { DTCs };
                this.Invoke(method, args);
            }
            else
            {
                this.gridFaultCodes.Rows.Clear();
                int index = 0;
                if (0 < DTCs.Length)
                {
                    do
                    {
                        string dTCDescription = this.GetDTCDescription(this.m_DetectedECU[this.m_CurrentECUIdx].m_shortname, DTCs[index].code);
                        object[] values = new object[] { DTCs[index].code, dTCDescription };
                        this.gridFaultCodes.Rows.Add(values);
                        string code = DTCs[index].code;
                        int num2 = this.gridFaultCodes.Rows.Count - 1;
                        DTCStatus_t status = DTCs[index].status;
                        if (*(((int*) &status)) != 0)
                        {
                            if (*(((int*) &status)) != 1)
                            {
                                CustomAssert(&??_C@_0BE@NEIAFJLK@FaultCodesTasks?4cpp?$AA@, 0x197, true, null);
                            }
                            else
                            {
                                code = code + ("\n\n" + this.GetLocalizedString("strStoredFault").ToUpper());
                                System.Drawing.Color lightGray = System.Drawing.Color.LightGray;
                                this.gridFaultCodes.Rows[num2].DefaultCellStyle.BackColor = lightGray;
                            }
                        }
                        else
                        {
                            code = code + ("\n\n" + this.GetLocalizedString("strCurrentFault").ToUpper());
                        }
                        code = code + "\n\n" + dTCDescription;
                        this.gridFaultCodes.Rows[num2].Cells[0].ToolTipText = code;
                        this.gridFaultCodes.Rows[num2].Cells[1].ToolTipText = code;
                        index++;
                    }
                    while (index < DTCs.Length);
                }
                this.UpdateGridFaultCodesHeight();
                this.pnlFaultCodes.Enabled = true;
                this.StopOperation();
                int length = DTCs.Length;
                if (length == 1)
                {
                    this.AddToLogThreadSafe(this.GetLocalizedString("str1faultfound") + "\r\n");
                }
                else
                {
                    this.AddToLogThreadSafe(this.GetParamedLocalizedString("strXfaultsfound", length) + "\r\n");
                }
            }
        }

        private unsafe void ReadFaultsTask()
        {
            uint num;
            int num3 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                DTC_t modopt(IsConst)* _tPtr;
                DTCInfo_t[] _tArray;
                uint num8;
                byte num13;
                uint num14;
                $ArrayType$$$BY0BA@E e$$$byba@e;
                TruckType_t truckType = this.m_TruckType;
                if (*(((int*) &truckType)) != 0)
                {
                    if (*(((int*) &truckType)) != 1)
                    {
                        CustomAssert(&??_C@_0BE@NEIAFJLK@FaultCodesTasks?4cpp?$AA@, 0x142, true, null);
                    }
                    else
                    {
                        this.TaskNotImplementedThreadSafe();
                    }
                    return;
                }
                this.AskForIgnition(true, this.m_LastOperationStr, true);
                if (!CmdLayerCreateDTCReadParams((byte*) &e$$$byba@e, 0x10, &num14, this.m_DetectedECU[this.m_CurrentECUIdx].m_addr))
                {
                    CustomAssert(&??_C@_0BE@NEIAFJLK@FaultCodesTasks?4cpp?$AA@, 0xf3, true, null);
                }
                if (!RunLongOperation((Command_t) 0xb9, (byte modopt(IsConst)*) &e$$$byba@e, num14, (Command_t) 0xba, (Command_t) 0xbb, 0))
                {
                    goto Label_01DA;
                }
                CmdLayerGetDTCReadData(&_tPtr, &num8);
                uint num9 = 0;
                uint num5 = 0;
            Label_00AD:
                if (num5 >= num8)
                {
                    goto Label_0103;
                }
                bool flag2 = true;
                uint num7 = num5 + 1;
                while (true)
                {
                    if (num7 >= num8)
                    {
                        break;
                    }
                    DTC_t modopt(IsConst)* _tPtr5 = ((DTC_t modopt(IsConst)*) (num7 * 8)) + _tPtr;
                    DTC_t modopt(IsConst)* _tPtr4 = ((DTC_t modopt(IsConst)*) (num5 * 8)) + _tPtr;
                    if ((_tPtr4 == _tPtr5) && (*(((byte*) (_tPtr4 + 6))) == *(((byte*) (_tPtr5 + 6)))))
                    {
                        flag2 = false;
                        goto Label_00FB;
                    }
                    num7++;
                }
                if (flag2)
                {
                    num9++;
                }
            Label_00FB:
                num5++;
                goto Label_00AD;
            Label_0103:
                _tArray = new DTCInfo_t[num9];
                uint index = 0;
                uint num2 = 0;
            Label_0111:
                if (num2 >= num8)
                {
                    goto Label_01CD;
                }
                bool flag = true;
                uint num6 = num2 + 1;
                while (true)
                {
                    if (num6 >= num8)
                    {
                        break;
                    }
                    DTC_t modopt(IsConst)* _tPtr3 = ((DTC_t modopt(IsConst)*) (num6 * 8)) + _tPtr;
                    DTC_t modopt(IsConst)* _tPtr2 = ((DTC_t modopt(IsConst)*) (num2 * 8)) + _tPtr;
                    if ((_tPtr2 == _tPtr3) && (*(((byte*) (_tPtr2 + 6))) == *(((byte*) (_tPtr3 + 6)))))
                    {
                        flag = false;
                        goto Label_01C4;
                    }
                    num6++;
                }
                if (flag)
                {
                    uint num12 = num2 * 8;
                    _tArray[index].code = new string((sbyte*) (num12 + _tPtr));
                    int num11 = *((int*) ((_tPtr + num12) + 6));
                    if (num11 != 0)
                    {
                        if (num11 != 1)
                        {
                            CustomAssert(&??_C@_0BE@NEIAFJLK@FaultCodesTasks?4cpp?$AA@, 0x128, true, null);
                        }
                        else
                        {
                            _tArray[index].status = DTCStatus_t.Current;
                        }
                    }
                    else
                    {
                        _tArray[index].status = DTCStatus_t.Stored;
                    }
                    index++;
                }
            Label_01C4:
                num2++;
                goto Label_0111;
            Label_01CD:
                this.ReadFaultsOkThreadSafe(_tArray);
                return;
            Label_01DA:
                num13 = CmdLayerGetErrorData((Command_t) 0xbb);
                this.ReadFaultsFailedThreadSafe(this.GetErrorExplanation(num13));
            }
            catch (UserAborted)
            {
                this.ReadFaultsFailedThreadSafe(this.GetLocalizedString("strUserAborted"));
            }
            catch (InvalidOBDPower)
            {
                this.ReadFaultsFailedThreadSafe(this.GetLocalizedString("strInvalidOBDPower"));
            }
            catch (NoOBDPower)
            {
                this.ReadFaultsFailedThreadSafe(this.GetLocalizedString("strNoOBDPower"));
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num3);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t;
                        byte errorcode = (byte) _t;
                        this.AddToLogThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(errorcode) + ")!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(errorcode) + ")!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0BE@NEIAFJLK@FaultCodesTasks?4cpp?$AA@, 0x15d, false, null);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num3, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num3);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num3, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num3);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0BE@NEIAFJLK@FaultCodesTasks?4cpp?$AA@, 0x170, true, null);
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num3, (int) num);
                }
            }
        }

        private void ReadKeysInfoFailedThreadSafe(string ErrorString)
        {
            if (this.InvokeRequired)
            {
                TaskFailedDelegate method = new TaskFailedDelegate(this.ReadKeysInfoFailedThreadSafe);
                object[] args = new object[] { ErrorString };
                this.Invoke(method, args);
            }
            else
            {
                this.StopOperation();
                if (ErrorString != null)
                {
                    this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + ErrorString + ")!\r\n");
                    this.MessageBoxThreadSafe((this.GetLocalizedString("strReadKeysInfoFailed") + " (") + ErrorString + ")!", this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    this.AddToLogThreadSafe(this.GetLocalizedString("strfailed") + "\r\n");
                }
            }
        }

        private unsafe void ReadKeysInfoTask()
        {
            uint num;
            int num2 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                TruckType_t truckType = this.m_TruckType;
                if (*(((int*) &truckType)) != 0)
                {
                    if (*(((int*) &truckType)) != 1)
                    {
                        CustomAssert(&??_C@_0BC@DFLNDNFC@KeyLearnTasks?4cpp?$AA@, 0x2f7, true, null);
                    }
                    else
                    {
                        this.AskForIgnition(true, this.GetLocalizedString("strReadKeysInfo"), true);
                        MANMainECU_t mANMainECU = this.m_MANMainECU;
                        if (*(((int*) &mANMainECU)) != 1)
                        {
                            if (*(((int*) &mANMainECU)) != 2)
                            {
                                CustomAssert(&??_C@_0BC@DFLNDNFC@KeyLearnTasks?4cpp?$AA@, 0x2f2, true, null);
                            }
                            else if (RunLongOperation((Command_t) 0xe9, null, 0, (Command_t) 0xea, (Command_t) 0xeb, 0))
                            {
                                bool flag4;
                                PTMImmoInfo_t _t4;
                                CmdLayerGetPTMImmoInfo(&_t4, &flag4);
                                this.m_KeysTab.m_MANPTMKeyStatus = *((ushort*) (&_t4 + 1));
                                this.m_KeysTab.m_NumberOfKeys = *((byte*) (&_t4 + 5));
                                this.m_KeysTab.m_MANPTMImmoStatus = *((bool*) &_t4);
                                this.m_KeysTab.m_MANPTMSynced = flag4;
                                this.MANReadKeysInfoOkThreadSafe();
                            }
                            else
                            {
                                byte errorcode = CmdLayerGetErrorData((Command_t) 0xeb);
                                string errorExplanation = this.GetErrorExplanation(errorcode);
                                this.ReadKeysInfoFailedThreadSafe(errorExplanation);
                            }
                        }
                        else if (RunLongOperation((Command_t) 0xf9, null, 0, (Command_t) 250, (Command_t) 0xfb, 0))
                        {
                            bool flag3;
                            FFRImmoInfo_t _t3;
                            CmdLayerGetFFRImmoInfo(&_t3, &flag3);
                            this.m_KeysTab.m_MANFFRKeyStatus = *((ushort*) (&_t3 + 1));
                            this.m_KeysTab.m_NumberOfKeys = *((byte*) (&_t3 + 5));
                            this.m_KeysTab.m_MANFFRImmoStatus = *((bool*) &_t3);
                            this.m_KeysTab.m_MANFFRSynced = flag3;
                            this.MANReadKeysInfoOkThreadSafe();
                        }
                        else
                        {
                            byte num7 = CmdLayerGetErrorData((Command_t) 0xeb);
                            string errorString = this.GetErrorExplanation(num7);
                            this.ReadKeysInfoFailedThreadSafe(errorString);
                        }
                    }
                }
                else
                {
                    this.AskForIgnition(true, this.m_LastOperationStr, true);
                    this.m_KeysTab.m_MRInfoValid = false;
                    if (RunLongOperation((Command_t) 150, null, 0, (Command_t) 0x97, (Command_t) 0x98, 0))
                    {
                        KeysInfo_t _t2;
                        CmdLayerGetMRTransponderKeysInfo(&_t2);
                        this.m_KeysTab.m_NumberOfKeys = *((byte*) (&_t2 + 8));
                        this.m_KeysTab.m_MRImmoStatusCode = *((ushort*) &_t2);
                        this.m_KeysTab.m_MRKeyStatusCode = *((ushort*) (&_t2 + 4));
                        this.m_KeysTab.m_MRTransponderCode = new byte[5];
                        int index = 0;
                        while (true)
                        {
                            byte[] mRTransponderCode = this.m_KeysTab.m_MRTransponderCode;
                            if (index >= mRTransponderCode.Length)
                            {
                                break;
                            }
                            mRTransponderCode[index] = *((byte*) (index + (&_t2 + 9)));
                            index++;
                        }
                        this.m_KeysTab.m_MRInfoValid = true;
                    }
                    else
                    {
                        byte num6 = CmdLayerGetErrorData((Command_t) 0x98);
                        string str2 = this.GetErrorExplanation(num6);
                        this.AddToLogThreadSafe((this.GetParamedLocalizedString("strECUXfailed", "MR") + " (") + str2 + ")... ");
                        this.MessageBoxThreadSafe((this.GetParamedLocalizedString("strECUXReadKeysInfoFailed", "MR") + " (") + str2 + ")!", this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    this.m_KeysTab.m_FRInfoValid = false;
                    if (this.m_ShowFRInfo && this.m_CanAccessFR)
                    {
                        if (RunLongOperation((Command_t) 0xe3, null, 0, (Command_t) 0xe4, (Command_t) 0xe5, 0))
                        {
                            bool flag;
                            bool flag2;
                            CmdLayerGetFRImmoInfo(&flag2, &flag);
                            this.m_KeysTab.m_FRImmoStatus = flag2;
                            this.m_KeysTab.m_FRKeyDetected = flag;
                            this.m_KeysTab.m_FRInfoValid = true;
                        }
                        else
                        {
                            byte num5 = CmdLayerGetErrorData((Command_t) 0xe5);
                            string str = this.GetErrorExplanation(num5);
                            this.AddToLogThreadSafe((this.GetParamedLocalizedString("strECUXfailed", "FR") + " (") + str + ")... ");
                            this.MessageBoxThreadSafe((this.GetParamedLocalizedString("strECUXReadKeysInfoFailed", "FR") + " (") + str + ")!", this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                    KeysTab keysTab = this.m_KeysTab;
                    if (!keysTab.m_MRInfoValid && !keysTab.m_FRInfoValid)
                    {
                        this.ReadKeysInfoFailedThreadSafe(null);
                    }
                    else
                    {
                        this.MBReadKeysInfoOkThreadSafe();
                    }
                }
            }
            catch (UserAborted)
            {
                this.ReadKeysInfoFailedThreadSafe(this.GetLocalizedString("strUserAborted"));
            }
            catch (InvalidOBDPower)
            {
                this.ReadKeysInfoFailedThreadSafe(this.GetLocalizedString("strInvalidOBDPower"));
            }
            catch (NoOBDPower)
            {
                this.ReadKeysInfoFailedThreadSafe(this.GetLocalizedString("strNoOBDPower"));
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t;
                        byte num4 = (byte) _t;
                        this.AddToLogThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(num4) + ")!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(num4) + ")!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0BC@DFLNDNFC@KeyLearnTasks?4cpp?$AA@, 0x314, false, null);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0BC@DFLNDNFC@KeyLearnTasks?4cpp?$AA@, 0x327, true, null);
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
        }

        private void SetProgressBoundsThreadSafe(int min, int max)
        {
            if (this.InvokeRequired)
            {
                SetProgressBoundsDelegate method = new SetProgressBoundsDelegate(this.SetProgressBoundsThreadSafe);
                object[] args = new object[] { min, max };
                this.Invoke(method, args);
            }
            else
            {
                this.pbarProgress.Minimum = min;
                this.pbarProgress.Maximum = max;
                this.pbarProgress.Value = this.pbarProgress.Minimum;
                this.pbarProgress.Style = ProgressBarStyle.Continuous;
            }
        }

        private void SetProgressCommentThreadSafe(string comment)
        {
            if (this.InvokeRequired)
            {
                SetProgressCommentDelegate method = new SetProgressCommentDelegate(this.SetProgressCommentThreadSafe);
                object[] args = new object[] { comment };
                this.Invoke(method, args);
            }
        }

        private void SetProgressUndefinedThreadSafe()
        {
            if (this.InvokeRequired)
            {
                SetProgressUndefinedDelegate method = new SetProgressUndefinedDelegate(this.SetProgressUndefinedThreadSafe);
                base.Invoke(method);
            }
            else
            {
                this.pbarProgress.Style = ProgressBarStyle.Marquee;
            }
        }

        private void SetProgressValueThreadSafe(int val)
        {
            if (this.InvokeRequired)
            {
                SetProgressValueDelegate method = new SetProgressValueDelegate(this.SetProgressValueThreadSafe);
                object[] args = new object[] { val };
                this.Invoke(method, args);
            }
            else
            {
                this.pbarProgress.Value = val;
            }
        }

        private void SetSpeedLimitFailedThreadSafe(string ErrorString)
        {
            if (this.InvokeRequired)
            {
                TaskFailedDelegate method = new TaskFailedDelegate(this.SetSpeedLimitFailedThreadSafe);
                object[] args = new object[] { ErrorString };
                this.Invoke(method, args);
            }
            else
            {
                this.StopOperation();
                this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + ErrorString + ")!\r\n");
                this.MessageBoxThreadSafe((this.GetLocalizedString("strSetSpeedLimitFailed") + " (") + ErrorString + ")!", this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void SetSpeedLimitOkThreadSafe()
        {
            if (this.InvokeRequired)
            {
                Action method = new Action(this.SetSpeedLimitOkThreadSafe);
                base.Invoke(method);
            }
            else
            {
                this.StopOperation();
                this.AddToLogThreadSafe(this.GetLocalizedString("strdone") + "\r\n");
            }
        }

        private unsafe void SetSpeedLimitTask()
        {
            uint num;
            int num2 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                uint num5;
                $ArrayType$$$BY0BA@E e$$$byba@e;
                this.AskForIgnition(true, this.m_LastOperationStr, true);
                if (!CmdLayerCreateSpeedLimitSetData((byte*) &e$$$byba@e, 0x10, &num5, this.m_ExtraTab.m_SpeedLimit))
                {
                    CustomAssert(&??_C@_0P@NKJDEOOE@ExtraTasks?4cpp?$AA@, 0x113, true, null);
                }
                if (RunLongOperation((Command_t) 0xc2, (byte modopt(IsConst)*) &e$$$byba@e, num5, (Command_t) 0xc3, (Command_t) 0xc4, 0))
                {
                    this.SetSpeedLimitOkThreadSafe();
                }
                else
                {
                    byte errorcode = CmdLayerGetErrorData((Command_t) 0xc4);
                    this.SetSpeedLimitFailedThreadSafe(this.GetErrorExplanation(errorcode));
                }
            }
            catch (UserAborted)
            {
                this.SetSpeedLimitFailedThreadSafe(this.GetLocalizedString("strUserAborted"));
            }
            catch (InvalidOBDPower)
            {
                this.SetSpeedLimitFailedThreadSafe(this.GetLocalizedString("strInvalidOBDPower"));
            }
            catch (NoOBDPower)
            {
                this.SetSpeedLimitFailedThreadSafe(this.GetLocalizedString("strNoOBDPower"));
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t;
                        byte num3 = (byte) _t;
                        this.AddToLogThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(num3) + ")!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(num3) + ")!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0P@NKJDEOOE@ExtraTasks?4cpp?$AA@, 0x138, false, null);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0P@NKJDEOOE@ExtraTasks?4cpp?$AA@, 0x14b, true, null);
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
        }

        private void SetTorqueLimitFailedThreadSafe(string ErrorString)
        {
            if (this.InvokeRequired)
            {
                TaskFailedDelegate method = new TaskFailedDelegate(this.SetTorqueLimitFailedThreadSafe);
                object[] args = new object[] { ErrorString };
                this.Invoke(method, args);
            }
            else
            {
                this.StopOperation();
                this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + ErrorString + ")!\r\n");
                this.MessageBoxThreadSafe((this.GetLocalizedString("strSetTorqueLimitFailed") + " (") + ErrorString + ")!", this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void SetTorqueLimitOkThreadSafe()
        {
            if (this.InvokeRequired)
            {
                Action method = new Action(this.SetTorqueLimitOkThreadSafe);
                base.Invoke(method);
            }
            else
            {
                this.StopOperation();
                this.AddToLogThreadSafe(this.GetLocalizedString("strdone") + "\r\n");
            }
        }

        private unsafe void SetTorqueLimitTask()
        {
            uint num;
            int num2 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                uint num5;
                $ArrayType$$$BY0BA@E e$$$byba@e;
                this.AskForIgnition(true, this.m_LastOperationStr, true);
                if (!CmdLayerCreateNOxTorqueLimitSetData((byte*) &e$$$byba@e, 0x10, &num5, this.m_ExtraTab.m_TorqueLimit))
                {
                    CustomAssert(&??_C@_0P@NKJDEOOE@ExtraTasks?4cpp?$AA@, 0x206, true, null);
                }
                if (RunLongOperation((Command_t) 0xcb, (byte modopt(IsConst)*) &e$$$byba@e, num5, (Command_t) 0xcc, (Command_t) 0xcd, 0))
                {
                    this.SetTorqueLimitOkThreadSafe();
                }
                else
                {
                    byte errorcode = CmdLayerGetErrorData((Command_t) 0xcd);
                    this.SetTorqueLimitFailedThreadSafe(this.GetErrorExplanation(errorcode));
                }
            }
            catch (UserAborted)
            {
                this.SetTorqueLimitFailedThreadSafe(this.GetLocalizedString("strUserAborted"));
            }
            catch (InvalidOBDPower)
            {
                this.SetTorqueLimitFailedThreadSafe(this.GetLocalizedString("strInvalidOBDPower"));
            }
            catch (NoOBDPower)
            {
                this.SetTorqueLimitFailedThreadSafe(this.GetLocalizedString("strNoOBDPower"));
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t;
                        byte num3 = (byte) _t;
                        this.AddToLogThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(num3) + ")!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(num3) + ")!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0P@NKJDEOOE@ExtraTasks?4cpp?$AA@, 0x22b, false, null);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0P@NKJDEOOE@ExtraTasks?4cpp?$AA@, 0x23e, true, null);
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
        }

        private void ShowMessageBoxThreadSafe(string text, string caption)
        {
            if (this.InvokeRequired)
            {
                ShowMessageBoxDelegate method = new ShowMessageBoxDelegate(this.ShowMessageBoxThreadSafe);
                object[] args = new object[] { text, caption };
                this.Invoke(method, args);
            }
            else
            {
                this.m_msgbox.Show(text, caption, MessageBoxButtons.OKCancel);
            }
        }

        private void SoftwareUpdateFinishedThreadSafe([MarshalAs(UnmanagedType.U1)] bool needrestart)
        {
            if (this.InvokeRequired)
            {
                SoftwareUpdateFinishedDelegate method = new SoftwareUpdateFinishedDelegate(this.SoftwareUpdateFinishedThreadSafe);
                object[] args = new object[] { needrestart };
                this.Invoke(method, args);
            }
            else
            {
                this.StopOperation();
                if (needrestart)
                {
                    base.Close();
                }
            }
        }

        private void SoftwareUpdateGotNewFilesize(uint modopt(IsLong) filesize)
        {
            this.SetProgressBoundsThreadSafe(0, filesize);
        }

        private void SoftwareUpdateSizeDownloaded(uint modopt(IsLong) sizedownloaded)
        {
            this.SetProgressValueThreadSafe(sizedownloaded);
        }

        private unsafe void SoftwareUpdateTask()
        {
            int num2 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            bool needrestart = false;
            try
            {
                SoftwareUpdater updater = new SoftwareUpdater("TruckExplorer");
                updater.OnFileDownloadSizeObtained += new SoftwareUpdater.FileDownloadSizeObtainedHandler(this.SoftwareUpdateGotNewFilesize);
                updater.OnAmountDownloadedChanged += new SoftwareUpdater.AmountDownloadedChangedHandler(this.SoftwareUpdateSizeDownloaded);
                bool flag2 = updater.IsNewVersionAvailable();
                DateTime now = DateTime.Now;
                this.m_Settings.SoftwareUpdateLastCheckTime = now;
                if (flag2)
                {
                    this.AddToLogThreadSafe(this.GetLocalizedString("strnewVersionFound"));
                    this.AddToLogThreadSafe("\r\n");
                    if (this.MessageBoxThreadSafe(this.GetLocalizedString("strWantToUpdateProgram"), this.GetLocalizedString("strUpdateSoftware"), MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDownloadingUpdate"));
                        updater.Update();
                        needrestart = true;
                    }
                }
                else
                {
                    this.AddToLogThreadSafe(this.GetLocalizedString("strnoNewVersionFound"));
                    this.AddToLogThreadSafe("\r\n");
                    if (!this.m_AutomaticSoftwareUpdate)
                    {
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strNoNewSoftwareUpdates"), this.GetLocalizedString("strUpdateSoftware"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch (WebException)
            {
                this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + this.GetLocalizedString("strCannotConnectToServer") + ").");
                this.AddToLogThreadSafe("\r\n");
                if (!this.m_AutomaticSoftwareUpdate)
                {
                    this.MessageBoxThreadSafe(this.GetLocalizedString("strCannotConnectToServer"), this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch (FileNotFoundException)
            {
                this.AddToLogThreadSafe("NET Framework 4.0 Full not found!");
                this.AddToLogThreadSafe("\r\n");
                this.MessageBoxThreadSafe("Microsoft Framework 4.0 Full was not found. Please install it before using this application.", "Library missed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception exception3)
            {
                this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + this.GetLocalizedString("strCannotConnectToServer") + ").");
                this.AddToLogThreadSafe("\r\n");
                if (!this.m_AutomaticSoftwareUpdate)
                {
                    this.MessageBoxThreadSafe(this.GetLocalizedString("strCannotConnectToServer"), this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                marshal_context _context = new marshal_context();
                string str = exception3.ToString();
                CustomAssert(&??_C@_0BI@PKKHDHBN@SoftwareUpdateTasks?4cpp?$AA@, 0x67, false, marshal_context.internal_marshaler<char const *,System::String ^,1>.marshal_as((string modopt(IsConst)* modopt(IsImplicitlyDereferenced)) &str, _context._clean_up_list));
            }
            catch when (?)
            {
                uint num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + this.GetLocalizedString("strCannotConnectToServer") + ").");
                        this.AddToLogThreadSafe("\r\n");
                        if (!this.m_AutomaticSoftwareUpdate)
                        {
                            this.MessageBoxThreadSafe(this.GetLocalizedString("strCannotConnectToServer"), this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        CustomAssert(&??_C@_0BI@PKKHDHBN@SoftwareUpdateTasks?4cpp?$AA@, 0x75, false, null);
                        goto Label_02E3;
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
            }
        Label_02E3:
            this.SoftwareUpdateFinishedThreadSafe(needrestart);
        }

        private void StartOperation(string LogMessage, string OperationStr)
        {
            this.AddToLogThreadSafe("\r\n" + LogMessage + "... ");
            this.m_LastOperationStr = OperationStr;
            this.m_SelectedTabPrevState = this.tabctlActions.SelectedTab.Enabled;
            this.tabctlActions.SelectedTab.Enabled = false;
            this.tabctlActions.Enabled = false;
            this.m_CarChangeBtnPrevState = this.btnCarLeft.Enabled;
            this.btnCarLeft.Enabled = false;
            this.btnCarRight.Enabled = false;
            this.m_ConnectBtnPrevState = this.btnConnect.Enabled;
            this.btnConnect.Enabled = false;
            this.m_DisconnectBtnPrevState = this.btnDisconnect.Enabled;
            this.btnDisconnect.Enabled = false;
            this.btnExit.Enabled = false;
            base.UseWaitCursor = true;
            this.pbarProgress.Visible = true;
            this.m_OperationRunning = true;
        }

        private void StartTask(ThreadStart taskthread, string logmsg, string tasktitle)
        {
            this.StartOperation(logmsg, tasktitle);
            Thread thread = new Thread(taskthread);
            try
            {
                thread.CurrentUICulture = new CultureInfo(this.m_Languages[this.m_Settings.UserLanguage]);
            }
            catch (KeyNotFoundException)
            {
                this.MessageBoxThreadSafe($"Cannot find translation for {this.m_Settings.UserLanguage}! Please reinstall application.", "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            thread.Start();
        }

        private unsafe void StopDeviceUpdateThreadSafe(DeviceUpdateResult_t status, byte errcode, string wwwresponse)
        {
            string str;
            if (this.InvokeRequired)
            {
                StopDeviceUpdateDelegate method = new StopDeviceUpdateDelegate(this.StopDeviceUpdateThreadSafe);
                object[] args = new object[] { status, errcode, wwwresponse };
                this.Invoke(method, args);
                return;
            }
            this.StopOperation();
            switch (status)
            {
                case DeviceUpdateResult_t.SuccessUpdated:
                    this.AddToLogThreadSafe(this.GetLocalizedString("strdone"));
                    this.AddToLogThreadSafe("\r\n");
                    this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceUpdateDone"), this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    goto Label_0327;

                case DeviceUpdateResult_t.SuccessNoUpdates:
                    this.AddToLogThreadSafe(this.GetLocalizedString("strdone"));
                    this.AddToLogThreadSafe("\r\n");
                    this.AddToLogThreadSafe(this.GetLocalizedString("strNoNewDeviceUpdates"));
                    this.AddToLogThreadSafe("\r\n");
                    if (!this.m_AutomaticDeviceUpdate)
                    {
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strNoNewDeviceUpdates"), this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    return;

                case DeviceUpdateResult_t.FinalCheckFailed:
                    this.AddToLogThreadSafe(this.GetLocalizedString("strfailed"));
                    this.AddToLogThreadSafe(".\r\n");
                    this.MessageBoxThreadSafe(this.GetLocalizedString("strUpdateFailed") + ". " + this.GetLocalizedString("strTryAgain"), this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    goto Label_0327;

                case DeviceUpdateResult_t.Failed:
                    this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + this.GetErrorExplanation(errcode) + ")!");
                    this.AddToLogThreadSafe("\r\n");
                    this.MessageBoxThreadSafe((this.GetLocalizedString("strDeviceUpdateFailed") + " (") + this.GetErrorExplanation(errcode) + ")!", this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    goto Label_0327;

                case DeviceUpdateResult_t.CantConnectServer:
                    this.AddToLogThreadSafe(this.GetLocalizedString("strfailed") + $" ({this.GetLocalizedString("strCannotConnectToServer")})!");
                    this.AddToLogThreadSafe("\r\n");
                    if (!this.m_AutomaticDeviceUpdate)
                    {
                        this.MessageBoxThreadSafe($"{this.GetLocalizedString("strCannotConnectToServer")}!", this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    return;

                case DeviceUpdateResult_t.BadServerResponse:
                    if (string.IsNullOrEmpty(wwwresponse))
                    {
                        str = $" (code {errcode})!";
                        break;
                    }
                    str = $" ({wwwresponse})!";
                    break;

                case DeviceUpdateResult_t.BadServerData:
                    this.AddToLogThreadSafe(this.GetLocalizedString("strfailed") + $" ({this.GetLocalizedString("strBadServerData")})!");
                    this.AddToLogThreadSafe("\r\n");
                    this.MessageBoxThreadSafe($"{this.GetLocalizedString("strBadServerData")}!", this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    goto Label_0327;

                default:
                    CustomAssert(&??_C@_0BG@FOAPKIFG@DeviceUpdateTasks?4cpp?$AA@, 0x35f, true, null);
                    goto Label_0327;
            }
            this.AddToLogThreadSafe(this.GetLocalizedString("strfailed") + str);
            this.AddToLogThreadSafe("\r\n");
            this.MessageBoxThreadSafe(this.GetLocalizedString("strUpdateFailed") + str, this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return;
        Label_0327:
            this.DisconnectThreadSafe();
        }

        private void StopOperation()
        {
            this.tabctlActions.Enabled = true;
            this.tabctlActions.SelectedTab.Enabled = this.m_SelectedTabPrevState;
            this.btnCarLeft.Enabled = this.m_CarChangeBtnPrevState;
            this.btnCarRight.Enabled = this.m_CarChangeBtnPrevState;
            this.btnConnect.Enabled = this.m_ConnectBtnPrevState;
            this.btnDisconnect.Enabled = this.m_DisconnectBtnPrevState;
            this.btnExit.Enabled = true;
            base.UseWaitCursor = false;
            this.pbarProgress.Visible = false;
            this.pbarProgress.Style = ProgressBarStyle.Marquee;
            this.m_OperationRunning = false;
        }

        private void TaskNotImplementedThreadSafe()
        {
            if (this.InvokeRequired)
            {
                Action method = new Action(this.TaskNotImplementedThreadSafe);
                base.Invoke(method);
            }
            else
            {
                this.StopOperation();
                this.AddToLogThreadSafe("not implemented\r\n");
                this.MessageBoxThreadSafe("Not implemented", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void UpdateCarNavigationButtons()
        {
            bool flag;
            if (this.m_ConnectionState != ConnectionState_t.TruckConnected)
            {
                int num = 0;
                if (this.m_MBEnabled)
                {
                    num = 1;
                }
                if (this.m_MANEnabled)
                {
                    num++;
                }
                if (this.m_EngineEnabled)
                {
                    num++;
                }
                flag = (bool) ((byte) (num > 1));
            }
            else
            {
                flag = false;
            }
            this.btnCarLeft.Enabled = flag;
            this.btnCarRight.Enabled = flag;
        }

        private unsafe void UpdateCarNavigationImage()
        {
            int num = 0;
            if (this.m_ConnectionState == ConnectionState_t.TruckConnected)
            {
                num = 1;
            }
            TruckType_t truckType = this.m_TruckType;
            if (*(((int*) &truckType)) != 0)
            {
                if (*(((int*) &truckType)) != 1)
                {
                    if (*(((int*) &truckType)) != 2)
                    {
                        CustomAssert(&??_C@_0DA@EIDDNHFD@c?3?2work?2mbexplorer?2gui?2truckexpl@, 0xfd2, true, null);
                    }
                    else
                    {
                        this.imgCar.Image = this.imglstTrucks.Images[num + 4];
                        this.lblCar.Text = this.GetLocalizedString("strEngines");
                    }
                }
                else
                {
                    this.imgCar.Image = this.imglstTrucks.Images[num + 2];
                    this.lblCar.Text = this.GetLocalizedString("strTrucksAndBuses");
                }
            }
            else
            {
                this.imgCar.Image = this.imglstTrucks.Images[num];
                this.lblCar.Text = this.GetLocalizedString("strTrucksAndBuses");
            }
        }

        private void UpdateGridFaultCodesHeight()
        {
            this.pnlFaultCodes.AutoScroll = false;
            this.gridFaultCodes.Width = this.pnlFaultCodes.Width;
            this.gridFaultCodes.Columns[1].Width = 0xec;
            int columnHeadersHeight = this.gridFaultCodes.ColumnHeadersHeight;
            int num3 = 0;
            if (0 < this.gridFaultCodes.Rows.Count)
            {
                do
                {
                    columnHeadersHeight = this.gridFaultCodes.Rows[num3].Height + columnHeadersHeight;
                    num3++;
                }
                while (num3 < this.gridFaultCodes.Rows.Count);
            }
            if (columnHeadersHeight > this.pnlFaultCodes.Height)
            {
                this.pnlFaultCodes.AutoScroll = true;
                this.gridFaultCodes.Width = 0x106;
                this.gridFaultCodes.Columns[1].Width = 0xdb;
                columnHeadersHeight = this.gridFaultCodes.ColumnHeadersHeight;
                int num2 = 0;
                if (0 < this.gridFaultCodes.Rows.Count)
                {
                    do
                    {
                        columnHeadersHeight = this.gridFaultCodes.Rows[num2].Height + columnHeadersHeight;
                        num2++;
                    }
                    while (num2 < this.gridFaultCodes.Rows.Count);
                }
            }
            this.gridFaultCodes.Height = columnHeadersHeight;
        }

        private void VeDocCalcPrepareFailedThreadSafe(string ErrorString)
        {
            if (this.InvokeRequired)
            {
                TaskFailedDelegate method = new TaskFailedDelegate(this.VeDocCalcPrepareFailedThreadSafe);
                object[] args = new object[] { ErrorString };
                this.Invoke(method, args);
            }
            else
            {
                this.edVeDocRnd.Enabled = false;
                this.edVeDocRnd.Clear();
                this.edVeDocID.Enabled = false;
                this.edVeDocID.Clear();
                this.edVeDocNumOfKeys.Enabled = false;
                this.edVeDocNumOfKeys.Clear();
                this.edVeDocTransponderCode.Enabled = false;
                this.edVeDocTransponderCode.Clear();
                this.cbxVeDocCalcType.Enabled = false;
                this.cbxVeDocCalcType.SelectedIndex = -1;
                this.btnVeDocCalculate.Enabled = false;
                this.edVeDocResult.Clear();
                this.edVeDocResult.Enabled = false;
                this.StopOperation();
                this.AddToLogThreadSafe((this.GetLocalizedString("strfailed") + " (") + ErrorString + ")!\r\n");
                this.MessageBoxThreadSafe((this.GetLocalizedString("strVeDocCalcPrepareFailed") + " (") + ErrorString + ")!", this.m_LastOperationStr, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void VeDocCalcPrepareOkThreadSafe(byte[] RandomNumber, byte[] SerialNumber, byte[] TransponderCode, byte NumberOfKeys)
        {
            if (this.InvokeRequired)
            {
                VeDocCalcPrepareOkDelegate method = new VeDocCalcPrepareOkDelegate(this.VeDocCalcPrepareOkThreadSafe);
                object[] args = new object[] { RandomNumber, SerialNumber, TransponderCode, NumberOfKeys };
                this.Invoke(method, args);
            }
            else
            {
                this.edVeDocRnd.Enabled = true;
                this.edVeDocRnd.Text = $"{RandomNumber[0]:X2} {RandomNumber[1]:X2}";
                this.edVeDocID.Enabled = true;
                this.edVeDocID.Text = $"{SerialNumber[3]:X2} {SerialNumber[2]:X2} {SerialNumber[1]:X2} {SerialNumber[0]:X2}";
                this.edVeDocNumOfKeys.Enabled = true;
                this.edVeDocNumOfKeys.Text = $"{NumberOfKeys}";
                this.edVeDocTransponderCode.Enabled = true;
                this.edVeDocTransponderCode.Text = $"{TransponderCode[0]:X2} {TransponderCode[1]:X2} {TransponderCode[2]:X2} {TransponderCode[3]:X2} {TransponderCode[4]:X2}";
                this.cbxVeDocCalcType.Enabled = true;
                this.cbxVeDocCalcType.SelectedIndex = -1;
                this.btnVeDocCalculate.Enabled = false;
                this.edVeDocResult.Clear();
                this.edVeDocResult.Enabled = false;
                this.StopOperation();
                this.AddToLogThreadSafe(this.GetLocalizedString("strdone") + "\r\n");
            }
        }

        [return: MarshalAs(UnmanagedType.U1)]
        private unsafe bool VeDocCryptoKeySet(string MsgCaption, byte* modopt(IsImplicitlyDereferenced) ErrorCode)
        {
            if (!this.m_VeDocCryptoKeySetWasCalled)
            {
                if (!this.MRStart(MsgCaption, ErrorCode))
                {
                    return false;
                }
                if (!RunLongOperation((Command_t) 0x34, null, 0, (Command_t) 0x35, (Command_t) 0x36, 0))
                {
                    ErrorCode[0] = (byte* modopt(IsImplicitlyDereferenced)) CmdLayerGetErrorData((Command_t) 0x36);
                    return false;
                }
                if (!RunLongOperation((Command_t) 0x16, null, 0, (Command_t) 0x17, (Command_t) 0x18, 0))
                {
                    ErrorCode[0] = (byte* modopt(IsImplicitlyDereferenced)) CmdLayerGetErrorData((Command_t) 0x18);
                    return false;
                }
                this.m_VeDocCryptoKeySetWasCalled = true;
            }
            this.AskForIgnition(true, MsgCaption, true);
            return true;
        }

        private unsafe void VeDocPrepareTask()
        {
            uint num;
            int num2 = (int) stackalloc byte[___CxxQueryExceptionSize()];
            try
            {
                byte num6;
                if (!this.VeDocCryptoKeySet(this.m_LastOperationStr, &num6))
                {
                    this.VeDocCalcPrepareFailedThreadSafe(this.GetErrorExplanation(num6));
                }
                else if (RunLongOperation((Command_t) 0x9c, null, 0, (Command_t) 0x9d, (Command_t) 0x9e, 0))
                {
                    VeDocCalcParams_t _t2;
                    CmdLayerGetVeDocCalcParams(&_t2);
                    byte[] randomNumber = new byte[2];
                    int index = 0;
                    while (true)
                    {
                        if (index >= randomNumber.Length)
                        {
                            break;
                        }
                        randomNumber[index] = *((byte*) (index + &_t2));
                        index++;
                    }
                    byte[] serialNumber = new byte[4];
                    int num4 = 0;
                    while (true)
                    {
                        if (num4 >= serialNumber.Length)
                        {
                            break;
                        }
                        serialNumber[num4] = *((byte*) (num4 + (&_t2 + 2)));
                        num4++;
                    }
                    byte[] transponderCode = new byte[5];
                    int num3 = 0;
                    while (true)
                    {
                        if (num3 >= transponderCode.Length)
                        {
                            break;
                        }
                        transponderCode[num3] = *((byte*) (num3 + (&_t2 + 6)));
                        num3++;
                    }
                    this.VeDocCalcPrepareOkThreadSafe(randomNumber, serialNumber, transponderCode, *((byte*) (&_t2 + 11)));
                }
                else
                {
                    num6 = CmdLayerGetErrorData((Command_t) 0x9e);
                    this.VeDocCalcPrepareFailedThreadSafe(this.GetErrorExplanation(num6));
                }
            }
            catch (UserAborted)
            {
                this.VeDocCalcPrepareFailedThreadSafe(this.GetLocalizedString("strUserAborted"));
            }
            catch (InvalidOBDPower)
            {
                this.VeDocCalcPrepareFailedThreadSafe(this.GetLocalizedString("strInvalidOBDPower"));
            }
            catch (NoOBDPower)
            {
                this.VeDocCalcPrepareFailedThreadSafe(this.GetLocalizedString("strNoOBDPower"));
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CommandUtilsError_t _t;
                        byte errorcode = (byte) _t;
                        this.AddToLogThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(errorcode) + ")!");
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe((this.GetLocalizedString("strDeviceCommError") + " (") + this.GetErrorExplanation(errorcode) + ")!", this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CustomAssert(&??_C@_0P@JDGGEPBJ@VeDocTasks?4cpp?$AA@, 0x4f, false, null);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        this.AddToLogThreadSafe(this.GetLocalizedString("strDeviceCommLost"));
                        this.AddToLogThreadSafe("\r\n");
                        this.MessageBoxThreadSafe(this.GetLocalizedString("strDeviceCommLost"), this.GetLocalizedString("strDeviceCommError"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.DisconnectThreadSafe();
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
            catch when (?)
            {
                num = 0;
                ___CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num2);
                try
                {
                    try
                    {
                        CustomAssert(&??_C@_0P@JDGGEPBJ@VeDocTasks?4cpp?$AA@, 0x62, true, null);
                    }
                    catch when (?)
                    {
                    }
                    return;
                    if (num != 0)
                    {
                        throw;
                    }
                }
                finally
                {
                    ___CxxUnregisterExceptionObject((void*) num2, (int) num);
                }
            }
        }

        [return: MarshalAs(UnmanagedType.U1)]
        private bool WasIgnitionChanged()
        {
            this.m_WatchIgnitionChange = false;
            return this.m_WasIgnitionChanged;
        }

        private void WatchIgnitionChange()
        {
            this.m_WatchIgnitionChange = true;
            this.m_WasIgnitionChanged = false;
        }

        private delegate void AddToLogDelegate(string text);

        private enum ConnectionState_t
        {
            GoodDeviceConnected,
            BadDeviceConnected,
            OldDeviceConnected,
            GUITooOld,
            NotConnected,
            TruckConnected
        }

        private delegate void ConnectMBOkDelegate(string MRSerialNumber, string MRCertificationNumber, string MRDatasetNumber, string MRFWVersion, string FRFWVersion, string FRDiagVersion, string FRDatasetNumber);

        private delegate void DASPwdCalculateOkDelegate(uint modopt(IsLong) Password);

        private enum DeviceUpdateResult_t
        {
            SuccessUpdated,
            SuccessNoUpdates,
            FinalCheckFailed,
            Failed,
            CantConnectServer,
            BadServerResponse,
            BadServerData
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct DTCInfo_t
        {
            public string code;
            public MainForm.DTCStatus_t status;
        }

        private enum DTCStatus_t
        {
            Current,
            Stored
        }

        private class ExtraTab
        {
            public int m_ActiveOperationIdx;
            public bool m_HaveSpeedLimit;
            public bool m_HaveTorqueLimit;
            public byte modopt(IsConst) m_MaxSpeedLimit = 150;
            public List<Operation> m_OperationList;
            public byte m_SpeedLimit;
            public byte m_TorqueLimit;

            public ExtraTab()
            {
                List<Operation> modopt(IsConst) list = new List<Operation>();
                this.m_OperationList = list;
                list.Clear();
                this.m_ActiveOperationIdx = 0;
                this.m_HaveTorqueLimit = false;
                this.m_HaveSpeedLimit = false;
            }

            public void Clear()
            {
                this.m_OperationList.Clear();
                this.m_ActiveOperationIdx = 0;
                this.m_HaveTorqueLimit = false;
                this.m_HaveSpeedLimit = false;
            }

            public Operation GetActiveOperation() => 
                this.m_OperationList[this.m_ActiveOperationIdx];

            public enum Operation
            {
                GetSpeedLimit,
                SetSpeedLimit,
                GetTorqueLimit,
                SetTorqueLimit,
                EraseEmissionFaults
            }
        }

        private class InvalidOBDPower
        {
        }

        private class KeysTab
        {
            public int m_ActiveOperationIdx;
            public AddKeysType m_AddKeysType;
            public bool m_FRImmoStatus;
            public bool m_FRImmoStatus2Set;
            public bool m_FRInfoValid;
            public bool m_FRKeyDetected;
            public int m_KeysAdded;
            public bool m_MANFFRImmoStatus;
            public ushort m_MANFFRKeyStatus;
            public bool m_MANFFRSynced;
            public int modopt(IsConst) m_MANMaxNumOfKeysAllowed = 8;
            public bool m_MANPTMImmoStatus;
            public ushort m_MANPTMKeyStatus;
            public bool m_MANPTMSynced;
            public int modopt(IsConst) m_MBMaxNumOfKeysAllowed = 8;
            public ushort m_MRImmoStatusCode;
            public bool m_MRInfoValid;
            public ushort m_MRKeyStatusCode;
            public byte[] m_MRTransponderCode;
            public byte m_NumberOfKeys;
            public List<Operation> m_OperationList;

            public KeysTab()
            {
                List<Operation> modopt(IsConst) list = new List<Operation>();
                this.m_OperationList = list;
                list.Clear();
                this.m_ActiveOperationIdx = 0;
            }

            public void Clear()
            {
                this.m_OperationList.Clear();
                this.m_ActiveOperationIdx = 0;
            }

            public Operation GetActiveOperation() => 
                this.m_OperationList[this.m_ActiveOperationIdx];

            public enum AddKeysType
            {
                Add,
                EraseThenAdd
            }

            public enum Operation
            {
                MRImmoOff,
                FRImmoOff,
                FRImmoOn,
                EDCFFRPairing,
                EDCPTMPairing
            }
        }

        private enum MANMainECU_t
        {
            Unknown,
            FFR,
            PTM
        }

        private class MemoryTab
        {
            public int m_ActiveECUIdx;
            public int m_ActiveOperationIdx;
            public List<ECU> m_ECUList = new List<ECU>();
            public MemoryStream m_EEPROMA;
            public string m_EEPROMAName;
            public uint modopt(IsLong) m_EEPROMASize;
            public MemoryStream m_EEPROMB;
            public string m_EEPROMBName;
            public uint modopt(IsLong) m_EEPROMBSize;
            public MemoryStream m_Flash;
            public string m_FlashName;
            public uint modopt(IsLong) m_FlashSize;
            public Dictionary<ECU, List<Operation>> m_OperationList = new Dictionary<ECU, List<Operation>>();
            public bool m_WasAnalysed;
            public int m_WorkingEEPROMIdx;

            public MemoryTab()
            {
                this.Clear();
            }

            public void Clear()
            {
                this.m_ECUList.Clear();
                this.m_ActiveECUIdx = 0;
                this.m_OperationList.Clear();
                this.m_ActiveOperationIdx = 0;
                this.m_WasAnalysed = false;
                this.m_EEPROMBName = null;
                this.m_EEPROMAName = null;
                this.m_FlashName = null;
                this.m_EEPROMB = null;
                this.m_EEPROMA = null;
                this.m_Flash = null;
            }

            public ECU GetActiveECU() => 
                this.m_ECUList[this.m_ActiveECUIdx];

            public unsafe string GetActiveECUString()
            {
                ECU ecu = this.m_ECUList[this.m_ActiveECUIdx];
                return ((ECU) *(((int*) &ecu))).ToString();
            }

            public Operation GetActiveOperation()
            {
                ECU ecu = this.m_ECUList[this.m_ActiveECUIdx];
                return this.m_OperationList[ecu][this.m_ActiveOperationIdx];
            }

            public string GetECUString(ECU ecu) => 
                ecu.ToString();

            public enum ECU
            {
                MR,
                MCM,
                FR,
                FFR,
                PTM
            }

            public enum Operation
            {
                WriteFuelMap
            }
        }

        private delegate DialogResult MessageBoxDelegate(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon);

        private class NoOBDPower
        {
        }

        private delegate void ReadFaultsOkDelegate(MainForm.DTCInfo_t[] DTCs);

        private delegate void SetProgressBoundsDelegate(int min, int max);

        private delegate void SetProgressCommentDelegate(string comment);

        private delegate void SetProgressUndefinedDelegate();

        private delegate void SetProgressValueDelegate(int val);

        private delegate void ShowMessageBoxDelegate(string text, string caption);

        private delegate void SoftwareUpdateFinishedDelegate([MarshalAs(UnmanagedType.U1)] bool needrestart);

        private delegate void StopDeviceUpdateDelegate(MainForm.DeviceUpdateResult_t status, byte errcode, string wwwresponse);

        private delegate void TaskFailedDelegate(string ErrorString);

        private enum TruckType_t
        {
            MercedesBenz,
            MAN,
            Engine
        }

        private class UserAborted
        {
        }

        private delegate void VeDocCalcPrepareOkDelegate(byte[] RandomNumber, byte[] SerialNumber, byte[] TransponderCode, byte NumberOfKeys);
    }
}

