using BLL;
using DAL;
using DAL.Data;
using System;
using System.Windows.Forms;

namespace Day8_Form;

public delegate void AddNewDepartment();

public partial class Form2 : Form
{
    BusinessLayer businessLayer = new BusinessLayer();
    Form1 form;

    public event AddNewDepartment OnAddNewDepartment;

    public Form2(Form1 form)
    {
        InitializeComponent();

        dataGridView1.DataSource = businessLayer.GetDepartments();
        this.form = form;
        OnAddNewDepartment += form.RefreshDepartmentsCombobox;
    }

    private void button3_Click(object sender, EventArgs e)
    {
        Department newDept = new()
        {
            Dname = textBox3.Text,
            Dnum = int.Parse(textBox4.Text),
        };

        businessLayer.InsertDepartment(newDept);

        OnAddNewDepartment?.Invoke();
        dataGridView1.DataSource = businessLayer.GetDepartments();
    }
}
