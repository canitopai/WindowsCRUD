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
namespace WindowsFormsAppCRUD.presentation
{
    public partial class FormAdd : Form
    {
        public int? miId;
        public Usuario miTabla = null;
        public FormAdd(int? miId)
        {
            InitializeComponent();

            this.miId = miId;
            if (miId != null)
            {
                cargarDatos();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (CRUD_1Entities db = new CRUD_1Entities())
            {
                if (miId == null)
                {
                    miTabla = new Usuario();
                }
                miTabla.Nombre = txtName.Text;
                miTabla.Apellido = txtLastName.Text;
                miTabla.Correo = txtMail.Text;
                miTabla.Fecha_nac = dtFecha.Value;

                if (miId == null)
                {
                    db.Usuario.Add(miTabla);
                }
                else
                {
                    db.Entry(miTabla).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();


                this.Close();
            }
        }
        private void cargarDatos()
        {
            using (CRUD_1Entities db = new CRUD_1Entities())
            {
                miTabla = db.Usuario.Find(miId);
                txtName.Text = miTabla.Nombre;
                txtLastName.Text = miTabla.Apellido;
                txtMail.Text = miTabla.Correo;
                dtFecha.Value = miTabla.Fecha_nac;
            }
        }
    }
}
