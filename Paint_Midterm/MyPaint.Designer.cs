namespace Paint_Midterm
{
    partial class MyPaint
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyPaint));
            this.Shape_tb = new System.Windows.Forms.TextBox();
            this.DashStyle = new System.Windows.Forms.ComboBox();
            this.PenWidth = new System.Windows.Forms.NumericUpDown();
            this.Fill_btn = new System.Windows.Forms.Button();
            this.Fill_pl = new System.Windows.Forms.Panel();
            this.Fill_Color_btn = new System.Windows.Forms.Button();
            this.Color_btn = new System.Windows.Forms.Button();
            this.Modify_pl = new System.Windows.Forms.Panel();
            this.Shapes_pl = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.DashList = new System.Windows.Forms.ImageList(this.components);
            this.Tools_pl = new System.Windows.Forms.Panel();
            this.Modify_lb = new System.Windows.Forms.Label();
            this.Color_lb = new System.Windows.Forms.Label();
            this.Shapes_lb = new System.Windows.Forms.Label();
            this.Tools_lb = new System.Windows.Forms.Label();
            this.Mode_tb = new System.Windows.Forms.TextBox();
            this.Note_tb = new System.Windows.Forms.TextBox();
            this.Title = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.Notes_pl = new System.Windows.Forms.Panel();
            this.Notes_lb = new System.Windows.Forms.Label();
            this.Exit_btn = new System.Windows.Forms.Button();
            this.Icon_PBox = new System.Windows.Forms.PictureBox();
            this.Select_btn = new System.Windows.Forms.Button();
            this.Delete_btn = new System.Windows.Forms.Button();
            this.Save_btn = new System.Windows.Forms.Button();
            this.ZoomIn_btn = new System.Windows.Forms.Button();
            this.Group_btn = new System.Windows.Forms.Button();
            this.Clear_btn = new System.Windows.Forms.Button();
            this.ZoomOut_btn = new System.Windows.Forms.Button();
            this.Ungroup_btn = new System.Windows.Forms.Button();
            this.Circle_btn = new System.Windows.Forms.Button();
            this.Line_btn = new System.Windows.Forms.Button();
            this.Rec_btn = new System.Windows.Forms.Button();
            this.Polygon_btn = new System.Windows.Forms.Button();
            this.Arc_btn = new System.Windows.Forms.Button();
            this.Ellipse_btn = new System.Windows.Forms.Button();
            this.Freehand_btn = new System.Windows.Forms.Button();
            this.Dash_PBox = new System.Windows.Forms.PictureBox();
            this.Width_PBox = new System.Windows.Forms.PictureBox();
            this.Main_PBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PenWidth)).BeginInit();
            this.Fill_pl.SuspendLayout();
            this.Modify_pl.SuspendLayout();
            this.Shapes_pl.SuspendLayout();
            this.Tools_pl.SuspendLayout();
            this.Notes_pl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Icon_PBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dash_PBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Width_PBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_PBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Shape_tb
            // 
            this.Shape_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Shape_tb.Location = new System.Drawing.Point(111, 10);
            this.Shape_tb.Name = "Shape_tb";
            this.Shape_tb.ReadOnly = true;
            this.Shape_tb.Size = new System.Drawing.Size(174, 26);
            this.Shape_tb.TabIndex = 5;
            this.Shape_tb.Text = "NULL";
            // 
            // DashStyle
            // 
            this.DashStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.DashStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DashStyle.DropDownWidth = 150;
            this.DashStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DashStyle.FormattingEnabled = true;
            this.DashStyle.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.DashStyle.Location = new System.Drawing.Point(48, 48);
            this.DashStyle.Name = "DashStyle";
            this.DashStyle.Size = new System.Drawing.Size(132, 27);
            this.DashStyle.TabIndex = 8;
            this.toolTip.SetToolTip(this.DashStyle, "Change dash style of the shape");
            this.DashStyle.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.DashStyle_DrawItem);
            // 
            // PenWidth
            // 
            this.PenWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PenWidth.Location = new System.Drawing.Point(48, 11);
            this.PenWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PenWidth.Name = "PenWidth";
            this.PenWidth.Size = new System.Drawing.Size(132, 26);
            this.PenWidth.TabIndex = 9;
            this.toolTip.SetToolTip(this.PenWidth, "Change width of the shape");
            this.PenWidth.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.PenWidth.ValueChanged += new System.EventHandler(this.PenSize_ValueChanged);
            // 
            // Fill_btn
            // 
            this.Fill_btn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fill_btn.Location = new System.Drawing.Point(17, 52);
            this.Fill_btn.Name = "Fill_btn";
            this.Fill_btn.Size = new System.Drawing.Size(81, 29);
            this.Fill_btn.TabIndex = 14;
            this.Fill_btn.Text = "FILL: OFF";
            this.toolTip.SetToolTip(this.Fill_btn, "Change to Fill Mode");
            this.Fill_btn.UseVisualStyleBackColor = true;
            this.Fill_btn.Click += new System.EventHandler(this.Fill_btn_Click);
            // 
            // Fill_pl
            // 
            this.Fill_pl.BackColor = System.Drawing.SystemColors.Window;
            this.Fill_pl.Controls.Add(this.Fill_Color_btn);
            this.Fill_pl.Controls.Add(this.Color_btn);
            this.Fill_pl.Controls.Add(this.Fill_btn);
            this.Fill_pl.Location = new System.Drawing.Point(834, 57);
            this.Fill_pl.Name = "Fill_pl";
            this.Fill_pl.Size = new System.Drawing.Size(116, 92);
            this.Fill_pl.TabIndex = 27;
            // 
            // Fill_Color_btn
            // 
            this.Fill_Color_btn.BackColor = System.Drawing.Color.Black;
            this.Fill_Color_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Fill_Color_btn.Location = new System.Drawing.Point(58, 8);
            this.Fill_Color_btn.Name = "Fill_Color_btn";
            this.Fill_Color_btn.Size = new System.Drawing.Size(40, 40);
            this.Fill_Color_btn.TabIndex = 61;
            this.toolTip.SetToolTip(this.Fill_Color_btn, "Border Color");
            this.Fill_Color_btn.UseVisualStyleBackColor = false;
            this.Fill_Color_btn.Click += new System.EventHandler(this.Fill_Color_btn_Click);
            // 
            // Color_btn
            // 
            this.Color_btn.BackColor = System.Drawing.Color.Black;
            this.Color_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Color_btn.Location = new System.Drawing.Point(15, 8);
            this.Color_btn.Name = "Color_btn";
            this.Color_btn.Size = new System.Drawing.Size(40, 40);
            this.Color_btn.TabIndex = 60;
            this.toolTip.SetToolTip(this.Color_btn, "Border Color");
            this.Color_btn.UseVisualStyleBackColor = false;
            this.Color_btn.Click += new System.EventHandler(this.Color_btn_Click);
            // 
            // Modify_pl
            // 
            this.Modify_pl.BackColor = System.Drawing.SystemColors.Window;
            this.Modify_pl.Controls.Add(this.Dash_PBox);
            this.Modify_pl.Controls.Add(this.Width_PBox);
            this.Modify_pl.Controls.Add(this.DashStyle);
            this.Modify_pl.Controls.Add(this.PenWidth);
            this.Modify_pl.Location = new System.Drawing.Point(963, 57);
            this.Modify_pl.Name = "Modify_pl";
            this.Modify_pl.Size = new System.Drawing.Size(190, 92);
            this.Modify_pl.TabIndex = 28;
            // 
            // Shapes_pl
            // 
            this.Shapes_pl.BackColor = System.Drawing.SystemColors.Window;
            this.Shapes_pl.Controls.Add(this.button1);
            this.Shapes_pl.Controls.Add(this.Circle_btn);
            this.Shapes_pl.Controls.Add(this.Line_btn);
            this.Shapes_pl.Controls.Add(this.Rec_btn);
            this.Shapes_pl.Controls.Add(this.Polygon_btn);
            this.Shapes_pl.Controls.Add(this.Arc_btn);
            this.Shapes_pl.Controls.Add(this.Ellipse_btn);
            this.Shapes_pl.Controls.Add(this.Freehand_btn);
            this.Shapes_pl.Location = new System.Drawing.Point(636, 57);
            this.Shapes_pl.Name = "Shapes_pl";
            this.Shapes_pl.Size = new System.Drawing.Size(186, 92);
            this.Shapes_pl.TabIndex = 29;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGray;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(137, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 60;
            this.toolTip.SetToolTip(this.button1, "Arc");
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DashList
            // 
            this.DashList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("DashList.ImageStream")));
            this.DashList.TransparentColor = System.Drawing.Color.Transparent;
            this.DashList.Images.SetKeyName(0, "dash0.png");
            this.DashList.Images.SetKeyName(1, "dash1.png");
            this.DashList.Images.SetKeyName(2, "dash2.png");
            this.DashList.Images.SetKeyName(3, "dash3.png");
            this.DashList.Images.SetKeyName(4, "dash4.png");
            // 
            // Tools_pl
            // 
            this.Tools_pl.BackColor = System.Drawing.SystemColors.Window;
            this.Tools_pl.Controls.Add(this.Select_btn);
            this.Tools_pl.Controls.Add(this.Delete_btn);
            this.Tools_pl.Controls.Add(this.Save_btn);
            this.Tools_pl.Controls.Add(this.ZoomIn_btn);
            this.Tools_pl.Controls.Add(this.Group_btn);
            this.Tools_pl.Controls.Add(this.Clear_btn);
            this.Tools_pl.Controls.Add(this.ZoomOut_btn);
            this.Tools_pl.Controls.Add(this.Ungroup_btn);
            this.Tools_pl.Controls.Add(this.Shape_tb);
            this.Tools_pl.Location = new System.Drawing.Point(35, 58);
            this.Tools_pl.Name = "Tools_pl";
            this.Tools_pl.Size = new System.Drawing.Size(307, 91);
            this.Tools_pl.TabIndex = 30;
            // 
            // Modify_lb
            // 
            this.Modify_lb.AutoSize = true;
            this.Modify_lb.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Modify_lb.Location = new System.Drawing.Point(1032, 152);
            this.Modify_lb.Name = "Modify_lb";
            this.Modify_lb.Size = new System.Drawing.Size(52, 19);
            this.Modify_lb.TabIndex = 29;
            this.Modify_lb.Text = "Modify";
            // 
            // Color_lb
            // 
            this.Color_lb.AutoSize = true;
            this.Color_lb.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Color_lb.Location = new System.Drawing.Point(871, 152);
            this.Color_lb.Name = "Color_lb";
            this.Color_lb.Size = new System.Drawing.Size(42, 19);
            this.Color_lb.TabIndex = 31;
            this.Color_lb.Text = "Color";
            // 
            // Shapes_lb
            // 
            this.Shapes_lb.AutoSize = true;
            this.Shapes_lb.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Shapes_lb.Location = new System.Drawing.Point(702, 152);
            this.Shapes_lb.Name = "Shapes_lb";
            this.Shapes_lb.Size = new System.Drawing.Size(52, 19);
            this.Shapes_lb.TabIndex = 32;
            this.Shapes_lb.Text = "Shapes";
            // 
            // Tools_lb
            // 
            this.Tools_lb.AutoSize = true;
            this.Tools_lb.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tools_lb.Location = new System.Drawing.Point(169, 152);
            this.Tools_lb.Name = "Tools_lb";
            this.Tools_lb.Size = new System.Drawing.Size(40, 19);
            this.Tools_lb.TabIndex = 33;
            this.Tools_lb.Text = "Tools";
            // 
            // Mode_tb
            // 
            this.Mode_tb.BackColor = System.Drawing.SystemColors.Control;
            this.Mode_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mode_tb.Location = new System.Drawing.Point(11, 12);
            this.Mode_tb.Name = "Mode_tb";
            this.Mode_tb.ReadOnly = true;
            this.Mode_tb.Size = new System.Drawing.Size(250, 26);
            this.Mode_tb.TabIndex = 48;
            this.Mode_tb.Text = "MODE: GROUP";
            // 
            // Note_tb
            // 
            this.Note_tb.BackColor = System.Drawing.SystemColors.Control;
            this.Note_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Note_tb.Location = new System.Drawing.Point(11, 49);
            this.Note_tb.Name = "Note_tb";
            this.Note_tb.ReadOnly = true;
            this.Note_tb.Size = new System.Drawing.Size(250, 26);
            this.Note_tb.TabIndex = 49;
            this.Note_tb.Text = "NOTE: ";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(74, 17);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(165, 25);
            this.Title.TabIndex = 52;
            this.Title.Text = "Paint Application";
            // 
            // Notes_pl
            // 
            this.Notes_pl.BackColor = System.Drawing.SystemColors.Window;
            this.Notes_pl.Controls.Add(this.Mode_tb);
            this.Notes_pl.Controls.Add(this.Note_tb);
            this.Notes_pl.Location = new System.Drawing.Point(353, 57);
            this.Notes_pl.Name = "Notes_pl";
            this.Notes_pl.Size = new System.Drawing.Size(272, 92);
            this.Notes_pl.TabIndex = 62;
            // 
            // Notes_lb
            // 
            this.Notes_lb.AutoSize = true;
            this.Notes_lb.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Notes_lb.Location = new System.Drawing.Point(467, 151);
            this.Notes_lb.Name = "Notes_lb";
            this.Notes_lb.Size = new System.Drawing.Size(45, 19);
            this.Notes_lb.TabIndex = 63;
            this.Notes_lb.Text = "Notes";
            // 
            // Exit_btn
            // 
            this.Exit_btn.BackColor = System.Drawing.Color.Transparent;
            this.Exit_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Exit_btn.BackgroundImage")));
            this.Exit_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Exit_btn.Location = new System.Drawing.Point(1113, 11);
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.Size = new System.Drawing.Size(40, 40);
            this.Exit_btn.TabIndex = 60;
            this.toolTip.SetToolTip(this.Exit_btn, "Exit");
            this.Exit_btn.UseVisualStyleBackColor = false;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // Icon_PBox
            // 
            this.Icon_PBox.Image = global::Paint_Midterm.Properties.Resources.Icon;
            this.Icon_PBox.Location = new System.Drawing.Point(32, 10);
            this.Icon_PBox.Name = "Icon_PBox";
            this.Icon_PBox.Size = new System.Drawing.Size(40, 40);
            this.Icon_PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Icon_PBox.TabIndex = 50;
            this.Icon_PBox.TabStop = false;
            this.Icon_PBox.Click += new System.EventHandler(this.Icon_PBox_Click);
            // 
            // Select_btn
            // 
            this.Select_btn.BackColor = System.Drawing.Color.Transparent;
            this.Select_btn.BackgroundImage = global::Paint_Midterm.Properties.Resources.select;
            this.Select_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Select_btn.Location = new System.Drawing.Point(17, 4);
            this.Select_btn.Name = "Select_btn";
            this.Select_btn.Size = new System.Drawing.Size(40, 40);
            this.Select_btn.TabIndex = 67;
            this.toolTip.SetToolTip(this.Select_btn, "Select & Move");
            this.Select_btn.UseVisualStyleBackColor = false;
            this.Select_btn.Click += new System.EventHandler(this.Select_btn_Click);
            // 
            // Delete_btn
            // 
            this.Delete_btn.BackColor = System.Drawing.Color.Transparent;
            this.Delete_btn.BackgroundImage = global::Paint_Midterm.Properties.Resources.eraser;
            this.Delete_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Delete_btn.Location = new System.Drawing.Point(62, 4);
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.Size = new System.Drawing.Size(40, 40);
            this.Delete_btn.TabIndex = 66;
            this.toolTip.SetToolTip(this.Delete_btn, "Delete");
            this.Delete_btn.UseVisualStyleBackColor = false;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // Save_btn
            // 
            this.Save_btn.BackColor = System.Drawing.Color.Transparent;
            this.Save_btn.BackgroundImage = global::Paint_Midterm.Properties.Resources.save;
            this.Save_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Save_btn.Location = new System.Drawing.Point(17, 45);
            this.Save_btn.Name = "Save_btn";
            this.Save_btn.Size = new System.Drawing.Size(40, 40);
            this.Save_btn.TabIndex = 65;
            this.toolTip.SetToolTip(this.Save_btn, "Save");
            this.Save_btn.UseVisualStyleBackColor = false;
            this.Save_btn.Click += new System.EventHandler(this.Save_btn_Click);
            // 
            // ZoomIn_btn
            // 
            this.ZoomIn_btn.BackColor = System.Drawing.Color.Transparent;
            this.ZoomIn_btn.BackgroundImage = global::Paint_Midterm.Properties.Resources.zoomin;
            this.ZoomIn_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ZoomIn_btn.Location = new System.Drawing.Point(111, 45);
            this.ZoomIn_btn.Name = "ZoomIn_btn";
            this.ZoomIn_btn.Size = new System.Drawing.Size(40, 40);
            this.ZoomIn_btn.TabIndex = 63;
            this.toolTip.SetToolTip(this.ZoomIn_btn, "Zoom in");
            this.ZoomIn_btn.UseVisualStyleBackColor = false;
            this.ZoomIn_btn.Click += new System.EventHandler(this.ZoomIn_btn_Click);
            // 
            // Group_btn
            // 
            this.Group_btn.BackColor = System.Drawing.Color.Transparent;
            this.Group_btn.BackgroundImage = global::Paint_Midterm.Properties.Resources.group;
            this.Group_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Group_btn.Location = new System.Drawing.Point(202, 45);
            this.Group_btn.Name = "Group_btn";
            this.Group_btn.Size = new System.Drawing.Size(40, 40);
            this.Group_btn.TabIndex = 61;
            this.toolTip.SetToolTip(this.Group_btn, "Group");
            this.Group_btn.UseVisualStyleBackColor = false;
            this.Group_btn.Click += new System.EventHandler(this.Group_btn_Click);
            // 
            // Clear_btn
            // 
            this.Clear_btn.BackColor = System.Drawing.Color.Transparent;
            this.Clear_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Clear_btn.BackgroundImage")));
            this.Clear_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Clear_btn.Location = new System.Drawing.Point(62, 45);
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.Size = new System.Drawing.Size(40, 40);
            this.Clear_btn.TabIndex = 64;
            this.toolTip.SetToolTip(this.Clear_btn, "Zoom out");
            this.Clear_btn.UseVisualStyleBackColor = false;
            this.Clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // ZoomOut_btn
            // 
            this.ZoomOut_btn.BackColor = System.Drawing.Color.Transparent;
            this.ZoomOut_btn.BackgroundImage = global::Paint_Midterm.Properties.Resources.zoomout;
            this.ZoomOut_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ZoomOut_btn.Location = new System.Drawing.Point(156, 45);
            this.ZoomOut_btn.Name = "ZoomOut_btn";
            this.ZoomOut_btn.Size = new System.Drawing.Size(40, 40);
            this.ZoomOut_btn.TabIndex = 62;
            this.toolTip.SetToolTip(this.ZoomOut_btn, "Zoom out");
            this.ZoomOut_btn.UseVisualStyleBackColor = false;
            this.ZoomOut_btn.Click += new System.EventHandler(this.ZoomOut_btn_Click);
            // 
            // Ungroup_btn
            // 
            this.Ungroup_btn.BackColor = System.Drawing.Color.Transparent;
            this.Ungroup_btn.BackgroundImage = global::Paint_Midterm.Properties.Resources.ungroup;
            this.Ungroup_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Ungroup_btn.Location = new System.Drawing.Point(248, 45);
            this.Ungroup_btn.Name = "Ungroup_btn";
            this.Ungroup_btn.Size = new System.Drawing.Size(40, 40);
            this.Ungroup_btn.TabIndex = 60;
            this.toolTip.SetToolTip(this.Ungroup_btn, "Ungroup");
            this.Ungroup_btn.UseVisualStyleBackColor = false;
            this.Ungroup_btn.Click += new System.EventHandler(this.Ungroup_btn_Click);
            // 
            // Circle_btn
            // 
            this.Circle_btn.BackColor = System.Drawing.Color.Transparent;
            this.Circle_btn.BackgroundImage = global::Paint_Midterm.Properties.Resources.circle;
            this.Circle_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Circle_btn.Location = new System.Drawing.Point(8, 47);
            this.Circle_btn.Name = "Circle_btn";
            this.Circle_btn.Size = new System.Drawing.Size(40, 40);
            this.Circle_btn.TabIndex = 59;
            this.toolTip.SetToolTip(this.Circle_btn, "Circle");
            this.Circle_btn.UseVisualStyleBackColor = false;
            this.Circle_btn.Click += new System.EventHandler(this.Circle_btn_Click);
            // 
            // Line_btn
            // 
            this.Line_btn.BackColor = System.Drawing.Color.Transparent;
            this.Line_btn.BackgroundImage = global::Paint_Midterm.Properties.Resources.line;
            this.Line_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Line_btn.Location = new System.Drawing.Point(8, 4);
            this.Line_btn.Name = "Line_btn";
            this.Line_btn.Size = new System.Drawing.Size(40, 40);
            this.Line_btn.TabIndex = 58;
            this.toolTip.SetToolTip(this.Line_btn, "Line");
            this.Line_btn.UseVisualStyleBackColor = false;
            this.Line_btn.Click += new System.EventHandler(this.Line_btn_Click);
            // 
            // Rec_btn
            // 
            this.Rec_btn.BackColor = System.Drawing.Color.Transparent;
            this.Rec_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Rec_btn.BackgroundImage")));
            this.Rec_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Rec_btn.Location = new System.Drawing.Point(51, 4);
            this.Rec_btn.Name = "Rec_btn";
            this.Rec_btn.Size = new System.Drawing.Size(40, 40);
            this.Rec_btn.TabIndex = 57;
            this.toolTip.SetToolTip(this.Rec_btn, "Rectangle");
            this.Rec_btn.UseVisualStyleBackColor = false;
            this.Rec_btn.Click += new System.EventHandler(this.Rec_btn_Click);
            // 
            // Polygon_btn
            // 
            this.Polygon_btn.BackColor = System.Drawing.Color.Transparent;
            this.Polygon_btn.BackgroundImage = global::Paint_Midterm.Properties.Resources.polygon;
            this.Polygon_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Polygon_btn.Location = new System.Drawing.Point(51, 47);
            this.Polygon_btn.Name = "Polygon_btn";
            this.Polygon_btn.Size = new System.Drawing.Size(40, 40);
            this.Polygon_btn.TabIndex = 56;
            this.toolTip.SetToolTip(this.Polygon_btn, "Polygon");
            this.Polygon_btn.UseVisualStyleBackColor = false;
            this.Polygon_btn.Click += new System.EventHandler(this.Polygon_btn_Click);
            // 
            // Arc_btn
            // 
            this.Arc_btn.BackColor = System.Drawing.Color.Transparent;
            this.Arc_btn.BackgroundImage = global::Paint_Midterm.Properties.Resources.arc;
            this.Arc_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Arc_btn.Location = new System.Drawing.Point(94, 47);
            this.Arc_btn.Name = "Arc_btn";
            this.Arc_btn.Size = new System.Drawing.Size(40, 40);
            this.Arc_btn.TabIndex = 55;
            this.toolTip.SetToolTip(this.Arc_btn, "Arc");
            this.Arc_btn.UseVisualStyleBackColor = false;
            this.Arc_btn.Click += new System.EventHandler(this.Arc_btn_Click);
            // 
            // Ellipse_btn
            // 
            this.Ellipse_btn.BackColor = System.Drawing.Color.Transparent;
            this.Ellipse_btn.BackgroundImage = global::Paint_Midterm.Properties.Resources.ellipse;
            this.Ellipse_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Ellipse_btn.Location = new System.Drawing.Point(94, 4);
            this.Ellipse_btn.Name = "Ellipse_btn";
            this.Ellipse_btn.Size = new System.Drawing.Size(40, 40);
            this.Ellipse_btn.TabIndex = 54;
            this.toolTip.SetToolTip(this.Ellipse_btn, "Ellipse");
            this.Ellipse_btn.UseVisualStyleBackColor = false;
            this.Ellipse_btn.Click += new System.EventHandler(this.Ellipse_btn_Click);
            // 
            // Freehand_btn
            // 
            this.Freehand_btn.BackColor = System.Drawing.Color.Transparent;
            this.Freehand_btn.BackgroundImage = global::Paint_Midterm.Properties.Resources.paint;
            this.Freehand_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Freehand_btn.Location = new System.Drawing.Point(137, 4);
            this.Freehand_btn.Name = "Freehand_btn";
            this.Freehand_btn.Size = new System.Drawing.Size(40, 40);
            this.Freehand_btn.TabIndex = 53;
            this.toolTip.SetToolTip(this.Freehand_btn, "Freehand");
            this.Freehand_btn.UseVisualStyleBackColor = false;
            this.Freehand_btn.Click += new System.EventHandler(this.Freehand_btn_Click);
            // 
            // Dash_PBox
            // 
            this.Dash_PBox.Image = global::Paint_Midterm.Properties.Resources.dash;
            this.Dash_PBox.Location = new System.Drawing.Point(8, 46);
            this.Dash_PBox.Name = "Dash_PBox";
            this.Dash_PBox.Size = new System.Drawing.Size(28, 32);
            this.Dash_PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Dash_PBox.TabIndex = 34;
            this.Dash_PBox.TabStop = false;
            // 
            // Width_PBox
            // 
            this.Width_PBox.Image = global::Paint_Midterm.Properties.Resources.width;
            this.Width_PBox.Location = new System.Drawing.Point(8, 10);
            this.Width_PBox.Name = "Width_PBox";
            this.Width_PBox.Size = new System.Drawing.Size(28, 28);
            this.Width_PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Width_PBox.TabIndex = 33;
            this.Width_PBox.TabStop = false;
            // 
            // Main_PBox
            // 
            this.Main_PBox.BackColor = System.Drawing.SystemColors.Window;
            this.Main_PBox.Location = new System.Drawing.Point(35, 180);
            this.Main_PBox.Name = "Main_PBox";
            this.Main_PBox.Size = new System.Drawing.Size(1120, 565);
            this.Main_PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Main_PBox.TabIndex = 3;
            this.Main_PBox.TabStop = false;
            this.Main_PBox.Paint += new System.Windows.Forms.PaintEventHandler(this.Main_Panel_Paint);
            this.Main_PBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_Panel_MouseDown);
            this.Main_PBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_Panel_MouseMove);
            this.Main_PBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Main_Panel_MouseUp);
            // 
            // MyPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(1184, 775);
            this.Controls.Add(this.Notes_lb);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.Icon_PBox);
            this.Controls.Add(this.Tools_lb);
            this.Controls.Add(this.Shapes_lb);
            this.Controls.Add(this.Color_lb);
            this.Controls.Add(this.Modify_lb);
            this.Controls.Add(this.Tools_pl);
            this.Controls.Add(this.Shapes_pl);
            this.Controls.Add(this.Modify_pl);
            this.Controls.Add(this.Fill_pl);
            this.Controls.Add(this.Main_PBox);
            this.Controls.Add(this.Notes_pl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyPaint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paint";
            this.Load += new System.EventHandler(this.MyPaint_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyPaint_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MyPaint_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.PenWidth)).EndInit();
            this.Fill_pl.ResumeLayout(false);
            this.Modify_pl.ResumeLayout(false);
            this.Shapes_pl.ResumeLayout(false);
            this.Tools_pl.ResumeLayout(false);
            this.Tools_pl.PerformLayout();
            this.Notes_pl.ResumeLayout(false);
            this.Notes_pl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Icon_PBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dash_PBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Width_PBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_PBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox Main_PBox;
        private System.Windows.Forms.TextBox Shape_tb;
        private System.Windows.Forms.ComboBox DashStyle;
        private System.Windows.Forms.NumericUpDown PenWidth;
        private System.Windows.Forms.Button Fill_btn;
        private System.Windows.Forms.Panel Fill_pl;
        private System.Windows.Forms.Panel Modify_pl;
        private System.Windows.Forms.Panel Shapes_pl;
        private System.Windows.Forms.ImageList DashList;
        private System.Windows.Forms.Panel Tools_pl;
        private System.Windows.Forms.Label Modify_lb;
        private System.Windows.Forms.Label Color_lb;
        private System.Windows.Forms.Label Shapes_lb;
        private System.Windows.Forms.PictureBox Width_PBox;
        private System.Windows.Forms.PictureBox Dash_PBox;
        private System.Windows.Forms.Label Tools_lb;
        private System.Windows.Forms.TextBox Mode_tb;
        private System.Windows.Forms.TextBox Note_tb;
        private System.Windows.Forms.PictureBox Icon_PBox;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button Freehand_btn;
        private System.Windows.Forms.Button Ellipse_btn;
        private System.Windows.Forms.Button Arc_btn;
        private System.Windows.Forms.Button Polygon_btn;
        private System.Windows.Forms.Button Rec_btn;
        private System.Windows.Forms.Button Circle_btn;
        private System.Windows.Forms.Button Line_btn;
        private System.Windows.Forms.Button Fill_Color_btn;
        private System.Windows.Forms.Button Color_btn;
        private System.Windows.Forms.Button Exit_btn;
        private System.Windows.Forms.Button Ungroup_btn;
        private System.Windows.Forms.Button Group_btn;
        private System.Windows.Forms.Button ZoomIn_btn;
        private System.Windows.Forms.Button ZoomOut_btn;
        private System.Windows.Forms.Button Save_btn;
        private System.Windows.Forms.Button Clear_btn;
        private System.Windows.Forms.Button Select_btn;
        private System.Windows.Forms.Button Delete_btn;
        private System.Windows.Forms.Panel Notes_pl;
        private System.Windows.Forms.Label Notes_lb;
        private System.Windows.Forms.Button button1;
    }
}

