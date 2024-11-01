using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_project_HOME_ACCOUNTANCE.Expenses_functions
{
    public partial class Expenses : Form
    {
        public Expenses()
        {
            InitializeComponent();
        }

        private void AddIncome_Click(object sender, EventArgs e)
        {
            this.Close();
            TransactionsAdd transactionsAdd = new TransactionsAdd();
            transactionsAdd.ShowDialog();
        }
    }
}
