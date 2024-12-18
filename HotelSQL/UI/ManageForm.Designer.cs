namespace HotelSQL.UI
{
    partial class ManageForm
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
            if (disposing && (components != null)) {
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
            AntdUI.CarouselItem carouselItem1 = new AntdUI.CarouselItem();
            AntdUI.CarouselItem carouselItem2 = new AntdUI.CarouselItem();
            AntdUI.CarouselItem carouselItem3 = new AntdUI.CarouselItem();
            AntdUI.CarouselItem carouselItem4 = new AntdUI.CarouselItem();
            AntdUI.CarouselItem carouselItem5 = new AntdUI.CarouselItem();
            AntdUI.CarouselItem carouselItem6 = new AntdUI.CarouselItem();
            AntdUI.MenuItem menuItem1 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem2 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem3 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem4 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem5 = new AntdUI.MenuItem();
            HotelCarousel = new AntdUI.Carousel();
            HotelMenu = new AntdUI.Menu();
            CarouselPanel = new AntdUI.Panel();
            CarouselPanel.SuspendLayout();
            SuspendLayout();
            // 
            // HotelCarousel
            // 
            HotelCarousel.Autoplay = true;
            HotelCarousel.BackColor = Color.Transparent;
            HotelCarousel.DotPosition = AntdUI.TAlignMini.Bottom;
            HotelCarousel.HandCursor = Cursors.Default;
            carouselItem1.Img = Properties.Resources.Hotel0;
            carouselItem2.Img = Properties.Resources.Hotel1;
            carouselItem3.Img = Properties.Resources.Hotel2;
            carouselItem4.Img = Properties.Resources.Hotel3;
            carouselItem5.Img = Properties.Resources.Hotel4;
            carouselItem6.Img = Properties.Resources.Hotel5;
            HotelCarousel.Image.Add(carouselItem1);
            HotelCarousel.Image.Add(carouselItem2);
            HotelCarousel.Image.Add(carouselItem3);
            HotelCarousel.Image.Add(carouselItem4);
            HotelCarousel.Image.Add(carouselItem5);
            HotelCarousel.Image.Add(carouselItem6);
            HotelCarousel.ImageFit = AntdUI.TFit.Contain;
            HotelCarousel.Location = new Point(3, 3);
            HotelCarousel.Name = "HotelCarousel";
            HotelCarousel.Radius = 3;
            HotelCarousel.SelectIndex = 1;
            HotelCarousel.Size = new Size(958, 634);
            HotelCarousel.TabIndex = 0;
            HotelCarousel.Text = "carousel1";
            HotelCarousel.UseWaitCursor = true;
            // 
            // HotelMenu
            // 
            HotelMenu.AutoCollapse = true;
            HotelMenu.BackColor = Color.White;
            HotelMenu.Dock = DockStyle.Left;
            HotelMenu.ForeColor = Color.Gray;
            HotelMenu.Indent = true;
            menuItem1.Font = new Font("汉仪文黑-85W", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuItem1.Icon = Properties.Resources.HomeLogo1;
            menuItem1.PARENTITEM = null;
            menuItem1.Select = true;
            menuItem1.Text = "首页";
            menuItem2.Font = new Font("汉仪文黑-85W", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuItem2.Icon = Properties.Resources.ItemLogo;
            menuItem2.PARENTITEM = null;
            menuItem3.Font = new Font("汉仪文黑-85W", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuItem3.Icon = Properties.Resources.HotelLogo2;
            menuItem3.PARENTITEM = menuItem2;
            menuItem3.Text = "酒店管理";
            menuItem4.Font = new Font("汉仪文黑-85W", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuItem4.Icon = Properties.Resources.RoomLogo;
            menuItem4.PARENTITEM = menuItem2;
            menuItem4.Text = "房间管理";
            menuItem5.Font = new Font("汉仪文黑-85W", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuItem5.Icon = Properties.Resources.OrderLogo;
            menuItem5.PARENTITEM = menuItem2;
            menuItem5.Text = "订单管理";
            menuItem2.Sub.Add(menuItem3);
            menuItem2.Sub.Add(menuItem4);
            menuItem2.Sub.Add(menuItem5);
            menuItem2.Text = "酒店";
            HotelMenu.Items.Add(menuItem1);
            HotelMenu.Items.Add(menuItem2);
            HotelMenu.Location = new Point(0, 0);
            HotelMenu.Name = "HotelMenu";
            HotelMenu.Round = true;
            HotelMenu.ShowSubBack = true;
            HotelMenu.Size = new Size(175, 681);
            HotelMenu.TabIndex = 1;
            HotelMenu.Text = "ManageMenu";
            HotelMenu.Theme = AntdUI.TAMode.Light;
            HotelMenu.Unique = true;
            HotelMenu.UseWaitCursor = true;
            HotelMenu.SelectChanged += HotelMenu_SelectChanged;
            // 
            // CarouselPanel
            // 
            CarouselPanel.Back = Color.Transparent;
            CarouselPanel.BackColor = Color.Transparent;
            CarouselPanel.Controls.Add(HotelCarousel);
            CarouselPanel.Location = new Point(239, 12);
            CarouselPanel.Name = "CarouselPanel";
            CarouselPanel.Size = new Size(1013, 640);
            CarouselPanel.TabIndex = 2;
            CarouselPanel.Text = "panel1";
            // 
            // ManageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(76, 76, 76);
            BackgroundImage = Properties.Resources.BackGround2;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1264, 681);
            Controls.Add(CarouselPanel);
            Controls.Add(HotelMenu);
            DoubleBuffered = true;
            Name = "ManageForm";
            Text = "酒店管理系统";
            Load += ManageForm_Load;
            CarouselPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Carousel HotelCarousel;
        private AntdUI.Menu HotelMenu;
        private AntdUI.Panel CarouselPanel;
    }
}