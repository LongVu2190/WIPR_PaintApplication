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
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Freehand_btn = new System.Windows.Forms.PictureBox();
            this.Polygon_btn = new System.Windows.Forms.PictureBox();
            this.Circle_btn = new System.Windows.Forms.PictureBox();
            this.Rec_btn = new System.Windows.Forms.PictureBox();
            this.Ellipse_btn = new System.Windows.Forms.PictureBox();
            this.Line_btn = new System.Windows.Forms.PictureBox();
            this.DashList = new System.Windows.Forms.ImageList(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.Save_btn = new System.Windows.Forms.PictureBox();
            this.Select_btn = new System.Windows.Forms.PictureBox();
            this.Ungroup_btn = new System.Windows.Forms.PictureBox();
            this.Group_btn = new System.Windows.Forms.PictureBox();
            this.ZoomOut_btn = new System.Windows.Forms.PictureBox();
            this.ZoomIn_btn = new System.Windows.Forms.PictureBox();
            this.Clear_btn = new System.Windows.Forms.PictureBox();
            this.Delete_btn = new System.Windows.Forms.PictureBox();
            this.Modify_lb = new System.Windows.Forms.Label();
            this.Color_lb = new System.Windows.Forms.Label();
            this.Shapes_lb = new System.Windows.Forms.Label();
            this.Tools_lb = new System.Windows.Forms.Label();
            this.Mode_tb = new System.Windows.Forms.TextBox();
            this.Note_tb = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Exit_btn = new System.Windows.Forms.PictureBox();
            this.Main_PBox = new System.Windows.Forms.PictureBox();
            this.Title = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PenWidth)).BeginInit();
            this.Fill_pl.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Freehand_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Polygon_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Circle_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rec_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ellipse_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Line_btn)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Save_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Select_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ungroup_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Group_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomOut_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomIn_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Clear_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Delete_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_PBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Shape_tb
            // 
            this.Shape_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Shape_tb.Location = new System.Drawing.Point(127, 13);
            this.Shape_tb.Name = "Shape_tb";
            this.Shape_tb.ReadOnly = true;
            this.Shape_tb.Size = new System.Drawing.Size(160, 26);
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
            this.DashStyle.Location = new System.Drawing.Point(55, 48);
            this.DashStyle.Name = "DashStyle";
            this.DashStyle.Size = new System.Drawing.Size(132, 27);
            this.DashStyle.TabIndex = 8;
            this.toolTip.SetToolTip(this.DashStyle, "Change dash style of the shape");
            this.DashStyle.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.DashStyle_DrawItem);
            // 
            // PenWidth
            // 
            this.PenWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PenWidth.Location = new System.Drawing.Point(55, 11);
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
            this.Fill_btn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fill_btn.Location = new System.Drawing.Point(21, 57);
            this.Fill_btn.Name = "Fill_btn";
            this.Fill_btn.Size = new System.Drawing.Size(75, 23);
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
            this.Fill_pl.Controls.Add(this.Fill_btn);
            this.Fill_pl.Controls.Add(this.Color_btn);
            this.Fill_pl.Location = new System.Drawing.Point(806, 57);
            this.Fill_pl.Name = "Fill_pl";
            this.Fill_pl.Size = new System.Drawing.Size(116, 92);
            this.Fill_pl.TabIndex = 27;
            // 
            // Fill_Color_btn
            // 
            this.Fill_Color_btn.BackColor = System.Drawing.Color.Black;
            this.Fill_Color_btn.Location = new System.Drawing.Point(61, 14);
            this.Fill_Color_btn.Name = "Fill_Color_btn";
            this.Fill_Color_btn.Size = new System.Drawing.Size(35, 35);
            this.Fill_Color_btn.TabIndex = 50;
            this.toolTip.SetToolTip(this.Fill_Color_btn, "Fill Color");
            this.Fill_Color_btn.UseVisualStyleBackColor = false;
            this.Fill_Color_btn.Click += new System.EventHandler(this.Fill_Color_btn_Click);
            // 
            // Color_btn
            // 
            this.Color_btn.BackColor = System.Drawing.Color.Black;
            this.Color_btn.Location = new System.Drawing.Point(20, 14);
            this.Color_btn.Name = "Color_btn";
            this.Color_btn.Size = new System.Drawing.Size(35, 35);
            this.Color_btn.TabIndex = 15;
            this.toolTip.SetToolTip(this.Color_btn, "Border Color");
            this.Color_btn.UseVisualStyleBackColor = false;
            this.Color_btn.Click += new System.EventHandler(this.Color_btn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.DashStyle);
            this.panel2.Controls.Add(this.PenWidth);
            this.panel2.Location = new System.Drawing.Point(942, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(213, 92);
            this.panel2.TabIndex = 28;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Paint_Midterm.Properties.Resources.dash;
            this.pictureBox2.Location = new System.Drawing.Point(15, 46);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Paint_Midterm.Properties.Resources.width;
            this.pictureBox1.Location = new System.Drawing.Point(15, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Controls.Add(this.Freehand_btn);
            this.panel3.Controls.Add(this.Polygon_btn);
            this.panel3.Controls.Add(this.Circle_btn);
            this.panel3.Controls.Add(this.Rec_btn);
            this.panel3.Controls.Add(this.Ellipse_btn);
            this.panel3.Controls.Add(this.Line_btn);
            this.panel3.Location = new System.Drawing.Point(627, 57);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(157, 92);
            this.panel3.TabIndex = 29;
            // 
            // Freehand_btn
            // 
            this.Freehand_btn.Image = global::Paint_Midterm.Properties.Resources.arc;
            this.Freehand_btn.Location = new System.Drawing.Point(107, 47);
            this.Freehand_btn.Name = "Freehand_btn";
            this.Freehand_btn.Size = new System.Drawing.Size(36, 36);
            this.Freehand_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Freehand_btn.TabIndex = 40;
            this.Freehand_btn.TabStop = false;
            this.toolTip.SetToolTip(this.Freehand_btn, "Draw a Freehand");
            this.Freehand_btn.Click += new System.EventHandler(this.Freehand_btn_Click);
            // 
            // Polygon_btn
            // 
            this.Polygon_btn.Image = global::Paint_Midterm.Properties.Resources.polygon;
            this.Polygon_btn.Location = new System.Drawing.Point(60, 45);
            this.Polygon_btn.Name = "Polygon_btn";
            this.Polygon_btn.Size = new System.Drawing.Size(40, 40);
            this.Polygon_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Polygon_btn.TabIndex = 39;
            this.Polygon_btn.TabStop = false;
            this.toolTip.SetToolTip(this.Polygon_btn, "Draw a Polygon");
            this.Polygon_btn.Click += new System.EventHandler(this.Polygon_btn_Click);
            // 
            // Circle_btn
            // 
            this.Circle_btn.Image = global::Paint_Midterm.Properties.Resources.circle;
            this.Circle_btn.Location = new System.Drawing.Point(14, 45);
            this.Circle_btn.Name = "Circle_btn";
            this.Circle_btn.Size = new System.Drawing.Size(40, 40);
            this.Circle_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Circle_btn.TabIndex = 38;
            this.Circle_btn.TabStop = false;
            this.toolTip.SetToolTip(this.Circle_btn, "Draw a Circle");
            this.Circle_btn.Click += new System.EventHandler(this.Circle_btn_Click);
            // 
            // Rec_btn
            // 
            this.Rec_btn.Image = global::Paint_Midterm.Properties.Resources.rec;
            this.Rec_btn.Location = new System.Drawing.Point(60, 5);
            this.Rec_btn.Name = "Rec_btn";
            this.Rec_btn.Size = new System.Drawing.Size(40, 40);
            this.Rec_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Rec_btn.TabIndex = 37;
            this.Rec_btn.TabStop = false;
            this.toolTip.SetToolTip(this.Rec_btn, "Draw a Rectangle");
            this.Rec_btn.Click += new System.EventHandler(this.Rec_btn_Click);
            // 
            // Ellipse_btn
            // 
            this.Ellipse_btn.Image = global::Paint_Midterm.Properties.Resources.ellipse;
            this.Ellipse_btn.Location = new System.Drawing.Point(106, 5);
            this.Ellipse_btn.Name = "Ellipse_btn";
            this.Ellipse_btn.Size = new System.Drawing.Size(40, 40);
            this.Ellipse_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Ellipse_btn.TabIndex = 36;
            this.Ellipse_btn.TabStop = false;
            this.toolTip.SetToolTip(this.Ellipse_btn, "Draw a Ellipse");
            this.Ellipse_btn.Click += new System.EventHandler(this.Ellipse_btn_Click);
            // 
            // Line_btn
            // 
            this.Line_btn.Image = global::Paint_Midterm.Properties.Resources.line;
            this.Line_btn.Location = new System.Drawing.Point(14, 6);
            this.Line_btn.Name = "Line_btn";
            this.Line_btn.Size = new System.Drawing.Size(40, 40);
            this.Line_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Line_btn.TabIndex = 35;
            this.Line_btn.TabStop = false;
            this.toolTip.SetToolTip(this.Line_btn, "Draw a Line");
            this.Line_btn.Click += new System.EventHandler(this.Line_btn_Click);
            // 
            // DashList
            // 
            this.DashList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("DashList.ImageStream")));
            this.DashList.TransparentColor = System.Drawing.Color.Transparent;
            this.DashList.Images.SetKeyName(0, "0.png");
            this.DashList.Images.SetKeyName(1, "1.png");
            this.DashList.Images.SetKeyName(2, "2.png");
            this.DashList.Images.SetKeyName(3, "3.png");
            this.DashList.Images.SetKeyName(4, "4.png");
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Window;
            this.panel4.Controls.Add(this.Save_btn);
            this.panel4.Controls.Add(this.Select_btn);
            this.panel4.Controls.Add(this.Ungroup_btn);
            this.panel4.Controls.Add(this.Group_btn);
            this.panel4.Controls.Add(this.ZoomOut_btn);
            this.panel4.Controls.Add(this.ZoomIn_btn);
            this.panel4.Controls.Add(this.Clear_btn);
            this.panel4.Controls.Add(this.Delete_btn);
            this.panel4.Controls.Add(this.Shape_tb);
            this.panel4.Location = new System.Drawing.Point(35, 58);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(307, 91);
            this.panel4.TabIndex = 30;
            // 
            // Save_btn
            // 
            this.Save_btn.Image = global::Paint_Midterm.Properties.Resources.save;
            this.Save_btn.Location = new System.Drawing.Point(22, 48);
            this.Save_btn.Name = "Save_btn";
            this.Save_btn.Size = new System.Drawing.Size(33, 33);
            this.Save_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Save_btn.TabIndex = 48;
            this.Save_btn.TabStop = false;
            this.toolTip.SetToolTip(this.Save_btn, "Save the drawn picture");
            this.Save_btn.Click += new System.EventHandler(this.Save_btn_Click);
            // 
            // Select_btn
            // 
            this.Select_btn.Image = global::Paint_Midterm.Properties.Resources.select;
            this.Select_btn.Location = new System.Drawing.Point(18, 5);
            this.Select_btn.Name = "Select_btn";
            this.Select_btn.Size = new System.Drawing.Size(40, 40);
            this.Select_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Select_btn.TabIndex = 47;
            this.Select_btn.TabStop = false;
            this.toolTip.SetToolTip(this.Select_btn, "Select or Move a shape");
            this.Select_btn.Click += new System.EventHandler(this.Select_btn_Click);
            // 
            // Ungroup_btn
            // 
            this.Ungroup_btn.BackColor = System.Drawing.SystemColors.Window;
            this.Ungroup_btn.Image = global::Paint_Midterm.Properties.Resources.ungroup;
            this.Ungroup_btn.Location = new System.Drawing.Point(252, 45);
            this.Ungroup_btn.Name = "Ungroup_btn";
            this.Ungroup_btn.Size = new System.Drawing.Size(35, 35);
            this.Ungroup_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Ungroup_btn.TabIndex = 46;
            this.Ungroup_btn.TabStop = false;
            this.toolTip.SetToolTip(this.Ungroup_btn, "Ungroup the selecting shape");
            this.Ungroup_btn.Click += new System.EventHandler(this.Ungroup_btn_Click);
            // 
            // Group_btn
            // 
            this.Group_btn.Image = global::Paint_Midterm.Properties.Resources.group;
            this.Group_btn.Location = new System.Drawing.Point(211, 45);
            this.Group_btn.Name = "Group_btn";
            this.Group_btn.Size = new System.Drawing.Size(35, 35);
            this.Group_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Group_btn.TabIndex = 45;
            this.Group_btn.TabStop = false;
            this.toolTip.SetToolTip(this.Group_btn, "Group shapes");
            this.Group_btn.Click += new System.EventHandler(this.Group_btn_Click);
            // 
            // ZoomOut_btn
            // 
            this.ZoomOut_btn.Image = global::Paint_Midterm.Properties.Resources.zoomout;
            this.ZoomOut_btn.Location = new System.Drawing.Point(170, 45);
            this.ZoomOut_btn.Name = "ZoomOut_btn";
            this.ZoomOut_btn.Size = new System.Drawing.Size(35, 35);
            this.ZoomOut_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ZoomOut_btn.TabIndex = 44;
            this.ZoomOut_btn.TabStop = false;
            this.toolTip.SetToolTip(this.ZoomOut_btn, "Zoom out the selecting shape");
            this.ZoomOut_btn.Click += new System.EventHandler(this.ZoomOut_btn_Click);
            // 
            // ZoomIn_btn
            // 
            this.ZoomIn_btn.Image = global::Paint_Midterm.Properties.Resources.zoomin;
            this.ZoomIn_btn.Location = new System.Drawing.Point(127, 45);
            this.ZoomIn_btn.Name = "ZoomIn_btn";
            this.ZoomIn_btn.Size = new System.Drawing.Size(35, 35);
            this.ZoomIn_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ZoomIn_btn.TabIndex = 43;
            this.ZoomIn_btn.TabStop = false;
            this.toolTip.SetToolTip(this.ZoomIn_btn, "Zoom in the selecting shape");
            this.ZoomIn_btn.Click += new System.EventHandler(this.ZoomIn_btn_Click);
            // 
            // Clear_btn
            // 
            this.Clear_btn.Image = global::Paint_Midterm.Properties.Resources.clear;
            this.Clear_btn.Location = new System.Drawing.Point(68, 43);
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.Size = new System.Drawing.Size(40, 40);
            this.Clear_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Clear_btn.TabIndex = 42;
            this.Clear_btn.TabStop = false;
            this.toolTip.SetToolTip(this.Clear_btn, "Clear all shapes");
            this.Clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // Delete_btn
            // 
            this.Delete_btn.Image = global::Paint_Midterm.Properties.Resources.eraser;
            this.Delete_btn.Location = new System.Drawing.Point(70, 6);
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.Size = new System.Drawing.Size(40, 40);
            this.Delete_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Delete_btn.TabIndex = 41;
            this.Delete_btn.TabStop = false;
            this.toolTip.SetToolTip(this.Delete_btn, "Detele the selecting shape");
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // Modify_lb
            // 
            this.Modify_lb.AutoSize = true;
            this.Modify_lb.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Modify_lb.Location = new System.Drawing.Point(1022, 154);
            this.Modify_lb.Name = "Modify_lb";
            this.Modify_lb.Size = new System.Drawing.Size(52, 19);
            this.Modify_lb.TabIndex = 29;
            this.Modify_lb.Text = "Modify";
            // 
            // Color_lb
            // 
            this.Color_lb.AutoSize = true;
            this.Color_lb.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Color_lb.Location = new System.Drawing.Point(843, 154);
            this.Color_lb.Name = "Color_lb";
            this.Color_lb.Size = new System.Drawing.Size(42, 19);
            this.Color_lb.TabIndex = 31;
            this.Color_lb.Text = "Color";
            // 
            // Shapes_lb
            // 
            this.Shapes_lb.AutoSize = true;
            this.Shapes_lb.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Shapes_lb.Location = new System.Drawing.Point(678, 154);
            this.Shapes_lb.Name = "Shapes_lb";
            this.Shapes_lb.Size = new System.Drawing.Size(52, 19);
            this.Shapes_lb.TabIndex = 32;
            this.Shapes_lb.Text = "Shapes";
            // 
            // Tools_lb
            // 
            this.Tools_lb.AutoSize = true;
            this.Tools_lb.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tools_lb.Location = new System.Drawing.Point(171, 152);
            this.Tools_lb.Name = "Tools_lb";
            this.Tools_lb.Size = new System.Drawing.Size(40, 19);
            this.Tools_lb.TabIndex = 33;
            this.Tools_lb.Text = "Tools";
            // 
            // Mode_tb
            // 
            this.Mode_tb.BackColor = System.Drawing.Color.White;
            this.Mode_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mode_tb.Location = new System.Drawing.Point(356, 71);
            this.Mode_tb.Name = "Mode_tb";
            this.Mode_tb.ReadOnly = true;
            this.Mode_tb.Size = new System.Drawing.Size(255, 26);
            this.Mode_tb.TabIndex = 48;
            this.Mode_tb.Text = "MODE: GROUP";
            // 
            // Note_tb
            // 
            this.Note_tb.BackColor = System.Drawing.Color.White;
            this.Note_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Note_tb.Location = new System.Drawing.Point(356, 109);
            this.Note_tb.Name = "Note_tb";
            this.Note_tb.ReadOnly = true;
            this.Note_tb.Size = new System.Drawing.Size(255, 26);
            this.Note_tb.TabIndex = 49;
            this.Note_tb.Text = "NOTE: ";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Paint_Midterm.Properties.Resources.Icon;
            this.pictureBox3.Location = new System.Drawing.Point(32, 11);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 50;
            this.pictureBox3.TabStop = false;
            // 
            // Exit_btn
            // 
            this.Exit_btn.Image = global::Paint_Midterm.Properties.Resources.exit;
            this.Exit_btn.Location = new System.Drawing.Point(1117, 11);
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.Size = new System.Drawing.Size(40, 40);
            this.Exit_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Exit_btn.TabIndex = 48;
            this.Exit_btn.TabStop = false;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // Main_PBox
            // 
            this.Main_PBox.BackColor = System.Drawing.SystemColors.Window;
            this.Main_PBox.Location = new System.Drawing.Point(35, 180);
            this.Main_PBox.Name = "Main_PBox";
            this.Main_PBox.Size = new System.Drawing.Size(1120, 565);
            this.Main_PBox.TabIndex = 3;
            this.Main_PBox.TabStop = false;
            this.Main_PBox.Paint += new System.Windows.Forms.PaintEventHandler(this.Main_Panel_Paint);
            this.Main_PBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_Panel_MouseDown);
            this.Main_PBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_Panel_MouseMove);
            this.Main_PBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Main_Panel_MouseUp);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(74, 17);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(223, 25);
            this.Title.TabIndex = 52;
            this.Title.Text = "Super Paint Application";
            // 
            // MyPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(1184, 775);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Note_tb);
            this.Controls.Add(this.Mode_tb);
            this.Controls.Add(this.Tools_lb);
            this.Controls.Add(this.Shapes_lb);
            this.Controls.Add(this.Color_lb);
            this.Controls.Add(this.Modify_lb);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Fill_pl);
            this.Controls.Add(this.Main_PBox);
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
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Freehand_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Polygon_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Circle_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rec_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ellipse_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Line_btn)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Save_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Select_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ungroup_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Group_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomOut_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomIn_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Clear_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Delete_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit_btn)).EndInit();
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ImageList DashList;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label Modify_lb;
        private System.Windows.Forms.Label Color_lb;
        private System.Windows.Forms.Label Shapes_lb;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox Line_btn;
        private System.Windows.Forms.PictureBox Freehand_btn;
        private System.Windows.Forms.PictureBox Polygon_btn;
        private System.Windows.Forms.PictureBox Circle_btn;
        private System.Windows.Forms.PictureBox Rec_btn;
        private System.Windows.Forms.PictureBox Ellipse_btn;
        private System.Windows.Forms.PictureBox Delete_btn;
        private System.Windows.Forms.PictureBox Clear_btn;
        private System.Windows.Forms.PictureBox ZoomOut_btn;
        private System.Windows.Forms.PictureBox ZoomIn_btn;
        private System.Windows.Forms.PictureBox Ungroup_btn;
        private System.Windows.Forms.PictureBox Group_btn;
        private System.Windows.Forms.Label Tools_lb;
        private System.Windows.Forms.PictureBox Select_btn;
        private System.Windows.Forms.TextBox Mode_tb;
        private System.Windows.Forms.TextBox Note_tb;
        private System.Windows.Forms.Button Color_btn;
        private System.Windows.Forms.Button Fill_Color_btn;
        private System.Windows.Forms.PictureBox Save_btn;
        private System.Windows.Forms.PictureBox Exit_btn;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

