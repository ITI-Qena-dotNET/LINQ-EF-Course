using BLL;
using DAL.Data;
using System;
using System.Windows.Forms;

namespace Day8_Form;

public partial class Form1 : Form
{
    BusinessLayer businessLayer = new BusinessLayer();

    public Form1()
    {
        InitializeComponent();

        comboBox1.DataSource = businessLayer.GetDepartments();
        comboBox1.DisplayMember = "Dname";
        comboBox1.ValueMember = "Dnum";

        dataGridView1.DataSource = businessLayer.GetEmplooyees();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        int depId = int.Parse(comboBox1.SelectedValue.ToString());
        string Fname = textBox1.Text;
        string Lname = textBox2.Text;
        decimal salary = numericUpDown1.Value;

        businessLayer.InsertEmployee(Fname, Lname, salary, depId);
        dataGridView1.DataSource = null;
        dataGridView1.DataSource = businessLayer.GetEmplooyees();
    }

    private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        var fname = dataGridView1.Rows[e.RowIndex].Cells[0].Value;

        Employee emp = businessLayer.GetEmployee(fname.ToString());

        textBox1.Text = emp.Fname;
        textBox2.Text = emp.Lname;
        numericUpDown1.Value = (decimal)emp.Salary;
    }

    private void button2_Click(object sender, EventArgs e)
    {
        var fname = dataGridView1.SelectedRows[0].Cells[0].Value;

        Employee emp = new()
        {
            Fname = textBox1.Text,
            Lname = textBox2.Text,
            Salary = (int)numericUpDown1.Value
        };

        businessLayer.UpdateEmployee(emp, fname.ToString());

        dataGridView1.DataSource = businessLayer.GetEmplooyees();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        Form2 form = new(this);
        form.Show();
    }

    public void RefreshDepartmentsCombobox()
    {
        comboBox1.DataSource = businessLayer.GetDepartments();
        comboBox1.DisplayMember = "Dname";
        comboBox1.ValueMember = "Dnum";
    }

    private void button4_Click(object sender, EventArgs e)
    {
        //var fname = dataGridView1.SelectedRows[0].Cells[0].Value;

        businessLayer.DeleteEmployee(textBox1.Text);
        dataGridView1.DataSource = businessLayer.GetEmplooyees();
    }
}
