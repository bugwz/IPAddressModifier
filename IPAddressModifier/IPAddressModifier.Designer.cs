namespace IPAddressModifier
{
    partial class IPAddressModifier
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IPAddressModifier));
            this.adapterInfo = new System.Windows.Forms.GroupBox();
            this.adapterDNS2Text = new System.Windows.Forms.Label();
            this.adapterDNS2 = new System.Windows.Forms.Label();
            this.adapterDNS1Text = new System.Windows.Forms.Label();
            this.adapterDNS1 = new System.Windows.Forms.Label();
            this.adapterGatewayText = new System.Windows.Forms.Label();
            this.adapterGateway = new System.Windows.Forms.Label();
            this.adapterSubText = new System.Windows.Forms.Label();
            this.adapterSub = new System.Windows.Forms.Label();
            this.adapterMacText = new System.Windows.Forms.Label();
            this.adapterMac = new System.Windows.Forms.Label();
            this.adapterIPText = new System.Windows.Forms.Label();
            this.adapterIP = new System.Windows.Forms.Label();
            this.adapterNameText = new System.Windows.Forms.Label();
            this.adapterName = new System.Windows.Forms.Label();
            this.adapterList = new System.Windows.Forms.Label();
            this.adapterListText = new System.Windows.Forms.ComboBox();
            this.adapterOperate = new System.Windows.Forms.GroupBox();
            this.preview = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.submit = new System.Windows.Forms.Button();
            this.adapterInfoToM = new System.Windows.Forms.Button();
            this.adapterInfoToText = new System.Windows.Forms.ComboBox();
            this.adapterInfoTo = new System.Windows.Forms.Label();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.Instruction = new System.Windows.Forms.Label();
            this.powerby = new System.Windows.Forms.Label();
            this.adapterInfo.SuspendLayout();
            this.adapterOperate.SuspendLayout();
            this.SuspendLayout();
            // 
            // adapterInfo
            // 
            this.adapterInfo.Controls.Add(this.adapterDNS2Text);
            this.adapterInfo.Controls.Add(this.adapterDNS2);
            this.adapterInfo.Controls.Add(this.adapterDNS1Text);
            this.adapterInfo.Controls.Add(this.adapterDNS1);
            this.adapterInfo.Controls.Add(this.adapterGatewayText);
            this.adapterInfo.Controls.Add(this.adapterGateway);
            this.adapterInfo.Controls.Add(this.adapterSubText);
            this.adapterInfo.Controls.Add(this.adapterSub);
            this.adapterInfo.Controls.Add(this.adapterMacText);
            this.adapterInfo.Controls.Add(this.adapterMac);
            this.adapterInfo.Controls.Add(this.adapterIPText);
            this.adapterInfo.Controls.Add(this.adapterIP);
            this.adapterInfo.Controls.Add(this.adapterNameText);
            this.adapterInfo.Controls.Add(this.adapterName);
            this.adapterInfo.Controls.Add(this.adapterList);
            this.adapterInfo.Controls.Add(this.adapterListText);
            this.adapterInfo.Location = new System.Drawing.Point(12, 12);
            this.adapterInfo.Name = "adapterInfo";
            this.adapterInfo.Size = new System.Drawing.Size(307, 256);
            this.adapterInfo.TabIndex = 1;
            this.adapterInfo.TabStop = false;
            this.adapterInfo.Text = "网络适配器信息";
            // 
            // adapterDNS2Text
            // 
            this.adapterDNS2Text.Location = new System.Drawing.Point(119, 225);
            this.adapterDNS2Text.Name = "adapterDNS2Text";
            this.adapterDNS2Text.Size = new System.Drawing.Size(171, 12);
            this.adapterDNS2Text.TabIndex = 15;
            this.adapterDNS2Text.Text = "202.194.68.10";
            // 
            // adapterDNS2
            // 
            this.adapterDNS2.Location = new System.Drawing.Point(31, 225);
            this.adapterDNS2.Name = "adapterDNS2";
            this.adapterDNS2.Size = new System.Drawing.Size(90, 12);
            this.adapterDNS2.TabIndex = 14;
            this.adapterDNS2.Text = "备用DNS地址：";
            // 
            // adapterDNS1Text
            // 
            this.adapterDNS1Text.Location = new System.Drawing.Point(119, 196);
            this.adapterDNS1Text.Name = "adapterDNS1Text";
            this.adapterDNS1Text.Size = new System.Drawing.Size(170, 12);
            this.adapterDNS1Text.TabIndex = 13;
            this.adapterDNS1Text.Text = "202.194.64.1";
            // 
            // adapterDNS1
            // 
            this.adapterDNS1.Location = new System.Drawing.Point(31, 196);
            this.adapterDNS1.Name = "adapterDNS1";
            this.adapterDNS1.Size = new System.Drawing.Size(90, 12);
            this.adapterDNS1.TabIndex = 12;
            this.adapterDNS1.Text = "首选DNS地址：";
            // 
            // adapterGatewayText
            // 
            this.adapterGatewayText.Location = new System.Drawing.Point(119, 166);
            this.adapterGatewayText.Name = "adapterGatewayText";
            this.adapterGatewayText.Size = new System.Drawing.Size(170, 12);
            this.adapterGatewayText.TabIndex = 11;
            this.adapterGatewayText.Text = "172.17.61.251";
            // 
            // adapterGateway
            // 
            this.adapterGateway.Location = new System.Drawing.Point(31, 166);
            this.adapterGateway.Name = "adapterGateway";
            this.adapterGateway.Size = new System.Drawing.Size(86, 12);
            this.adapterGateway.TabIndex = 10;
            this.adapterGateway.Text = "网关地址：";
            // 
            // adapterSubText
            // 
            this.adapterSubText.Location = new System.Drawing.Point(119, 134);
            this.adapterSubText.Name = "adapterSubText";
            this.adapterSubText.Size = new System.Drawing.Size(170, 12);
            this.adapterSubText.TabIndex = 9;
            this.adapterSubText.Text = "255.255.255.0";
            // 
            // adapterSub
            // 
            this.adapterSub.Location = new System.Drawing.Point(31, 134);
            this.adapterSub.Name = "adapterSub";
            this.adapterSub.Size = new System.Drawing.Size(86, 12);
            this.adapterSub.TabIndex = 8;
            this.adapterSub.Text = "子网掩码：";
            // 
            // adapterMacText
            // 
            this.adapterMacText.Location = new System.Drawing.Point(117, 81);
            this.adapterMacText.Name = "adapterMacText";
            this.adapterMacText.Size = new System.Drawing.Size(186, 12);
            this.adapterMacText.TabIndex = 7;
            this.adapterMacText.Text = "5F:34:4E:3D:24:6C";
            // 
            // adapterMac
            // 
            this.adapterMac.Location = new System.Drawing.Point(31, 81);
            this.adapterMac.Name = "adapterMac";
            this.adapterMac.Size = new System.Drawing.Size(86, 12);
            this.adapterMac.TabIndex = 6;
            this.adapterMac.Text = "MAC 地址：";
            // 
            // adapterIPText
            // 
            this.adapterIPText.Location = new System.Drawing.Point(117, 105);
            this.adapterIPText.Name = "adapterIPText";
            this.adapterIPText.Size = new System.Drawing.Size(172, 12);
            this.adapterIPText.TabIndex = 5;
            this.adapterIPText.Text = "172.17.61.154";
            // 
            // adapterIP
            // 
            this.adapterIP.Location = new System.Drawing.Point(31, 105);
            this.adapterIP.Name = "adapterIP";
            this.adapterIP.Size = new System.Drawing.Size(86, 12);
            this.adapterIP.TabIndex = 4;
            this.adapterIP.Text = "IP 地址：";
            // 
            // adapterNameText
            // 
            this.adapterNameText.Location = new System.Drawing.Point(119, 57);
            this.adapterNameText.Name = "adapterNameText";
            this.adapterNameText.Size = new System.Drawing.Size(184, 12);
            this.adapterNameText.TabIndex = 3;
            this.adapterNameText.Text = "以太网";
            // 
            // adapterName
            // 
            this.adapterName.Location = new System.Drawing.Point(31, 57);
            this.adapterName.Name = "adapterName";
            this.adapterName.Size = new System.Drawing.Size(86, 12);
            this.adapterName.TabIndex = 2;
            this.adapterName.Text = "适配器名称：";
            // 
            // adapterList
            // 
            this.adapterList.AutoSize = true;
            this.adapterList.Location = new System.Drawing.Point(23, 27);
            this.adapterList.Name = "adapterList";
            this.adapterList.Size = new System.Drawing.Size(77, 12);
            this.adapterList.TabIndex = 1;
            this.adapterList.Text = "网络适配器：";
            // 
            // adapterListText
            // 
            this.adapterListText.FormattingEnabled = true;
            this.adapterListText.Location = new System.Drawing.Point(106, 24);
            this.adapterListText.Name = "adapterListText";
            this.adapterListText.Size = new System.Drawing.Size(173, 20);
            this.adapterListText.TabIndex = 0;
            this.adapterListText.SelectedIndexChanged += new System.EventHandler(this.adapterListText_SelectedIndexChanged);
            // 
            // adapterOperate
            // 
            this.adapterOperate.Controls.Add(this.preview);
            this.adapterOperate.Controls.Add(this.cancel);
            this.adapterOperate.Controls.Add(this.submit);
            this.adapterOperate.Controls.Add(this.adapterInfoToM);
            this.adapterOperate.Controls.Add(this.adapterInfoToText);
            this.adapterOperate.Controls.Add(this.adapterInfoTo);
            this.adapterOperate.Location = new System.Drawing.Point(12, 274);
            this.adapterOperate.Name = "adapterOperate";
            this.adapterOperate.Size = new System.Drawing.Size(307, 129);
            this.adapterOperate.TabIndex = 2;
            this.adapterOperate.TabStop = false;
            this.adapterOperate.Text = "操作";
            // 
            // preview
            // 
            this.preview.Location = new System.Drawing.Point(130, 58);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(69, 29);
            this.preview.TabIndex = 5;
            this.preview.Text = "预览";
            this.preview.UseVisualStyleBackColor = true;
            this.preview.Click += new System.EventHandler(this.preview_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(130, 94);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(152, 29);
            this.cancel.TabIndex = 4;
            this.cancel.Text = "退出";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(217, 58);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(65, 29);
            this.submit.TabIndex = 3;
            this.submit.Text = "应用";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // adapterInfoToM
            // 
            this.adapterInfoToM.Location = new System.Drawing.Point(16, 64);
            this.adapterInfoToM.Name = "adapterInfoToM";
            this.adapterInfoToM.Size = new System.Drawing.Size(105, 54);
            this.adapterInfoToM.TabIndex = 2;
            this.adapterInfoToM.Text = "网络适配器预选信息添加/删除";
            this.adapterInfoToM.UseVisualStyleBackColor = true;
            this.adapterInfoToM.Click += new System.EventHandler(this.adapterInfoToM_Click);
            // 
            // adapterInfoToText
            // 
            this.adapterInfoToText.FormattingEnabled = true;
            this.adapterInfoToText.Location = new System.Drawing.Point(130, 19);
            this.adapterInfoToText.Name = "adapterInfoToText";
            this.adapterInfoToText.Size = new System.Drawing.Size(151, 20);
            this.adapterInfoToText.TabIndex = 1;
            this.adapterInfoToText.SelectedIndexChanged += new System.EventHandler(this.adapterInfoToText_SelectedIndexChanged);
            // 
            // adapterInfoTo
            // 
            this.adapterInfoTo.AutoSize = true;
            this.adapterInfoTo.Location = new System.Drawing.Point(15, 23);
            this.adapterInfoTo.Name = "adapterInfoTo";
            this.adapterInfoTo.Size = new System.Drawing.Size(113, 12);
            this.adapterInfoTo.TabIndex = 0;
            this.adapterInfoTo.Text = "网络适配器修改为：";
            // 
            // openFile
            // 
            this.openFile.FileName = "openFile";
            // 
            // Instruction
            // 
            this.Instruction.AutoSize = true;
            this.Instruction.Location = new System.Drawing.Point(12, 409);
            this.Instruction.Name = "Instruction";
            this.Instruction.Size = new System.Drawing.Size(71, 12);
            this.Instruction.TabIndex = 3;
            this.Instruction.Text = "Instruction";
            this.Instruction.Click += new System.EventHandler(this.Instruction_Click);
            // 
            // powerby
            // 
            this.powerby.AutoSize = true;
            this.powerby.Location = new System.Drawing.Point(225, 409);
            this.powerby.Name = "powerby";
            this.powerby.Size = new System.Drawing.Size(95, 12);
            this.powerby.TabIndex = 4;
            this.powerby.Text = "Power By：Gavin";
            // 
            // IPAddressModifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(329, 426);
            this.Controls.Add(this.powerby);
            this.Controls.Add(this.Instruction);
            this.Controls.Add(this.adapterOperate);
            this.Controls.Add(this.adapterInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IPAddressModifier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IPAddressModifier";
            this.Load += new System.EventHandler(this.IPAddressModifier_Load);
            this.adapterInfo.ResumeLayout(false);
            this.adapterInfo.PerformLayout();
            this.adapterOperate.ResumeLayout(false);
            this.adapterOperate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox adapterInfo;
        private System.Windows.Forms.Label adapterDNS2Text;
        private System.Windows.Forms.Label adapterDNS2;
        private System.Windows.Forms.Label adapterDNS1Text;
        private System.Windows.Forms.Label adapterDNS1;
        private System.Windows.Forms.Label adapterGatewayText;
        private System.Windows.Forms.Label adapterGateway;
        private System.Windows.Forms.Label adapterSubText;
        private System.Windows.Forms.Label adapterSub;
        private System.Windows.Forms.Label adapterMacText;
        private System.Windows.Forms.Label adapterMac;
        private System.Windows.Forms.Label adapterIPText;
        private System.Windows.Forms.Label adapterIP;
        private System.Windows.Forms.Label adapterNameText;
        private System.Windows.Forms.Label adapterName;
        private System.Windows.Forms.Label adapterList;
        private System.Windows.Forms.ComboBox adapterListText;
        private System.Windows.Forms.GroupBox adapterOperate;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Button adapterInfoToM;
        private System.Windows.Forms.ComboBox adapterInfoToText;
        private System.Windows.Forms.Label adapterInfoTo;
        private System.Windows.Forms.Button preview;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.Label Instruction;
        private System.Windows.Forms.Label powerby;
    }
}

