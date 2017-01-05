# IPAddressModifier
C#IPAddressModifier
# IP地址修改器

### 编写初衷：
在学校的时候很多时候需要更改自己电脑的IP地址，比如机房课程设计的时候，拔掉机房的网线插到自己电脑上的时候，每次都得配上机房的IP地址，下午下课回去后还得自己更改为自动获取IP地址，很是烦人。之后我曾经用过BAT的方式去修改电脑的IP地址等信息，之前用起来效果也十分不错，但是毕竟添加IP地址等信息还得去编辑BAT，也不是十分方便，对于一些小白用户来说多少也是个麻烦事，并且之前的那个BAT需要手动以管理员方式运行，也比较麻烦，为此打算用C#写一个小程序，方便的来改变电脑的IP地址等信息。

### 软件详细介绍：
该IPAddressModifier软件使用Microsoft Visual Studio 2015这款IDE使用C#进行编写，整体上只设计了两个窗体，一个是当前网络适配器详情以及预览预设置IP地址等信息的窗体，还有一个是针对预选IP地址等信息的操作窗体，整体的耗时大概一周左右，其实时间应该是两周左右，因为中间有一些考试，我还需要好好复习一下，所以一共做的时间应该是一周左右，因为本人C#的技能并不是很好，也想把这次当作C#的一次复习，所以就是边查边做了。开始进入界面，并详细介绍。

> ##### 第一个窗体截图如下：
![第一个窗体](http://ww3.sinaimg.cn/mw690/006qpCDTgw1fbfwky13tnj30970ck0t3.jpg)

打开这个窗体的时候需要使用管理员权限打开，打开时会有该软件需要管理员权限等的提示，然后就针对“管理员权限”这一点详细说明一下；之前我是在`app.manifest`中修改后的如下代码启用管理员权限：

```C#
<requestedExecutionLevel  level="requireAdministrator" uiAccess="false" />
```

因为我当初的想法是将这个软件打包发行，但是后来出现的问题是VS无法在这种情况下打包，总是出现类似于“ClickOnce”之类的错误，我尝试按照网络上一些人的建议进行修改，最后仍然会出现这种错误，最后使用在`Program.cs`文件中的设置修改如下代码完成管理员权限的赋予：

```C#
static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new IPAddressModifier());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /**
             * 当前用户是管理员的时候，直接启动应用程序
             * 如果不是管理员，则使用启动对象启动程序，以确保使用管理员身份运行
             */
            //获得当前登录的Windows用户标示
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
            //判断当前登录用户是否为管理员
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
            {
                //如果是管理员，则直接运行
                Application.Run(new IPAddressModifier());
            }
            else
            {
                //创建启动对象
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.UseShellExecute = true;
                startInfo.WorkingDirectory = Environment.CurrentDirectory;
                startInfo.FileName = Application.ExecutablePath;
                //设置启动动作,确保以管理员身份运行
                startInfo.Verb = "runas";
                try
                {
                    System.Diagnostics.Process.Start(startInfo);
                }
                catch
                {
                    return;
                }
                //退出
                Application.Exit();
            }
        }
```

> ##### 第二个窗体截图如下：

![第二个窗体](http://ww4.sinaimg.cn/mw690/006qpCDTjw1fbfw62ys31j309k0akt8z.jpg)

这个窗体中主要就是对于网络适配器的预选信息进行增加删除修改操作，需要说明的是，这些信息全部存放在本机的`C:\Windows\IPInfo.txt`中，也可以自己手动去更改其中的信息，这其中的知识点就是C#对于文件的读写操作。

需要说的一点是，在这个窗体中所做的修改会同时同步到第一个窗体中的下面的网络适配器目标信息的combox中，这里使用的方法如下：

第一个窗体中的代码如下：（重点代码以作注释标注）
```C#
public static IPAddressModifier ipWindow = null;//重点
        public IPAddressModifier()
        {
            InitializeComponent();
            ipWindow = this;//重点
        }
        string[,] adapterinfo=new string[20,10];//存放网卡信息的二维数组
        string[,] toadapterinfo = new string[20, 10];//存放目标网卡信息的二维数组
        int adapter_i=0;
        string adapterid="";
        string path= "C:\\Windows\\IPInfo.txt";//存放ip信息的路径
        adapterFile adapterF;
        //adapterFile窗体通过此方法更新adapterInfoToText的combox的items      [重点方法]

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
```

第二个窗体中的调用代码如下：

```C#
IPAddressModifier.ipWindow.update_adapterInfoToText(i, j, ipnum, adapter_info[i, j].ToString());
```


### 结束语：

其实最初的想法并没有那么复杂，只是想写一个软件来修改IP地址等信息就好了，但是出于本人的有点强迫症，这个坑感觉越挖越有点大，截止到目前为止，其实还有好多坑没填上，比如挖坑的时候还想要这个软件能够获取出所有禁用的和启用的网卡，但是目前为止只能获取到已经启用的网卡；当初还想要可以对网卡进行禁用或启用操作，现在也还没实现，但是说实话我感觉现在已经弄得很不错了，代码我已经放在[GitHub](https://github.com/CUBEGWZ/IPAddressModifier) 上了，希望大家能够多提意见，改进一下这款软件。

### 我的博客：

[Gavin's Blog](https://bugwz.com)
