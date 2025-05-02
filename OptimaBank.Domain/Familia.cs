namespace OptimaBank.Domain
{
    public class Familia : Componente
    {
        private IList<Componente> _hijos;

        public override IList<Componente> Hijos
        {
            get { return _hijos.ToArray(); }
        }

        private string _nodo;
        public override string Nodo { get { return _nodo; } }

        public Familia(string nombre, string permiso) : base(nombre, permiso)
        {
            this._nodo = "Familia";
        }

        public override void Agregar(Componente component)
        {
            this._hijos.Add(component);
        }

        public override void Quitar()
        {
           this._hijos = new List<Componente>();
        }

        public override string ToString()
        {
            return this.Nodo;
        }
    }
}
