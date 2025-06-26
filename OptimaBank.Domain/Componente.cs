namespace OptimaBank.Domain
{
    public abstract class Componente
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _persmiso;

        public string Permiso
        {
            get { return _persmiso; }
            set { _persmiso = value; }
        }

        public Componente(string nombre, string permiso)
        {
            this._nombre = nombre;
            this._persmiso = permiso;
        }

        public abstract IList<Componente> Hijos { get; }

        public abstract string Nodo { get; }

        public abstract void Agregar(Componente component);

        public abstract void Quitar();

        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
