using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPAddressModifier
{
    public partial class adapterFile : Form
    {
        public adapterFile()
        {
            InitializeComponent();
        }
        string[,] adapter_info = new string[20, 10];
        string[] ipAll;
        string text = "";
        string path = IPAddressModifier.ipWindow.getPath();
        int ipsinfonum = 0;
        int[] submaskValue = new int[9] { 0, 128, 192, 224, 240, 248, 252, 254, 255 };
        string reg = "^(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)\\.(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)\\.(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)\\.(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)$";
        string submaskReg = "^((255\\.255\\.255\\.(254|252|248|240|224|192|128|0))|(255\\.255\\.(254|252|248|240|224|192|128|0)\\.0)|(255\\.(254|252|248|240|224|192|128|0)\\.0\\.0)|((254|252|248|240|224|192|128|0)\\.0\\.0\\.0))$";
        //adapterFile窗体通过此方法更新adapterInfoToText的combox的items
        public void returnChange(int ipnum)
        {
            for (int i = 0; i < ipnum; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    IPAddressModifier.ipWindow.update_adapterInfoToText(i, j, ipnum, adapter_info[i, j].ToString());
                }
            }
        }
        //检测IP地址与网关地址是否处于同一网段
        private bool CheckIPMaskGateway(string ip,string mask, string gateway)
        {
            string[] maskList = mask.Split('.');
            string[] gatewayList = gateway.Split('.');
            string[] ipList = ip.Split('.');
            for (int j = 0; j < maskList.Length; j++)
            {
                if ((int.Parse(gatewayList[j]) & int.Parse(maskList[j])) != (int.Parse(ipList[j]) & int.Parse(maskList[j])))
                {
                    return false;
                }
            }
            return true;
        }
        //验证IP等信息的正则方法
        public bool ipsInfoRegular()
        {
            bool returnReg = false;
            //嵌套式自上而下判断避免出现众多弹窗影响体验
            if (nameText.Text.Length == 0 || ipText.Text.Length == 0 || submaskText.Text.Length == 0 || gatewayText.Text.Length == 0 || dns1Text.Text.Length == 0 || dns2Text.Text.Length == 0)
            {
                MessageBox.Show("所填信息不能为空！", "操作提示：");
            }
            else
            {
                if (!Regex.IsMatch(ipText.Text, @reg))
                {
                    MessageBox.Show("IP地址格式错误！", "操作提示：");
                }
                else
                {
                    //是否符合子网掩码的地址规范
                    if (!Regex.IsMatch(submaskText.Text, @submaskReg))
                    {
                        MessageBox.Show("子网掩码格式错误！", "操作提示：");
                    }
                    else
                    {
                        bool checkSegment = CheckIPMaskGateway(ipText.Text, submaskText.Text, gatewayText.Text);
                        if (!Regex.IsMatch(gatewayText.Text, @reg))
                        {
                            MessageBox.Show("网关地址格式错误！", "操作提示：");
                        }
                        else
                        {
                            //检测网段是否相同
                            if (!CheckIPMaskGateway(ipText.Text, submaskText.Text, gatewayText.Text))
                            {
                                MessageBox.Show("IP地址与网关地址不处于同一网段！", "操作提示：");
                            }
                            else
                            {
                                if (!Regex.IsMatch(dns1Text.Text, @reg))
                                {
                                    MessageBox.Show("首选DNS地址格式错误！", "操作提示：");
                                }
                                else
                                {
                                    if (!Regex.IsMatch(dns2Text.Text, @reg))
                                    {
                                        MessageBox.Show("备用DNS地址格式错误！", "操作提示：");
                                    }
                                    else
                                    {
                                        returnReg = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return returnReg;
        }
            
        //窗体加载时触发
        private void adapterFile_Load(object sender, EventArgs e)
        {
            
            if (!File.Exists(path))
            {
                FileStream fs = new FileStream(@path, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                sw.Write("目标IP的名称@MAC地址@IP地址@子网掩码@网关地址@首选DNS地址@备用DNS地址");
                sw.Close();
                fs.Close();
            }
            StreamReader sr = new StreamReader(@path, Encoding.UTF8);
            text = sr.ReadToEnd();
            sr.Close();
            ipAll = text.Split('*');
            ipsinfonum = ipAll.Length - 1;
            for (int i = 0; i < ipAll.Length; i++)
            {
                if (i >= 1)
                {
                    string[] str = ipAll[i].Split('#');
                    for (int j = 0; j < str.Length; j++)
                    {
                        if (j == 0)
                        {
                            //去除每条IP信息中第一个数据前的回车换行符
                            str[j]=str[j].Remove(0, 2);
                        }
                        adapter_info[i-1, j] = str[j];
                    }
                    adapterToListText.Items.Add(adapter_info[i-1, 0]);
                }
            }
            newtitle.Visible = false;
            if (ipsinfonum == 0)
            {
                MessageBox.Show("预选适配器信息为空，请添加！","系统提示：");
                add.PerformClick();
            }
            else
            {
                adapterToListText.SelectedIndex = 0;
            }
        }

        private void adapterToListText_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = adapterToListText.SelectedIndex;
            nameText.Text = adapter_info[num, 0];
            ipText.Text= adapter_info[num, 2];
            submaskText.Text= adapter_info[num, 3];
            gatewayText.Text= adapter_info[num, 4];
            dns1Text.Text= adapter_info[num, 5];
            dns2Text.Text= adapter_info[num, 6];
            
        }
        //点击更新按钮式触发
        private void update_Click(object sender, EventArgs e)
        {
            //根据标题是否可见判断目前的页面位置
            if (newtitle.Visible == true)
            {
                //调用正则验证的方法
                if (ipsInfoRegular())
                {
                    try
                    {
                        StreamWriter sw = new StreamWriter(@path, true, Encoding.UTF8);
                        sw.Write("*\r\n" + nameText.Text + "#FF:FF:FF:FF:FF:FF#" + ipText.Text + "#" + submaskText.Text + "#" + gatewayText.Text + "#" + dns1Text.Text + "#" + dns2Text.Text + "");
                        sw.Close();
                        ipsinfonum = ipsinfonum + 1;
                        adapterToListText.Items.Add(nameText.Text);
                        adapterToListText.Items.Clear();
                        StreamReader sr = new StreamReader(@path, Encoding.UTF8);
                        text = sr.ReadToEnd();
                        sr.Close();
                        ipAll = text.Split('*');
                        ipsinfonum = ipAll.Length - 1;
                        for (int i = 0; i < ipAll.Length; i++)
                        {
                            if (i >= 1)
                            {
                                string[] str = ipAll[i].Split('#');
                                for (int j = 0; j < str.Length; j++)
                                {
                                    if (j == 0)
                                    {
                                        str[j] = str[j].Remove(0, 2);
                                    }
                                    adapter_info[i - 1, j] = str[j];
                                }
                                adapterToListText.Items.Add(adapter_info[i - 1, 0]);
                            }
                        }
                        //利用adapterFile中的方法同步修改Form1中的adapterInfoToText这个combox中的items
                        returnChange(ipsinfonum);
                        MessageBox.Show("添加预选适配器信息成功！", "添加新信息提示：");
                    }
                    catch
                    {
                        MessageBox.Show("添加预选适配器信息失败！", "添加新信息提示：");
                    }
                }
            }
            else
            {
                int num = adapterToListText.SelectedIndex;
                if (nameText.Text == adapter_info[num, 0] && ipText.Text == adapter_info[num, 2] && submaskText.Text == adapter_info[num, 3] && gatewayText.Text == adapter_info[num, 4] && dns1Text.Text == adapter_info[num, 5] && dns2Text.Text == adapter_info[num, 6])
                {
                    MessageBox.Show("未更改任何信息！");
                }
                else
                {
                    adapter_info[num, 0] = nameText.Text;
                    adapter_info[num, 2] = ipText.Text;
                    adapter_info[num, 3] = submaskText.Text;
                    adapter_info[num, 4] = gatewayText.Text;
                    adapter_info[num, 5] = dns1Text.Text;
                    adapter_info[num, 6] = dns2Text.Text;
                    //调用正则验证的方法
                    if (ipsInfoRegular())
                    {
                        try
                        {
                            adapterToListText.Items.Clear();
                            StreamWriter sw_1 = new StreamWriter(@path, false, Encoding.UTF8);
                            sw_1.Write("目标IP的名称@MAC地址@IP地址@子网掩码@网关地址@首选DNS地址@备用DNS地址");
                            sw_1.Close();
                            StreamWriter sw = new StreamWriter(@path, true, Encoding.UTF8);
                            for (int i = 0; i < ipsinfonum; i++)
                            {
                                adapterToListText.Items.Add(adapter_info[i, 0]);
                                sw.Write("*\r\n" + adapter_info[i, 0] + "#" + adapter_info[i, 1] + "#" + adapter_info[i, 2] + "#" + adapter_info[i, 3] + "#" + adapter_info[i, 4] + "#" + adapter_info[i, 5] + "#" + adapter_info[i, 6] + "");
                            }
                            sw.Close();
                            if (ipsinfonum != 0)
                                adapterToListText.SelectedIndex = 0;
                            adapterToListText.Items.Clear();
                            StreamReader sr = new StreamReader(@path, Encoding.UTF8);
                            text = sr.ReadToEnd();
                            sr.Close();
                            ipAll = text.Split('*');
                            ipsinfonum = ipAll.Length - 1;
                            for (int i = 0; i < ipAll.Length; i++)
                            {
                                if (i >= 1)
                                {
                                    string[] str = ipAll[i].Split('#');
                                    for (int j = 0; j < str.Length; j++)
                                    {
                                        if (j == 0)
                                        {
                                            str[j] = str[j].Remove(0, 2);
                                        }
                                        adapter_info[i - 1, j] = str[j];
                                    }
                                    adapterToListText.Items.Add(adapter_info[i - 1, 0]);
                                }
                            }
                            //利用adapterFile中的方法同步修改Form1中的adapterInfoToText这个combox中的items
                            returnChange(ipsinfonum);
                            MessageBox.Show("更新预选适配器信息成功！", "更新信息提示：");
                        }
                        catch
                        {
                            MessageBox.Show("更新预选适配器信息失败！", "更新信息提示：");
                        }
                    }
                }
            }
        }
        private void add_Click_1(object sender, EventArgs e)
        {
            adapterToList.Visible = false;
            adapterToListText.Visible = false;
            newtitle.Visible = true;
            nameText.Text = "";
            ipText.Text = "";
            submaskText.Text = "";
            gatewayText.Text = "";
            dns1Text.Text = "";
            dns2Text.Text = "";
            update.Text = "保存新信息";
            cancel.Text = "返回";
            add.Enabled = false;
            deleteSelected.Enabled = false;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            if(newtitle.Visible == true)
            {
                adapterToList.Visible = true;
                adapterToListText.Visible = true;
                newtitle.Visible = false;
                update.Text = "更新";
                cancel.Text = "关闭";
                add.Enabled = true;
                deleteSelected.Enabled = true;
                try
                {
                    adapterToListText.SelectedIndex = 0;
                }
                catch { }
            }
            else
            {
                this.Close();
            }
        }
        //点击删除按钮时触发
        private void deleteSelected_Click(object sender, EventArgs e)
        {
            int delnum = adapterToListText.SelectedIndex;
            adapterToListText.Items.Clear();
            for (int i = 0; i < ipsinfonum; i++)
            {
                if (i >= delnum)
                {
                    if (i == ipsinfonum - 1)
                    {
                        for(int j = 0; j < 7; j++)
                        {
                            adapter_info[i, j] = "";
                        }
                    }
                    else
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            adapter_info[i, j] = adapter_info[i + 1, j];
                        }
                    }
                }
            }
            ipsinfonum = ipsinfonum - 1;
            try
            {
                StreamWriter sw_1 = new StreamWriter(@path, false, Encoding.UTF8);
                sw_1.Write("目标IP的名称@MAC地址@IP地址@子网掩码@网关地址@首选DNS地址@备用DNS地址");
                sw_1.Close();
                StreamWriter sw = new StreamWriter(@path, true, Encoding.UTF8);
                for (int i = 0; i < ipsinfonum; i++)
                {
                    adapterToListText.Items.Add(adapter_info[i,0]);
                    sw.Write("*\r\n" + adapter_info[i, 0] + "#" + adapter_info[i, 1] + "#" + adapter_info[i, 2] + "#" + adapter_info[i, 3] + "#" + adapter_info[i, 4] + "#" + adapter_info[i, 5] + "#" + adapter_info[i, 6] + "");
                }
                sw.Close();
                if (ipsinfonum != 0)
                    adapterToListText.SelectedIndex = 0;
                //利用adapterFile中的方法同步修改Form1中的adapterInfoToText这个combox中的items
                returnChange(ipsinfonum);
                MessageBox.Show("删除预选适配器信息成功！", "删除新信息提示：");
            }
            catch
            {
                MessageBox.Show("删除预选适配器信息失败！", "删除新信息提示：");
            }
        }
    }
}
