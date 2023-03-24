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
            this.Main_PBox = new System.Windows.Forms.PictureBox();
            this.ZoomIn_btn = new System.Windows.Forms.Button();
            this.Shape_txb = new System.Windows.Forms.TextBox();
            this.ZoomOut_btn = new System.Windows.Forms.Button();
            this.DashStyle = new System.Windows.Forms.ComboBox();
            this.PenSize = new System.Windows.Forms.NumericUpDown();
            this.Delete_btn = new System.Windows.Forms.Button();
            this.Color_btn = new System.Windows.Forms.Button();
            this.Clear_btn = new System.Windows.Forms.Button();
            this.Rec_btn = new System.Windows.Forms.Button();
            this.Fill_btn = new System.Windows.Forms.Button();
            this.check = new System.Windows.Forms.TextBox();
            this.Line_btn = new System.Windows.Forms.Button();
            this.DrawnShapes = new System.Windows.Forms.CheckedListBox();
            this.Debug = new System.Windows.Forms.TextBox();
            this.Ungroup_btn = new System.Windows.Forms.Button();
            this.Ellipse_btn = new System.Windows.Forms.Button();
            this.Fill_Color_btn = new System.Windows.Forms.Button();
            this.Circle_btn = new System.Windows.Forms.Button();
            this.Polygon_btn = new System.Windows.Forms.Button();
            this.Group_btn = new System.Windows.Forms.Button();
            this.Select_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Main_PBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PenSize)).BeginInit();
            this.SuspendLayout();
            // 
            // Main_PBox
            // 
            this.Main_PBox.BackColor = System.Drawing.SystemColors.Window;
            this.Main_PBox.Location = new System.Drawing.Point(244, 0);
            this.Main_PBox.Name = "Main_PBox";
            this.Main_PBox.Size = new System.Drawing.Size(1019, 681);
            this.Main_PBox.TabIndex = 3;
            this.Main_PBox.TabStop = false;
            this.Main_PBox.Paint += new System.Windows.Forms.PaintEventHandler(this.Main_Panel_Paint);
            this.Main_PBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_Panel_MouseDown);
            this.Main_PBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_Panel_MouseMove);
            this.Main_PBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Main_Panel_MouseUp);
            // 
            // ZoomIn_btn
            // 
            this.ZoomIn_btn.Location = new System.Drawing.Point(136, 9);
            this.ZoomIn_btn.Name = "ZoomIn_btn";
            this.ZoomIn_btn.Size = new System.Drawing.Size(75, 23);
            this.ZoomIn_btn.TabIndex = 4;
            this.ZoomIn_btn.Text = "Zoom In";
            this.ZoomIn_btn.UseVisualStyleBackColor = true;
            this.ZoomIn_btn.Click += new System.EventHandler(this.ZoomIn_btn_Click);
            // 
            // Shape_txb
            // 
            this.Shape_txb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Shape_txb.Location = new System.Drawing.Point(13, 173);
            this.Shape_txb.Name = "Shape_txb";
            this.Shape_txb.ReadOnly = true;
            this.Shape_txb.Size = new System.Drawing.Size(213, 26);
            this.Shape_txb.TabIndex = 5;
            this.Shape_txb.Text = "NULL";
            // 
            // ZoomOut_btn
            // 
            this.ZoomOut_btn.Location = new System.Drawing.Point(136, 38);
            this.ZoomOut_btn.Name = "ZoomOut_btn";
            this.ZoomOut_btn.Size = new System.Drawing.Size(75, 23);
            this.ZoomOut_btn.TabIndex = 7;
            this.ZoomOut_btn.Text = "Zoom Out";
            this.ZoomOut_btn.UseVisualStyleBackColor = true;
            this.ZoomOut_btn.Click += new System.EventHandler(this.ZoomOut_btn_Click);
            // 
            // DashStyle
            // 
            this.DashStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DashStyle.FormattingEnabled = true;
            this.DashStyle.Location = new System.Drawing.Point(151, 104);
            this.DashStyle.Name = "DashStyle";
            this.DashStyle.Size = new System.Drawing.Size(75, 28);
            this.DashStyle.TabIndex = 8;
            this.DashStyle.Text = "1";
            // 
            // PenSize
            // 
            this.PenSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PenSize.Location = new System.Drawing.Point(151, 138);
            this.PenSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PenSize.Name = "PenSize";
            this.PenSize.Size = new System.Drawing.Size(75, 26);
            this.PenSize.TabIndex = 9;
            this.PenSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.PenSize.ValueChanged += new System.EventHandler(this.PenSize_ValueChanged);
            // 
            // Delete_btn
            // 
            this.Delete_btn.Location = new System.Drawing.Point(14, 107);
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.Size = new System.Drawing.Size(75, 23);
            this.Delete_btn.TabIndex = 10;
            this.Delete_btn.Text = "Delete";
            this.Delete_btn.UseVisualStyleBackColor = true;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // Color_btn
            // 
            this.Color_btn.BackColor = System.Drawing.Color.Black;
            this.Color_btn.Location = new System.Drawing.Point(12, 3);
            this.Color_btn.Name = "Color_btn";
            this.Color_btn.Size = new System.Drawing.Size(35, 35);
            this.Color_btn.TabIndex = 11;
            this.Color_btn.TabStop = false;
            this.Color_btn.UseVisualStyleBackColor = false;
            this.Color_btn.Click += new System.EventHandler(this.Color_btn_Click);
            // 
            // Clear_btn
            // 
            this.Clear_btn.Location = new System.Drawing.Point(14, 140);
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.Size = new System.Drawing.Size(75, 23);
            this.Clear_btn.TabIndex = 12;
            this.Clear_btn.Text = "Clear";
            this.Clear_btn.UseVisualStyleBackColor = true;
            this.Clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // Rec_btn
            // 
            this.Rec_btn.Location = new System.Drawing.Point(92, 248);
            this.Rec_btn.Name = "Rec_btn";
            this.Rec_btn.Size = new System.Drawing.Size(75, 23);
            this.Rec_btn.TabIndex = 13;
            this.Rec_btn.Text = "Rectangle";
            this.Rec_btn.UseVisualStyleBackColor = true;
            this.Rec_btn.Click += new System.EventHandler(this.Rec_btn_Click);
            // 
            // Fill_btn
            // 
            this.Fill_btn.Location = new System.Drawing.Point(14, 208);
            this.Fill_btn.Name = "Fill_btn";
            this.Fill_btn.Size = new System.Drawing.Size(75, 23);
            this.Fill_btn.TabIndex = 14;
            this.Fill_btn.Text = "Fill";
            this.Fill_btn.UseVisualStyleBackColor = true;
            this.Fill_btn.Click += new System.EventHandler(this.Fill_btn_Click);
            // 
            // check
            // 
            this.check.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check.Location = new System.Drawing.Point(128, 205);
            this.check.Name = "check";
            this.check.ReadOnly = true;
            this.check.Size = new System.Drawing.Size(98, 26);
            this.check.TabIndex = 15;
            this.check.Text = "False";
            // 
            // Line_btn
            // 
            this.Line_btn.Location = new System.Drawing.Point(11, 248);
            this.Line_btn.Name = "Line_btn";
            this.Line_btn.Size = new System.Drawing.Size(75, 23);
            this.Line_btn.TabIndex = 16;
            this.Line_btn.Text = "Line";
            this.Line_btn.UseVisualStyleBackColor = true;
            this.Line_btn.Click += new System.EventHandler(this.Line_btn_Click);
            // 
            // DrawnShapes
            // 
            this.DrawnShapes.FormattingEnabled = true;
            this.DrawnShapes.Location = new System.Drawing.Point(12, 342);
            this.DrawnShapes.Name = "DrawnShapes";
            this.DrawnShapes.Size = new System.Drawing.Size(178, 169);
            this.DrawnShapes.TabIndex = 17;
            this.DrawnShapes.SelectedIndexChanged += new System.EventHandler(this.DrawnShapes_SelectedIndexChanged);
            // 
            // Debug
            // 
            this.Debug.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Debug.Location = new System.Drawing.Point(11, 558);
            this.Debug.Name = "Debug";
            this.Debug.ReadOnly = true;
            this.Debug.Size = new System.Drawing.Size(213, 26);
            this.Debug.TabIndex = 18;
            this.Debug.Text = "Debug Box";
            // 
            // Ungroup_btn
            // 
            this.Ungroup_btn.Location = new System.Drawing.Point(14, 75);
            this.Ungroup_btn.Name = "Ungroup_btn";
            this.Ungroup_btn.Size = new System.Drawing.Size(75, 23);
            this.Ungroup_btn.TabIndex = 19;
            this.Ungroup_btn.Text = "UnGroup";
            this.Ungroup_btn.UseVisualStyleBackColor = true;
            this.Ungroup_btn.Click += new System.EventHandler(this.Ungroup_btn_Click);
            // 
            // Ellipse_btn
            // 
            this.Ellipse_btn.Location = new System.Drawing.Point(11, 277);
            this.Ellipse_btn.Name = "Ellipse_btn";
            this.Ellipse_btn.Size = new System.Drawing.Size(75, 23);
            this.Ellipse_btn.TabIndex = 20;
            this.Ellipse_btn.Text = "Ellipse";
            this.Ellipse_btn.UseVisualStyleBackColor = true;
            this.Ellipse_btn.Click += new System.EventHandler(this.Ellipse_btn_Click);
            // 
            // Fill_Color_btn
            // 
            this.Fill_Color_btn.BackColor = System.Drawing.Color.Black;
            this.Fill_Color_btn.Location = new System.Drawing.Point(12, 38);
            this.Fill_Color_btn.Name = "Fill_Color_btn";
            this.Fill_Color_btn.Size = new System.Drawing.Size(35, 35);
            this.Fill_Color_btn.TabIndex = 21;
            this.Fill_Color_btn.TabStop = false;
            this.Fill_Color_btn.UseVisualStyleBackColor = false;
            this.Fill_Color_btn.Click += new System.EventHandler(this.Fill_Color_btn_Click);
            // 
            // Circle_btn
            // 
            this.Circle_btn.Location = new System.Drawing.Point(92, 277);
            this.Circle_btn.Name = "Circle_btn";
            this.Circle_btn.Size = new System.Drawing.Size(75, 23);
            this.Circle_btn.TabIndex = 22;
            this.Circle_btn.Text = "Circle";
            this.Circle_btn.UseVisualStyleBackColor = true;
            this.Circle_btn.Click += new System.EventHandler(this.Circle_btn_Click);
            // 
            // Polygon_btn
            // 
            this.Polygon_btn.Location = new System.Drawing.Point(11, 306);
            this.Polygon_btn.Name = "Polygon_btn";
            this.Polygon_btn.Size = new System.Drawing.Size(75, 23);
            this.Polygon_btn.TabIndex = 23;
            this.Polygon_btn.Text = "Polygon";
            this.Polygon_btn.UseVisualStyleBackColor = true;
            this.Polygon_btn.Click += new System.EventHandler(this.Polygon_btn_Click);
            // 
            // Group_btn
            // 
            this.Group_btn.Location = new System.Drawing.Point(55, 38);
            this.Group_btn.Name = "Group_btn";
            this.Group_btn.Size = new System.Drawing.Size(75, 23);
            this.Group_btn.TabIndex = 25;
            this.Group_btn.Text = "Group";
            this.Group_btn.UseVisualStyleBackColor = true;
            this.Group_btn.Click += new System.EventHandler(this.Group_btn_Click);
            // 
            // Select_btn
            // 
            this.Select_btn.Location = new System.Drawing.Point(55, 9);
            this.Select_btn.Name = "Select_btn";
            this.Select_btn.Size = new System.Drawing.Size(75, 23);
            this.Select_btn.TabIndex = 24;
            this.Select_btn.Text = "Select";
            this.Select_btn.UseVisualStyleBackColor = true;
            this.Select_btn.Click += new System.EventHandler(this.Select_btn_Click);
            // 
            // MyPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.Group_btn);
            this.Controls.Add(this.Select_btn);
            this.Controls.Add(this.Polygon_btn);
            this.Controls.Add(this.Circle_btn);
            this.Controls.Add(this.Fill_Color_btn);
            this.Controls.Add(this.Ellipse_btn);
            this.Controls.Add(this.Ungroup_btn);
            this.Controls.Add(this.Debug);
            this.Controls.Add(this.DrawnShapes);
            this.Controls.Add(this.Line_btn);
            this.Controls.Add(this.check);
            this.Controls.Add(this.Fill_btn);
            this.Controls.Add(this.Rec_btn);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Color_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.PenSize);
            this.Controls.Add(this.DashStyle);
            this.Controls.Add(this.ZoomOut_btn);
            this.Controls.Add(this.Shape_txb);
            this.Controls.Add(this.ZoomIn_btn);
            this.Controls.Add(this.Main_PBox);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyPaint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyPaint";
            this.Load += new System.EventHandler(this.MyPaint_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyPaint_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MyPaint_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Main_PBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PenSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox Main_PBox;
        private System.Windows.Forms.Button ZoomIn_btn;
        private System.Windows.Forms.TextBox Shape_txb;
        private System.Windows.Forms.Button ZoomOut_btn;
        private System.Windows.Forms.ComboBox DashStyle;
        private System.Windows.Forms.NumericUpDown PenSize;
        private System.Windows.Forms.Button Delete_btn;
        private System.Windows.Forms.Button Color_btn;
        private System.Windows.Forms.Button Clear_btn;
        private System.Windows.Forms.Button Rec_btn;
        private System.Windows.Forms.Button Fill_btn;
        private System.Windows.Forms.TextBox check;
        private System.Windows.Forms.Button Line_btn;
        private System.Windows.Forms.CheckedListBox DrawnShapes;
        private System.Windows.Forms.TextBox Debug;
        private System.Windows.Forms.Button Ungroup_btn;
        private System.Windows.Forms.Button Ellipse_btn;
        private System.Windows.Forms.Button Fill_Color_btn;
        private System.Windows.Forms.Button Circle_btn;
        private System.Windows.Forms.Button Polygon_btn;
        private System.Windows.Forms.Button Group_btn;
        private System.Windows.Forms.Button Select_btn;
    }
}

