using System;
using Gtk;
using Gdk;
using Glade;
using GtkSharp;
using System.Text;

public partial class MainWindow : Gtk.Window
{
    bool operandperformed = false;
    string operand = "";
    double result = 0;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }


    protected void click(object sender, EventArgs e)
    {
        if (operandperformed||entry2.Text=="0")
            entry2.Text = "";

        entry2.Text = entry2.Text + ((Label)((Button)sender).Child).Text;
    }



    protected void operation(object sender, EventArgs e)
    {
        operandperformed = true;
        procc.Text = procc.Text + " " + entry2.Text + " " + ((Label)((Button)sender).Child).Text;

        switch (operand)
        {
            case "+" : entry2.Text = (result + double.Parse(entry2.Text)).ToString();break;
            case "-": entry2.Text = (result - double.Parse(entry2.Text)).ToString(); break;
            case "/": entry2.Text = (result / double.Parse(entry2.Text)).ToString(); break;
            case "*": entry2.Text = (result * double.Parse(entry2.Text)).ToString(); break;
            default:break;
        }
        result = double.Parse(entry2.Text);
        operand = ((Label)((Button)sender).Child).Text;
    }

    protected void equal(object sender, EventArgs e)
    {
        procc.Text = procc.Text + " " + entry2.Text;
        operandperformed = true;
        switch (operand)
        {
            case "+": entry2.Text = (result + double.Parse(entry2.Text)).ToString(); break;
            case "-": entry2.Text = (result - double.Parse(entry2.Text)).ToString(); break;
            case "/": entry2.Text = (result / double.Parse(entry2.Text)).ToString(); break;
            case "*": entry2.Text = (result * double.Parse(entry2.Text)).ToString(); break;
            default: break;
        }
        result = double.Parse(entry2.Text);
        entry2.Text = result.ToString();
        result = 0;
        operand = "";

    }

}
