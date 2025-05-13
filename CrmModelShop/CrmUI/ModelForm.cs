using CrmBL.Models;
using System.Windows.Forms;

namespace CrmUI
{
    /// <summary>
    /// Computer model form
    /// </summary>
    public partial class ModelForm : Form
    {
        /// <summary>
        /// Create computer model
        /// </summary>
        ShopComputerModel computerModel = new ShopComputerModel();

        /// <summary>
        /// Computer model form constructor
        /// </summary>
        public ModelForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Running the Simulation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            List<CashBoxView> cashBoxViews = new List<CashBoxView>();

            computerModel.Start();
            button1.Enabled = false;
            CashBoxCount.Enabled = false;

            for (int i = 0; i < computerModel.CashBoxCount; i++)
            {
                CashBoxView newCashBoxView = new CashBoxView(computerModel.CashBoxes[i], i, 10, 26 * i);
                cashBoxViews.Add(newCashBoxView);
                Controls.Add(newCashBoxView.CashBoxName);
                Controls.Add(newCashBoxView.Price);
                Controls.Add(newCashBoxView.QueueLenght);
                Controls.Add(newCashBoxView.LeaveCustomersCount);
            }

        }

        /// <summary>
        /// Stop the Simulation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            computerModel.Stop();
        }

        /// <summary>
        /// Load computer model form 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModelForm_Load(object sender, EventArgs e)
        {
            computerModel.CashBoxCount = Convert.ToInt32(CashBoxCount.Value);
            computerModel.CustomersProductCount = Convert.ToInt32(ProductsCount.Value);
            computerModel.CustomersCount = Convert.ToInt32(CustomersCount.Value);
            computerModel.CustomersSpeed = Convert.ToInt32(CustomerSpeed.Value);
            computerModel.CashBoxSpeed = Convert.ToInt32(CashBoxSpeed.Value);
        }

        /// <summary>
        /// Initialization of computer model data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CashBoxCount_ValueChanged(object sender, EventArgs e)
        {
            computerModel.CashBoxCount = Convert.ToInt32(CashBoxCount.Value);
        }
        private void ProductsCount_ValueChanged(Object sender, EventArgs e)
        {
            computerModel.CustomersProductCount = Convert.ToInt32(ProductsCount.Value);
        }
        private void CustomersCount_ValueChanged(Object sender, EventArgs e)
        {
            computerModel.CustomersCount = Convert.ToInt32(CustomersCount.Value);
        }
        private void CustomerSpeed_ValueChanged(Object sender, EventArgs e)
        {
            computerModel.CustomersSpeed = Convert.ToInt32(CustomerSpeed.Value);
        }
        private void CashBoxSpeed_ValueChanged(Object sender, EventArgs e)
        {
            computerModel.CashBoxSpeed = Convert.ToInt32(CashBoxSpeed.Value);
        }
    }
}
