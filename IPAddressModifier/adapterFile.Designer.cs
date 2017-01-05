namespace IPAddressModifier
{
    partial class adapterFile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adapterFile));
            this.adapter = new System.Windows.Forms.GroupBox();
            this.newtitle = new System.Windows.Forms.Label();
            this.dns2Text = new System.Windows.Forms.TextBox();
            this.dns1Text = new System.Windows.Forms.TextBox();
            this.gatewayText = new System.Windows.Forms.TextBox();
            this.submaskText = new System.Windows.Forms.TextBox();
            this.ipText = new System.Windows.Forms.TextBox();
            this.nameText = new System.Windows.Forms.TextBox();
            this.dns2 = new System.Windows.Forms.Label();
            this.dns1 = new System.Windows.Forms.Label();
            this.gateway = new System.Windows.Forms.Label();
            this.submask = new System.Windows.Forms.Label();
            this.ip = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.adapterToListText = new System.Windows.Forms.ComboBox();
            this.adapterToList = new System.Windows.Forms.Label();
            this.update = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.deleteSelected = new System.Windows.Forms.Button();
            this.adapteraction = new System.Windows.Forms.GroupBox();
            this.adapter.SuspendLayout();
            this.adapteraction.SuspendLayout();
            this.SuspendLayout();
            // 
            // adapter
            // 
            this.adapter.Controls.Add(this.newtitle);
            this.adapter.Controls.Add(this.dns2Text);
            this.adapter.Controls.Add(this.dns1Text);
            this.adapter.Controls.Add(this.gatewayText);
            this.adapter.Controls.Add(this.submaskText);
            this.adapter.Controls.Add(this.ipText);
            this.adapter.Controls.Add(this.nameText);
            this.adapter.Controls.Add(this.dns2);
            this.adapter.Controls.Add(this.dns1);
            this.adapter.Controls.Add(this.gateway);
            this.adapter.Controls.Add(this.submask);
            this.adapter.Controls.Add(this.ip);
            this.adapter.Controls.Add(this.name);
            this.adapter.Controls.Add(this.adapterToListText);
            this.adapter.Controls.Add(this.adapterToList);
            this.adapter.Location = new System.Drawing.Point(11, 13);
            this.adapter.Name = "adapter";
            this.adapter.Size = new System.Drawing.Size(321, 236);
            this.adapter.TabIndex = 0;
            this.adapter.TabStop = false;
            this.adapter.Text = "预选适配器信息";
            // 
            // newtitle
            // 
            this.newtitle.AutoSize = true;
            this.newtitle.Location = new System.Drawing.Point(69, 26);
            this.newtitle.Name = "newtitle";
            this.newtitle.Size = new System.Drawing.Size(185, 12);
            this.newtitle.TabIndex = 14;
            this.newtitle.Text = "请输入新的网络适配器预选信息：";
            this.newtitle.Visible = false;
            // 
            // dns2Text
            // 
            this.dns2Text.Location = new System.Drawing.Point(138, 199);
            this.dns2Text.Name = "dns2Text";
            this.dns2Text.Size = new System.Drawing.Size(142, 21);
            this.dns2Text.TabIndex = 13;
            // 
            // dns1Text
            // 
            this.dns1Text.Location = new System.Drawing.Point(138, 171);
            this.dns1Text.Name = "dns1Text";
            this.dns1Text.Size = new System.Drawing.Size(142, 21);
            this.dns1Text.TabIndex = 12;
            // 
            // gatewayText
            // 
            this.gatewayText.Location = new System.Drawing.Point(138, 143);
            this.gatewayText.Name = "gatewayText";
            this.gatewayText.Size = new System.Drawing.Size(142, 21);
            this.gatewayText.TabIndex = 11;
            // 
            // submaskText
            // 
            this.submaskText.Location = new System.Drawing.Point(138, 115);
            this.submaskText.Name = "submaskText";
            this.submaskText.Size = new System.Drawing.Size(142, 21);
            this.submaskText.TabIndex = 10;
            // 
            // ipText
            // 
            this.ipText.Location = new System.Drawing.Point(138, 87);
            this.ipText.Name = "ipText";
            this.ipText.Size = new System.Drawing.Size(142, 21);
            this.ipText.TabIndex = 9;
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(138, 58);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(142, 21);
            this.nameText.TabIndex = 8;
            // 
            // dns2
            // 
            this.dns2.AutoSize = true;
            this.dns2.Location = new System.Drawing.Point(37, 204);
            this.dns2.Name = "dns2";
            this.dns2.Size = new System.Drawing.Size(83, 12);
            this.dns2.TabIndex = 7;
            this.dns2.Text = "备用DNS地址：";
            // 
            // dns1
            // 
            this.dns1.AutoSize = true;
            this.dns1.Location = new System.Drawing.Point(37, 175);
            this.dns1.Name = "dns1";
            this.dns1.Size = new System.Drawing.Size(83, 12);
            this.dns1.TabIndex = 6;
            this.dns1.Text = "首选DNS地址：";
            // 
            // gateway
            // 
            this.gateway.AutoSize = true;
            this.gateway.Location = new System.Drawing.Point(43, 147);
            this.gateway.Name = "gateway";
            this.gateway.Size = new System.Drawing.Size(65, 12);
            this.gateway.TabIndex = 5;
            this.gateway.Text = "网关地址：";
            // 
            // submask
            // 
            this.submask.AutoSize = true;
            this.submask.Location = new System.Drawing.Point(42, 120);
            this.submask.Name = "submask";
            this.submask.Size = new System.Drawing.Size(65, 12);
            this.submask.TabIndex = 4;
            this.submask.Text = "子网掩码：";
            // 
            // ip
            // 
            this.ip.AutoSize = true;
            this.ip.Location = new System.Drawing.Point(46, 91);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(59, 12);
            this.ip.TabIndex = 3;
            this.ip.Text = "IP 地址：";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(42, 63);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(65, 12);
            this.name.TabIndex = 2;
            this.name.Text = "目标名称：";
            // 
            // adapterToListText
            // 
            this.adapterToListText.FormattingEnabled = true;
            this.adapterToListText.Location = new System.Drawing.Point(114, 23);
            this.adapterToListText.Name = "adapterToListText";
            this.adapterToListText.Size = new System.Drawing.Size(166, 20);
            this.adapterToListText.TabIndex = 1;
            this.adapterToListText.SelectedIndexChanged += new System.EventHandler(this.adapterToListText_SelectedIndexChanged);
            // 
            // adapterToList
            // 
            this.adapterToList.AutoSize = true;
            this.adapterToList.Location = new System.Drawing.Point(27, 27);
            this.adapterToList.Name = "adapterToList";
            this.adapterToList.Size = new System.Drawing.Size(89, 12);
            this.adapterToList.TabIndex = 0;
            this.adapterToList.Text = "预选信息列表：";
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(181, 20);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(83, 29);
            this.update.TabIndex = 1;
            this.update.Text = "更新";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(181, 55);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(83, 29);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "关闭";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(46, 20);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(81, 29);
            this.add.TabIndex = 3;
            this.add.Text = "添加";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click_1);
            // 
            // deleteSelected
            // 
            this.deleteSelected.Location = new System.Drawing.Point(46, 55);
            this.deleteSelected.Name = "deleteSelected";
            this.deleteSelected.Size = new System.Drawing.Size(81, 29);
            this.deleteSelected.TabIndex = 4;
            this.deleteSelected.Text = "删除当前";
            this.deleteSelected.UseVisualStyleBackColor = true;
            this.deleteSelected.Click += new System.EventHandler(this.deleteSelected_Click);
            // 
            // adapteraction
            // 
            this.adapteraction.Controls.Add(this.add);
            this.adapteraction.Controls.Add(this.deleteSelected);
            this.adapteraction.Controls.Add(this.update);
            this.adapteraction.Controls.Add(this.cancel);
            this.adapteraction.Location = new System.Drawing.Point(10, 255);
            this.adapteraction.Name = "adapteraction";
            this.adapteraction.Size = new System.Drawing.Size(322, 90);
            this.adapteraction.TabIndex = 5;
            this.adapteraction.TabStop = false;
            this.adapteraction.Text = "操作方式";
            // 
            // adapterFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(344, 353);
            this.Controls.Add(this.adapteraction);
            this.Controls.Add(this.adapter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "adapterFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "网络适配器预选信息";
            this.Load += new System.EventHandler(this.adapterFile_Load);
            this.adapter.ResumeLayout(false);
            this.adapter.PerformLayout();
            this.adapteraction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox adapter;
        private System.Windows.Forms.Label ip;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.ComboBox adapterToListText;
        private System.Windows.Forms.Label adapterToList;
        private System.Windows.Forms.Label gateway;
        private System.Windows.Forms.Label submask;
        private System.Windows.Forms.Label dns1;
        private System.Windows.Forms.Label dns2;
        private System.Windows.Forms.TextBox dns2Text;
        private System.Windows.Forms.TextBox dns1Text;
        private System.Windows.Forms.TextBox gatewayText;
        private System.Windows.Forms.TextBox submaskText;
        private System.Windows.Forms.TextBox ipText;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button deleteSelected;
        private System.Windows.Forms.GroupBox adapteraction;
        private System.Windows.Forms.Label newtitle;
    }
}