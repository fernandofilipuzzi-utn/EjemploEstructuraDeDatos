using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EjemploLinkedList
{
    public partial class FormPrincipal : Form
    {
        LinkedList<Persona> personas = new LinkedList<Persona>();

        public FormPrincipal()
        {
            InitializeComponent();

            #region inicializando con unos ejemplos hardcodeados
            personas.AddLast(new Persona() { DNI = 29834234, Nombre = "Teresa" });
            personas.AddLast(new Persona() { DNI = 30521135, Nombre = "Romina" });
            personas.AddLast(new Persona() { DNI = 29245203, Nombre = "Andrés" });
            #endregion

            #region llenando al listBox1
            /*form 1 - requiere si o si implementar ToString()*/
            lbPersonas.Items.AddRange(personas.ToArray<Persona>());

            /*forma 2
            foreach (Persona persona in personas)
                lbPersonas.Items.Add(persona.ToString());
            */
            #endregion
        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {
            int dni = Convert.ToInt32(textBox1.Text);
                        
            Persona buscado=null;

            /*forma 1: buscando secuencialmente.
            LinkedListNode<Persona> actual = personas.First;
            while (actual != null && buscado == null)
            {
                if (actual.Value.DNI == dni)
                    buscado = actual.Value;
                actual = actual.Next;
            }
             **/

            /* forma 2: para lo siguiente necesito implementado el método Equals
             * no confundirse con el método CompareTo
             */
            LinkedListNode<Persona> buscadoNodo = personas.Find( new Persona { DNI=dni});
            if (buscadoNodo != null) buscado = buscadoNodo.Value;


            tbResultados.Text += "Registro buscado: " + dni + "\r\n";
            if (buscado != null)
                tbResultados.Text+=buscado+"\r\n";
            else
                tbResultados.Text += "no encontrado" + "\r\n";
            tbResultados.Text += "--" + "\r\n";


            /* Probando el método Contains(),
             * para lo siguiente necesito implementado el método Equals
             * no confundirse con el método CompareTo
             */
            tbResultados.Text += "Probando llamar a contains:" + "\r\n";
            if ( personas.Contains(new Persona() { DNI = dni }))
                tbResultados.Text += $" {dni} se encuentra" + "\r\n";
            else
                tbResultados.Text += $" {dni} no se encuentra" + "\r\n";
            tbResultados.Text += "--" + "\r\n";
        }

    }
}
