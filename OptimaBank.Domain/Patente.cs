using System.ComponentModel;

namespace OptimaBank.Domain
{
    public class Patente : Componente
    {
        public override IList<Componente> Hijos => new List<Componente>();

        private string _nodo;
        public override string Nodo { get { return _nodo; } }

        public Patente(string nombre, string permiso) : base(nombre, permiso)
        {
            this._nodo = "Patente";
        }

        public override void Agregar(Componente component)
        {
            throw new NotImplementedException();
        }

        public override void Quitar()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return this.Nodo;
        }
    }
}
