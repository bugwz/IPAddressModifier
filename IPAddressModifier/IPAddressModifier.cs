using System;
using System.Drawing;
using System.IO;
using System.Management;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
namespace IPAddressModifier
{
    public partial class IPAddressModifier : Form
    {
        public static IPAddressModifier ipWindow = null;
        public IPAddressModifier()
        {
            InitializeComponent();
            ipWindow = this;
        }
        string[,] adapterinfo=new string[20,10];//存放网卡信息的二维数组
        string[,] toadapterinfo = new string[20, 10];//存放目标网卡信息的二维数组
        int adapter_i=0;
        string adapterid="";
        string path= "C:\\Windows\\IPInfo.txt";//存放ip信息的路径
        adapterFile adapterF;
        //adapterFile窗体通过此方法更新adapterInfoToText的combox的items
        public void update_adapterInfoToText(int i,int j,int inum,string str)
        {
            //MessageBox.Show(i.ToString()+"dadad");
            if (i == 0 && j==0)
            {
                adapterInfoToText.Items.Clear();//先清空，添加items之前必须清空一次
                adapterInfoToText.Items.Add(toadapterinfo[0, 0]);
                toadapterinfo[i + 1, 0] = str;
                adapterInfoToText.Items.Add(toadapterinfo[i + 1, 0]);
            }
            else
            {
                toadapterinfo[i + 1, j] = str;
                if (j == 0)
                {
                    adapterInfoToText.Items.Add(toadapterinfo[i + 1, 0]);
                }
            }
            if (i == inum-1)
            {
                adapterListText.SelectedIndex = 0;
                adapterInfoToText.SelectedIndex = 0;
                changeColor("black");
                try
                {
                    for (int n = 0; n < 7; n++)
                    {
                        changeText(n, adapterinfo[0, n]);
                    }
                }catch { }
            }
        }
        public string  getPath()
        {
            return this.path;
        }
        // 改变字体颜色方法
        public void changeColor(string color)
        {
            if (color == "black")
            {
                //将当前网卡的信息显示后设置为黑色字体
                adapterIPText.ForeColor = Color.Black;
                adapterSubText.ForeColor = Color.Black;
                adapterGatewayText.ForeColor = Color.Black;
                adapterDNS1Text.ForeColor = Color.Black;
                adapterDNS2Text.ForeColor = Color.Black;
            }
            else if (color == "red")
            {
                //预览时设置字体颜色为红色
                adapterIPText.ForeColor = Color.Red;
                adapterSubText.ForeColor = Color.Red;
                adapterGatewayText.ForeColor = Color.Red;
                adapterDNS1Text.ForeColor = Color.Red;
                adapterDNS2Text.ForeColor = Color.Red;
            }
            else
            {

            }
        }
        //改变IP项对应的文字
        public void changeText(int i,string text)
        {
            switch (i)
            {
                case 0: adapterNameText.Text=text; break;
                case 1: adapterMacText.Text = text;break;
                case 2: adapterIPText.Text = text;break;
                case 3: adapterSubText.Text = text; break;
                case 4: adapterGatewayText.Text = text; break;
                case 5: adapterDNS1Text.Text = text; break;
                case 6: adapterDNS2Text.Text = text; break;
                default :MessageBox.Show("不存在对应的IP信息项！","系统提示：");break;
            }
        }
        //点击当前网卡的列表并选中其中一个
        private void adapterListText_SelectedIndexChanged(object sender, EventArgs e)
        {
            //将adapterListText的信息显示在对应的位置
            int adapterListTextnum = adapterListText.SelectedIndex;
            for(int i = 0; i < 7; i++)
            {
                changeText(i, adapterinfo[adapterListTextnum,i]);
            }
            changeColor("black");
            //记录当前网卡的ID，便于对该网卡的IP等信息进行更新
            adapterid = adapterinfo[adapterListTextnum, 7];
        }
        //点击"预览"按钮
        private void preview_Click(object sender, EventArgs e)
        {
            //将目标信息在对应栏目上显示出来
            int num = adapterInfoToText.SelectedIndex;
            for(int i = 2; i < 7; i++)
            {
                changeText(i, toadapterinfo[num, i]);
            }
            changeColor("red");
            
        }

        //点击"应用"按钮时触发
        private void submit_Click(object sender, EventArgs e)
        {
            ManagementClass wmi = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = wmi.GetInstances();
            ManagementBaseObject inPar = null;
            ManagementBaseObject outPar = null;
            //获取要设置的目标网卡信息-IP-子网掩码-网关-DNS1-DNS2
            int num = adapterInfoToText.SelectedIndex;
            string ip = toadapterinfo[num,2];
            string submask = toadapterinfo[num, 3];
            string way = toadapterinfo[num, 4] ;
            string dns1 = toadapterinfo[num, 5];
            string dns2 = toadapterinfo[num, 6];

            foreach (ManagementObject mo in moc)
            {
                //遍历每个当前的网卡信息并与要更改的网卡进行匹配便于进行设置
                string nicid = mo.GetPropertyValue("SettingID").ToString();
                if (nicid == toadapterinfo[num, 7])
                {
                    //如果没有启用IP设置的网络设备则跳过
                    if (!(bool)mo["IPEnabled"])
                    {
                        MessageBox.Show("当前网卡未启用IP设置，无法进行IP修改操作！","设置提示：");
                    }else
                    {
                        //设置非"自动获取IP"之外的IP信息
                        if (num != 0)
                        {
                            try
                            {
                                //设置IP地址和子网掩码
                                inPar = mo.GetMethodParameters("EnableStatic");
                                inPar["IPAddress"] = new string[] { ip };
                                inPar["SubnetMask"] = new string[] { submask };
                                outPar = mo.InvokeMethod("EnableStatic", inPar, null);
                                //设置网关地址
                                inPar = mo.GetMethodParameters("SetGateways");
                                inPar["DefaultIPGateway"] = new string[] { way };
                                mo.InvokeMethod("SetGateways", inPar, null);
                                //设置DNS   
                                inPar = mo.GetMethodParameters("SetDNSServerSearchOrder");
                                string[] dns = new string[] { dns1, dns2 };
                                inPar["DNSServerSearchOrder"] = dns;
                                mo.InvokeMethod("SetDNSServerSearchOrder", inPar, null);
                                MessageBox.Show("当前适配器设置<" + toadapterinfo[num, 0] + ">成功！", "设置提示：");
                            }
                            catch
                            {
                                MessageBox.Show("当前适配器设置<" + toadapterinfo[num, 0] + ">失败！", "设置提示：");
                            }
                        }
                        //设置网卡为"自动获取IP地址"
                        else
                        {
                            try
                            {
                                mo.InvokeMethod("SetDNSServerSearchOrder", null);
                                mo.InvokeMethod("EnableStatic", null);
                                mo.InvokeMethod("SetGateways", null);
                                mo.InvokeMethod("EnableDHCP", null);
                                MessageBox.Show("当前适配器设置<" + toadapterinfo[num, 0] + ">成功！", "设置提示：");
                            }
                            catch
                            {
                                MessageBox.Show("当前适配器设置<" + toadapterinfo[num, 0] + ">失败！", "设置提示：");
                            }
                        }
                    }
                }
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void adapterInfoToText_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取目标项的序号
            int adapterInfoToTextnum = adapterInfoToText.SelectedIndex;
            adapterInfoToText.SelectedItem = adapterInfoToTextnum;

            toadapterinfo[adapterInfoToTextnum, 7] = adapterinfo[adapterListText.SelectedIndex,7];
            //MessageBox.Show(toadapterinfo[adapterInfoToTextnum, 7]);
        }

        private void IPAddressModifier_Load(object sender, EventArgs e)
        {
            //本地计算机上的网络接口的对象
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in nics)
            {
                adapterListText.Items.Add(adapter.Name);//list添加节点
                adapterinfo[adapter_i,0] = adapter.Name;//适配器名称，数组第一个
                string mac = adapter.GetPhysicalAddress().ToString();//适配器mac地址
                //格式化mac地址，数组第二个
                try
                {
                    adapterinfo[adapter_i, 1] = mac.Substring(0, 2)+":"+ mac.Substring(2, 2)+":"+ mac.Substring(4, 2)+":"+ mac.Substring(6, 2)+":"+ mac.Substring(8, 2)+":"+ mac.Substring(10, 2);//MAC地址
                }
                catch{
                    adapterinfo[adapter_i, 1] = "00:00:00:00:00:00";
                }
                IPInterfaceProperties ip = adapter.GetIPProperties();     //IP配置信息//获取单播地址集
                UnicastIPAddressInformationCollection ipCollection = ip.UnicastAddresses;
                foreach (UnicastIPAddressInformation ipadd in ipCollection)
                {
                    if (ipadd.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        adapterinfo[adapter_i,2] = ipadd.Address.ToString();//IP地址，数组第三个
                        adapterinfo[adapter_i,3] = ipadd.IPv4Mask.ToString();//子网掩码，数组第四个
                    }
                }
                //获取网关，当有多个网关的时候只获取其中一个网关，同时避免了0.0.0.0网关的情况
                //数组第五个
                string ipGateway="";
                int ipGatewayNum=ip.GatewayAddresses.Count;
                if (ip.GatewayAddresses.Count == 0)
                {
                    ipGateway = "0.0.0.0";
                }
                while (--ipGatewayNum>=0)
                {
                    if (ip.GatewayAddresses[ipGatewayNum].Address.ToString() != "0.0.0.0")
                    {
                        ipGateway = ip.GatewayAddresses[ipGatewayNum].Address.ToString();
                    }
                }
                adapterinfo[adapter_i, 4] = ipGateway;//默认网关
                //获取两个dns信息
                int DnsCount = ip.DnsAddresses.Count;
                //其中第一个为首选DNS，第二个为备用的，余下的所有DNS为DNS备用，按使用顺序排列
                //数组第六个第七个
                for (int i = 0; i < 2; i++)
                {
                    //防止只有一个dns的情况，确保dns占用数组两个位置
                    if (DnsCount == 1 && i==1)
                    {
                        adapterinfo[adapter_i, 5] = "0.0.0.0";//DNS地址
                    }
                    try
                    {
                        adapterinfo[adapter_i, 4+i] = ip.DnsAddresses[i].ToString();//DNS地址
                    }
                    catch
                    {
                        adapterinfo[adapter_i, 4+i] = "0.0.0.0";
                    }
                }
                adapterinfo[adapter_i, 7] = adapter.Id;
                adapter_i++;
            }
            string text="";
            if (!File.Exists(path)){
                FileStream fs = new FileStream(@path, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                sw.Write("目标IP的名称@MAC地址@IP地址@子网掩码@网关地址@首选DNS地址@备用DNS地址");
                sw.Close();
                fs.Close();
            }
            StreamReader sr = new StreamReader(@path, Encoding.UTF8);
            text = sr.ReadToEnd();
            sr.Close();

            //预设置的自动获取IP地址
            toadapterinfo[0, 0] = "自动获取IP地址";
            
            toadapterinfo[0, 1] = "00:00:00:00:00:00";
            for(int i = 2; i < 7; i++)
            {
                toadapterinfo[0, i] = "0.0.0.0";
            }
            adapterInfoToText.Items.Add(toadapterinfo[0, 0]);
            //MessageBox.Show(text);//显示全部字符串
            string[] ipAll = text.Split('*');
            //MessageBox.Show(ipAll.Length.ToString());
            for(int i = 0; i < ipAll.Length; i++)
            {
                if (i >= 1)
                {
                    string []str = ipAll[i].Split('#');
                    for(int j = 0; j < str.Length; j++)
                    {
                        if (j == 0)
                        {
                            str[j]= str[j].Remove(0, 2);
                        }
                        toadapterinfo[i, j] = str[j];
                    }
                    //MessageBox.Show(toadapterinfo[i-1,6].ToString());
                    adapterInfoToText.Items.Add(toadapterinfo[i, 0]);
                }
            }
            adapterListText.SelectedIndex = 0;
            adapterInfoToText.SelectedIndex = 0;

            //设置label中的值的字体居中
            adapterNameText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            adapterMacText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            adapterIPText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            adapterSubText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            adapterGatewayText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            adapterDNS1Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            adapterDNS2Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            //设置label中的键的字体居中
            adapterName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            adapterMac.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            adapterIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            adapterSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            adapterGateway.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            adapterDNS1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            adapterDNS2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        }
        //点击"网络适配器预选信息添加/删除"
        private void adapterInfoToM_Click(object sender, EventArgs e)
        {
            //判断窗体对象是否为空，不存在则创建
            if (adapterF == null)
            {
                adapterF = new adapterFile();
                adapterF.StartPosition = FormStartPosition.CenterScreen;
                adapterF.Show();
            }
            else
            {
                if (adapterF.IsDisposed)
                {
                    adapterF = new adapterFile();
                    adapterF.StartPosition = FormStartPosition.CenterScreen;
                    adapterF.Show();
                }else
                {
                    adapterF.WindowState = FormWindowState.Normal;
                    //设置窗体为当前活动的窗体
                    adapterF.Activate();
                    adapterF.Show();
                }
            }
        }
        private void Instruction_Click(object sender, EventArgs e)
        {
            MessageBox.Show("录入的IP地址等信息存放路径为：\r\n\""+path+"\"", "Instruction");
        }
    }
}