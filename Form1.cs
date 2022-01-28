using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppCRUD.model;

namespace WindowsFormsAppCRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        #region
        private void Refresh()
        {
            using (CRUD_1Entities db = new CRUD_1Entities())
            {
                var lst = from d in db.Usuario select d;
                dataGridView1.DataSource = lst.ToList();

            }
        }
        private int? getId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int? id = null;
            presentation.FormAdd miFrmAdd = new presentation.FormAdd(id);
            miFrmAdd.ShowDialog();
            Refresh();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int? id = getId();
            if(id!=null)
            {
                presentation.FormAdd miTablaAdd = new presentation.FormAdd(id);
                miTablaAdd.ShowDialog();
                Refresh();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int? id = getId();
            if(id != null)
            {
                using (CRUD_1Entities db = new CRUD_1Entities())
                {
                    Usuario miTabla = db.Usuario.Find(id);
                    db.Usuario.Remove(miTabla);

                    db.SaveChanges();
                }
                Refresh();
            }
        }
    }
}
