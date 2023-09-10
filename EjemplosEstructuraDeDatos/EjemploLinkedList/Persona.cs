using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EjemploLinkedList
{
    class Persona:IComparable
    {
        public int DNI{get;set;}
        public string Nombre {get;set;}

        public override string ToString()
        {
            return $"{ DNI,-10} {Nombre,52}";
        }

        public int CompareTo(object obj)
        {
            Persona persona = obj as Persona;
            if(persona!=null)
                return DNI.CompareTo(persona.DNI);
            return -1;
        }

        public override bool Equals(object obj)
        {
            Persona persona = obj as Persona;
            if (persona != null)
                return DNI.Equals(persona.DNI);
            return false;
        }
    }
}
