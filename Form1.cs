using System.Diagnostics;

namespace WinFormsApp1;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(textBox1.Text, out var time))
        {
            MessageBox.Show("Не удалось преобразовать строку в число");
            return;
        }
        string newTime;
        switch (comboBox1.SelectedIndex)
        {
            case 0:
                newTime = (time * 1).ToString();
                break;
            case 1:
                newTime = (time * 60).ToString();
                break;
            case 2:
                newTime = (time * 3600).ToString();
                break;
            default:
                MessageBox.Show("Не выбран формат времени");
                return;
        }
        var startInfo = "shutdown /s /t " + newTime;
        var process = new Process();
        process.StartInfo.Arguments = "/C " + startInfo;
        process.StartInfo.FileName = "cmd";
        process.StartInfo.CreateNoWindow = true;
        process.Start();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        var process = new Process();
        process.StartInfo.Arguments = "/C shutdown -a";
        process.StartInfo.FileName = "cmd";
        process.StartInfo.CreateNoWindow = true;
        process.Start();
    }
}