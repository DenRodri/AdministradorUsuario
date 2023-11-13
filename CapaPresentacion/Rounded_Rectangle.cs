using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedRectangle : Control
{
    public RoundedRectangle()
    {
        this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        this.BackColor = Color.Transparent;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        int radius = 10;
        int diameter = radius * 2;
        Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
        GraphicsPath path = new GraphicsPath();

        path.AddLine(rect.X + radius, rect.Y, rect.X + rect.Width - radius, rect.Y);
        path.AddArc(rect.X + rect.Width - diameter, rect.Y, diameter, diameter, 270, 90);
        path.AddLine(rect.X + rect.Width, rect.Y + radius, rect.X + rect.Width, rect.Y + rect.Height - radius);
        path.AddArc(rect.X + rect.Width - diameter, rect.Y + rect.Height - diameter, diameter, diameter, 0, 90);
        path.AddLine(rect.X + rect.Width - radius, rect.Y + rect.Height, rect.X + radius, rect.Y + rect.Height);
        path.AddArc(rect.X, rect.Y + rect.Height - diameter, diameter, diameter, 90, 90);
        path.AddLine(rect.X, rect.Y + rect.Height - radius, rect.X, rect.Y + radius);
        path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
        path.CloseAllFigures();

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        // If the control has a transparent background color, we need to draw the
        // rounded rectangle using a transparent brush.
        if (this.BackColor == Color.Transparent)
        {
            e.Graphics.FillPath(new SolidBrush(Color.Transparent), path);
            e.Graphics.DrawPath(new Pen(Color.Black, 2), path);
        }
        else
        {
            e.Graphics.FillPath(new SolidBrush(this.BackColor), path);
            e.Graphics.DrawPath(new Pen(Color.Black, 2), path);
        }
    }
}