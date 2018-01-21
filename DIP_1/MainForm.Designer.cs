namespace DIP_1
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.originalImageBox = new System.Windows.Forms.PictureBox();
            this.alteredImageBox = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.procedureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contrastLinearScalingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertedContrastScallingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brightnessSliceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogrammsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHistogramsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uniformHistogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.degree23ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hyperbolicHistogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.добавитьШумToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьШумToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.локальноеУсреднениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.методКближайшихСоседейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сглаживаниеПоОднороднойОкрестностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.медианнаяФильтрацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выделениеКонтуровToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.лапласианToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.филтрРобертсаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.детекторГраницКанниToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.морфологическаяОбработкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.эрозияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заполнениеОбластиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.утончениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.построениеОстоваToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестовыеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выделениеГраницToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mask3x3 = new System.Windows.Forms.RadioButton();
            this.mask5x5 = new System.Windows.Forms.RadioButton();
            this.mask7x7 = new System.Windows.Forms.RadioButton();
            this.mask9x9 = new System.Windows.Forms.RadioButton();
            this.erosionGroup = new System.Windows.Forms.GroupBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.closeFillModeButton = new System.Windows.Forms.Button();
            this.эрозияToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.originalImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alteredImageBox)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.erosionGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // originalImageBox
            // 
            this.originalImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.originalImageBox.Location = new System.Drawing.Point(12, 27);
            this.originalImageBox.Name = "originalImageBox";
            this.originalImageBox.Size = new System.Drawing.Size(427, 427);
            this.originalImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.originalImageBox.TabIndex = 0;
            this.originalImageBox.TabStop = false;
            this.originalImageBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.originalImageBox_MouseClick);
            // 
            // alteredImageBox
            // 
            this.alteredImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.alteredImageBox.Location = new System.Drawing.Point(476, 27);
            this.alteredImageBox.Name = "alteredImageBox";
            this.alteredImageBox.Size = new System.Drawing.Size(427, 427);
            this.alteredImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.alteredImageBox.TabIndex = 1;
            this.alteredImageBox.TabStop = false;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.procedureToolStripMenuItem,
            this.histogrammsToolStripMenuItem,
            this.фильтрацияToolStripMenuItem,
            this.выделениеКонтуровToolStripMenuItem,
            this.морфологическаяОбработкаToolStripMenuItem,
            this.тестовыеToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(915, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.doToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // doToolStripMenuItem
            // 
            this.doToolStripMenuItem.Name = "doToolStripMenuItem";
            this.doToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.doToolStripMenuItem.Text = "do";
            this.doToolStripMenuItem.Click += new System.EventHandler(this.doToolStripMenuItem_Click);
            // 
            // procedureToolStripMenuItem
            // 
            this.procedureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contrastLinearScalingToolStripMenuItem,
            this.invertedContrastScallingToolStripMenuItem,
            this.brightnessSliceToolStripMenuItem});
            this.procedureToolStripMenuItem.Name = "procedureToolStripMenuItem";
            this.procedureToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.procedureToolStripMenuItem.Text = "Procedure";
            // 
            // contrastLinearScalingToolStripMenuItem
            // 
            this.contrastLinearScalingToolStripMenuItem.Name = "contrastLinearScalingToolStripMenuItem";
            this.contrastLinearScalingToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.contrastLinearScalingToolStripMenuItem.Text = "Contrast Linear Scaling";
            this.contrastLinearScalingToolStripMenuItem.Click += new System.EventHandler(this.contrastLinearScalingToolStripMenuItem_Click);
            // 
            // invertedContrastScallingToolStripMenuItem
            // 
            this.invertedContrastScallingToolStripMenuItem.Name = "invertedContrastScallingToolStripMenuItem";
            this.invertedContrastScallingToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.invertedContrastScallingToolStripMenuItem.Text = "Inverted Contrast Scalling";
            this.invertedContrastScallingToolStripMenuItem.Click += new System.EventHandler(this.invertedContrastScallingToolStripMenuItem_Click);
            // 
            // brightnessSliceToolStripMenuItem
            // 
            this.brightnessSliceToolStripMenuItem.Name = "brightnessSliceToolStripMenuItem";
            this.brightnessSliceToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.brightnessSliceToolStripMenuItem.Text = "Brightness Slice";
            this.brightnessSliceToolStripMenuItem.Click += new System.EventHandler(this.brightnessSliceToolStripMenuItem_Click);
            // 
            // histogrammsToolStripMenuItem
            // 
            this.histogrammsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHistogramsToolStripMenuItem,
            this.uniformHistogramToolStripMenuItem,
            this.degree23ToolStripMenuItem,
            this.hyperbolicHistogramToolStripMenuItem});
            this.histogrammsToolStripMenuItem.Name = "histogrammsToolStripMenuItem";
            this.histogrammsToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.histogrammsToolStripMenuItem.Text = "Histograms";
            // 
            // showHistogramsToolStripMenuItem
            // 
            this.showHistogramsToolStripMenuItem.Name = "showHistogramsToolStripMenuItem";
            this.showHistogramsToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.showHistogramsToolStripMenuItem.Text = "Show histograms";
            this.showHistogramsToolStripMenuItem.Click += new System.EventHandler(this.showHistogramsToolStripMenuItem_Click);
            // 
            // uniformHistogramToolStripMenuItem
            // 
            this.uniformHistogramToolStripMenuItem.Name = "uniformHistogramToolStripMenuItem";
            this.uniformHistogramToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.uniformHistogramToolStripMenuItem.Text = "Uniform histogram";
            this.uniformHistogramToolStripMenuItem.Click += new System.EventHandler(this.uniformHistogramToolStripMenuItem_Click);
            // 
            // degree23ToolStripMenuItem
            // 
            this.degree23ToolStripMenuItem.Name = "degree23ToolStripMenuItem";
            this.degree23ToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.degree23ToolStripMenuItem.Text = "Degree 2/3";
            this.degree23ToolStripMenuItem.Click += new System.EventHandler(this.degree23ToolStripMenuItem_Click);
            // 
            // hyperbolicHistogramToolStripMenuItem
            // 
            this.hyperbolicHistogramToolStripMenuItem.Name = "hyperbolicHistogramToolStripMenuItem";
            this.hyperbolicHistogramToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.hyperbolicHistogramToolStripMenuItem.Text = "Hyperbolic histogram";
            this.hyperbolicHistogramToolStripMenuItem.Click += new System.EventHandler(this.hyperbolicHistogramToolStripMenuItem_Click);
            // 
            // фильтрацияToolStripMenuItem
            // 
            this.фильтрацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateImageToolStripMenuItem,
            this.dToolStripMenuItem,
            this.добавитьШумToolStripMenuItem,
            this.удалитьШумToolStripMenuItem1,
            this.локальноеУсреднениеToolStripMenuItem,
            this.методКближайшихСоседейToolStripMenuItem,
            this.сглаживаниеПоОднороднойОкрестностиToolStripMenuItem,
            this.toolStripMenuItem2,
            this.медианнаяФильтрацияToolStripMenuItem});
            this.фильтрацияToolStripMenuItem.Name = "фильтрацияToolStripMenuItem";
            this.фильтрацияToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.фильтрацияToolStripMenuItem.Text = "Фильтрация";
            // 
            // generateImageToolStripMenuItem
            // 
            this.generateImageToolStripMenuItem.Name = "generateImageToolStripMenuItem";
            this.generateImageToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.generateImageToolStripMenuItem.Text = "Сгенерировать изображение";
            this.generateImageToolStripMenuItem.Click += new System.EventHandler(this.generateImageToolStripMenuItem_Click);
            // 
            // dToolStripMenuItem
            // 
            this.dToolStripMenuItem.Name = "dToolStripMenuItem";
            this.dToolStripMenuItem.Size = new System.Drawing.Size(305, 6);
            // 
            // добавитьШумToolStripMenuItem
            // 
            this.добавитьШумToolStripMenuItem.Name = "добавитьШумToolStripMenuItem";
            this.добавитьШумToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.добавитьШумToolStripMenuItem.Text = "Добавить шум";
            this.добавитьШумToolStripMenuItem.Click += new System.EventHandler(this.добавитьШумToolStripMenuItem_Click);
            // 
            // удалитьШумToolStripMenuItem1
            // 
            this.удалитьШумToolStripMenuItem1.Name = "удалитьШумToolStripMenuItem1";
            this.удалитьШумToolStripMenuItem1.Size = new System.Drawing.Size(308, 22);
            this.удалитьШумToolStripMenuItem1.Text = "Удалить шум";
            this.удалитьШумToolStripMenuItem1.Click += new System.EventHandler(this.удалитьШумToolStripMenuItem1_Click);
            // 
            // локальноеУсреднениеToolStripMenuItem
            // 
            this.локальноеУсреднениеToolStripMenuItem.Name = "локальноеУсреднениеToolStripMenuItem";
            this.локальноеУсреднениеToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.локальноеУсреднениеToolStripMenuItem.Text = "Локальное усреднение";
            this.локальноеУсреднениеToolStripMenuItem.Click += new System.EventHandler(this.локальноеУсреднениеToolStripMenuItem_Click);
            // 
            // методКближайшихСоседейToolStripMenuItem
            // 
            this.методКближайшихСоседейToolStripMenuItem.Name = "методКближайшихСоседейToolStripMenuItem";
            this.методКближайшихСоседейToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.методКближайшихСоседейToolStripMenuItem.Text = "Метод К-ближайших соседей";
            this.методКближайшихСоседейToolStripMenuItem.Click += new System.EventHandler(this.методКближайшихСоседейToolStripMenuItem_Click);
            // 
            // сглаживаниеПоОднороднойОкрестностиToolStripMenuItem
            // 
            this.сглаживаниеПоОднороднойОкрестностиToolStripMenuItem.Name = "сглаживаниеПоОднороднойОкрестностиToolStripMenuItem";
            this.сглаживаниеПоОднороднойОкрестностиToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.сглаживаниеПоОднороднойОкрестностиToolStripMenuItem.Text = "Сглаживание по однородной окрестности";
            this.сглаживаниеПоОднороднойОкрестностиToolStripMenuItem.Click += new System.EventHandler(this.сглаживаниеПоОднороднойОкрестностиToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(305, 6);
            // 
            // медианнаяФильтрацияToolStripMenuItem
            // 
            this.медианнаяФильтрацияToolStripMenuItem.Name = "медианнаяФильтрацияToolStripMenuItem";
            this.медианнаяФильтрацияToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.медианнаяФильтрацияToolStripMenuItem.Text = "Медианная фильтрация";
            this.медианнаяФильтрацияToolStripMenuItem.Click += new System.EventHandler(this.медианнаяФильтрацияToolStripMenuItem_Click);
            // 
            // выделениеКонтуровToolStripMenuItem
            // 
            this.выделениеКонтуровToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.лапласианToolStripMenuItem,
            this.филтрРобертсаToolStripMenuItem,
            this.детекторГраницКанниToolStripMenuItem});
            this.выделениеКонтуровToolStripMenuItem.Name = "выделениеКонтуровToolStripMenuItem";
            this.выделениеКонтуровToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.выделениеКонтуровToolStripMenuItem.Text = "Выделение контуров";
            this.выделениеКонтуровToolStripMenuItem.Click += new System.EventHandler(this.выделениеКонтуровToolStripMenuItem_Click);
            // 
            // лапласианToolStripMenuItem
            // 
            this.лапласианToolStripMenuItem.Name = "лапласианToolStripMenuItem";
            this.лапласианToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.лапласианToolStripMenuItem.Text = "Лапласиан";
            this.лапласианToolStripMenuItem.Click += new System.EventHandler(this.лапласианToolStripMenuItem_Click);
            // 
            // филтрРобертсаToolStripMenuItem
            // 
            this.филтрРобертсаToolStripMenuItem.Name = "филтрРобертсаToolStripMenuItem";
            this.филтрРобертсаToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.филтрРобертсаToolStripMenuItem.Text = "Фильтр Робертса";
            this.филтрРобертсаToolStripMenuItem.Click += new System.EventHandler(this.филтрРобертсаToolStripMenuItem_Click);
            // 
            // детекторГраницКанниToolStripMenuItem
            // 
            this.детекторГраницКанниToolStripMenuItem.Name = "детекторГраницКанниToolStripMenuItem";
            this.детекторГраницКанниToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.детекторГраницКанниToolStripMenuItem.Text = "Детектор границ Канни";
            this.детекторГраницКанниToolStripMenuItem.Click += new System.EventHandler(this.детекторГраницКанниToolStripMenuItem_Click);
            // 
            // морфологическаяОбработкаToolStripMenuItem
            // 
            this.морфологическаяОбработкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.эрозияToolStripMenuItem,
            this.заполнениеОбластиToolStripMenuItem,
            this.утончениеToolStripMenuItem,
            this.построениеОстоваToolStripMenuItem});
            this.морфологическаяОбработкаToolStripMenuItem.Name = "морфологическаяОбработкаToolStripMenuItem";
            this.морфологическаяОбработкаToolStripMenuItem.Size = new System.Drawing.Size(184, 20);
            this.морфологическаяОбработкаToolStripMenuItem.Text = "Морфологическая обработка";
            // 
            // эрозияToolStripMenuItem
            // 
            this.эрозияToolStripMenuItem.Name = "эрозияToolStripMenuItem";
            this.эрозияToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.эрозияToolStripMenuItem.Text = "Эрозия";
            this.эрозияToolStripMenuItem.Click += new System.EventHandler(this.эрозияToolStripMenuItem_Click);
            // 
            // заполнениеОбластиToolStripMenuItem
            // 
            this.заполнениеОбластиToolStripMenuItem.Name = "заполнениеОбластиToolStripMenuItem";
            this.заполнениеОбластиToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.заполнениеОбластиToolStripMenuItem.Text = "Заполнение области";
            this.заполнениеОбластиToolStripMenuItem.Click += new System.EventHandler(this.заполнениеОбластиToolStripMenuItem_Click);
            // 
            // утончениеToolStripMenuItem
            // 
            this.утончениеToolStripMenuItem.Name = "утончениеToolStripMenuItem";
            this.утончениеToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.утончениеToolStripMenuItem.Text = "Утончение";
            this.утончениеToolStripMenuItem.Click += new System.EventHandler(this.утончениеToolStripMenuItem_Click);
            // 
            // построениеОстоваToolStripMenuItem
            // 
            this.построениеОстоваToolStripMenuItem.Name = "построениеОстоваToolStripMenuItem";
            this.построениеОстоваToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.построениеОстоваToolStripMenuItem.Text = "Построение остова";
            this.построениеОстоваToolStripMenuItem.Click += new System.EventHandler(this.построениеОстоваToolStripMenuItem_Click);
            // 
            // тестовыеToolStripMenuItem
            // 
            this.тестовыеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выделениеГраницToolStripMenuItem,
            this.эрозияToolStripMenuItem1});
            this.тестовыеToolStripMenuItem.Name = "тестовыеToolStripMenuItem";
            this.тестовыеToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.тестовыеToolStripMenuItem.Text = "Тестовые";
            // 
            // выделениеГраницToolStripMenuItem
            // 
            this.выделениеГраницToolStripMenuItem.Name = "выделениеГраницToolStripMenuItem";
            this.выделениеГраницToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.выделениеГраницToolStripMenuItem.Text = "Выделение границ";
            this.выделениеГраницToolStripMenuItem.Click += new System.EventHandler(this.выделениеГраницToolStripMenuItem_Click);
            // 
            // mask3x3
            // 
            this.mask3x3.AutoSize = true;
            this.mask3x3.Location = new System.Drawing.Point(6, 25);
            this.mask3x3.Name = "mask3x3";
            this.mask3x3.Size = new System.Drawing.Size(42, 17);
            this.mask3x3.TabIndex = 3;
            this.mask3x3.TabStop = true;
            this.mask3x3.Text = "3x3";
            this.mask3x3.UseVisualStyleBackColor = true;
            // 
            // mask5x5
            // 
            this.mask5x5.AutoSize = true;
            this.mask5x5.Location = new System.Drawing.Point(6, 48);
            this.mask5x5.Name = "mask5x5";
            this.mask5x5.Size = new System.Drawing.Size(42, 17);
            this.mask5x5.TabIndex = 4;
            this.mask5x5.TabStop = true;
            this.mask5x5.Text = "5x5";
            this.mask5x5.UseVisualStyleBackColor = true;
            // 
            // mask7x7
            // 
            this.mask7x7.AutoSize = true;
            this.mask7x7.Location = new System.Drawing.Point(54, 25);
            this.mask7x7.Name = "mask7x7";
            this.mask7x7.Size = new System.Drawing.Size(42, 17);
            this.mask7x7.TabIndex = 5;
            this.mask7x7.TabStop = true;
            this.mask7x7.Text = "7x7";
            this.mask7x7.UseVisualStyleBackColor = true;
            // 
            // mask9x9
            // 
            this.mask9x9.AutoSize = true;
            this.mask9x9.Location = new System.Drawing.Point(54, 48);
            this.mask9x9.Name = "mask9x9";
            this.mask9x9.Size = new System.Drawing.Size(42, 17);
            this.mask9x9.TabIndex = 6;
            this.mask9x9.TabStop = true;
            this.mask9x9.Text = "9x9";
            this.mask9x9.UseVisualStyleBackColor = true;
            // 
            // erosionGroup
            // 
            this.erosionGroup.Controls.Add(this.applyButton);
            this.erosionGroup.Controls.Add(this.mask3x3);
            this.erosionGroup.Controls.Add(this.mask9x9);
            this.erosionGroup.Controls.Add(this.mask5x5);
            this.erosionGroup.Controls.Add(this.mask7x7);
            this.erosionGroup.Location = new System.Drawing.Point(12, 460);
            this.erosionGroup.Name = "erosionGroup";
            this.erosionGroup.Size = new System.Drawing.Size(118, 100);
            this.erosionGroup.TabIndex = 7;
            this.erosionGroup.TabStop = false;
            this.erosionGroup.Text = "Маска эрозии";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(6, 71);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(106, 23);
            this.applyButton.TabIndex = 7;
            this.applyButton.Text = "Применить";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(445, 213);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(25, 27);
            this.changeButton.TabIndex = 8;
            this.changeButton.Text = "<--";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // closeFillModeButton
            // 
            this.closeFillModeButton.Location = new System.Drawing.Point(671, 494);
            this.closeFillModeButton.Name = "closeFillModeButton";
            this.closeFillModeButton.Size = new System.Drawing.Size(232, 45);
            this.closeFillModeButton.TabIndex = 10;
            this.closeFillModeButton.Text = "Выйти из режима заполнения областей";
            this.closeFillModeButton.UseVisualStyleBackColor = true;
            this.closeFillModeButton.Click += new System.EventHandler(this.closeFillModeButton_Click);
            // 
            // эрозияToolStripMenuItem1
            // 
            this.эрозияToolStripMenuItem1.Name = "эрозияToolStripMenuItem1";
            this.эрозияToolStripMenuItem1.Size = new System.Drawing.Size(177, 22);
            this.эрозияToolStripMenuItem1.Text = "Эрозия";
            this.эрозияToolStripMenuItem1.Click += new System.EventHandler(this.эрозияToolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 564);
            this.Controls.Add(this.closeFillModeButton);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.erosionGroup);
            this.Controls.Add(this.alteredImageBox);
            this.Controls.Add(this.originalImageBox);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Digital Image Processing";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.originalImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alteredImageBox)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.erosionGroup.ResumeLayout(false);
            this.erosionGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem procedureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contrastLinearScalingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertedContrastScallingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brightnessSliceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogrammsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uniformHistogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem degree23ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hyperbolicHistogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showHistogramsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фильтрацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateImageToolStripMenuItem;
        public System.Windows.Forms.PictureBox originalImageBox;
        private System.Windows.Forms.ToolStripSeparator dToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьШумToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem локальноеУсреднениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem методКближайшихСоседейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сглаживаниеПоОднороднойОкрестностиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьШумToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem медианнаяФильтрацияToolStripMenuItem;
        public System.Windows.Forms.PictureBox alteredImageBox;
        private System.Windows.Forms.ToolStripMenuItem выделениеКонтуровToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem лапласианToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem филтрРобертсаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem детекторГраницКанниToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem морфологическаяОбработкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem эрозияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заполнениеОбластиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem утончениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem построениеОстоваToolStripMenuItem;
        private System.Windows.Forms.RadioButton mask3x3;
        private System.Windows.Forms.RadioButton mask5x5;
        private System.Windows.Forms.RadioButton mask7x7;
        private System.Windows.Forms.RadioButton mask9x9;
        private System.Windows.Forms.GroupBox erosionGroup;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doToolStripMenuItem;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button closeFillModeButton;
        private System.Windows.Forms.ToolStripMenuItem тестовыеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выделениеГраницToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem эрозияToolStripMenuItem1;
    }
}

