namespace ElementaryAbsence
{
    partial class OpeningEditForm
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.dtOpen = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtClose = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dtOpen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtClose)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(13, 13);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(200, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "開始日期:";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(12, 74);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(201, 23);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "截止日期:";
            // 
            // dtOpen
            // 
            this.dtOpen.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.dtOpen.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtOpen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtOpen.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtOpen.ButtonDropDown.Visible = true;
            this.dtOpen.IsPopupCalendarOpen = false;
            this.dtOpen.Location = new System.Drawing.Point(13, 43);
            // 
            // 
            // 
            this.dtOpen.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtOpen.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtOpen.MonthCalendar.BackgroundStyle.Class = "";
            this.dtOpen.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtOpen.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtOpen.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtOpen.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtOpen.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtOpen.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtOpen.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtOpen.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtOpen.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dtOpen.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtOpen.MonthCalendar.DisplayMonth = new System.DateTime(2014, 12, 1, 0, 0, 0, 0);
            this.dtOpen.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtOpen.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtOpen.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtOpen.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtOpen.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtOpen.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dtOpen.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtOpen.MonthCalendar.TodayButtonVisible = true;
            this.dtOpen.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtOpen.Name = "dtOpen";
            this.dtOpen.Size = new System.Drawing.Size(247, 25);
            this.dtOpen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtOpen.TabIndex = 2;
            // 
            // dtClose
            // 
            this.dtClose.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.dtClose.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtClose.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtClose.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtClose.ButtonDropDown.Visible = true;
            this.dtClose.IsPopupCalendarOpen = false;
            this.dtClose.Location = new System.Drawing.Point(13, 103);
            // 
            // 
            // 
            this.dtClose.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtClose.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtClose.MonthCalendar.BackgroundStyle.Class = "";
            this.dtClose.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtClose.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtClose.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtClose.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtClose.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtClose.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtClose.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtClose.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtClose.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dtClose.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtClose.MonthCalendar.DisplayMonth = new System.DateTime(2014, 12, 1, 0, 0, 0, 0);
            this.dtClose.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtClose.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtClose.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtClose.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtClose.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtClose.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dtClose.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtClose.MonthCalendar.TodayButtonVisible = true;
            this.dtClose.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtClose.Name = "dtClose";
            this.dtClose.Size = new System.Drawing.Size(247, 25);
            this.dtClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtClose.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(105, 147);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "儲存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(186, 147);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "離開";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // OpeningEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 184);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtClose);
            this.Controls.Add(this.dtOpen);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Name = "OpeningEditForm";
            this.Text = "1~6年級請假天數輸入開放設定";
            ((System.ComponentModel.ISupportInitialize)(this.dtOpen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtOpen;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtClose;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnClose;
    }
}