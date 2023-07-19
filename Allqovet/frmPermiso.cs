using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AllqovetBLL;
using Entidades;

namespace Allqovet
{
    public partial class frmPermiso : Form
    {
        public frmPermiso()
        {
            InitializeComponent();
        }

        private void frmPermiso_Load(object sender, EventArgs e)
        {
            ListarAccesos();
        }
        private void ListarAccesos()
        {
            try
            {
                NivelaccesoBLL nivel = new NivelaccesoBLL();

                cmbusuario.ValueMember = "Idnivel";
                cmbusuario.DisplayMember = "descripcion";
                cmbusuario.DataSource = nivel.Listar();

                cmbusuario.SelectedIndex = -1;
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                Application.Exit();
            }


        }

        private List<MenuSistema> ObtenerMenusConSubmenus(int idusuario)
        {
            List<MenuSistema> ListadoMenu = new List<MenuSistema>();
            List<SubmenuSistema> ListadoSubMenu = new List<SubmenuSistema>();

            using (MenuBLL db=new MenuBLL())
            {
                try
                {
                  
                    using (SubMenuBLL dba =new SubMenuBLL())
                    {
                        ListadoSubMenu = dba.ListaSubMenu(idusuario);
                    }


                    ListadoMenu = db.ListaMenu(idusuario);

                    foreach (MenuSistema item in ListadoMenu)
                    {
                        item.SubMenus = ListadoSubMenu.Where(s => s.idmenu == item.idmenu).ToList();
                     
                    }

                  
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            return ListadoMenu;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (cmbusuario.SelectedIndex==-1)
            {
                MessageBox.Show("seleccione un usuario");
            }
            else
            {
                treeView1.Nodes.Clear();
                int idusuario = Convert.ToInt32(cmbusuario.SelectedValue);
                LlenarTreeView( idusuario);
            }

          
        }

        private void LlenarTreeView(int idusuario)
        {
            List<MenuSistema> menus = ObtenerMenusConSubmenus(idusuario);

            foreach (MenuSistema menu in menus)
            {
                TreeNode nodoMenu = new TreeNode(menu.descripcion);

                if (menu.permiso_menu.Equals("1"))
                {
                    nodoMenu.Checked = true;
                }
                else
                {
                    nodoMenu.Checked = false;
                }

                foreach (SubmenuSistema submenu in menu.SubMenus)
                {
                    TreeNode nodoSubmenu = new TreeNode(submenu.descripcion) ;
                    if (submenu.permiso_submenu.Equals("1"))
                    {
                        nodoSubmenu.Checked = true;
                    }
                    else
                    {
                        nodoSubmenu.Checked = false;
                    }

                    nodoMenu.Nodes.Add(nodoSubmenu);
                }

                treeView1.Nodes.Add(nodoMenu);
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("¿ Esta seguro de guardar los cambios?", "Permisos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                RegistrarPermisoMEnu();
            }
        }

        private void RegistrarPermisoMEnu()
        {
            PermisoMenu permisoMenu = new PermisoMenu();
            PermisoSubMenu permisoSub = new PermisoSubMenu();

            using (PermisoBLL db=new PermisoBLL())
            {
                try
                {
                    TreeNode permiso0 = treeView1.Nodes[0];
                    TreeNode permiso1 = treeView1.Nodes[1];
                    TreeNode permiso2 = treeView1.Nodes[2];
                    TreeNode permiso3 = treeView1.Nodes[3];
                    TreeNode permiso4 = treeView1.Nodes[4];
                    TreeNode permiso5 = treeView1.Nodes[5];
                    TreeNode permiso6 = treeView1.Nodes[6];
                    TreeNode permiso7 = treeView1.Nodes[7];
                    TreeNode permiso8 = treeView1.Nodes[8];

                    permisoMenu.idnivel = Convert.ToInt32(cmbusuario.SelectedValue);
                    permisoSub.idnivel = Convert.ToInt32(cmbusuario.SelectedValue);

                    permisoMenu.valor1 = permiso0.Checked ? "1" : "0";
                    permisoMenu.valor2 = permiso1.Checked ? "1" : "0";
                    permisoMenu.valor3 = permiso2.Checked ? "1" : "0";
                    permisoMenu.valor4 = permiso3.Checked ? "1" : "0";
                    permisoMenu.valor5 = permiso4.Checked ? "1" : "0";
                    permisoMenu.valor6 = permiso5.Checked ? "1" : "0";
                    permisoMenu.valor7 = permiso6.Checked ? "1" : "0";
                    permisoMenu.valor8 = permiso7.Checked ? "1" : "0";
                    permisoMenu.valor9 = permiso8.Checked ? "1" : "0";

                    //subnodos
                    //TreeNode subnodoEspecifico = nodoPadre.Nodes[indiceSubnodo];
                    //menu ventas
                    TreeNode subnodo0 = permiso0.Nodes[0];
                    TreeNode subnodo1 = permiso0.Nodes[1];
                    TreeNode subnodo2 = permiso0.Nodes[2];
                    TreeNode subnodo3 = permiso0.Nodes[3];
                    TreeNode subnodo4 = permiso0.Nodes[4];

                    //menu clientes
                    TreeNode subnodo5 = permiso1.Nodes[0];
                    TreeNode subnodo6 = permiso1.Nodes[1];

                    //menu productos
                    TreeNode subnodo7 = permiso2.Nodes[0];
                    TreeNode subnodo8 = permiso2.Nodes[1];
                    TreeNode subnodo9 = permiso2.Nodes[2];
                    TreeNode subnodo10 = permiso2.Nodes[3];


                    //menu facturacion
                    TreeNode subnodo11 = permiso3.Nodes[0];
                    TreeNode subnodo12 = permiso3.Nodes[1];

                    //menu reportes
                    TreeNode subnodo13 = permiso4.Nodes[0];
                    TreeNode subnodo14 = permiso4.Nodes[1];
                    TreeNode subnodo15 = permiso4.Nodes[2];
                    TreeNode subnodo16 = permiso4.Nodes[3];
                    TreeNode subnodo17 = permiso4.Nodes[4];

                    //menu almacen
                    TreeNode subnodo18 = permiso5.Nodes[0];
                    TreeNode subnodo19= permiso5.Nodes[1];
                    TreeNode subnodo20 = permiso5.Nodes[2];

                    //menu consultorio
                    TreeNode subnodo21 = permiso6.Nodes[0];
                    TreeNode subnodo22 = permiso6.Nodes[1];
                    TreeNode subnodo23 = permiso6.Nodes[2];
                    TreeNode subnodo24 = permiso6.Nodes[3];

                    //menu mantenimiento
                    TreeNode subnodo25 = permiso7.Nodes[0];
                    TreeNode subnodo26 = permiso7.Nodes[1];
                    TreeNode subnodo27 = permiso7.Nodes[2];
                    TreeNode subnodo28 = permiso7.Nodes[3];


                    //menu sistema
                    TreeNode subnodo29 = permiso8.Nodes[0];
                    TreeNode subnodo30 = permiso8.Nodes[1];

                    permisoSub.valor1  = subnodo0.Checked ? "1" : "0";
                    permisoSub.valor2 = subnodo1.Checked ? "1" : "0";
                    permisoSub.valor3 = subnodo2.Checked ? "1" : "0";
                    permisoSub.valor4 = subnodo3.Checked ? "1" : "0";
                    permisoSub.valor5 = subnodo4.Checked ? "1" : "0";
                    permisoSub.valor6 = subnodo5.Checked ? "1" : "0";
                    permisoSub.valor7 = subnodo6.Checked ? "1" : "0";
                    permisoSub.valor8 = subnodo7.Checked ? "1" : "0";
                    permisoSub.valor9 = subnodo8.Checked ? "1" : "0";
                    permisoSub.valor10 = subnodo9.Checked ? "1" : "0";
                    permisoSub.valor11 = subnodo10.Checked ? "1" : "0";
                    permisoSub.valor12 = subnodo11.Checked ? "1" : "0";
                    permisoSub.valor13 = subnodo12.Checked ? "1" : "0";
                    permisoSub.valor14 = subnodo13.Checked ? "1" : "0";
                    permisoSub.valor15 = subnodo14.Checked ? "1" : "0";
                    permisoSub.valor16 = subnodo15.Checked ? "1" : "0";
                    permisoSub.valor17 = subnodo16.Checked ? "1" : "0";
                    permisoSub.valor18 = subnodo17.Checked ? "1" : "0";
                    permisoSub.valor19 = subnodo18.Checked ? "1" : "0";
                    permisoSub.valor20 = subnodo19.Checked ? "1" : "0";
                    permisoSub.valor21 = subnodo20.Checked ? "1" : "0";
                    permisoSub.valor22 = subnodo21.Checked ? "1" : "0";
                    permisoSub.valor23 = subnodo22.Checked ? "1" : "0";
                    permisoSub.valor24 = subnodo23.Checked ? "1" : "0";
                    permisoSub.valor25 = subnodo24.Checked ? "1" : "0";
                    permisoSub.valor26 = subnodo25.Checked ? "1" : "0";
                    permisoSub.valor27 = subnodo26.Checked ? "1" : "0";
                    permisoSub.valor28 = subnodo27.Checked ? "1" : "0";
                    permisoSub.valor29 = subnodo28.Checked ? "1" : "0";
                    permisoSub.valor30 = subnodo29.Checked ? "1" : "0";
                    permisoSub.valor31 = subnodo30.Checked ? "1" : "0";


                    if (db.ActualizarPermisoMenu(permisoMenu, permisoSub) >0)
                    {
                        MessageBox.Show("permisos actualizados");
                        this.Close();
                    }


                }

                catch (Exception ex)
                {
                     MessageBox.Show( ex.Message);
                }
            }

        }

        private void RecorrerNodos(TreeView treeView, TreeNodeCollection nodes, List<string> arreglo)
        {

            PermisoMenu permisoMenu=new PermisoMenu();

            int n = 0;

            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    permisoMenu.valor1 = "2";

                    arreglo.Add(node.Text); // Guardar el valor del nodo marcado en el arreglo
                }

                // Recorrer los subnodos recursivamente
                RecorrerNodos(treeView, node.Nodes, arreglo);
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {

            if (e.Action != TreeViewAction.Unknown)
            {
                // Recorrer todos los subnodos del nodo actual
                foreach (TreeNode childNode in e.Node.Nodes)
                {
                    childNode.Checked = e.Node.Checked;
                }
            }


        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
