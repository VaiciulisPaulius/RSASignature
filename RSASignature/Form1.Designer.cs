using System.Collections;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;

namespace RSASignature
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox rsaSignatureField;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            textInputBox = new TextBox();
            textInputBoxlabel = new Label();
            rsaSignatureField = new TextBox();
            rsaSignatureLabel = new Label();
            privateKeyLabel = new Label();
            modulusField1 = new TextBox();
            signButton = new Button();
            sendButton = new Button();
            serverAddressLabel = new Label();
            serverAddressInputBox = new TextBox();
            ipInputBoxLabel = new Label();
            ipInfoBox = new TextBox();
            modulusLabel = new Label();
            privateExponentField = new TextBox();
            exponentLabel = new Label();
            exponentLabel1 = new Label();
            publicExponentField = new TextBox();
            label2 = new Label();
            modulusField2 = new TextBox();
            label3 = new Label();
            connectToServerBtn = new Button();
            serverHostInputBox = new TextBox();
            serverHostLabel = new Label();
            statusLabel = new Label();
            SuspendLayout();
            // 
            // textInputBox
            // 
            textInputBox.Location = new Point(33, 52);
            textInputBox.Name = "textInputBox";
            textInputBox.Size = new Size(474, 23);
            textInputBox.TabIndex = 0;
            // 
            // textInputBoxlabel
            // 
            textInputBoxlabel.AutoSize = true;
            textInputBoxlabel.Location = new Point(33, 34);
            textInputBoxlabel.Name = "textInputBoxlabel";
            textInputBoxlabel.Size = new Size(190, 15);
            textInputBoxlabel.TabIndex = 1;
            textInputBoxlabel.Text = "Įveskite tekstą kuri bus siunčiamas:";
            // 
            // rsaSignatureField
            // 
            rsaSignatureField.Location = new Point(33, 168);
            rsaSignatureField.Name = "rsaSignatureField";
            rsaSignatureField.ReadOnly = true;
            rsaSignatureField.Size = new Size(474, 23);
            rsaSignatureField.TabIndex = 2;
            // 
            // rsaSignatureLabel
            // 
            rsaSignatureLabel.AutoSize = true;
            rsaSignatureLabel.Location = new Point(33, 150);
            rsaSignatureLabel.Name = "rsaSignatureLabel";
            rsaSignatureLabel.Size = new Size(143, 15);
            rsaSignatureLabel.TabIndex = 3;
            rsaSignatureLabel.Text = "Sugeneruota RSA parašas:";
            // 
            // privateKeyLabel
            // 
            privateKeyLabel.AutoSize = true;
            privateKeyLabel.Location = new Point(33, 232);
            privateKeyLabel.Name = "privateKeyLabel";
            privateKeyLabel.Size = new Size(148, 15);
            privateKeyLabel.TabIndex = 4;
            privateKeyLabel.Text = "Privataus rakto parametrai:";
            // 
            // modulusField1
            // 
            modulusField1.Location = new Point(187, 229);
            modulusField1.Name = "modulusField1";
            modulusField1.ReadOnly = true;
            modulusField1.Size = new Size(126, 23);
            modulusField1.TabIndex = 5;
            // 
            // signButton
            // 
            signButton.Location = new Point(33, 81);
            signButton.Name = "signButton";
            signButton.Size = new Size(123, 23);
            signButton.TabIndex = 8;
            signButton.Text = "Pasirašyti žinutę";
            signButton.UseVisualStyleBackColor = true;
            signButton.Click += Button1_Click;
            // 
            // sendButton
            // 
            sendButton.Location = new Point(33, 372);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(190, 33);
            sendButton.TabIndex = 9;
            sendButton.Text = "Siųsti pasirašytą žinutę į serverį";
            sendButton.UseVisualStyleBackColor = true;
            // 
            // serverAddressLabel
            // 
            serverAddressLabel.AutoSize = true;
            serverAddressLabel.Location = new Point(584, 211);
            serverAddressLabel.Name = "serverAddressLabel";
            serverAddressLabel.Size = new Size(94, 15);
            serverAddressLabel.TabIndex = 10;
            serverAddressLabel.Text = "Serverio adresas:";
            // 
            // serverAddressInputBox
            // 
            serverAddressInputBox.Location = new Point(584, 232);
            serverAddressInputBox.Name = "serverAddressInputBox";
            serverAddressInputBox.Size = new Size(202, 23);
            serverAddressInputBox.TabIndex = 11;
            // 
            // ipInputBoxLabel
            // 
            ipInputBoxLabel.AutoSize = true;
            ipInputBoxLabel.Location = new Point(528, 24);
            ipInputBoxLabel.Name = "ipInputBoxLabel";
            ipInputBoxLabel.Size = new Size(81, 15);
            ipInputBoxLabel.TabIndex = 12;
            ipInputBoxLabel.Text = "Programos ip:";
            // 
            // ipInfoBox
            // 
            ipInfoBox.Location = new Point(615, 21);
            ipInfoBox.Name = "ipInfoBox";
            ipInfoBox.ReadOnly = true;
            ipInfoBox.Size = new Size(160, 23);
            ipInfoBox.TabIndex = 13;
            // 
            // modulusLabel
            // 
            modulusLabel.AutoSize = true;
            modulusLabel.Location = new Point(219, 211);
            modulusLabel.Name = "modulusLabel";
            modulusLabel.Size = new Size(54, 15);
            modulusLabel.TabIndex = 14;
            modulusLabel.Text = "modulus";
            // 
            // privateExponentField
            // 
            privateExponentField.Location = new Point(337, 229);
            privateExponentField.Name = "privateExponentField";
            privateExponentField.ReadOnly = true;
            privateExponentField.Size = new Size(126, 23);
            privateExponentField.TabIndex = 15;
            // 
            // exponentLabel
            // 
            exponentLabel.AutoSize = true;
            exponentLabel.Location = new Point(349, 211);
            exponentLabel.Name = "exponentLabel";
            exponentLabel.Size = new Size(96, 15);
            exponentLabel.TabIndex = 16;
            exponentLabel.Text = "private exponent";
            // 
            // exponentLabel1
            // 
            exponentLabel1.AutoSize = true;
            exponentLabel1.Location = new Point(349, 275);
            exponentLabel1.Name = "exponentLabel1";
            exponentLabel1.Size = new Size(93, 15);
            exponentLabel1.TabIndex = 21;
            exponentLabel1.Text = "public exponent";
            // 
            // publicExponentField
            // 
            publicExponentField.Location = new Point(337, 293);
            publicExponentField.Name = "publicExponentField";
            publicExponentField.ReadOnly = true;
            publicExponentField.Size = new Size(126, 23);
            publicExponentField.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(219, 275);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 19;
            label2.Text = "modulus";
            // 
            // modulusField2
            // 
            modulusField2.Location = new Point(187, 293);
            modulusField2.Name = "modulusField2";
            modulusField2.ReadOnly = true;
            modulusField2.Size = new Size(126, 23);
            modulusField2.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 296);
            label3.Name = "label3";
            label3.Size = new Size(139, 15);
            label3.TabIndex = 17;
            label3.Text = "Viešaus rakto parametrai:";
            // 
            // connectToServerBtn
            // 
            connectToServerBtn.Location = new Point(584, 327);
            connectToServerBtn.Name = "connectToServerBtn";
            connectToServerBtn.Size = new Size(190, 33);
            connectToServerBtn.TabIndex = 22;
            connectToServerBtn.Text = "Prisijungti prie serverio";
            connectToServerBtn.UseVisualStyleBackColor = true;
            connectToServerBtn.Click += ConnectToServerBtn_Click;
            // 
            // serverHostInputBox
            // 
            serverHostInputBox.Location = new Point(584, 287);
            serverHostInputBox.Name = "serverHostInputBox";
            serverHostInputBox.Size = new Size(202, 23);
            serverHostInputBox.TabIndex = 24;
            // 
            // serverHostLabel
            // 
            serverHostLabel.AutoSize = true;
            serverHostLabel.Location = new Point(584, 266);
            serverHostLabel.Name = "serverHostLabel";
            serverHostLabel.Size = new Size(89, 15);
            serverHostLabel.TabIndex = 23;
            serverHostLabel.Text = "Serverio hostas:";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(584, 381);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(52, 15);
            statusLabel.TabIndex = 25;
            statusLabel.Text = "statusas:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusLabel);
            Controls.Add(serverHostInputBox);
            Controls.Add(serverHostLabel);
            Controls.Add(connectToServerBtn);
            Controls.Add(exponentLabel1);
            Controls.Add(publicExponentField);
            Controls.Add(label2);
            Controls.Add(modulusField2);
            Controls.Add(label3);
            Controls.Add(exponentLabel);
            Controls.Add(privateExponentField);
            Controls.Add(modulusLabel);
            Controls.Add(ipInfoBox);
            Controls.Add(ipInputBoxLabel);
            Controls.Add(serverAddressInputBox);
            Controls.Add(serverAddressLabel);
            Controls.Add(sendButton);
            Controls.Add(signButton);
            Controls.Add(modulusField1);
            Controls.Add(privateKeyLabel);
            Controls.Add(rsaSignatureLabel);
            Controls.Add(rsaSignatureField);
            Controls.Add(textInputBoxlabel);
            Controls.Add(textInputBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textInputBox;
        private Label textInputBoxlabel;
        private Label rsaSignatureLabel;
        private Label privateKeyLabel;
        private TextBox modulusField1;
        private Button signButton;
        private Button sendButton;
        private Label serverAddressLabel;
        private TextBox serverAddressInputBox;
        private Label ipInputBoxLabel;
        private TextBox ipInfoBox;
        private Label modulusLabel;
        private TextBox privateExponentField;
        private Label exponentLabel;
        private Label exponentLabel1;
        private TextBox publicExponentField;
        private Label label2;
        private TextBox modulusField2;
        private Label label3;
        private Button connectToServerBtn;
        private TextBox serverHostInputBox;
        private Label serverHostLabel;
        private Label statusLabel;
    }
}