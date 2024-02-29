using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Policy;
using System.Windows.Forms;
namespace Lab7CSharp
{
    partial class Form1 :Form
    {

        private Panel movingPanel;  // Панель, яка рухається
        private Panel rotatingPanel;  // Панель, яка обертається
        private Timer timerRotation;
        private Timer timerMovement;
        private Random random;

        private float rotationAngle = 0.0f;
        private int rotatingPanelRadius = 150;  // Радіус обертання для малого квадрата


        private void InitializeTimers()
        {
            timerRotation = new Timer();
            timerRotation.Interval = 100;
            timerRotation.Tick += timerRotation_Tick;

            timerMovement = new Timer();
            timerMovement.Interval = 50;
            timerMovement.Tick += timerMovement_Tick;

            random = new Random();
        }

        private void InitializeRotatingPanel()
        {
            rotatingPanel = new Panel();
            rotatingPanel.Size = new Size(150, 150);  // Задайте більший розмір
            rotatingPanel.Location = new Point((ClientSize.Width - rotatingPanel.Width) / 2, (ClientSize.Height - rotatingPanel.Height) / 2);
            rotatingPanel.BackColor = GetRandomColor();

            Controls.Add(rotatingPanel);
        }

        private void InitializeMovingPanel()
        {
            movingPanel = new Panel();
            movingPanel.Size = new Size(50, 50);
            movingPanel.BackColor = GetRandomColor();

            Controls.Add(movingPanel);
        }

        private void timerRotation_Tick(object sender, EventArgs e)
        {
            rotationAngle += 0.1f;  // Збільшено швидкість обертання

            // Рухати маленький квадрат по колу
            int x = rotatingPanel.Location.X + rotatingPanel.Width / 2 + (int)(rotatingPanelRadius * Math.Cos(rotationAngle));
            int y = rotatingPanel.Location.Y + rotatingPanel.Height / 2 + (int)(rotatingPanelRadius * Math.Sin(rotationAngle));
            movingPanel.Location = new Point(x - movingPanel.Width / 2, y - movingPanel.Height / 2);

            rotatingPanel.BackColor = GetRandomColor();
            movingPanel.BackColor = GetRandomColor();

            // Оновити форму
            Invalidate();
        }

        private void timerMovement_Tick(object sender, EventArgs e)
        {
            rotatingPanel.Location = new Point(
                 (rotatingPanel.Location.X + random.Next(2 * 5 + 1) - 5 + ClientSize.Width) % ClientSize.Width,
                 (rotatingPanel.Location.Y + random.Next(2 * 5 + 1) - 5 + ClientSize.Height) % ClientSize.Height
             );
        }

        private Point RotatePoint(Point center, float angle)
        {
            // Застосувати трансформацію матриці для обертання точки навколо центра
            Matrix matrix = new Matrix();
            matrix.RotateAt(angle, new PointF(rotatingPanel.Location.X + rotatingPanel.Width / 2, rotatingPanel.Location.Y + rotatingPanel.Height / 2));

            Point[] points = { center };
            matrix.TransformPoints(points);

            return points[0];
        }

        private Color GetRandomColor()
        {
            // Генерувати випадковий колір
            return Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();

            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.PaleGreen;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(376, -1);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lab 7.   C# ";
            this.label1.Click += new System.EventHandler(this.label1_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 386);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

            InitializeTimers();
            InitializeRotatingPanel();
            InitializeMovingPanel();

            timerRotation.Start();
            timerMovement.Start();
        }

        private System.Windows.Forms.Label label1;
    }
}

